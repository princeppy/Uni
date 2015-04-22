function hide(){
    var el = document.getElementById("invoice");
    if(!el.checked){
        var div = document.getElementById("test");
        div.style.display = "none";
    }
    if(el.checked){
        var div = document.getElementById("test");
        div.style.display = "block";
    }
}