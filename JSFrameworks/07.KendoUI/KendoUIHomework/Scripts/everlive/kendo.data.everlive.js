(function (undefined) {
    var $ = window.jQuery,
        kendo = window.kendo;
    if ($ === undefined || kendo === undefined)
        return;
    var extend = $.extend;

    extend(true, kendo.data, {
        schemas: {
            everlive: {
                type: "json",
                data: function (data) {
                    // update
                    if (typeof data.ModifiedAt !== 'undefined') {
                        return { ModifiedAt: data.ModifiedAt };
                    }
                    else {
                        return data.Result || data;
                    }
                },
                total: "Count"
            }
        },
        transports: {
            everlive: {
                read: {
                    dataType: "json",
                    type: "GET",
                    cache: false
                },
                update: {
                    dataType: "json",
                    contentType: "application/json",
                    type: "PUT",
                    cache: false
                },
                create: {
                    dataType: "json",
                    contentType: "application/json",
                    type: "POST",
                    cache: false
                },
                destroy: {
                    dataType: "json",
                    type: "DELETE",
                    cache: false
                },
                parameterMap: function (data, operation) {
                    if (operation === "destroy") {
                        return {};
                    }

                    if (operation === "create" || operation === "update") {
                        return JSON.stringify(data);
                    }

                    if (operation === "read") {
                        return null;
                    }
                }
            }
        }
    });

    function translateKendoQuery(data) {
        var result = {};
        if (data) {
            if (data.skip) {
                result.$skip = data.skip;
                delete data.skip;
            }
            if (data.take) {
                result.$take = data.take;
                delete data.take;
            }
            if (data.sort) {
                var sortExpressions = data.sort;
                var sort = {}
                if (!$.isArray(sortExpressions)) {
                    sortExpressions = [sortExpressions];
                }
                $.each(sortExpressions, function (idx, value) {
                    sort[value.field] = value.dir === 'asc' ? 1 : -1;
                });
                result.$sort = sort;
                delete data.sort;
            }
            if (data.filter) {
                var filter = new FilterBuilder().build(data.filter);
                result.$where = filter;
                delete data.filter;
            }
        }
        return result;
    }

    var regexOperations = ['startsWith', 'endsWith', 'contains'];
    function FilterBuilder() {
    }
    FilterBuilder.prototype = {
        build: function (filter) {
            return this._build(filter);
        },
        _build: function (filter) {
            if (this._isRaw(filter)) {
                return this._raw(filter);
            }
            else if (this._isSimple(filter)) {
                return this._simple(filter);
            }
            else if (this._isRegex(filter)) {
                return this._regex(filter);
            }
            else if (this._isAnd(filter)) {
                return this._and(filter);
            }
            else if (this._isOr(filter)) {
                return this._or(filter);
            }
        },
        _isRaw: function (filter) {
            return filter.operator === '_raw';
        },
        _raw: function (filter) {
            var fieldTerm = {};
            fieldTerm[filter.field] = filter.value;
            return fieldTerm;
        },
        _isSimple: function (filter) {
            return typeof filter.logic === 'undefined' && !this._isRegex(filter);
        },
        _simple: function (filter) {
            var term = {}, fieldTerm = {};
            var operator = this._translateoperator(filter.operator);
            if (operator) {
                term[operator] = filter.value;
            }
            else {
                term = filter.value;
            }
            fieldTerm[filter.field] = term;
            return fieldTerm;
        },
        _isRegex: function (filter) {
            return $.inArray(filter.operator, regexOperations) !== -1;
        },
        _regex: function (filter) {
            var fieldTerm = {};
            var regex = this._getRegex(filter);
            var regexValue = this._getRegexValue(regex);
            fieldTerm[filter.field] = regexValue;
            return fieldTerm;
        },
        _getRegex: function (filter) {
            var pattern = filter.value;
            switch (filter.operator) {
                case 'contains':
                    return new RegExp(".*" + pattern + ".*", "i");
                case 'startsWith':
                    return new RegExp(pattern + ".*", "i");
                case 'endsWith':
                    return new RegExp(".*" + pattern, "i");
            }
            throw new Error("Unknown operator type.");
        },
        _getRegexValue: function (regex) {
            return Everlive.QueryBuilder.prototype._getRegexValue.call(this, regex);
        },
        _isAnd: function (filter) {
            return filter.logic === 'and';
        },
        _and: function (filter) {
            var i, l, term, result = {};
            var operands = filter.filters;
            for (i = 0, l = operands.length; i < l; i++) {
                term = this._build(operands[i]);
                result = this._andAppend(result, term);
            }
            return result;
        },
        _andAppend: function (andObj, newObj) {
            return Everlive.QueryBuilder.prototype._andAppend.call(this, andObj, newObj);
        },
        _isOr: function (filter) {
            return filter.logic === 'or';
        },
        _or: function (filter) {
            var i, l, term, result = [];
            var operands = filter.filters;
            for (i = 0, l = operands.length; i < l; i++) {
                term = this._build(operands[i]);
                result.push(term);
            }
            return { $or: result };
        },
        _translateoperator: function (operator) {
            switch (operator) {
                case 'eq':
                    return null;
                case 'neq':
                    return "$ne";
                case 'gt':
                    return "$gt";
                case 'lt':
                    return "$lt";
                case 'gte':
                    return "$gte";
                case 'lte':
                    return "$lte";
            }
            throw new Error("Unknown operator type.");
        }
    };

    function createEverliveQuery(query) {
        return new Everlive.Query(query.$where, null, query.$sort, query.$skip, query.$take);
    }

    // replace the setup method of RemoteTransport in order to inject options
    // the setup method is called on all crud operations
    var RemoteTransport_setup = kendo.data.RemoteTransport.prototype.setup;
    kendo.data.RemoteTransport.prototype.setup = function (options, type) {
        if (!options.url && !this.options[type].url && this.options.typeName) {
            options.url = Everlive.Request.prototype.buildUrl(Everlive.$.setup) + this.options.typeName;
            if (type === 'update' || type === 'destroy')
                options.url += '/' + options.data[Everlive.idField];
        }
        options.headers = Everlive.Request.prototype.buildAuthHeader(Everlive.$.setup);
        if (type === 'read' && options.data) {
            var query = translateKendoQuery(options.data);
            var everliveQuery = createEverliveQuery(query);
            options.headers = $.extend(options.headers, Everlive.Request.prototype.buildQueryHeaders(everliveQuery));
        }
        if (type === 'create' || type === 'read' || type === 'update') {
            var success = options.success;
            options.success = function (result) {
                // convert date strings into dates
                Everlive._traverseAndRevive(result);
                if (success)
                    success(result);
            };
        }
        return RemoteTransport_setup.call(this, options, type);
    };

    // kendo merges the rest service result with the original data
    // but Everlive does not return the whole objects on update and create
    // so replace the accept method of Model in order to merge the response
    // from the request for creating a new item to the client model item
    var createRequestFields = [Everlive.idField, 'CreatedAt'];
    var Model_accept = kendo.data.Model.prototype.accept;
    kendo.data.Model.prototype.accept = function (data) {
        var that = this, field, value;
        Everlive._traverseAndRevive(data);
        // create
        if (data && that.isNew() && data[Everlive.idField]) {
            for (field in that.fields) {
                if ($.inArray(field, createRequestFields) === -1) {
                    value = that.get(field);
                    data[field] = value;
                }
            }
        }
        // update
        else if (data && typeof data.ModifiedAt !== 'undefined') {
            for (field in that.fields) {
                if (field !== 'ModifiedAt') {
                    value = that.get(field);
                    data[field] = value;
                }
            }
        }
        Model_accept.call(this, data);
    };
})();