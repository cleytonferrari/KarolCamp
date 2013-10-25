function EditarViewModel() {
    var self = this;
    self.id = ko.observable();
    self.nome = ko.observable();

    self.preencheForm = function () {
        var id = $(location).attr('href').split("/").pop();
        $.getJSON('/api/salas', { id: id }, function (retorno) {
            self.id(retorno.Id);
            self.nome(retorno.Nome);
        });
    };

    self.salvar = function () {
        var sala = {
            Id: self.id(),
            Nome: self.nome(),
        };

        $.ajax({
            url: '/api/salas/'+self.id(),
            type: "PUT",
            data: JSON.stringify(sala),
            contentType: 'application/json',
            statusCode: {
                200: function (retorno) {
                    console.log(retorno);
                    window.location.href = '/KO/Sala';
                },

                403: function (msg) { console.log(msg); },

                400: function (msg) { console.log(msg); },

                404: function (msg) { console.log(msg); },

                500: function (msg) { console.log(msg); }
            }
        });
    };


    self.construtor = function () {
        self.preencheForm();
    };
}

$(function () {
    var viewModel = new EditarViewModel();
    viewModel.construtor();
    ko.applyBindings(viewModel);
});