var noteController = {
    getNotes: function () {
        $("#divNotes").load('/Note/FillNotesPartial', function (data) {
            $('#divNotes').html(data);
        });
    }
}