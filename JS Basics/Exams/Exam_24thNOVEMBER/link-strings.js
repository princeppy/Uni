function solve(input){

    for (var i in input) {
        var result = {};
        var arrLine = input[i].split(/&|\?/g);

        for (var index in arrLine) {
            if(arrLine[index].indexOf('=')>0){
                var arr = arrLine[index].split('=');
                arr[0] = arr[0].replace(/\+|%20|\s+/g,' ').replace(/\s+/g,' ').trim();
                arr[1] = arr[1].replace(/\+|%20|\s+/g,' ').replace(/\s+/g,' ').trim();
                if(!result[arr[0]]){
                    result[arr[0]]=[]
                }
                if(result[arr[0]].indexOf(arr[1])<0){
                    result[arr[0]].push(arr[1]);
                }

            }
        }
        console.log(JSON.stringify(result).replace(/{|}/g,'').replace(/"/g,'').replace(/:\[/g,'=[').replace(/],/g,']').replace(/,/g,', ').replace(/\s+/g,' '));
    }

}


solve([
'foo=%20foo&value=+val&foo+=5+%20+203',
'foo=poo%20&value=valley&dog=wow+',
'url=https://softuni.bg/trainings/coursesinstances/details/1070',
'https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php'
    ])