var counter = 1;
var board = [[0, 0, 0], [0, 0, 0], [0, 0, 0]];
var xScore = 0;
var oScore= 0;
function putMark(element) {

    if (element.getAttribute('src') == "img/empty.png" && counter % 2 == 1) {
        element.setAttribute('src', 'img/circle.png');
        var parent = element.parentNode;
        var parentSize = window.getComputedStyle(parent, null).getPropertyValue('width');
        var imgWidth = element.style.width = parseInt(parentSize) * 0.75 + 'px';
        var imgHeight = element.style.height = parseInt(parentSize) * 0.75 + 'px';
        parent.style.display = 'flex';
        parent.style.justifyContent = 'center';
        var x = parent.style.width;
        element.style.alignSelf = 'center';

        var values = parent.id.split(' ');
        var row = parseInt(values[0]);
        var col = parseInt(values[1]);

        board[row][col] = 1;
        checkWin();

        counter++;
    }
    else if (element.getAttribute('src') == "img/empty.png" && counter % 2 == 0) {
        element.setAttribute('src', 'img/xmark.png');
        var parent = element.parentNode;
        var parentSize = window.getComputedStyle(parent, null).getPropertyValue('width');
        var imgWidth = element.style.width = parseInt(parentSize) * 0.75 + 'px';
        var imgHeight = element.style.height = parseInt(parentSize) * 0.75 + 'px';
        parent.style.display = 'flex';
        parent.style.justifyContent = 'center';
        var x = parent.style.width;
        element.style.alignSelf = 'center';

        var values = parent.id.split(' ');
        var row = parseInt(values[0]);
        var col = parseInt(values[1]);

        board[row][col] = 2;
        checkWin();
        counter++;
    }

    if(counter==10){
        setTimeout(function(){resetBoard()},2000);
    }
}

function resetBoard() {
    var list = document.getElementsByTagName('img');
    for (var i = 0; i < list.length; i++) {
        var imageObj = list[i];
        imageObj.setAttribute('src', "img/empty.png");
        var parent = imageObj.parentNode;
        parent.style.backgroundColor = 'transparent';
        var parentSize = window.getComputedStyle(parent, null).getPropertyValue('width');
        var imgWidth = imageObj.style.width = parseInt(parentSize) + 'px';
        var imgHeight = imageObj.style.height = parseInt(parentSize) + 'px';
    }

    for (var i = 0; i < board[0].length; i++) {
        for (var j = 0; j < board[1].length; j++) {
            board[i][j] = 0;
        }
    }
    document.getElementById('winner').innerHTML = "";
    document.getElementById('winner').style.backgroundColor = 'white';


    counter = 1;
}

function resetResult(){
    xScore=0;
    oScore=0;
    document.getElementById('scoreX').innerHTML = "SCORE BLUE: "+xScore;
    document.getElementById('scoreO').innerHTML = "SCORE RED: "+oScore;
}

function checkWin() {

    var value = 0;
    var check = false;

    //Check horizontal for winner
    for (var i = 0; i < board[0].length; i++) {
        if (board[i][0] == board[i][1] && board[i][1] == board[i][2] && board[i][0] != 0) {
            var a1 = document.getElementById(i + ' ' + 0);
            a1.style.backgroundColor = 'limegreen';
            var a2 = document.getElementById((i) + ' ' + (1));
            a2.style.backgroundColor = 'limegreen';
            var a3 = document.getElementById((i) + ' ' + (2));
            a3.style.backgroundColor = 'limegreen';
            value = board[i][0];
            check = true;
            break;
        }
    }

    //Check vertical for winner
    for (var i = 0; i < board[0].length; i++) {
        if (board[0][i] == board[1][i] && board[1][i] == board[2][i] && board[0][i] != 0) {
            var a1 = document.getElementById(0 + ' ' + i);
            a1.style.backgroundColor = 'limegreen';
            var a2 = document.getElementById((1) + ' ' + (i));
            a2.style.backgroundColor = 'limegreen';
            var a3 = document.getElementById((2) + ' ' + (i));
            a3.style.backgroundColor = 'limegreen';
            value = board[0][i];
            check = true;
            break;
        }
    }

    //Check diagonal from top left for winnner
    if (board[0][0] == board[1][1] && board[1][1] == board[2][2] && board[0][0] != 0) {
        var a1 = document.getElementById(0 + ' ' + 0);
        a1.style.backgroundColor = 'limegreen';
        var a2 = document.getElementById((1) + ' ' + (1));
        a2.style.backgroundColor = 'limegreen';
        var a3 = document.getElementById((2) + ' ' + (2));
        a3.style.backgroundColor = 'limegreen';
        value = board[0][0];
        check = true;

    }

    //Check diagonal from top right for winner
    if (board[0][2] == board[1][1] && board[1][1] == board[2][0] && board[0][2] != 0) {
        var a1 = document.getElementById(0 + ' ' + 2);
        a1.style.backgroundColor = 'limegreen';
        var a2 = document.getElementById((1) + ' ' + (1));
        a2.style.backgroundColor = 'limegreen';
        var a3 = document.getElementById((2) + ' ' + (0));
        a3.style.backgroundColor = 'limegreen';
        value = board[0][2];
        check = true;
    }

    if(check==true){
        if(value==1){
            document.getElementById('winner').innerHTML = "WINNER: RED";
            document.getElementById('winner').style.backgroundColor = 'red';
            oScore++;
            document.getElementById('scoreO').innerHTML = "SCORE RED: "+oScore;
        }
        else{
            document.getElementById('winner').innerHTML = "WINNER: BLUE";
            document.getElementById('winner').style.backgroundColor = 'dodgerblue';
            xScore++;
            document.getElementById('scoreX').innerHTML = "SCORE BLUE: "+xScore;
        }
        setTimeout(function(){resetBoard()},2000);
    }
}