function EditarViewModel() {
    var self = this;
    self.id = ko.observable();
    self.nome = ko.observable();

    self.preencheForm = function () {
        //pegar o ID da URL
        $.getJSON('/api/trilhas', { id: 'af459cfadace49df9b64d5caab6e1615' }, function (retorno) {
            console.log(retorno);
            self.id(retorno.Id);
            self.nome(retorno.Nome);
        });
    };

    self.salvar = function () {
        var trilha = {
            Id: self.id(),
            Nome: self.nome(),
        };

        $.ajax({
            url: '/api/trilhas',
            type: "PUT",
            data: JSON.stringify(trilha),
            contentType: 'application/json',
            statusCode: {
                200: function (retorno) {
                    console.log(retorno);
                    //Window.location('KO/Trilha/');
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