function LoadDocuments() {
    PostAction("/Home/FindDocument",
        {

        },
        function (data) {
            var txt = '';
            for (var i in data) {
                txt += "<tr><td>" + i.DateCreated + "</td>" + Name + "<td></td><td>" + Owner + "</td><td>" + Category + "</td> </tr>";
            }
        }
    );
}
LoadDocuments();
$('#AutorId').bind('input',
    function () {
        PostActionByString("/Home/FindAutor", $('#AutorIdbrowsers').val()
            , function (data) {
                var optionsHtml = '';
                for (var i of data) {
                    var name = i.id + ')'+ (i.firstName === undefined ? "" : i.firstName) + ' ' + (i.lastName === undefined ? "" : i.lastName);
                    optionsHtml += '<option data-id"' + i.id + '" value="' + name + '"/>';
                }
                $('#AutorIdbrowsers').html(optionsHtml);
            });
    });

