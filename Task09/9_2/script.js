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
    var numbers = [...str.matchAll(/(\d+\.?\d+|\d+)/g)];
    var signs = [...str.matchAll(/[+\-*/]/g)];

    var result = Number.parseFloat(numbers[0]);
    for (var i = 1; i < numbers.length; i++) {
        result = evalTwoNums(result, numbers[i], signs[i-1]);
    }
    
    return result % 1 == 0 ? result : result.toFixed(2);
}