function drawText(text, x, y, size) {
    var canvas = document.getElementById("myCanvas");
    var ctx = canvas.getContext("2d");
    ctx.font = size + " Helvetica";
    ctx.fillText(text, x, y);
}

function imageDraw(image,x,y){
    var canvas = document.getElementById("myCanvas");
    var ctx = canvas.getContext("2d");
    image.onload= function() {
        ctx.drawImage(image, x, y);
    };
}