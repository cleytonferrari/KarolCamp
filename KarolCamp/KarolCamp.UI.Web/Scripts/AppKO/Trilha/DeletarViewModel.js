function CadastrarViewModel() {
    var self = this;
    self.id = ko.observable();
    self.nome = ko.observable();
    
    self.excluir = function () {
        $.ajax({
            url: '/api/trilhas/'+self.id(),
            type: "DELETE",
            contentType: 'application/json',
            statusCode: {
                200: function (retorno) {
                    console.log(retorno);
                    //Window.location('KO/Trilha/');
                },

                403: function (msg) {console.log(msg);},

                400: function (msg) {console.log(msg);},

                404: function (msg) {console.log(msg);},

                500: function (msg) {console.log(msg);}
            }
        });
        //redirecionar para index
    };


    self.construtor = function () {
        //pegar o id da URL
        $.getJSON('/api/trilhas', { id: 'af459cfadace49df9b64d5caab6e1615' }, function (retorno) {
            self.id(retorno.Id);
            self.nome(retorno.Nome);
        });
    };
}

$(function () {
    var viewModel = new CadastrarViewModel();
    viewModel.construtor();
    ko.applyBindings(viewModel);
});