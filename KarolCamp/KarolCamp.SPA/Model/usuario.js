define(['datacontexto', 'jquery', 'ko', 'sammy'], function (datacontexto, jq, ko, sammy) {
    var modulo = {
        usuario: new model(),
        listaDeUsuarios: ko.observableArray([]),
        init: init,
        buscar: buscar,
        logar: logar,
        buscarCallback: function () { },
    };

    function init() {
        //buscar(modulo.listaDeUsuarios);
        return modulo;
    };

    return init();

    function model(data) {
        var self = this;
        data = data || {};
        self.Id = ko.observable(data.Id);
        self.UserName = ko.observable(data.UserName);
        self.Telefone = ko.observable(data.Telefone);

        self.listaDeErros = ko.observable({ temErro: false, lista: [] });

        self.Limpar = function () {
            self.Id('');
            self.UserName('');
            self.Telefone('');

            self.listaDeErros({ temErro: false, lista: [] });
        };
        return self;
    };

    function logar(login, senha, persistir) {

        var dados = {
            Login: login,
            Senha: senha
        };
        var callback = datacontexto.requisicao('Post', tokenUrl(), dados);
        callback.done(function (data) {
            if (data && data.error_description) {
                console.log(data.error_description);
                return;
            }
            navegarLogado(data.userName, data.access_token, persistir);
        });
    }

    function navegarLogado(userName, accessToken, persistir) {
        if (accessToken) {
            setAccessToken(accessToken, persistir, userName);
            
            logado(true);
            usuario(userName);

            location.replace('#/');
        }
    }

    function setAccessToken(accessToken, persistir, userName) {
        if (persistir) {
            localStorage["accessToken"] = accessToken;
            localStorage["usuario"] = userName;
        } else {
            sessionStorage["accessToken"] = accessToken;
            sessionStorage["usuario"] = userName;
        }
    };

    function clearAccessToken () {
        localStorage.removeItem("accessToken");
        sessionStorage.removeItem("accessToken");
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

    function buscarUrl() { return "api/usuarios"; }
    function tokenUrl() { return "api/usuarios/token"; }
});