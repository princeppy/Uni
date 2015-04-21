function checkMail(){
    var el = document.getElementById("email-input").value;
    var regex = new RegExp('[\\w\\.\\-_]{1,}@[A-z0-9\\.\\-]+\\.[A-z\\-_]+','g');
    var div = document.getElementById('check');
    if(regex.test(el)){
        div.style.display = 'block';
        div.innerText = el;
        div.style.backgroundColor = 'green';
    }
    else{
        div.style.display = 'block';
        div.innerText = el;
        div.style.backgroundColor = 'red';
    }
}