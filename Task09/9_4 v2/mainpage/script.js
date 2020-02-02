var time = 5;
var timeLeft = time;

var pages = [
    "../page1/index.html",
    "../page2/index.html",
    "../page3/index.html",
    "../page4/index.html"
];

// current page's number
var pageNumber = 0;

// set up first page
var frame = document.getElementsByClassName('page')[0];
frame.setAttribute("src", pages[pageNumber]);

// set up timer
var timer = document.getElementsByClassName('timer')[0];
setTimerValue(timeLeft);

// reset timer
function reset() {
    timeLeft = time;
    setTimerValue(timeLeft);
}

// flag indicating if the timer is paused
var isPaused = false;

function pause() {
    isPaused = true;
}

function play() {
    isPaused = false;
}

// sets timer value on the page
function setTimerValue(time) {
    timer.innerHTML = time.toFixed(1) + " seconds left";
}

var pageChangeInterval = setInterval(() => {
    if (!isPaused) {
        setTimerValue(timeLeft);
        timeLeft -= 0.1;
        if (timeLeft < 0) {
            if (pageNumber != pages.length - 1) {
                frame.setAttribute("src", pages[++pageNumber]);
            } else {
                if (confirm("Show again?")) {
                    window.location.reload();
                } else {
                    alert('Slide show over. Close the tab.');
                    clearInterval(pageChangeInterval);
                }
            }
            timeLeft = time;
        }
    }
}, 100);

function goToNext() {
    if (pageNumber == pages.length - 1) {
        alert("It's the last page!");
        return;
    }

    pageNumber++;
    frame.setAttribute("src", pages[pageNumber]);
    reset();
    play();
}

function goToPrev() {
    if (pageNumber == 0) {
        alert("It's the first page!");
        return;
    }

    pageNumber--;
    frame.setAttribute("src", pages[pageNumber]);
    reset();
    play();
}