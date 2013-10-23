function CadastrarViewModel() {
    var self = this;
    self.id = ko.observable();
    self.nome = ko.observable();
    
    self.salvar = function () {
        var trilha = {
            Id: self.id(),
            Nome: self.nome(),
        };
        
        $.ajax({
            url: '/api/trilhas',
            type: "POST",
            data: JSON.stringify(trilha),
            contentType: 'application/json',
            statusCode: {
                200: function (msg) { console.log(msg); },
                
                201: function (retorno) {
                    console.log(retorno);
                    window.location.href = '/KO/Trilha';
                },
                
                403: function (msg) {console.log(msg);},

                400: function (msg) {console.log(msg);},

                404: function (msg) {console.log(msg);},

                500: function (msg) {console.log(msg);}
            }
        });
    };


    self.construtor = function () {
        
    };
}

$(function () {
    var viewModel = new CadastrarViewModel();
    viewModel.construtor();
    ko.applyBindings(viewModel);
});