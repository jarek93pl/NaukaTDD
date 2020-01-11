function LoadDocuments() {
    PostAction("/Home/FindDocument",
        {

        },
        function (data) {
            var txt = '';
            for (var i in data) {
                txt += "<tr><td>" + i.DateCreated + "</td>" + Name + "<td></td><td>" + Owner + "</td><td>" + Category+"</td> </tr>";
            }
        }
    );
}
LoadDocuments();