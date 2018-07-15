var authController = {
    login: function () {
        var isValid = authController.validaton(data);

        if (isValid) {
            var data = $("#frmLogin").serialize();
            $.post('/Auth/Login', data, function (response) {

                if (!response.IsSuccess) {
                    $('#divLoginResult').html(respose.Errors);
                    $("#divLoginResult").removeClass('hidden');
                }
                else {
                    location.href = "/";
                }

            });
        }
    },

    validaton: function (data) {
        var userName = $('#username').val();
        if (userName == '') {
            $("#usernameRequired").removeClass('hidden');
            return false;
        }
        var psdword = $('#password').val();
        if (psdword === '') {
            $("#passwordRequired").removeClass('hidden');
            return false;
        }
        return true;
    },

    componentsOnBlur(object, requiredName) {
        var componentValue = $(object).val();
        if (componentValue == '') {
            $("#" + requiredName).removeClass('hidden');
            return false;
        }
        else {
            $("#" + requiredName).addClass('hidden');
            return true;
        }
    },

    checkMail: function () {

        $("#errorMessage").addClass('hidden');
        ;
        var email = $('#userEmail').val();
        var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

        if (!filter.test(email)) {
            $("#errorMessage").removeClass('hidden');
            $("#errorMessage").html("Girilen mail adresi geçerisizdir!");
            return false;
        }
        return true;
    },

    register: function () {

        var isValid = this.registerValidation();
        if (isValid) {

            var data = $('#frmRegister').serialize();
            $.post('/Auth/Register',
                data, function (res) {
                    $('#divInformation').html(res);
                   $('#messageBox').modal('show');
                });
        }
    },

    registerValidation: function () {
        var userMail = $('#userEmail').val();
        if (userMail == '') {
            $("#userEmailRequired").removeClass('hidden');
            return false;
        }
        var username = $('#username').val();
        if (username == '') {
            $("#usernameRequired").removeClass('hidden');
            return false;
        }
        var psdword = $('#psdword').val();
        if (psdword == '') {
            $("#passwordRequired").removeClass('hidden');
            return false;
        }
        var repsdword = $('#repassword').val();
        if (repsdword == '') {
            $("#repasswordRequired").removeClass('hidden');
            return false;
        }

        if (psdword.toUpperCase() !== repsdword.toUpperCase()) {
            $("#errorMessage").removeClass('hidden');
            $("#errorMessage").html("Şifre ve Şifre (Tekrar) Alanları aynı olmalıdır!");
            return false;
        }

        this.checkMail();
        return true;
    },

    logout: function () {
        $.post('/Auth/Logout', function (respomse) {
            if (respomse === "OK") {
                location.href = '/Auth/Login';
            }

        });
    }
}
