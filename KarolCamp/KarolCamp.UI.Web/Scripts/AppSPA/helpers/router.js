define(['jquery', 'sammy'], function (jq, sammy) {
    function setConfig(titulo) {
        document.title = titulo;
    }

    return sammy('#content', function () {
        
        this.get('#/', function (context) {
            this.load('/Content/html/inicio.html', { cache: true }).then(function (response) {
                setConfig("Karol Camp SPA");
                context.$element().html(response);
            });
        });
        this.get('#/trilha', function (context) {
            this.load('/Content/html/trilha.html', { cache: true }).then(function (response) {
                setConfig("Karol Camp SPA: Trilha");
                context.$element().html(response);
            });
        });
        
    }).run('#/');
});