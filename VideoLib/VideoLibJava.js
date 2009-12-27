function onResizePic(im) {

    im.style.width = 200;
    im.style.height = 200;

}
function offResizePic(im) {
    im.style.width = 84;
    im.style.height = 84;

}

function onSummery(sp) {

    sp.children[0].style.visibility = "visible";

}

function offSummery(sp) {
    sp.children[0].style.visibility = "hidden";
}

function onReviews(but) {
    var g = document.getElementById("repeater");
    if (g.style.visibility == "visible") {
        document.getElementById("repeater").style.visibility = "hidden";
        but.value = "Show Reviews"
    }
    else {
        document.getElementById("repeater").style.visibility = "visible";
        but.value = "Hide Reviews";
    }
}

function rate(imgeStar) {

    var stars = new Array();
    for (var i = 0; i < 5; i++) {

        stars[i] = document.getElementById("star" + i);
    }

    var count = 0;

    switch (imgeStar.id) {
        case "star1":
            count = 1;
            break;
        case "star2":
            count = 2;
            break;
        case "star3":
            count = 3;
            break;
        case "star4":
            count = 4;
            break;
        case "star5":
            count = 5;
            break;
    }
    document.getElementById("lblCar").innerText = count;

    var o = Request.Form[secretValue.UniqueID];
    for (var y = 1; y <= parseInt(count); y++) {

        document.getElementById("star" + y).src = "Images/starfull.gif";
    }



}
function onStar(imgeStar) {

    var stars = new Array();
    for (var i = 1; i <= 5; i++) {

        stars[i] = document.getElementById("star" + i);
    }
    
    var count = 0;

    switch (imgeStar.id) {
        case "star1":
            count = 1;
            break;
        case "star2":
            count = 2;
            break;
        case "star3":
            count = 3;
            break;
        case "star4":
            count = 4;
            break;
        case "star5":
            count = 5;
            break;
    }


    for (var y = 1; y <= parseInt(count); y++) {

        document.getElementById("star" + y).src = "Images/starfull.gif";
    }
}
function offStar(imgeStar) {

    for (var y = 1; y <= 5; y++) {

        document.getElementById("star" + y).src = "Images/starempty.gif";
    }

}
