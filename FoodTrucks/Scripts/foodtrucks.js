var map;
function initMap() {

    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 37.77, lng: -122.43 },
        zoom: 12
    });

    $.ajax({
        type: "GET",
        url: "/Home/getfoodtrucks",
        data: param = '',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: successFunc,
        //error: errorFunc
    });

}

function errorFunc() {
    alert('error');
}
function successFunc(data, status) {

    var marker, i;
    var length = data.length;

    for (i = 0; i < length; i++) {
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(data[i].Latitude, data[i].Longitude),
            map: map,
            visible: true
        });

        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                var infowindow = new google.maps.InfoWindow({});
                infowindow.setContent(data[i].LocationDescription);
                infowindow.open(map, marker);
            }
        })(marker, i));

    }

}

//function int() {
//    $("#search").keypress(function (e) {
function search(e)
{

    if (e.keyCode == 13) {
        debugger
        var searchtext = $('#search').val();


        $.ajax({
            type: "GET",
            url: "/Home/getfoodtrucksbyaddress",
            data: { address: searchtext },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: successFunc,
            error: errorFunc
        });

    }
}



//}

