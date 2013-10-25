function IndexViewModel() {
    var self = this;

    self.listaDeSalas = ko.observableArray();
    
    self.carregaSalas = function () {
        $.getJSON('/api/salas', function (retorno) {
            var array = self.listaDeSalas();
            ko.utils.arrayPushAll(array, retorno);
            self.listaDeSalas.valueHasMutated();
        });
    };
    self.construtor = function () {
        self.carregaSalas();
    };
}

$(function () {
    var viewModel = new IndexViewModel();
    viewModel.construtor();
    ko.applyBindings(viewModel);
});