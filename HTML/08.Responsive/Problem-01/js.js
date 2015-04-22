var s = document.createElement("script");
s.type = "text/javascript";
s.src = "http://somedomain.com/somescript";
// Add script content

function hi(){
    console.log('HELLO');
}

s.innerHTML = "function hi(){console.log('HELLO');}";

// Append

document.body.appendChild(s);