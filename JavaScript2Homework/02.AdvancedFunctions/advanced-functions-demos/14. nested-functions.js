String.prototype.compare = function compareStrings(other, caseSensitive) {
    if (caseSensitive) return compareCaseSensitive(this, other)
    else return compareCaseInsesitive(this, other);

    function compareCaseSensitive(str1, str2) {
        if (str1.length != str2.length) {
            return false;
        }
        for (var i = 0; i < str1.length; i += 1) {
            if (str1[i] !== str2[i]) {
                return false;
            }
        }
        return true;
    }

    function compareCaseInsesitive(str1, str2) {
        return compareCaseSensitive(str1.toLowerCase(), str2.toLowerCase());
    }
}
