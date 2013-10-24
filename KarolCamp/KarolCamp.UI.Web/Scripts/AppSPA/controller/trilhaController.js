define(['ko', 'model/trilha'], function (ko, trilha) {

    var controller = {
        trilha: trilha
    };
    
    ko.applyBindings(controller, $("#content")[0]);
    
    
    function init() {
        return controller;
    };

    return init();
});