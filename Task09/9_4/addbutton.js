let timerButton = document.createElement('button');
timerButton.className = "start";
timerButton.id = "start";
timerButton.innerHTML = "Продолжить";
document.body.prepend(timerButton);

timerButton = document.createElement('button');
timerButton.className = "stop";
timerButton.innerHTML = "Приостановить";
timerButton.id = "stop";
document.body.prepend(timerButton);

let timer = document.createElement('div');
timer.className = "timer";
timer.id = "timer";
document.body.prepend(timer);


let button = document.createElement('button');
button.className = "next"
button.id = "next";
button.innerHTML = "Следующая страница";
button.addEventListener("click", goToNext);
document.body.prepend(button);


button = document.createElement('button');
button.className = "previous";
button.id = "previous";
button.innerHTML = "Предыдущая страница";
button.addEventListener("click", goToPrevious);
document.body.prepend(button);