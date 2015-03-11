function calcCircleArea(r){
    var area = Math.PI*r*r;
    return area;
}
var p = document.getElementsByTagName('p');
for (var i = 0; i < p.length; i++) {
    var re = new RegExp(".*?[\\s]*=[\\s]*(?=\\d)");
    var r = p[i].innerHTML.replace(re,'');
    p[i].innerHTML = "r = " + r + "; area = "+calcCircleArea(r);
}