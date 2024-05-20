const bigBeep = new Audio('/sounds/big-beep.mp3');
const smallBeep = new Audio('/sounds/small-beep.mp3');

function playBigBeep() {
    bigBeep.volume = 0.5;
    bigBeep.play();
}

function playSmallBeep() {
    smallBeep.volume = 0.55;
    smallBeep.play();
}