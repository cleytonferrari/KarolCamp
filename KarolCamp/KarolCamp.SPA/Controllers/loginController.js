define(['ko', 'model/usuario'], function (ko, usuario) {

    var controller = {
        usuario: usuario,
        login: ko.observable(''),
        senha: ko.observable(''),
        persistirLogin: ko.observable(false),
        entrar: entrar
    };

    ko.applyBindings(controller, $("#conteudo")[0]);

    function init() {
        return controller;
    };
    
    function entrar() {
        controller.usuario.logar(controller.login(), controller.senha(),controller.persistirLogin());
    }

    return init();
});