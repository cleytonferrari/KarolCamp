define(['jquery', 'sammy'], function (jq, sammy) {
    function setConfig(titulo) {
        document.title = titulo;
    }

    return sammy('#conteudo', function () {

        this.get('#/', function (context) {
            this.load('/Views/inicio.html', { cache: true }).then(function (response) {
                setConfig("Karol Camp SPA");
                context.$element().html(response);
            });
        });
        this.get('#/trilha', function (context) {
            this.load('/Views/trilha.html', { cache: true }).then(function (response) {
                setConfig("Karol Camp SPA: Trilha");
                context.$element().html(response);
            });
        });

    }).run('#/');
});