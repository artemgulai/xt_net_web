var time = 20;
var timeLeft = time;

function setTimerValue(timer, timeLeft) {
    timer.innerHTML = timeLeft + " seconds left";
}

var intervalId;
function showCountdown() {
    let timer = document.getElementById('timer');
    timer.innerHTML = timeLeft + " seconds left";
    
    intervalId = setInterval(() => { timeLeft -=1;setTimerValue(timer, timeLeft);}, 1000);
}

var timerId;
function startCountdown() {
    timerId = setTimeout(goToNext, timeLeft * 1000);
    showCountdown();
}

function stopCountdown() {
    clearTimeout(timerId);
    clearInterval(intervalId);
}

document.getElementById("stop").addEventListener("click", stopCountdown);
document.getElementById("start").addEventListener("click", startCountdown);

// var time = 500; // time in seconds
// // setTimeout(goToNext, time * 1000);
// showCountdown(time);

startCountdown(time);