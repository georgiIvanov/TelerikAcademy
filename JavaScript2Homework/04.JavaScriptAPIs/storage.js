(function () {
    'use strict';

    //https://developer.mozilla.org/en-US/docs/DOM/Storage#Compatibility
    var localStorage = {
        getItem: function (sKey) {
            if (!sKey || !this.hasOwnProperty(sKey)) { return null; }
            return unescape(document.cookie.replace(new RegExp("(?:^|.*;\\s*)" + escape(sKey).replace(/[\-\.\+\*]/g, "\\$&") + "\\s*\\=\\s*((?:[^;](?!;))*[^;]?).*"), "$1"));
        },
        key: function (nKeyId) {
            return unescape(document.cookie.replace(/\s*\=(?:.(?!;))*$/, "").split(/\s*\=(?:[^;](?!;))*[^;]?;\s*/)[nKeyId]);
        },
        setItem: function (sKey, sValue) {
            if (!sKey) { return; }
            var str = (sKey + "=" + sValue + "; expires=Tue, 19 Jan 2038 03:14:07 GMT; path=/");
            document.cookie = escape(sKey) + "=" + escape(sValue) + "; expires=Tue, 19 Jan 2038 03:14:07 GMT; path=/";
            this.length = document.cookie.match(/\=/g).length;
        },
        length: (document.cookie.match(/\=/g) || []).length,
        removeItem: function (sKey) {
            if (!sKey || !this.hasOwnProperty(sKey)) { return; }
            document.cookie = escape(sKey) + "=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/";
            this.length--;
        },
        hasOwnProperty: function (sKey) {
            return (new RegExp("(?:^|;\\s*)" + escape(sKey).replace(/[\-\.\+\*]/g, "\\$&") + "\\s*\\=")).test(document.cookie);
        }
    };

    var sessionStorage = (function () {
        var keyToValueList = [];

        function getIndex(key) {
            var result = -1;

            for (var i = 0, length = keyToValueList.length; i < length; i += 1) {
                if (key === keyToValueList[i].key) {
                    result = i;
                    break;
                }
            }

            return result;
        }

        var sessionStorage = {
            getItem: function (sKey) {
                if (!sKey || !this.hasOwnProperty(sKey)) { return null; }
                return keyToValueList[getIndex(sKey)].value;
            },
            key: function (nKeyId) {
                var keyValuePair = keyToValueList[nKeyId];

                return keyValuePair !== undefined ?
                  keyValuePair.key :
                  undefined;
            },
            setItem: function (sKey, sValue) {
                if (!sKey) { return; }
                var keyValue = {
                    key: sKey,
                    value: sValue && sValue.toString() || sValue
                };

                var keyIndex = getIndex(sKey);

                if (keyIndex >= 0) {
                    keyToValueList[keyIndex] = keyValue;

                } else {
                    keyToValueList.push(keyValue);
                    this.length += 1;

                }
            },
            length: 0,
            removeItem: function (sKey) {
                if (!sKey || !this.hasOwnProperty(sKey)) { return; }
                keyToValueList.splice(getIndex(sKey), 1);
                this.length--;
            },
            hasOwnProperty: function (sKey) {
                return getIndex(sKey) >= 0;
            }
        };

        return sessionStorage;
    })();

    var Storage = localStorage;

    function renderStorage() {
        var StorageEl = document.querySelector('#local-storage tbody');

        StorageEl.innerHTML = '';

        var fragment = document.createDocumentFragment();

        for (var i = 0, length = Storage.length; i < length; i += 1) {
            var itemEl = document.createElement('tr'),
              key = Storage.key(i);

            var keyEl = document.createElement('td');
            keyEl.textContent = key;
            itemEl.appendChild(keyEl);

            var valueEl = keyEl.cloneNode();
            valueEl.textContent = Storage.getItem(key);
            itemEl.appendChild(valueEl);

            fragment.appendChild(itemEl);
        }

        StorageEl.appendChild(fragment);
    }

    renderStorage();

    document.querySelector('#set-item')
      .addEventListener('submit', function (event) {
          Storage.setItem(
            event.target.key.value,
            event.target.value.value
          );
      }, false);

    document.querySelector('#remove-item')
      .addEventListener('submit', function (event) {
          Storage.removeItem(event.target.key.value);
      }, false);

    document.querySelector('#choose-storage')
      .addEventListener('change', function (event) {
          Storage = event.target.value === 'local' ?
              localStorage :
            sessionStorage;

          renderStorage();
      }, false);

    document.addEventListener('submit', function (event) {
        event.preventDefault();

        renderStorage();

        event.target.reset();
    }, false);
})();
