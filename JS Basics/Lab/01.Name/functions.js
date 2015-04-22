var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');
ctx.font = '100px Verdana';
ctx.shadowColor = 'red';
ctx.shadowOffsetX = 0;
ctx.shadowOffsetY = 0;
ctx.shadowBlur = 20;
ctx.strokeStyle = 'red';
ctx.fillStyle = 'black';
ctx.lineWidth = 2;
ctx.fillText('BATMAN', 100, 100);
ctx.strokeText('BATMAN', 100, 100);
ctx.background='red';

