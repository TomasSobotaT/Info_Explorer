
//get Language
document.getElementById("language").innerText = navigator.language;

//get Browser
let userAgent = navigator.userAgent;
let browserName;

if (userAgent.match(/chrome|chromium|crios/i)) {
    browserName = "chrome";
} else if (userAgent.match(/firefox|fxios/i)) {
    browserName = "firefox";
} else if (userAgent.match(/safari/i)) {
    browserName = "safari";
} else if (userAgent.match(/opr\//i)) {
    browserName = "opera";
} else if (userAgent.match(/edg/i)) {
    browserName = "edge";
} else if (userAgent.match(/brave/i)) {
    browserName = "brave";
} else {
    browserName = "No browser detection";
}
document.getElementById("pokus").innerText = navigator.appName;
document.getElementById("browser_version").innerText = browserName;



// GOOGLE MAPS by lat. and long.
// Initialize and add the map
function initMap(a, b) {

    a = a.replace(',', '.')
    b = b.replace(',', '.')

    let lt = parseFloat(a);
    let lg = parseFloat(b);

    console.log(lt)
    console.log(lg)
    // The location of Uluru
    const uluru = { lat: lt, lng: lg };
    console.log(uluru)
    // The map, centered at Uluru
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 7,
        center: uluru,
    });
    // The marker, positioned at Uluru
    const marker = new google.maps.Marker({
        position: uluru,
        map: map,
    });
}


window.onload = function () {

    let a = document.getElementById("lati").innerText;
    let b = document.getElementById("long").innerText;
    initMap(a, b);


};

