function EditarViewModel() {
    var self = this;
    self.id = ko.observable();
    self.nome = ko.observable();

    self.construtor = function () {
        var id = $(location).attr('href').split("/").pop();
        
        $.getJSON('/api/salas', { id: id }, function (retorno) {
            self.id(retorno.Id);
            self.nome(retorno.Nome);
        });
    };
}

$(function () {
    var viewModel = new EditarViewModel();
    viewModel.construtor();
    ko.applyBindings(viewModel);
});