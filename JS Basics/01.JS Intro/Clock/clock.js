function clockTick(){
    var date = new Date();
    document.getElementById('clock').innerHTML = date.toTimeString().substring(0,8);
}

