define(['ko', 'model/palestrante', 'model/palestra'], function (ko, palestrante, palestra) {

    var controller = {
        palestrante: palestrante,
        palestra: palestra
    };

    ko.applyBindings(controller, $("#conteudo")[0]);

    function init() {
        return controller;
    };

    return init();
});