(function () {
    var self = this;
    require.config({
        baseUrl: '/Scripts/AppSPA',
        paths: {
            "router": "helpers/router",
            "datacontexto": "helpers/dataContexto",
        },

    });

    define('jquery', [], function () { return self.$; });
    define('sammy', [], function () { return self.Sammy; });
    define('ko', [], function () { return self.ko; });

    define(function () {
        return self.ko;
    });

})();