var maxikiosco = maxikiosco || {};
maxikiosco.util = function () {
    /**
    * Generates a GUID string, according to RFC4122 standards.
    * @returns {String} The generated GUID.
    * @example af8a8416-6e18-a307-bd9c-f2c947bbb3aa
    * @author Slavik Meltser (slavik@meltser.info).
    * @link http://slavik.meltser.info/?p=142
    */
    function guid() {
        function _p8(s) {
            var p = (Math.random().toString(16) + "000000000").substr(2, 8);
            return s ? "-" + p.substr(0, 4) + "-" + p.substr(4, 4) : p;
        }
        return _p8() + _p8(true) + _p8(true) + _p8();
    }
    
    function unicodeDecode (string) {
        var result = string;
        result = result.replace(/\\u05f3/gi, '\'');
        result = result.replace(/\\u000d\\u000a/gi, '\n');
        result = result.replace(/\\u000a\\u000d/gi, '\n');
        return result;
    }

    return {
        guid: guid,
        unicodeDecode: unicodeDecode
    };
}();

