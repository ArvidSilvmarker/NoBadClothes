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

function onLoad() {
    populateCityDropDown();
};

function populateCityDropDown() {
    console.log("Populerar stadsnamn.")
    var select = document.getElementById("cityNames");
    var cities = getTopTenCities();

    for (var i = 0; i < 10; i++) {
        var city = cities[i];
        var element = document.createElement("option");
        element.textContent = city;
        element.value = city;
        select.appendChild(element);
    };
};

$('#select').empty();
$.each(options, function (i, p) {
    $('#select').append($('<option></option>').val(p).html(p));
});


function getTopTenCities() {
    $.ajax({
        url: "/api/weather/getTopTenCityNames",
        method: "GET"
    })
    .done(function (result) {
        console.log(result);
        return result;
    })
    .fail(function (xhr, status, error) {
        alert("error");
    });
};
