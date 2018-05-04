$("#whatButton").click(function () {

    alert("första");
    var h = $("#hour").val();
    var d = $("#dateTime").val();
    var c = $("#cityName").val();


    //location.href = "/api/clothes/getClothes?hour={h}&dateTime={d}&cityName={c}";


    $.ajax({
        url: "/api/clothes/getClothes/",
        data: {
            hour: h,
            dateTime : d,
            cityName : c}

        })
        .done(function (result) {
            ("#text").html("<h2> Ha!.</h2>");
            alert("hello");

        })
        .fail(function (xhr, status, error) {

            alert("error");
        });
});