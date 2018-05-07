$(document).ready(function() {
    $("#whatButton").click(function() {

        var h = $("#hour").val();
        var d = $("#dateTime").val();
        var c = $("#cityNames").val();

        $.ajax({
                url: "/api/clothes/getClothesImg/",
                method: "GET",
                data: {
                    hour: h,
                    dateTime: d,
                    cityName: c
                }
            })
            .done(function(result) {
                $("#text").html(result);
                console.log(result);
            })
            .fail(function(xhr, status, error) {
                alert(`Error! ${xhr.responseText}`);
                console.log("xhr", xhr);
                console.log("status", status);
                console.log("error", error);
            });
    });
});

function onLoad() {
    PopulateOptionCities();
    $('input[type=datetime-local]').val(new Date().toJSON().slice(0, 19));
};

function PopulateOptionCities() {
    $.ajax({
        url: "/api/weather/getTopTenCityNames",
        method: "GET",
        success: function (cities) {
            var select = document.getElementById("cityNames");

            for (var i = 0; i < 10; i++) {
                var city = cities[i];
                var element = document.createElement("option");
                element.textContent = city;
                element.value = city;
                select.appendChild(element);
            };
        },
        error: function(xhr, status, error) {
            alert("error");
        }
    });
}
