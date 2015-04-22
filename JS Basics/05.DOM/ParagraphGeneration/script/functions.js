function createParagraph(id){
    var text = document.getElementById("text").value;
    var p = document.createElement('p');
    p.innerText = text;
    var id = document.getElementById(id);
    id.appendChild(p);
}