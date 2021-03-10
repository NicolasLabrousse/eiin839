let stations;

function retrieveAllContracts() {
    var targetUrl = "https://api.jcdecaux.com/vls/v3/contracts?apiKey=" + document.getElementById("apiKey").value;
    var requestType = "GET";

    var caller = new XMLHttpRequest();
    caller.open(requestType, targetUrl, true);
    // The header set below limits the elements we are OK to retrieve from the server.
    caller.setRequestHeader ("Accept", "application/json");
    // onload shall contain the function that will be called when the call is finished.
    caller.onload=contractsRetrieved;

    caller.send();
}

function contractsRetrieved() {
    // Let's parse the response:
    let response = JSON.parse(this.responseText);
    response.forEach(contract => {
        let option = document.createElement("option");
        option.append(contract.name);
        document.getElementById('datalist').append(option)
    });
}

function retrieveContractStations() {
    var targetUrl = "https://api.jcdecaux.com/vls/v3/stations?apiKey=" + document.getElementById("apiKey").value + "&contract=" + document.getElementById("contract").value;
    var requestType = "GET";

    var caller = new XMLHttpRequest();
    caller.open(requestType, targetUrl, true);
    // The header set below limits the elements we are OK to retrieve from the server.
    caller.setRequestHeader("Accept", "application/json");
    // onload shall contain the function that will be called when the call is finished.
    caller.onload = contractDetails;

    caller.send();
}

function contractDetails() {
    // Let's parse the response:
    let response = JSON.parse(this.responseText);
    stations = response;
    console.log(response);
}

function getDistanceFrom2GpsCoordinates(lat1, lon1, lat2, lon2) {
    // Radius of the earth in km
    var earthRadius = 6371;
    var dLat = deg2rad(lat2 - lat1);
    var dLon = deg2rad(lon2 - lon1);
    var a =
        Math.sin(dLat / 2) * Math.sin(dLat / 2) +
        Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
        Math.sin(dLon / 2) * Math.sin(dLon / 2)
        ;
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    var d = earthRadius * c; // Distance in km
    return d;
}

function deg2rad(deg) {
    return deg * (Math.PI / 180)
}

function getClosestStation() {
    let latitude = document.getElementById("latitude").value;
    let longitude = document.getElementById("longitude").value;
    let closestStation = stations[1];
    stations.forEach(station => {
        if (getDistanceFrom2GpsCoordinates(latitude, longitude, station.position.latitude, station.position.longitude) < getDistanceFrom2GpsCoordinates(latitude, longitude, closestStation.position.latitude, closestStation.position.longitude)) {
            closestStation = station;
        }
    })
    console.log(closestStation);
    document.getElementById("labelClosestStation").innerHTML = closestStation.name;

}