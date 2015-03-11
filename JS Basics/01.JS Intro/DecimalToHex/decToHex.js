function decToHex(){
    var num = parseInt(prompt('Enter a number in decimal format'));
    var numInHex = num.toString(16).toUpperCase();
    alert('The number in hexadecimal format is: ' + numInHex);
}