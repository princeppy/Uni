function solve(input) {
    var final = [];
    var people = [];


    for (var obj2 in input) {
        var arrLine = input[obj2].split(/\s*vs.|:\s*/g);
        var name1 = arrLine[0].replace(/\s+/, ' ').trim();
        var name2 = arrLine[1].replace(/\s+/, ' ').trim();

        if(people.indexOf(name1)<0){
            people.push(name1);
        }
        if(people.indexOf(name2)<0){
           people.push(name2)
        }
    }

    for (var obj5 in people) {
        people[obj5] = {name:people[obj5],matchesWon: 0, matchesLost: 0, setsWon: 0, setsLost: 0, gamesWon: 0, gamesLost: 0};
    }

    for (var obj in input) {
        arrLine = input[obj].split(/\s*vs.\s*|\s*:\s*/g);

        var player1 = {name: '', matchesWon: 0, matchesLost: 0, setsWon: 0, setsLost: 0, gamesWon: 0, gamesLost: 0};
        var player2 = {name: '', matchesWon: 0, matchesLost: 0, setsWon: 0, setsLost: 0, gamesWon: 0, gamesLost: 0};
        player1['name'] = arrLine[0].replace(/\s+/, ' ').trim();
        player2['name'] = arrLine[1].replace(/\s+/, ' ').trim();


        var results = arrLine[2];

        var arrResults = arrLine[2].split(/\s+/g);

        for (var obj1 in arrResults) {
            arrResults[obj1] = arrResults[obj1].trim();
            if (Number(arrResults[obj1][0]) > Number(arrResults[obj1][2])) {

                player1['setsWon']++;
                player2['setsLost']++;


            }
            else {

                player2['setsWon']++;
                player1['setsLost']++;

            }

            player1['gamesWon'] += Number(arrResults[obj1][0]);
            player2['gamesLost'] += Number(arrResults[obj1][0]);
            player1['gamesLost'] += Number(arrResults[obj1][2]);
            player2['gamesWon'] += Number(arrResults[obj1][2]);


        }
        if (player1['setsWon'] > player2['setsWon']) {
            player1['matchesWon']++;
            player2['matchesLost']++;
        }
        else {
            player1['matchesLost']++;
            player2['matchesWon']++;

        }


        final.push(player1);
        final.push(player2);
    }

    for (var obj3 in people) {
        for (var obj4 in final) {
            if(people[obj3]['name']==final[obj4]['name']){
                people[obj3]['gamesWon'] += final[obj4]['gamesWon'];
                people[obj3]['gamesLost'] += final[obj4]['gamesLost'];
                people[obj3]['setsWon'] += final[obj4]['setsWon'];
                people[obj3]['setsLost'] += final[obj4]['setsLost'];
                people[obj3]['matchesWon'] += final[obj4]['matchesWon'];
                people[obj3]['matchesLost'] += final[obj4]['matchesLost'];

            }
        }
    }

    people.sort(function(firstPlayer,secondPlayer){
        if (secondPlayer.matchesWon !== firstPlayer.matchesWon) {
            return secondPlayer.matchesWon - firstPlayer.matchesWon;
        }

        if (secondPlayer.setsWon !== firstPlayer.setsWon) {
            return secondPlayer.setsWon - firstPlayer.setsWon;
        }

        if (secondPlayer.gamesWon !== firstPlayer.gamesWon) {
            return secondPlayer.gamesWon - firstPlayer.gamesWon;
        }

        return firstPlayer.name.localeCompare(secondPlayer.name);





    })
console.log(JSON.stringify(people))



}

solve(
    ['   Novak Djokovic vs. Roger Federer : 6-3     6-3',
        'Roger    Federer    vs.        Novak Djokovic    :         6-2 6-3',
        'Rafael Nadal vs.      \tAndy Murray : 4-6 6-2 5-7',
        '   Andy Murray vs. David Ferrer : 6-4 7-6',
        'Tomas Bedrych vs. Kei Nishikori : 4-6 6-4 6-3 4-6 5-7',
        'Grigor Dimitrov vs. Milos Raonic : 6-3 4-6 7-6 6-2',
        'Boris Becker vs. Andre Agassi : 2-1',
        'Boris Beckervs.Andre        \t\t\tAgassi:1-2']
)