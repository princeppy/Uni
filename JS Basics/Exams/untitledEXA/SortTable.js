function baaasiChuek(input){
    var pattern = /<tr><td>(.+?(?=<\/td))<\/td><td>(.+?(?=<\/td))<\/td><td>(.+?(?=<\/td))/;

var result = [];
    for (var i = 2; i < input.length-1; i++) {
        var match = pattern.exec(input[i]);

        var name = match[1];
        var price = parseFloat(match[2]);
        var priceUnformatted = match[2];
        var rating = match[3];

        var line = {'name':name,'price':price,'priceToShow':priceUnformatted,'rating':rating};
        result.push(line);



    }


    result.sort(function(a,b){
        if(a.price=== b.price){
            return a.name.localeCompare(b.name);
        }
        return a.price- b.price;
    });
    console.log('<table>');
    console.log('<tr><th>Product</th><th>Price</th><th>Votes</th></tr>');

    for (var obj in result) {
        console.log('<tr><td>'+result[obj].name+'</td><td>'+result[obj].priceToShow+'</td><td>'+result[obj].rating+'</td></tr>');
    }
    console.log('</table>');
}

baaasiChuek([
'<table>',
'<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
'<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
'<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
'<tr><td>Laptop Lenovo IdeaPad B5400</td><td>929.00</td><td>0</td></tr>',
'<tr><td>Laptop ASUS ROG G550JK-CN268D</td><td>1939.00</td><td>+1</td></tr>',
'<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
'<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>',
'</table>'

]);