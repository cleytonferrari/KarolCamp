function HomeViewModel() {
    var self = this;

    self.listaDePalestrantes = ko.observableArray();
    self.listaDePalestras = ko.observableArray();
    
    self.carregaPalestrantes = function () {
        $.getJSON('/api/palestrantes', function (retorno) {
            var array = self.listaDePalestrantes();
            ko.utils.arrayPushAll(array, retorno);
            self.listaDePalestrantes.valueHasMutated();
        });
    };

    self.carregaPalestras = function () {
        $.getJSON('/api/palestras', function (retorno) {
            var array = self.listaDePalestras();
            ko.utils.arrayPushAll(array, retorno);
            self.listaDePalestras.valueHasMutated();
        });
    };

    self.construtor = function () {
        self.carregaPalestrantes();
        self.carregaPalestras();
    };
}

$(function () {
    var viewModel = new HomeViewModel();
    viewModel.construtor();
    ko.applyBindings(viewModel);
});