function buildStringBuilder() {
    return {
        string: [],
        len: 0,
        append: function (str) {
            this.string[this.len++] = str;
            return this;
        },
        toString: function () {
            return this.string.join("");
        },
        Reverse: function () {
            var reversed = "";
            for (var i = this.string.length - 1; i >= 0; i--) {
                for (var j = this.string[i].length - 1; j >= 0; j--) {
                    reversed += this.string[i].charAt(j);
                }
            }
            return reversed;
        },
        Clear: function () {
            this.string = [];
            this.len = 0;
        }
    };
}