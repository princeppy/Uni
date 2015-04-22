function solve(input) {
    var stars = {0:{name: '',x:'',y:''},1:{name: '',x:'',y:''},2:{name: '',x:'',y:''}};

    for (var i = 0; i < 3; i++) {
        var arr = input[i].split(/\s+/g);

        stars[i].name = arr[0].toLowerCase();
        stars[i].x = Number(arr[1]);
        stars[i].y = Number(arr[2]);
    }

    var arr = input[3].split(/\s+/g);
    var ship = {name:'Normandy',x:Number(arr[0]),y:Number(arr[1])};

    var moves = Number(input[4]);

    for (var j = 0; j <= moves; j++) {
        var inStar = false;


        for (var p in stars) {
            if((ship.x<=(stars[p].x+1)&&ship.x>=(stars[p].x-1))&&(ship.y<=(stars[p].y+1)&&ship.y>=(stars[p].y-1))){
                console.log(stars[p].name);
                inStar = true;
            }

        }
        if(!inStar){
            console.log('space');
        }
        ship.y+=1;

    }

    //console.log(stars)
    //console.log(ship)
}

solve([
    'Sirius 3 7',
    'Alpha-Centauri 7 5',
    'Gamma-Cygni 10 10',
    '8 1',
    '6'

]);
console.log();
solve([
    'Terra-Nova 16 2',
    'Perseus 2.6 4.8',
    'Virgo 1.6 7',
    '2 5',
    '4'

]);