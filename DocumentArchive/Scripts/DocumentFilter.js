$('#ShowCategoryAlert').click(function (e) {
    $('#AllertApp').show();
    $('#AllertApp').load('/Home/AddCategoryPage');
    e.preventDefault();
});
$('#ShowAutorAlert').click(function (e) {
    $('#AllertApp').show();
    $('#AllertApp').load('/Home/AddAutorPage');
    e.preventDefault();
});
$('#AllertApp').on("click", ".AddCategoryPage input[type=submit]",function (e) {
    e.preventDefault();
    PostAction('Home/AddCategory', { Name: $('.AddCategoryPage .form-control[asp-for="Name"]').val() }, function () {

    });
    $('#AllertApp').html('');
    $('#AllertApp').hide();
});
$('#AllertApp').on("click", ".AddAutorPage input[type=submit]", function (e) {
    e.preventDefault();
    PostAction('Home/AddAutor', {
        FirstName: $('.AddAutorPage .form-control[asp-for="FirstName"]').val(),
        LastName: $('.AddAutorPage .form-control[asp-for="LastName"]').val()
    }, function () {

    });
    $('#AllertApp').html('');
    $('#AllertApp').hide();
});