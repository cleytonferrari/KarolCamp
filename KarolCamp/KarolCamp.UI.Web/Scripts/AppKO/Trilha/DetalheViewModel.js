function EditarViewModel() {
    var self = this;
    self.id = ko.observable();
    self.nome = ko.observable();

    self.construtor = function () {
        //pegar o id da URL
        $.getJSON('/api/trilhas', { id: 'af459cfadace49df9b64d5caab6e1615' }, function (retorno) {
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