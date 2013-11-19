define(['jquery'], function (jq) {

    function init() {
        configuracao();
        return null;
    };

    return init();

    function configuracao() {
        jq.ajaxSetup({
            beforeSend: function () {
                $('#loader').fadeIn();
            },
            complete: function () {
                $('#loader').fadeOut('fast');
            },
            success: function () {
                $('#loader').fadeOut('fast');
            },
            statusCode: {
                401: function () {
                    // Redirec the to the login page.

                },
                403: function () {
                    // 403 -- Access denied

                }
            }
        });
        
        jq.ajaxPrefilter(function (options, originalOptions, jqXHR) {
            jqXHR.failJSON = function (callback) {
                jqXHR.fail(function (jqXHR, textStatus, error) {
                    var data;

                    try {
                        data = $.parseJSON(jqXHR.responseText);
                    }
                    catch (e) {
                        data = null;
                    }

                    callback(data, textStatus, jqXHR);
                });
            };
        });
    }

});