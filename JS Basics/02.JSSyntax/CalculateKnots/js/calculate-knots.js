function calculateKnots() {
    var speedKM = document.getElementById('speed-km').value;
    var speedKnots = speedKM/1.852;
    document.getElementById('speed-knots').innerHTML = speedKnots +' knots';
}