define(['jquery', 'helpers/ajaxConfig'], function (jq, cc) {
    var datacontexto = {
        requisicao: ajaxRequest
    };

    return datacontexto;

    //pra resolver esta questao, da pra expor os metodos GET, PUT, DELETE, POST ao invez de expor a requisicao
    function ajaxRequest(type, url, data, noToJson) {
        var servidor = "http://localhost:6880/";
        //var servidor = "http://karolcamp.apphb.com/";

        var options = {
            dataType: "json",
            contentType: 'application/json',
            cache: false,
            type: type,
            headers: getSecurityHeaders(),
            data: noToJson ? data : ko.toJSON(data)
        };
        
        return jq.ajax(servidor + url, options);
    }
    
    function getSecurityHeaders() {
        
        var accessToken = sessionStorage["accessToken"] || localStorage["accessToken"];
        if (accessToken) {
            return { "Authorization": "Bearer " + accessToken };
        }
        return {};
    }
});