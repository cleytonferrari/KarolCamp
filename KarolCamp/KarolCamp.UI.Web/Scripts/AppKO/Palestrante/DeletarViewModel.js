function DeletarViewModel() {
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
        var id = $(location).attr('href').split("/").pop();
        $.getJSON('/api/trilhas', { id: id }, function (retorno) {
            self.id(retorno.Id);
            self.nome(retorno.Nome);
        });
    };
}

$(function () {
    var viewModel = new DeletarViewModel();
    viewModel.construtor();
    ko.applyBindings(viewModel);
});