////<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

// TODO: Find en bedre måde at implementere typing animation på.
//// TODO: Implementere cursor animation.

//// Add cursor image and hides the real cursor.
//var cursorImg = document.createElement('img');
//cursorImg.src = 'images/cursor.png';
//cursorImg.style.position = 'absolute';
//cursorImg.style.width = '18px';
//cursorImg.style.height = '18px';

//// Set the start position of the cursor image
//cursorImg.style.left = '1000px';
//cursorImg.style.top = '100px';

//// cursorImg.style.WebkitTransition = '4s';
//// cursorImg.style.transition = '4s';
//cursorImg.style.pointerEvents = 'none'; // Allow mouse events to pass through the image
//document.body.style.cursor = 'none';
//document.body.appendChild(cursorImg);

//Typing animation

var i = 0;
var inputElement = document.getElementsByClassName("type-animation")[0];
var txt = inputElement.dataset.txt;
var speed = inputElement.dataset.speed; // Speed/duration of the effect in milliseconds
var url = inputElement.dataset.url; // The URL to redirect to
var redirectDelay = inputElement.dataset.redirectDelay;
var startTypingDelay = inputElement.dataset.startTypingDelay;

inputElement.value = "";
function typeWriter() {

    if (i < txt.length) {
        inputElement.value += txt.charAt(i);
        i++;
        setTimeout(typeWriter, speed);
        inputElement.dispatchEvent(new Event('input'));
    } else {
        // TODO: Implementere cursor animation.
        //moveCursorToButton();
        setTimeout(function () {
            window.location.href = url;
        }, redirectDelay); // Delay before redirecting
    }
}

//// TODO: Implementere cursor animation.
//function moveCursorToButton() {
//    // Cursor animation
//    var button = $("#search-btn");

//    // Get the button's position
//    var buttonOffset = button.offset();

//    // Move the cursor image to the center of the button
//    $(cursorImg).animate({
//        left: buttonOffset.left + button.width() / 2,
//        top: buttonOffset.top + button.height() / 2
//    }, 4000);

//    // Redirect to the URL
//    window.location.href = url;
//}

window.onload = function () {
    setTimeout(typeWriter, startTypingDelay); // Starts typing after a delay.
};