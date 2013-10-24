define(['datacontexto', 'jquery', 'ko'], function (datacontexto, jq, ko) {
    var modulo = {
        trilha: new model(),
        listaDeTrilhas: ko.observableArray([]),
        init: init,
        buscar: buscar,
        buscarCallback: function () { },
    };

    function init() {
        buscar(modulo.listaDeTrilhas);
        return modulo;
    };

    return init();

    function model(data) {
        var self = this;
        data = data || {};
        self.Id = ko.observable(data.Id);
        self.Nome = ko.observable(data.Nome);
        
        self.listaDeErros = ko.observable({ temErro: false, lista: [] });

        self.Limpar = function () {
            self.Id('');
            self.Nome('');
        
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

    function buscarUrl() { return "api/trilhas"; }
});