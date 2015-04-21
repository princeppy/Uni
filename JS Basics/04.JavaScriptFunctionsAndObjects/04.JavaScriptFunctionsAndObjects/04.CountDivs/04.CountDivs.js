var str = '<!DOCTYPE html> <html> <head lang="en"> <meta charset="UTF-8"> <title>index</title> <script src="/yourScript.js" defer></script> </head> <body> <div id="outerDiv"> <div class="first"> <div><div>hello</div></div> </div> <div>hi<div></div></div> <div>I am a div</div> </div> </body> </html>';

function countDivs(str){
    var htmlObject = document.createElement('div');
    htmlObject.innerHTML = str;
    var count = htmlObject.getElementsByTagName('div').length;

    console.log('The count of the divs is: '+count);
}

countDivs(str);
