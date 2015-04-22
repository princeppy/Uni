function solve(input) {
    var str = input[0];

    var regexP = new RegExp('<p>.+?(?=</p>)', 'g');

    var arr = str.match(regexP);
    var str1 = '';
    for (var p in arr) {
        str1 += arr[p].substr(3);
    }


    str1 = str1.replace(/[^a-z]+/g, ' ');
    var strFinal = '';
    for (var i = 0; i < str1.length; i++) {
        if (str1.charCodeAt(i) === 32) {
            strFinal += ' ';
            continue;
        }
        if (str1.charCodeAt(i) > 109) {
            strFinal += String.fromCharCode(str1.charCodeAt(i) - 13);
        }

        else {
            strFinal += String.fromCharCode(str1.charCodeAt(i) + 13);
        }
    }
    strFinal = strFinal.replace(/\\-+/g, ' ');
    console.log(strFinal);
}
