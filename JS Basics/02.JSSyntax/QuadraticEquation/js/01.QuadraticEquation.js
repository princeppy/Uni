function quadraticEq() {
    var a = document.getElementById('a').value;
    var b = document.getElementById('b').value;
    var c = document.getElementById('c').value;

    var discriminant = b * b - 4 * a * c;

    if (discriminant < 0) {
        document.getElementById('result').innerHTML = 'There are no real roots';
    }
    else if (discriminant == 0) {
        var x12 = -b / (2 * a);
        document.getElementById('result').innerHTML = 'x1 = x2 = ' + x12.toFixed(2);
    }
    else if (discriminant>0){
        var x1 = (-b + Math.sqrt(discriminant)) / (2 * a);
        var x2 = (-b - Math.sqrt(discriminant)) / (2 * a);
        document.getElementById('result').innerHTML = 'x1 = ' + x1.toFixed(2) + ' ' + 'x2 = ' + x2.toFixed(2);
    }

}