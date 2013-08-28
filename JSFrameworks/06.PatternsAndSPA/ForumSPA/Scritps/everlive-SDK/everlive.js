/*!
The MIT License (MIT)

Copyright (c) 2013 Telerik AD

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.y distributed under the MIT license.
*/
/*!
Everlive SDK
Version 1.1.1
*/
/*global RSVP,reqwest,_*/
(function (ns) {
    'use strict';
    var slice = Array.prototype.slice;
    var everliveUrl = "//api.everlive.com/v1/";
    var idField = "Id";
    function guardUnset(value, name, message) {
        if (!message)
            message = "The " + name + " is required";
        if (typeof value === "undefined" || value === null)
            throw new Error(message);
    }

    // An object that keeps information about an Everlive connecton
    function Setup(options) {
        this.url = everliveUrl;
        this.apiKey = null;
        this.masterKey = null;
        this.token = null;
        this.tokenType = null;
        this.scheme = 'https'; // http or https
        if (typeof options === "string")
            this.apiKey = options;
        else
            _.extend(this, options);
    }

    // An array keeping initialization functions called by the Everlive constructor.
    // These functions will be used to extend the functionality of an Everlive instance.
    var initializations = [];
    // The constructor of Everlive instances.
    // The entry point for the SDK.
    function Everlive(options) {
        var self = this;
        this.setup = new Setup(options);
        _.each(initializations, function (init) {
            init.func.call(self, options);
        });
        if (Everlive.$ === null)
            Everlive.$ = self;
    }
    // A reference to the current Everlive instance
    Everlive.$ = null;
    Everlive.idField = idField;
    Everlive.initializations = initializations;
    // Creates a new Everlive instance and set it as the current one
    Everlive.init = function (options) {
        Everlive.$ = null;
        return new Everlive(options);
    };
    Everlive.buildUrl = function (setup) {
        var url = '';
        if (typeof setup.scheme === "string")
            url += setup.scheme + ":";
        url += setup.url;
        if (setup.apiKey)
            url += setup.apiKey + "/";
        return url;
    };
    Everlive.prototype.data = function (collectionName) {
        return new Data(this.setup, collectionName);
    };
    Everlive.prototype.buildUrl = function () {
        return Everlive.buildUrl(this.setup);
    };
    var buildAuthHeader = function (setup, options) {
        var authHeaderValue = null;
        if (options && options.authHeaders === false)
            return authHeaderValue;
        if (setup.token) {
            authHeaderValue = (setup.tokenType || "bearer") + " " + setup.token;
        }
        else if (setup.masterKey) {
            authHeaderValue = 'masterkey ' + setup.masterKey;
        }
        if (authHeaderValue)
            return { "Authorization": authHeaderValue };
        else
            return null;
    };
    Everlive.prototype.buildAuthHeader = function () {
        return buildAuthHeader(this.setup);
    };

    // Everlive queries
    (function () {
        var OperatorType = {
            query: 1,

            where: 100,
            filter: 101,

            and: 110,
            or: 111,
            not: 112,

            equal: 120,
            not_equal: 121,
            lt: 122,
            lte: 123,
            gt: 124,
            gte: 125,
            isin: 126,
            notin: 127,
            all: 128,
            size: 129,
            regex: 130,
            contains: 131,
            startsWith: 132,
            endsWith: 133,

            nearShpere: 140,
            withinBox: 141,
            withinPolygon: 142,
            withinShpere: 143,

            select: 200,
            exclude: 201,

            order: 300,
            order_desc: 301,

            skip: 400,
            take: 401
        };

        function Expression(operator, operands) {
            this.operator = operator;
            this.operands = operands || [];
        }
        Expression.prototype = {
            addOperand: function (operand) {
                this.operands.push(operand);
            }
        };

        function Query(filter, fields, sort, skip, take) {
            this.filter = filter;
            this.fields = fields;
            this.sort = sort;
            this.toskip = skip;
            this.totake = take;
            this.expr = new Expression(OperatorType.query);
        }
        Query.prototype = {
            where: function (filter) {
                if (filter) {
                    return this._simple(OperatorType.filter, [filter]);
                }
                else {
                    return new WhereQuery(this);
                }
            },
            select: function () {
                return this._simple(OperatorType.select, arguments);
            },
            // TODO
            //exclude: function () {
            //    return this._simple(OperatorType.exclude, arguments);
            //},
            order: function (field) {
                return this._simple(OperatorType.order, [field]);
            },
            orderDesc: function (field) {
                return this._simple(OperatorType.order_desc, [field]);
            },
            skip: function (value) {
                return this._simple(OperatorType.skip, [value]);
            },
            take: function (value) {
                return this._simple(OperatorType.take, [value]);
            },
            build: function () {
                return new QueryBuilder(this).build();
            },
            _simple: function (op, oprs) {
                var args = slice.call(oprs);
                this.expr.addOperand(new Expression(op, args));
                return this;
            }
        };

        function WhereQuery(parentQuery, exprOp, singleOperand) {
            this.parent = parentQuery;
            this.single = singleOperand;
            this.expr = new Expression(exprOp || OperatorType.where);
            this.parent.expr.addOperand(this.expr);
        }
        WhereQuery.prototype = {
            and: function () {
                return new WhereQuery(this, OperatorType.and);
            },
            or: function () {
                return new WhereQuery(this, OperatorType.or);
            },
            not: function () {
                return new WhereQuery(this, OperatorType.not, true);
            },
            _simple: function (operator) {
                var args = slice.call(arguments, 1);
                this.expr.addOperand(new Expression(operator, args));
                return this._done();
            },
            eq: function (field, value) {
                return this._simple(OperatorType.equal, field, value);
            },
            ne: function (field, value) {
                return this._simple(OperatorType.not_equal, field, value);
            },
            gt: function (field, value) {
                return this._simple(OperatorType.gt, field, value);
            },
            gte: function (field, value) {
                return this._simple(OperatorType.gte, field, value);
            },
            lt: function (field, value) {
                return this._simple(OperatorType.lt, field, value);
            },
            lte: function (field, value) {
                return this._simple(OperatorType.lte, field, value);
            },
            isin: function (field, value) {
                return this._simple(OperatorType.isin, field, value);
            },
            notin: function (field, value) {
                return this._simple(OperatorType.notin, field, value);
            },
            all: function (field, value) {
                return this._simple(OperatorType.all, field, value);
            },
            size: function (field, value) {
                return this._simple(OperatorType.size, field, value);
            },
            regex: function (field, value, flags) {
                return this._simple(OperatorType.regex, field, value, flags);
            },
            startsWith: function (field, value, flags) {
                return this._simple(OperatorType.startsWith, field, value, flags);
            },
            endsWith: function (field, value, flags) {
                return this._simple(OperatorType.endsWith, field, value, flags);
            },
            nearSphere: function (field, point, distance, metrics) {
                return this._simple(OperatorType.nearShpere, field, point, distance, metrics);
            },
            withinBox: function (field, pointBottomLeft, pointUpperRight) {
                return this._simple(OperatorType.withinBox, field, pointBottomLeft, pointUpperRight);
            },
            withinPolygon: function (field, points) {
                return this._simple(OperatorType.withinPolygon, field, points);
            },
            withinCenterSphere: function (field, center, radius, metrics) {
                return this._simple(OperatorType.withinShpere, field, center, radius, metrics);
            },
            done: function () {
                if (this.parent instanceof WhereQuery)
                    return this.parent._done();
                else
                    return this.parent;
            },
            _done: function () {
                if (this.single)
                    return this.parent;
                else
                    return this;
            }
        };
        WhereQuery.prototype.equal = WhereQuery.prototype.eq;
        WhereQuery.prototype.notEqual = WhereQuery.prototype.ne;
        WhereQuery.prototype.greaterThan = WhereQuery.prototype.gt;
        WhereQuery.prototype.greaterThanEqual = WhereQuery.prototype.gte;
        WhereQuery.prototype.lessThan = WhereQuery.prototype.lt;
        WhereQuery.prototype.lessThanEqual = WhereQuery.prototype.lte;

        function QueryBuilder(query) {
            this.query = query;
            this.expr = query.expr;
        }
        var maxDistanceConsts = { 'radians': '$maxDistance', 'km': '$maxDistanceInKilometers', 'miles': '$maxDistanceInMiles' };
        var radiusConsts = { 'radians': 'radius', 'km': 'radiusInKilometers', 'miles': 'radiusInMiles' };
        QueryBuilder.prototype = {
            // TODO merge the two objects before returning them
            build: function () {
                var query = this.query;
                if (query.filter || query.fields || query.sort || query.toskip || query.totake)
                    return {
                        $where: query.filter || null,
                        $select: query.fields || null,
                        $sort: query.sort || null,
                        $skip: query.toskip || null,
                        $take: query.totake || null
                    };
                return {
                    $where: this._buildWhere(),
                    $select: this._buildSelect(),
                    $sort: this._buildSort(),
                    $skip: this._getSkip(),
                    $take: this._getTake()
                };
            },
            _getSkip: function () {
                var skipExpression = _.find(this.expr.operands, function (value, index, list) {
                    return value.operator === OperatorType.skip;
                });
                return skipExpression ? skipExpression.operands[0] : null;
            },
            _getTake: function () {
                var takeExpression = _.find(this.expr.operands, function (value, index, list) {
                    return value.operator === OperatorType.take;
                });
                return takeExpression ? takeExpression.operands[0] : null;
            },
            _buildSelect: function () {
                var selectExpression = _.find(this.expr.operands, function (value, index, list) {
                    return value.operator === OperatorType.select;
                });
                var result = {};
                if (selectExpression) {
                    _.reduce(selectExpression.operands, function (memo, value) {
                        memo[value] = 1;
                        return memo;
                    }, result);
                    return result;
                }
                else {
                    return null;
                }
            },
            _buildSort: function () {
                var sortExpressions = _.filter(this.expr.operands, function (value, index, list) {
                    return value.operator === OperatorType.order || value.operator === OperatorType.order_desc;
                });
                var result = {};
                if (sortExpressions.length > 0) {
                    _.reduce(sortExpressions, function (memo, value) {
                        memo[value.operands[0]] = value.operator === OperatorType.order ? 1 : -1;
                        return memo;
                    }, result);
                    return result;
                }
                else {
                    return null;
                }
            },
            _buildWhere: function () {
                var whereExpression = _.find(this.expr.operands, function (value, index, list) {
                    return value.operator === OperatorType.where;
                });
                if (whereExpression) {
                    return this._build(new Expression(OperatorType.and, whereExpression.operands));
                }
                else {
                    var filterExpression = _.find(this.expr.operands, function (value, index, list) {
                        return value.operator === OperatorType.filter;
                    });
                    if (filterExpression) {
                        return filterExpression.operands[0];
                    }
                    return null;
                }
            },
            _build: function (expr) {
                if (this._isSimple(expr)) {
                    return this._simple(expr);
                }
                else if (this._isRegex(expr)) {
                    return this._regex(expr);
                }
                else if (this._isGeo(expr)) {
                    return this._geo(expr);
                }
                else if (this._isAnd(expr)) {
                    return this._and(expr);
                }
                else if (this._isOr(expr)) {
                    return this._or(expr);
                }
                else if (this._isNot(expr)) {
                    return this._not(expr);
                }
            },
            _isSimple: function (expr) {
                return expr.operator >= OperatorType.equal && expr.operator <= OperatorType.size;
            },
            _simple: function (expr) {
                var term = {}, fieldTerm = {};
                var operands = expr.operands;
                var operator = this._translateoperator(expr.operator);
                if (operator) {
                    term[operator] = operands[1];
                }
                else {
                    term = operands[1];
                }
                fieldTerm[operands[0]] = term;
                return fieldTerm;
            },
            _isRegex: function (expr) {
                return expr.operator >= OperatorType.regex && expr.operator <= OperatorType.endsWith;
            },
            _regex: function (expr) {
                var fieldTerm = {};
                var regex = this._getRegex(expr);
                var regexValue = this._getRegexValue(regex);
                var operands = expr.operands;
                fieldTerm[operands[0]] = regexValue;
                return fieldTerm;
            },
            _getRegex: function (expr) {
                var pattern = expr.operands[1];
                var flags = expr.operands[2] ? expr.operands[2] : '';
                switch (expr.operator) {
                    case OperatorType.regex:
                        return pattern instanceof RegExp ? pattern : new RegExp(pattern, flags);
                    case OperatorType.startsWith:
                        return new RegExp(pattern + ".*", flags);
                    case OperatorType.endsWith:
                        return new RegExp(".*" + pattern, flags);
                    default:
                        throw new Error("Unknown operator type.");
                }
            },
            _getRegexValue: function (regex) {
                var options = '';
                if (regex.global)
                    options += 'g';
                if (regex.multiline)
                    options += 'm';
                if (regex.ignoreCase)
                    options += 'i';
                return { $regex: regex.source, $options: options };
            },
            _isGeo: function (expr) {
                return expr.operator >= OperatorType.nearShpere && expr.operator <= OperatorType.withinShpere;
            },
            _geo: function (expr) {
                var fieldTerm = {};
                var operands = expr.operands;
                fieldTerm[operands[0]] = this._getGeoTerm(expr);
                return fieldTerm;
            },
            _getGeoTerm: function (expr) {
                switch (expr.operator) {
                    case OperatorType.nearShpere:
                        return this._getNearSphereTerm(expr);
                    case OperatorType.withinBox:
                        return this._getWithinBox(expr);
                    case OperatorType.withinPolygon:
                        return this._getWithinPolygon(expr);
                    case OperatorType.withinShpere:
                        return this._getWithinCenterSphere(expr);
                    default:
                        throw new Error("Unknown operator type.");
                }
            },
            _getNearSphereTerm: function (expr) {
                var operands = expr.operands;
                var center = this._getGeoPoint(operands[1]);
                var maxDistance = operands[2];
                var metrics = operands[3];
                var maxDistanceConst;
                var term = {
                    '$nearSphere': center
                };
                if (typeof maxDistance !== 'undefined') {
                    maxDistanceConst = maxDistanceConsts[metrics] || maxDistanceConsts.radians;
                    term[maxDistanceConst] = maxDistance;
                }
                return term;
            },
            _getWithinBox: function (expr) {
                var operands = expr.operands;
                var bottomLeft = this._getGeoPoint(operands[1]);
                var upperRight = this._getGeoPoint(operands[2]);
                return {
                    '$within': {
                        '$box': [bottomLeft, upperRight]
                    }
                };
            },
            _getWithinPolygon: function (expr) {
                var operands = expr.operands;
                var points = this._getGeoPoints(operands[1]);
                return {
                    '$within': {
                        '$polygon': points
                    }
                };
            },
            _getWithinCenterSphere: function (expr) {
                var operands = expr.operands;
                var center = this._getGeoPoint(operands[1]);
                var radius = operands[2];
                var metrics = operands[3];
                var radiusConst = radiusConsts[metrics] || radiusConsts.radians;
                var sphereInfo = {
                    'center': center
                };
                sphereInfo[radiusConst] = radius;
                return {
                    '$within': {
                        '$centerSphere': sphereInfo
                    }
                };
            },
            _getGeoPoint: function (point) {
                if (_.isArray(point))
                    return new GeoPoint(point[0], point[1]);
                return point;
            },
            _getGeoPoints: function (points) {
                var self = this;
                return _.map(points, function (point) {
                    return self._getGeoPoint(point);
                });
            },
            _isAnd: function (expr) {
                return expr.operator === OperatorType.and;
            },
            _and: function (expr) {
                var i, l, term, result = {};
                var operands = expr.operands;
                for (i = 0, l = operands.length; i < l; i++) {
                    term = this._build(operands[i]);
                    result = this._andAppend(result, term);
                }
                return result;
            },
            _andAppend: function (andObj, newObj) {
                var i, l, key, value, newValue;
                var keys = _.keys(newObj);
                for (i = 0, l = keys.length; i < l; i++) {
                    key = keys[i];
                    value = andObj[key];
                    if (typeof value === 'undefined') {
                        andObj[key] = newObj[key];
                    }
                    else {
                        newValue = newObj[key];
                        if (typeof value === "object" && typeof newValue === "object")
                            value = _.extend(value, newValue);
                        else
                            value = newValue;
                        andObj[key] = value;
                    }
                }
                return andObj;
            },
            _isOr: function (expr) {
                return expr.operator === OperatorType.or;
            },
            _or: function (expr) {
                var i, l, term, result = [];
                var operands = expr.operands;
                for (i = 0, l = operands.length; i < l; i++) {
                    term = this._build(operands[i]);
                    result.push(term);
                }
                return { $or: result };
            },
            _isNot: function (expr) {
                return expr.operator === OperatorType.not;
            },
            _not: function (expr) {
                return { $not: this._build(expr.operands[0]) };
            },
            _translateoperator: function (operator) {
                switch (operator) {
                    case OperatorType.equal:
                        return null;
                    case OperatorType.not_equal:
                        return "$ne";
                    case OperatorType.gt:
                        return "$gt";
                    case OperatorType.lt:
                        return "$lt";
                    case OperatorType.gte:
                        return "$gte";
                    case OperatorType.lte:
                        return "$lte";
                    case OperatorType.isin:
                        return "$in";
                    case OperatorType.notin:
                        return "$nin";
                    case OperatorType.all:
                        return "$all";
                    case OperatorType.size:
                        return "$size";
                }
                throw new Error("Unknown operator type.");
            }
        };

        Everlive.Query = Query;
        Everlive.QueryBuilder = QueryBuilder;
    }());

    // Everlive requests
    var Request = (function () {
        // The headers used by the Everlive services
        var Headers = {
            filter: "X-Everlive-Filter",
            select: "X-Everlive-Fields",
            sort: "X-Everlive-Sort",
            skip: "X-Everlive-Skip",
            take: "X-Everlive-Take"
        };

        // The Request type is an abstraction over Ajax libraries
        // A Request object needs information about the Everlive connection and initialization options
        function Request(setup, options) {
            guardUnset(setup, "setup");
            guardUnset(options, "options");
            this.setup = setup;
            this.method = null;
            this.endpoint = null;
            this.data = null;
            this.headers = {};
            // TODO success and error callbacks should be uniformed for all ajax libs
            this.success = null;
            this.error = null;
            this.parse = Request.parsers.simple;
            _.extend(this, options);
            this._init(options);
        }

        Request.prototype = {
            // Calls the underlying Ajax library
            send: function () {
                Everlive.sendRequest(this);
            },
            // Returns an authorization header used by the request.
            // If there is a logged in user for the Everlive instance then her/his authentication will be used.
            buildAuthHeader: buildAuthHeader,
            // Builds the URL of the target Everlive service
            buildUrl: function buildUrl(setup) {
                return Everlive.buildUrl(setup);
            },
            // Processes the given query to return appropriate headers to be used by the request
            buildQueryHeaders: function buildQueryHeaders(query) {
                if (query) {
                    if (query instanceof Everlive.Query) {
                        return Request.prototype._buildQueryHeaders(query);
                    }
                    else {
                        return Request.prototype._buildFilterHeader(query);
                    }
                }
                else {
                    return {};
                }
            },
            // Initialize the Request object by using the passed options
            _init: function (options) {
                _.extend(this.headers, this.buildAuthHeader(this.setup, options), this.buildQueryHeaders(options.filter), options.headers);
            },
            // Translates an Everlive.Query to request headers
            _buildQueryHeaders: function (query) {
                query = query.build();
                var headers = {};
                if (query.$where !== null) {
                    headers[Headers.filter] = JSON.stringify(query.$where);
                }
                if (query.$select !== null) {
                    headers[Headers.select] = JSON.stringify(query.$select);
                }
                if (query.$sort !== null) {
                    headers[Headers.sort] = JSON.stringify(query.$sort);
                }
                if (query.$skip !== null) {
                    headers[Headers.skip] = query.$skip;
                }
                if (query.$take !== null) {
                    headers[Headers.take] = query.$take;
                }
                return headers;
            },
            // Creates a header from a simple filter
            _buildFilterHeader: function (filter) {
                var headers = {};
                headers[Headers.filter] = JSON.stringify(filter);
                return headers;
            }
        };
        // Exposes the Request constructor
        Everlive.Request = Request;
        // A utility method for creating requests for the current Everlive instance
        Everlive.prototype.request = function (attrs) {
            return new Request(this.setup, attrs);
        };
        function parseResult(data) {
            if (typeof data === "string" && data.length > 0) {
                data = JSON.parse(data);
            }
            if (data) {
                return { result: data.Result, count: data.Count };
            }
            else {
                return data;
            }
        }
        function parseError(error) {
            if (typeof error === "string" && error.length > 0) {
                try {
                    error = JSON.parse(error);
                    return { message: error.message, code: error.errorCode };
                }
                catch (e) {
                    return error;
                }
            }
            else {
                return error;
            }
        }
        function parseSingleResult(data) {
            if (typeof data === "string" && data.length > 0) {
                data = JSON.parse(data);
            }
            if (data) {
                return { result: data.Result };
            }
            else {
                return data;
            }
        }
        Request.parsers = {
            simple: {
                result: parseResult,
                error: parseError
            },
            single: {
                result: parseSingleResult,
                error: parseError
            }
        };
        Everlive.disableRequestCache = function (url, method) {
            if (method === 'GET') {
                var timestamp = (new Date()).getTime();
                var separator = url.indexOf('?') > -1 ? '&' : '?';
                url += separator + '_el=' + timestamp;
            }
            return url;
        };
        // TODO built for reqwest
        if (typeof Everlive.sendRequest === "undefined") {
            Everlive.sendRequest = function (request) {
                var url = request.buildUrl(request.setup) + request.endpoint;
                url = Everlive.disableRequestCache(url, request.method);
                var data = request.method === 'GET' ? request.data : JSON.stringify(request.data);
                //$.ajax(url, {
                reqwest({
                    url: url,
                    method: request.method,
                    data: data,
                    headers: request.headers,
                    type: "json",
                    contentType: 'application/json',
                    crossOrigin: true,
                    //processData: request.method === "GET",
                    success: function (data, textStatus, jqXHR) {
                        request.success.call(request, request.parse.result(data));
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        request.error.call(request, request.parse.error(jqXHR.responseText));
                    }
                });
            };
        }
        return Request;
    }());

    // rsvp promises
    Everlive.getCallbacks = function (success, error) {
        var promise;
        if (typeof success !== "function" && typeof error !== "function") {
            //promise = new RSVP.Promise();
            //success = function (data) {
            //    promise.resolve(data);
            //};
            //error = function (error) {
            //    promise.reject(error);
            //};
            promise = new RSVP.Promise(function (resolve, reject) {
                success = function (data) {
                    resolve(data);
                };
                error = function (error) {
                    reject(error);
                };
            });
        }
        return { promise: promise, success: success, error: error };
    };
    // whenjs promises
    //Everlive.getCallbacks = function (success, error) {
    //    var promise;
    //    if (typeof success !== "function" && typeof error !== "function") {
    //        promise = when.defer();
    //        success = function (data) {
    //            promise.resolve(data);
    //        };
    //        error = function (error) {
    //            promise.reject(error);
    //        };
    //    }
    //    return { promise: promise.promise, success: success, error: error };
    //};
    function buildPromise(operation, success, error) {
        var callbacks = Everlive.getCallbacks(success, error);
        operation(callbacks.success, callbacks.error);
        return callbacks.promise;
    }

    function Data(setup, collectionName) {
        this.setup = setup;
        this.collectionName = collectionName;
        this.options = null;
    }
    // Everlive base CRUD functions
    Data.prototype = {
        withHeaders: function (headers) {
            var options = this.options || {};
            options.headers = _.extend(options.headers || {}, headers);
            this.options = options;
            return this;
        },
        _createRequest: function (options) {
            _.extend(options, this.options);
            this.options = null;
            return new Request(this.setup, options);
        },
        // TODO implement options: { requestSettings: { executeServerCode: false } }. power fields queries could be added to that options argument
        get: function (filter, success, error) {
            var self = this;
            return buildPromise(function (success, error) {
                var request = self._createRequest({
                    method: "GET",
                    endpoint: self.collectionName,
                    filter: filter,
                    success: success,
                    error: error
                });
                request.send();
            }, success, error);
        },
        // TODO handle options
        // TODO think to pass the id as a filter
        getById: function (id, success, error) {
            var self = this;
            return buildPromise(function (success, error) {
                var request = self._createRequest({
                    method: "GET",
                    endpoint: self.collectionName + "/" + id,
                    parse: Request.parsers.single,
                    success: success,
                    error: error
                });
                request.send();
            }, success, error);
        },
        count: function (filter, success, error) {
            var self = this;
            return buildPromise(function (success, error) {
                var request = self._createRequest({
                    method: "GET",
                    endpoint: self.collectionName + "/_count",
                    filter: filter,
                    parse: Request.parsers.single,
                    success: success,
                    error: error
                });
                request.send();
            }, success, error);
        },
        create: function (data, success, error) {
            var self = this;
            return buildPromise(function (success, error) {
                var request = self._createRequest({
                    method: "POST",
                    endpoint: self.collectionName,
                    data: data,
                    parse: Request.parsers.single,
                    success: success,
                    error: error
                });
                request.send();
            }, success, error);
        },
        rawUpdate: function (attrs, filter, success, error) {
            var self = this;
            return buildPromise(function (success, error) {
                var endpoint = self.collectionName;
                var ofilter = null; // request options filter
                if (typeof filter === "string") // if filter is string than will update a single item using the filter as an identifier
                    endpoint += "/" + filter;
                else if (typeof filter === "object") // else if it is an object than we will use it as a query filter
                    ofilter = filter;
                var request = self._createRequest({
                    method: "PUT",
                    endpoint: endpoint,
                    data: attrs,
                    filter: ofilter,
                    success: success,
                    error: error
                });
                request.send();
            }, success, error);
        },
        _update: function (attrs, filter, single, replace, success, error) {
            var self = this;
            return buildPromise(function (success, error) {
                var endpoint = self.collectionName;
                if (single)
                    endpoint += "/" + attrs[idField];
                var data = {};
                data[replace ? "$replace" : "$set"] = attrs;
                var request = self._createRequest({
                    method: "PUT",
                    endpoint: endpoint,
                    data: data,
                    filter: filter,
                    success: success,
                    error: error
                });
                request.send();
            }, success, error);
        },
        updateSingle: function (model, success, error) {
            return this._update(model, null, true, false, success, error);
        },
        update: function (model, filter, success, error) {
            return this._update(model, filter, false, false, success, error);
        },
        replaceSingle: function (model, success, error) {
            return this._update(model, null, true, true, success, error);
        },
        _destroy: function (attrs, filter, single, success, error) {
            var self = this;
            return buildPromise(function (success, error) {
                var endpoint = self.collectionName;
                if (single)
                    endpoint += "/" + attrs[idField];
                var request = self._createRequest({
                    method: "DELETE",
                    endpoint: endpoint,
                    filter: filter,
                    success: success,
                    error: error
                });
                request.send();
            }, success, error);
        },
        destroySingle: function (model, success, error) {
            return this._destroy(model, null, true, success, error);
        },
        destroy: function (filter, success, error) {
            return this._destroy(null, filter, false, success, error);
        }
    };
    //TODO add a function for calculating the distances in geospatial queries

    function GeoPoint(longitude, latitude) {
        this.longitude = longitude || 0;
        this.latitude = latitude || 0;
    }
    Everlive.GeoPoint = GeoPoint;

    var addUsersFunctions = function (ns) {
        ns._loginSuccess = function (data) {
            var result = data.result;
            var setup = this.setup;
            setup.token = result.access_token;
            setup.tokenType = result.token_type;
        };
        ns._logoutSuccess = function () {
            var setup = this.setup;
            setup.token = null;
            setup.tokenType = null;
        };
        ns.register = function (username, password, attrs, success, error) {
            guardUnset(username, "username");
            guardUnset(password, "password");
            var user = {
                Username: username,
                Password: password
            };
            _.extend(user, attrs);
            return this.create(user, success, error);
        };
        ns.login = function (username, password, success, error) {
            var self = this;
            return buildPromise(function (success, error) {
                var request = new Request(self.setup, {
                    method: "POST",
                    endpoint: "oauth/token",
                    data: {
                        username: username,
                        password: password,
                        grant_type: "password"
                    },
                    authHeaders: false,
                    parse: Request.parsers.single,
                    success: function () {
                        self._loginSuccess.apply(self, arguments);
                        success.apply(null, arguments);
                    },
                    error: error
                });
                request.send();
            }, success, error);
        };
        ns.currentUser = function (success, error) {
            return this.getById("me", success, error);
        };
        ns.changePassword = function (username, password, newPassword, keepTokens, success, error) {
            var self = this;
            return buildPromise(function (success, error) {
                var endpoint = "Users/changepassword";
                if (keepTokens)
                    endpoint += "?keepTokens=true";
                var request = new Request(self.setup, {
                    method: "POST",
                    endpoint: endpoint,
                    data: {
                        Username: username,
                        Password: password,
                        NewPassword: newPassword
                    },
                    authHeaders: false,
                    parse: Request.parsers.single,
                    success: success,
                    error: error
                });
                request.send();
            }, success, error);
        };
        ns.logout = function (success, error) {
            var self = this;
            return buildPromise(function (success, error) {
                var request = new Request(self.setup, {
                    method: "GET",
                    endpoint: "oauth/logout",
                    success: function () {
                        self._logoutSuccess.apply(self, arguments);
                        success.apply(null, arguments);
                    },
                    error: error
                });
                request.send();
            }, success, error);
        };

        ns._loginWithProvider = function (providerName, accessToken, success, error) {
            var user = {
                Identity: {
                    Provider: providerName,
                    Token: accessToken
                }
            };
            var self = this;
            return buildPromise(function (success, error) {
                var request = new Request(self.setup, {
                    method: 'POST',
                    endpoint: 'Users',
                    data: user,
                    authHeaders: false,
                    parse: Request.parsers.single,
                    success: function () {
                        self._loginSuccess.apply(self, arguments);
                        success.apply(null, arguments);
                    },
                    error: error
                });
                request.send();
            }, success, error);
        };
        ns._linkWithProvider = function (providerName, userId, accessToken, success, error) {
            var identity = {
                Provider: providerName,
                Token: accessToken
            };
            var self = this;
            return buildPromise(function (success, error) {
                var request = new Request(self.setup, {
                    method: 'POST',
                    endpoint: 'Users/' + userId + '/link',
                    data: identity,
                    parse: Request.parsers.single,
                    success: success,
                    error: error
                });
                request.send();
            }, success, error);
        };
        ns._unlinkFromProvider = function (providerName, userId, success, error) {
            var identity = {
                Provider: providerName
            };
            var self = this;
            return buildPromise(function (success, error) {
                var request = new Request(self.setup, {
                    method: 'POST',
                    endpoint: 'Users/' + userId + '/unlink',
                    data: identity,
                    parse: Request.parsers.single,
                    success: success,
                    error: error
                });
                request.send();
            }, success, error);
        };

        ns.loginWithFacebook = function (accessToken, success, error) {
            return ns._loginWithProvider('Facebook', accessToken, success, error);
        };
        ns.linkWithFacebook = function (userId, accessToken, success, error) {
            return ns._linkWithProvider('Facebook', userId, accessToken, success, error);
        };
        ns.unlinkFromFacebook = function (userId, success, error) {
            return ns._unlinkFromProvider('Facebook', userId, success, error);
        };

        ns.loginWithLiveID = function (accessToken, success, error) {
            return ns._loginWithProvider('LiveID', accessToken, success, error);
        };
        ns.linkWithLiveID = function (userId, accessToken, success, error) {
            return ns._linkWithProvider('LiveID', userId, accessToken, success, error);
        };
        ns.unlinkFromLiveID = function (userId, success, error) {
            return ns._unlinkFromProvider('LiveID', userId, success, error);
        };

        ns.loginWithGoogle = function (accessToken, success, error) {
            return ns._loginWithProvider('Google', accessToken, success, error);
        }
        ns.linkWithGoogle = function (accessToken, success, error) {
            return ns._linkWithProvider('Google', userId, accessToken, success, error);
        }
        ns.unlinkFromGoogle = function (userId, success, error) {
            return ns._unlinkFromProvider('Google', userId, success, error);
        }
    };

    var addFilesFunctions = function (ns) {
        ns.getUploadUrl = function () {
            return Everlive.buildUrl(this.setup) + this.collectionName;
        };
        ns.getDownloadUrl = function (fileId) {
            return Everlive.buildUrl(this.setup) + this.collectionName + '/' + fileId + '/Download';
        };
        ns._getUpdateUrl = function (fileId) {
            return this.collectionName + '/' + fileId + '/Content';
        };
        ns.getUpdateUrl = function (fileId) {
            return Everlive.buildUrl(this.setup) + this._getUpdateUrl(fileId);
        };
        ns.updateContent = function (fileId, file, success, error) {
            var self = this;
            return buildPromise(function (success, error) {
                var endpoint = self._getUpdateUrl(fileId);
                // the passed file content is base64 encoded
                var request = self._createRequest({
                    method: "PUT",
                    endpoint: endpoint,
                    data: file,
                    success: success,
                    error: error
                });
                request.send();
            }, success, error);
        };
    };


    //#region Push

    //Constants for different platforms in Everlive
    var Platform = {
        WindowsPhone: 1,
        Windows8: 2,
        Android: 3,
        iOS: 4,
        OSX: 5,
        Blackberry: 6,
        Nokia: 7,
        Unknown: 100
    };

    //Global event handlers for push notification events. Required by the cordova PushNotifications plugin that we use.
    Everlive.PushCallbacks = {};

    var Push = function (el) {
        this._el = el;
        this._currentDevice;

        this.notifications = el.data('Push/Notifications');
        this.devices = el.data('Push/Devices');

    };
    Push.prototype = {
        currentDevice: function (emulatorMode) {
            if (!window.cordova) {
                throw new Error("Error: currentDevice() can only be called from within a hybrid mobile app, after 'deviceready' event has been fired.");
            }

            if (!this._currentDevice) {
                this._currentDevice = new CurrentDevice(this);
                this._currentDevice.emulatorMode = emulatorMode;
            }

            return this._currentDevice;
        }
    };

    var PushSettings = {
        iOS: {
            badge: true,
            sound: true,
            alert: true
        },
        android: {
            senderID: null
        },
        notificationCallbackAndroid: null,
        notificationCallbackIOS: null
    };

    var CurrentDevice = function (pushHandler) {
        this._pushHandler = pushHandler;
        this._initSuccessCallback = null;
        this._initErrorCallback = null;

        //Suffix for the global callback functions
        this._globalFunctionSuffix = null;

        this.pushSettings = null;
        this.pushToken = null;
        this.isInitialized = false;
        this.isInitializing = false;

        this.emulatorMode = false;
    };

    CurrentDevice.prototype = {

        /**
         * Initializes the current device for push notifications. This method requests a push token
         * from the device vendor and enables the push notification functionality on the device.
         * Once this is done, you can register the device in Everlive using the register() method.
         *
         * @param {PushSettings} pushSettings
         *   An object specifying various settings for the initialization.
         * @param {Function} success
         *   Callback to invoke on success.
         * @param {Function} error
         *   Callback to invoke on error.
         * @returns {Object}
         *   A promise for the operation, or void if success/error are supplied.
         */
        enableNotifications: function (pushSettings, success, error) {
            this.pushSettings = pushSettings;
            return buildPromise(_.bind(this._initialize, this), success, error);
        },

        /**
         * Disables push notifications for the current device. This method invalidates any push tokens
         * that were obtained for the device from the current application.
         *
         * @param {Function} success
         *   Callback to invoke on success.
         * @param {Function} error
         *   Callback to invoke on error.
         * @returns {Object}
         *   A promise for the operation, or void if success/error are supplied.
         */
        disableNotifications: function (success, error) {
            var self = this;

            return this.unregister().then(
                function () {
                    return buildPromise(
                        function (success, error) {
                            if (self.emulatorMode) {
                                success();
                            } else {
                                var pushNotification = window.plugins.pushNotification;
                                pushNotification.unregister(
                                    function () {
                                        self.isInitialized = false;
                                        success();
                                    },
                                    error
                                );
                            }
                        },
                        success,
                        error
                    );
                },
                error
            );
        },

        /**
         * Returns the push registration for the current device.
         *
         * @param {Function} success
         *   Callback to invoke on success.
         * @param {Function} error
         *   Callback to invoke on error.
         * @returns {Object}
         *   A promise for the operation, or void if success/error are supplied.
         */
        getRegistration: function (success, error) {
            var deviceId = this._getDeviceId();
            return this._pushHandler.devices.getById('HardwareId/' + deviceId, success, error);
        },

        /**
         * Registers the current device for push notifications in Everlive. This method can be called
         * only after enableNotifications() has completed successfully.
         * 
         * @param {Object} customParameters
         *   Custom parameters for the registration.
         * @param {Function} success
         *   Callback to invoke on success.
         * @param {Function} error
         *   Callback to invoke on error.
         * @returns {Object}
         *   A promise for the operation, or void if success/error are supplied.
         */
        register: function (customParameters, success, error) {
            var self = this;

            var deviceRegistration = {};
            if (customParameters !== undefined) {
                deviceRegistration.Parameters = customParameters;
            }
            return this._populateRegistrationObject(deviceRegistration).then(
                function () {
                    return self._pushHandler.devices.create(deviceRegistration, success, error);
                },
                error
            );
        },

        /**
         * Unregisters the current device from push notifications in Everlive. After this call completes
         * successfully, Everlive will no longer send notifications to this device. Note that this does
         * not prevent the device from receiving notifications and does not imvalidate push tokens.
         * 
         * @param {Function} success
         *   Callback to invoke on success.
         * @param {Function} error
         *   Callback to invoke on error.
         * @returns {Object} 
         *   A promise for the operation, or void if success/error are supplied.
         */
        unregister: function (success, error) {
            var deviceId = device.uuid;
            return this._pushHandler.devices.destroySingle({ Id: 'HardwareId/' + deviceId }, success, error);
        },

        /**
         * Updates the registration for the current device.
         * 
         * @param {Object} customParameters
         *   Custom parameters for the registration. If undefined, customParameters are not updated.
         * @param {Function} success
         *   Callback to invoke on success.
         * @param {Function} error
         *   Callback to invoke on error.
         * @returns {Object} 
         *   A promise for the operation, or void if success/error are supplied.
         */
        updateRegistration: function (customParameters, success, error) {
            var self = this;

            var deviceRegistration = {};
            if (customParameters !== undefined) {
                deviceRegistration.Parameters = customParameters;
            }
            return this._populateRegistrationObject(deviceRegistration).then(
                function () {
                    deviceRegistration.Id = 'HardwareId/' + deviceRegistration.HardwareId
                    return self._pushHandler.devices.updateSingle(deviceRegistration, success, error);
                },
                error
            );
        },


        //Initializes the push functionality on the device.
        _initialize: function (success, error) {
            var self = this;

            if (this.isInitializing) {
                error(new Error('Push notifications are currently initializing.'));
                return;
            }

            if (!this.emulatorMode && (!window.plugins || !window.plugins.pushNotification)) {
                error(new Error('The push notifications plugin is not initialized.'));
                return;
            }

            this._initSuccessCallback = success;
            this._initErrorCallback = error;

            if (this.isInitialized) {
                this._deviceRegistrationSuccess(this.pushToken);
                return;
            }

            if (this.emulatorMode) {
                setTimeout(
                    function () {
                        self._deviceRegistrationSuccess("fake_push_token");
                    },
                    1000
                );
                return;
            }

            this.isInitializing = true;

            var suffix = this._globalFunctionSuffix;
            if (!suffix) {
                suffix = Date.now().toString();
                this._globalFunctionSuffix = suffix;
            }

            var pushNotification = window.plugins.pushNotification;

            var platformType = this._getPlatformType(device.platform);
            if (platformType == Platform.iOS) {
                //Initialize global APN callback
                var apnCallbackName = "apnCallback_" + suffix;
                Everlive.PushCallbacks[apnCallbackName] = _.bind(this._onNotificationAPN, this);

                //Construct registration options object and validate iOS settings
                var apnRegistrationOptions = this.pushSettings.iOS;
                this._validateIOSSettings(apnRegistrationOptions);
                apnRegistrationOptions["ecb"] = "Everlive.PushCallbacks." + apnCallbackName;

                //Register for APN
                pushNotification.register(
                    _.bind(this._successfulRegistrationAPN, this),
                    _.bind(this._failedRegistrationAPN, this),
                    apnRegistrationOptions
                );
            } else if (platformType == Platform.Android) {
                //Initialize global GCM callback
                var gcmCallbackName = "gcmCallback_" + suffix;
                Everlive.PushCallbacks[gcmCallbackName] = _.bind(this._onNotificationGCM, this);

                //Construct registration options object and validate the Android settings
                var gcmRegistrationOptions = this.pushSettings.android;
                this._validateAndroidSettings(gcmRegistrationOptions);
                gcmRegistrationOptions["ecb"] = "Everlive.PushCallbacks." + gcmCallbackName;

                //Register for GCM
                pushNotification.register(
                    _.bind(this._successSentRegistrationGCM, this),
                    _.bind(this._errorSentRegistrationGCM, this),
                    gcmRegistrationOptions
                );

            } else {
                throw new Error("The current platform is not supported: " + device.platform);
            }
        },

        _validateAndroidSettings: function (androidSettings) {
            if (!androidSettings.senderID) {
                throw new Error("Sender ID (project number) is not set in the android settings.");
            }
        },

        _validateIOSSettings: function (iOSSettings) {

        },

        _populateRegistrationObject: function (deviceRegistration, success, error) {
            var self = this;

            return buildPromise(
                function (success, error) {
                    if (!self.pushToken) {
                        throw new Error("Push token is not available.");
                    }

                    self._getLocaleName(
                        function (locale) {
                            var deviceId = self._getDeviceId();
                            var hardwareModel = device.name;
                            var platformType = self._getPlatformType(device.platform);
                            var timeZone = jstz.determine().name();
                            var pushToken = self.pushToken;
                            var language = locale.value;
                            var platformVersion = device.version;

                            deviceRegistration.HardwareId = deviceId;
                            deviceRegistration.HardwareModel = hardwareModel;
                            deviceRegistration.PlatformType = platformType;
                            deviceRegistration.PlatformVersion = platformVersion;
                            deviceRegistration.TimeZone = timeZone;
                            deviceRegistration.PushToken = pushToken;
                            deviceRegistration.Locale = language;

                            success();
                        },
                        error
                    );
                },
                success,
                error
            );
        },

        _getLocaleName: function (success, error) {
            if (this.emulatorMode) {
                success({ value: "en_US" });
            } else {
                navigator.globalization.getLocaleName(
                    function (locale) {
                        success(locale);
                    },
                    error
                );
                navigator.globalization.getLocaleName(
                    function (locale) {

                    },
                    error
                );
            }
        },

        _getDeviceId: function () {
            return device.uuid;
        },

        //Returns the Everlive device platform constant given a value aquired from cordova's device.platform.
        _getPlatformType: function (platformString) {
            var psLower = platformString.toLowerCase();
            switch (psLower) {
                case "ios":
                case "iphone":
                case "ipad":
                    return Platform.iOS;
                case "android":
                    return Platform.Android;
                case "wince":
                    return Platform.WindowsPhone;
                default:
                    return Platform.Unknown;
            }
        },

        _deviceRegistrationFailed: function (error) {
            this.pushToken = null;
            this.isInitializing = false;
            this.isInitialized = false;

            if (this._initErrorCallback) {
                this._initErrorCallback({ error: error });
            }
        },

        _deviceRegistrationSuccess: function (token) {
            this.pushToken = token;
            this.isInitializing = false;
            this.isInitialized = true;

            if (this._initSuccessCallback) {
                this._initSuccessCallback({ token: token });
            }
        },

        //Occurs when the device registration in APN succeeds
        _successfulRegistrationAPN: function (token) {
            this._deviceRegistrationSuccess(token);
        },

        //Occurs if the device registration in APN fails
        _failedRegistrationAPN: function (error) {
            this._deviceRegistrationFailed(error);
        },

        //Occurs when device registration has been successfully sent to GCM
        _successSentRegistrationGCM: function (id) {
            //console.log("Successfully sent request for registering with GCM.");
        },

        //Occurs when an error occured when sending registration request to GCM
        _errorSentRegistrationGCM: function (error) {
            this._deviceRegistrationFailed(error);
        },

        //This function receives all notification events from APN
        _onNotificationAPN: function (e) {
            this._raiseNotificationEventIOS(e);
        },

        //This function receives all notification events from GCM
        _onNotificationGCM: function onNotificationGCM(e) {
            switch (e.event) {
                case 'registered':
                    if (e.regid.length > 0) {
                        this._deviceRegistrationSuccess(e.regid);
                    }
                    break;
                case 'message':
                    this._raiseNotificationEventAndroid(e);
                    break;
                case 'error':
                    if (!this.pushToken) {
                        this._deviceRegistrationFailed(e);
                    } else {
                        this._raiseNotificationEventAndroid(e);
                    }
                    break;
                default:
                    this._raiseNotificationEventAndroid(e);
                    break;
            }
        },

        _raiseNotificationEventAndroid: function (e) {
            if (this.pushSettings.notificationCallbackAndroid) {
                this.pushSettings.notificationCallbackAndroid(e);
            }
        },
        _raiseNotificationEventIOS: function (e) {
            if (this.pushSettings.notificationCallbackIOS) {
                this.pushSettings.notificationCallbackIOS(e);
            }
        }


    };

    //#endregion

    var initDefault = function () {
        this.Users = this.data('Users');
        addUsersFunctions(this.Users);
        this.Files = this.data('Files');
        addFilesFunctions(this.Files);

        this.push = new Push(this);
    };

    initializations.push({ name: "default", func: initDefault });

    ns.Everlive = Everlive;
}(this));
