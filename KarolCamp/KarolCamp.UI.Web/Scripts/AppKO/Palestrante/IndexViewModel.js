function IndexViewModel() {
    var self = this;

    self.listaDeTrilhas = ko.observableArray();
    
    self.carregaTrilhas = function () {
        $.getJSON('/api/trilhas', function (retorno) {
            var array = self.listaDeTrilhas();
            ko.utils.arrayPushAll(array, retorno);
            self.listaDeTrilhas.valueHasMutated();
        });
    };
    self.construtor = function () {
        self.carregaTrilhas();
    };
}

$(function () {
    var viewModel = new IndexViewModel();
    viewModel.construtor();
    ko.applyBindings(viewModel);
});