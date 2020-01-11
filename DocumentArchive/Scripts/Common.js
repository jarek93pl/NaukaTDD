function PostAction(url, data, completed) {
    $.ajax({
        url: url,
        type: "POST",
        cache: false,
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data === "") {
                completed(undefined);
            }
            else {
                completed(data);
            }
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });

}
function PostActionByString(url, data, completed) {
    $.ajax({
        url: url,
        type: "POST",
        cache: false,
        data: data,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data === "") {
                completed(undefined);
            }
            else {
                completed(data);
            }
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });

}