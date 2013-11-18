define(['datacontexto', 'jquery', 'ko'], function (datacontexto, jq, ko) {
    var modulo = {
        palestrante: new model(),
        set: set,
        listaDePalestrantes: ko.observableArray([]),
        init: init,
        buscar: buscar,
        buscarCallback: function () { },
    };

    function init() {
        buscar(modulo.listaDePalestrantes);
        return modulo;
    };

    return init();

    function set(data) {
        modulo.palestrante = new model(data);
    }

    function model(data) {
        var self = this;
        data = data || {};
        self.Id = ko.observable(data.Id);
        self.Nome = ko.observable(data.Nome);
        self.Twitter = ko.observable(data.Twitter);
        self.Bio = ko.observable(data.Bio);
        self.FotoId = ko.observable(data.FotoId);

        self.listaDeErros = ko.observable({ temErro: false, lista: [] });

        self.Limpar = function () {
            self.Id('');
            self.Nome('');
            self.Twitter('');
            self.Bio('');
            self.FotoId('');
            self.listaDeErros({ temErro: false, lista: [] });
        };
        return self;
    };

    function buscar(listaObservable) {
        var callback = datacontexto.requisicao('Get', buscarUrl());
        callback.done(function (retorno) {
            var array = ko.observableArray([]);
            jq(retorno).each(function () { array.push(new model(this)); });
            listaObservable(array());
        });
        return modulo.buscarCallback(callback);
    }

    function buscarUrl() { return "api/palestrantes"; }
});