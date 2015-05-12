function basiRukiteChuek(banici){

    var start = parseInt(banici[0]);
    var end = parseInt(banici[1]);
    //console.log(start);
    //console.log(end);
    console.log('<ul>');

    for (var number = start; number <= end; number++) {
        var thereIsRakiyaBaby = false;
        var text = number.toString();
        for (var i = 0; i < text.length-2; i+=1) {

            for (var j = i+2; j < text.length; j++) {

                //console.log((text[i]+text[i+1]));
                if((text[i]+text[i+1])==(text[j]+text[j+1])){
                    thereIsRakiyaBaby = true;
                    break;
                }
            }
        }
        if(thereIsRakiyaBaby){
            console.log("<li><span class='rakiya'>"+number+"</span>"+'<a href="view.php?id='+number+'>View</a></li>');

        }
        else{
            console.log("<li><span class='num'>"+number+"</span></li>");

        }
    }

    console.log('</ul>');




}

basiRukiteChuek([
    '55555',
    '55560'

]);

basiRukiteChuek([
    '11210',
    '11215'

]);

