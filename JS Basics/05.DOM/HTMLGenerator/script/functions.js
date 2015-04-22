function HTMLGenerator() {}

HTMLGenerator.createParagraph = function (id, text) {
    var p = document.createElement('p');
    p.innerText = text;
    var id = document.getElementById(id);
    id.appendChild(p);
};

HTMLGenerator.createDiv = function (id, divClass) {
    var div = document.createElement('div');
    div.className = divClass;
    var id = document.getElementById(id);
    id.appendChild(div);
};

HTMLGenerator.createLink = function (id, text, url) {
    var a = document.createElement('a');
    a.innerText = text;
    a.href = url;
    var id = document.getElementById(id);
    id.appendChild(a);
};

HTMLGenerator.createParagraph('wrapper','SoftUni')
HTMLGenerator.createDiv('wrapper','section');
HTMLGenerator.createLink('book','C# basics book','http://www.introprogramming.info/')


