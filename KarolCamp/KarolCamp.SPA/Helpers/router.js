define(['jquery', 'sammy'], function (jq, sammy) {
    function setConfig(titulo) {
        document.title = titulo;
    }

    return sammy('#conteudo', function () {

        this.get('#/', function (context) {
            if (!logado) return this.redirect('#/login');
            this.load('/Views/inicio.html', { cache: false }).then(function (response) {
                setConfig("Karol Camp SPA");
                context.$element().html(response);
            });
        });
        this.get('#/login', function (context) {
            this.load('/Views/login.html', { cache: false }).then(function (response) {
                setConfig("Karol Camp SPA: Acessar o sistema");
                context.$element().html(response);
            });
        });
        this.get('#/trilha', function (context) {
            if (!logado) return this.redirect('#/');
            this.load('/Views/trilha/index.html', { cache: false }).then(function (response) {
                setConfig("Karol Camp SPA: Trilha");
                context.$element().html(response);
            });
        });

    }).run('#/');
});