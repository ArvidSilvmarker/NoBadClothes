$("#seedButton").click(function () {
    $.ajax({
            url: "/api/weather/seedtopten",
            method: "POST"
        })
        .done(function (result) {
            alert(result);
        })
        .fail(function (xhr, status, error) {
            alert(`Error! ${xhr.responseText}`);
            console.log("xhr", xhr);
            console.log("status", status);
            console.log("error", error);
        });
});