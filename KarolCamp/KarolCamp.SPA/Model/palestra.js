define(['datacontexto', 'jquery', 'ko', 'model/palestrante'], function (datacontexto, jq, ko, palestrante) {
    var modulo = {
        palestra: new model(),
        listaDePalestras: ko.observableArray([]),
        init: init,
        buscar: buscar,
        buscarCallback: function () { },
    };

    function init() {
        buscar(modulo.listaDePalestras);
        return modulo;
    };

    return init();

    function model(data) {
        var self = this;
        data = data || {};
        self.Id = ko.observable(data.Id);
        self.Titulo = ko.observable(data.Titulo);
        self.Codigo = ko.observable(data.Codigo);
        self.Descricao = ko.observable(data.Descricao);
        self.Horario = ko.observable(data.Horario);
        self.Nivel = ko.observable(data.Nivel);



        self.Palestrante = ko.observable(palestrante.set(data.Palestrante));

        /*self.Trilha = ko.observable(data.Twitter);
        self.Sala = ko.observable(data.Twitter);*/

        self.listaDeErros = ko.observable({ temErro: false, lista: [] });

        self.Limpar = function () {
            self.Id('');
            self.Titulo('');
            self.Codigo('');
            self.Descricao('');
            self.Horario('');
            self.Nivel('');
            self.Palestrante.Limpar(),
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

    function buscarUrl() { return "api/palestras"; }
});