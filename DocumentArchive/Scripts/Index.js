function LoadFilter() {
    return {
        CategoryIdtext: GetIndex($('#CategoryId').val()),
        AutorIdtext: GetIndex($('#AutorId').val()),
        BeginCreateDateString: $('#BeginCreateDate').val(),
        EndCreateDateString: $('#EndCreateDate').val(),
        Prefix: $('#Prefix').val()
    };
}
function GetIndex(category) {

    var arrey = category.split(')');
    if (arrey.length > 0) {
        return arrey[0];
    }
    else {
        return "";
    }

}



function LoadDocuments() {
    PostAction("/Home/FindDocument", LoadFilter(),
        function (data) {
            var txt = '';
            for (var i of data) {
                txt += "<tr><td>" + i.dateCreated + "</td><td>" + i.name + "</td><td>" + i.ownerNavigation.name + "</td><td>" + i.categoryNavigation.name + "</td> </tr>";
            }
            $('#documents').html(txt);
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
                    var name = i.id + ')' + (i.firstName === undefined ? "" : i.firstName) + ' ' + (i.lastName === undefined ? "" : i.lastName);
                    optionsHtml += '<option data-id"' + i.id + '" value="' + name + '"/>';
                }
                $('#AutorIdbrowsers').html(optionsHtml);
            });
    });

$('#CategoryId').bind('input',
    function () {
        PostActionByString("/Home/FindCategory", $('#CategoryIdbrowsers').val()
            , function (data) {
                var optionsHtml = '';
                for (var i of data) {
                    var name = i.id + ')' + (i.name === undefined ? "" : i.name);
                    optionsHtml += '<option data-id"' + i.id + '" value="' + name + '"/>';
                }
                $('#CategoryIdbrowsers').html(optionsHtml);
            });
    });
$('.Shearch[type="submit"]').click(function (e) {
    e.preventDefault();
    LoadDocuments();
});

