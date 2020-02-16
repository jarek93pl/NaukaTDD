$('#ShowCategoryAlert').click(function (e) {
    $('#AllertApp').show();
    $('#AllertApp').load('/Home/AddCategoryPage');
    e.preventDefault();
});
$('#AllertApp').on("click", "input[type=submit]",function (e) {
    e.preventDefault();
    PostAction('Home/AddCategory', { Name: $('.AddCategoryPage .form-control[asp-for="Name"]').val() }, function () {

    });
    $('#AllertApp').html('');
    $('#AllertApp').hide();
});