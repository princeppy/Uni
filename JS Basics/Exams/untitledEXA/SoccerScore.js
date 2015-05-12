function machkaiLavinaaa(input) {


    var pattern = /(.+)(?=\/)\/(.+)(?=:):(.+)/;
    var teams = [];
    for (var i in input) {
        var match = pattern.exec(input[i]);
        var team1 = match[1].trim();
        var team2 = match[2].trim();
        var result = match[3].trim();
        result = result.split(/\s*-\s*/);
        var team1Scored =  parseInt(result[0]);
        var team1Conceded = parseInt(result[1]);
        var team2Scored =  parseInt(result[1]);
        var team2Conceded =  parseInt(result[0]);

        var team1Exist = false;
        var team2Exist = false;

        for (var j in teams) {
            if(teams[j].name == team1){
                teams[j].goalsScored +=team1Scored;
                teams[j].goalsConceded +=team1Conceded;
                if(teams[j].matchesPlayedWith.indexOf(team2)<0){
                    teams[j].matchesPlayedWith.push(team2);
                }
                team1Exist = true;
            }
            if(teams[j].name == team2){
                teams[j].goalsScored +=team2Scored;
                teams[j].goalsConceded +=team2Conceded;
                if(teams[j].matchesPlayedWith.indexOf(team1)<0){
                    teams[j].matchesPlayedWith.push(team1);
                }
                team2Exist = true;
            }

            teams[j].matchesPlayedWith.sort(function(a,b){
                return a.localeCompare(b);
            })
        }

        if(!team1Exist){
            var team = {'name':team1,'goalsScored':team1Scored,'goalsConceded':team1Conceded,'matchesPlayedWith':[team2]}
            teams.push(team);

        }
        if(!team2Exist){
            var team = {'name':team2,'goalsScored':team2Scored,'goalsConceded':team2Conceded,'matchesPlayedWith':[team1]}
            teams.push(team);
        }


    }


    teams.sort(function(a,b){
        return a.name.localeCompare(b.name);
    })

    var finalTeams = {};
    for (var obj in teams) {
        finalTeams[teams[obj].name] = {'goalsScored':teams[obj].goalsScored,'goalsConceded':teams[obj].goalsConceded,'matchesPlayedWith':teams[obj].matchesPlayedWith}

    }
    console.log(JSON.stringify(finalTeams));



}

machkaiLavinaaa([
'Germany / Argentina: 1-0',
'Brazil / Netherlands: 0-3',
'Netherlands / Argentina: 0-0',
'Brazil / Germany: 1-7',
'Argentina / Belgium: 1-0',
'Netherlands / Costa Rica: 0-0',
'France / Germany: 0-1',
'Brazil / Colombia: 2-1'

])