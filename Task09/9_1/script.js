function charRemover(str) {
    // array containing separator chars
    var separators = [' ','\t','?','!',':',';',',','.'];
    
    // array containing single words
    var words = [];
    var i = 0;
    var start = 0;
    do {
        i++;
        if (separators.includes(str[i]) || i == str.length) {
            words.push(str.slice(start, i));
            while (separators.includes(str[i]) && i != str.length) {
                i++;
            }
            start = i;
        }
    } while (i < str.length);

    var repeats = [];

    words.forEach(word => {
        for (var i = 0; i < word.length - 1; i++) {
            for (var j = i + 1; j < word.length; j++) {
                if (word[i] == word[j] && !repeats.includes(word[i])) {
                    repeats.push(word[i]);
                    j = word.length;
                }
            }
        }
    });

    var chars = str.split('');
    for (var i = chars.length - 1; i >= 0; i--) {
        if (repeats.includes(chars[i])) {
            chars.splice(i, 1);
        }
    }
    return chars.join('');
}

function remove() {
    document.getElementById("out").value = charRemover(document.getElementById("in").value);
}