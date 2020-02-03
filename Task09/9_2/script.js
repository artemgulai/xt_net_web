function evalTwoNums(a,b,sign) {
    b = Number.parseFloat(b);
    switch (sign[0]) {
        case '+': return a + b;
        case '-': return a - b;
        case '*': return a * b;
        case '/': return a / b;
    }
}

function evaluateExpression(str) {
    let startsWithMinus = (str[0] == "-");

    var numbers = [...str.matchAll(/(\d+\.?\d+|\d+)/g)];
    var signs = [...str.matchAll(/[+\-*/]/g)];

    if (startsWithMinus) {
        signs.shift();
    }
    var result = Number.parseFloat(numbers[0]);
    result = startsWithMinus ? -result : result;
    for (var i = 1; i < numbers.length; i++) {
        result = evalTwoNums(result, numbers[i], signs[i-1]);
    }
    
    return result % 1 == 0 ? result : result.toFixed(2);
}