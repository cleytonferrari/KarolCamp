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
    }

});