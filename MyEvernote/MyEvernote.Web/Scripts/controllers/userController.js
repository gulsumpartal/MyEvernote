var userController = {

    activetedUserProfile: function () {
        $.ajax({

            type: 'POST',
            url: '@Url.Action("ActivedProfile", "User")',
            data: $("#frmActivedProfile").serialize(),
            success: function (res) {
                //$('#divResult').html(res);
                //$('#messageBox').modal('show');
            }
        });
    },
    divActivedResultLoad: function () {
        setTimeout(function () { location.href='/Auth/Login' }, 6000);
    }

}