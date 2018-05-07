$("#whatButton").click(function () {

    //alert("första");
    var h = $("#hour").val();
    var d = $("#dateTime").val();
    var c = $("#cityName").val();


    //location.href = "/api/clothes/getClothes?hour={h}&dateTime={d}&cityName={c}";


    $.ajax({
        url: "/api/clothes/getClothesImg/",
        method: "GET",
        data: {
            hour: h,
            dateTime : d,
            cityName : c}

        })
        .done(function (result) {
            //document.getElementById("text").innerHTML = result;
            $("#text").html(result);
            console.log(result);
        })
        .fail(function (xhr, status, error) {

            alert("error");
        });
});