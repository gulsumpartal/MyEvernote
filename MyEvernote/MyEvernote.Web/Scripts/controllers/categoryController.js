var categoryController = {
    displayNotesByCategoryId: function (categoryId) {
        $.get('/Category/GetNotesByCategoryId', { 'categoryId': categoryId }, function (data) {
            $('#divNotes').html(data);
        });
    }
}