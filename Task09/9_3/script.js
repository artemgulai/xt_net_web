function moveSome(from, to) {
    var optionsFrom = from.options;
    var selected = false;          

    for (var i=0; i<optionsFrom.length; i++) {
        if (optionsFrom[i].selected) {
            optionsFrom[i].selected = false;
            to.add(optionsFrom[i]);
            i--;
            selected = true;
        }
    }
    if (!selected) {
        alert("Nothing is selected");
    }
}

function moveAll(from, to) {
    var optionsFrom = from.options;
    if (optionsFrom.length == 0) {
        alert('Nothing to move');
        return;
    }
              
    for (var i=0; i<optionsFrom.length; i++) {
        optionsFrom[i].selected = false;
        to.add(optionsFrom[i]);
        i--;
    }
}