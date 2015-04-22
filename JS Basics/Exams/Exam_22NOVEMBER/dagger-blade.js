function solve(input){
    var head = [
        '<table border="1">',
        '<thead>',
        '<tr><th colspan="3">Blades</th></tr>',
        '<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>',
        '</thead>',
        '<tbody>'];

    for (var obj in head) {
     console.log(head[obj]);
    }


    for (var obj1 in input) {
        var length = parseInt(input[obj1]);
        //console.log(length);
        if(length<=10){
            continue;
        }
        if(length>40){
            var type = 'sword';
        }
        else{
            var type = 'dagger';
        }

        var blade = length%5;
        var classType;
        switch (blade){
            case 0:classType = '*rap-poker'; break;
            case 1:classType='blade';  break;
            case 2:classType = 'quite a blade'; break;
            case 3:classType = 'pants-scraper'; break;
            case 4:classType = 'frog-butcher'; break;

        }

        console.log('<tr><td>'+length+'</td><td>'+type+'</td><td>'+classType+'</td></tr>');
    }

    console.log('</tbody>');
    console.log('</table>');

}

solve([
    '17.8',
    '19.4',
    '13',
    '55.8',
    '126.96541651',
    '3'

])



