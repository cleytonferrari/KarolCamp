define(['ko', 'model/trilha'], function (ko, trilha) {

    var controller = {
        trilha: trilha
    };

    ko.applyBindings(controller, $('body')[0]);

    function init() {
        return controller;
    };

    return init();
});