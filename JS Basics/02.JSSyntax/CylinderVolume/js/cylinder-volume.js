function cylinderVolume(radius, height) {
    var area = radius*radius*Math.PI;
    var volume = area*height;

    document.getElementById('volume').innerHTML = 'Volume = ' + volume.toFixed(2);
}