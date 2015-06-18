function maaaMu(input) {
    var pattern = /([A-Za-z\s]+)\s*-\s*(.+)?(?=:)\s*:\s*(.+)/;
    var resultArray = {};
    for (var obj in input) {
        var match = pattern.exec(input[obj]);
        //console.log(match);
        var name = match[1].trim();
        var exam = match[2].trim();
        var result = Number(match[3]);
        if (result >= 0 && result <= 400) {

            var examExist = false;

            for (var j in resultArray) {
                if (j == exam) {
                    var nameExist=false;
                    for (var obj1 in resultArray[j]) {
                        //console.log(resultArray[j][obj1]);
                        //console.log(resultArray[j][obj1].name);

                        if(resultArray[j][obj1].name==name){

                            if(result>resultArray[j][obj1].result){
                                resultArray[j][obj1].result=result;

                            }

                            resultArray[j][obj1].makeUpExams++;
                            nameExist = true;
                            break;
                        }



                    }
                    if(!nameExist){
                        resultArray[j].push({'name': name, 'result': result, 'makeUpExams': 0})
                    }

                    examExist=true;
                }

            }
            if (!examExist) {
                var d = {'name': name, 'result': result, 'makeUpExams': 0};
                //resultArray[exam] = exam;

                resultArray[exam] = [{'name': name, 'result': result, 'makeUpExams': 0}];

            }
        }

    }

    for (var obj2 in resultArray) {
        resultArray[obj2].sort(function(a,b){
            if(a.result=== b.result){
                if(a.makeUpExams=== b.makeUpExams){
                    return a.name.localeCompare(b.name);
                }
                return a.makeUpExams - b.makeUpExams;
            }
            return b.result - a.result;

        })
    }
    console.log(JSON.stringify(resultArray));
}



maaaMu([


    'Peter Jackson - JavaScript : 351',
    'Jane - JavaScript : 200',
    'Jane     -    JavaScript :     400',

])
//
//maaaMu([
//'Simon Cowell - PHP : 100',
//'Simon Cowell-PHP: 500',
//'Peter Jackson - PHP: 350',
//'Simon Cowell - PHP : 400'
//])