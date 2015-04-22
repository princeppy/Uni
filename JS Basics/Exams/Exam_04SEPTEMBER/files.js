function solve(input){
    var result = {};
    for (var obj in input) {
        var arr = input[obj].split(/\s+/g);

        if(!result[arr[1]]){
            result[arr[1]] = {files:[],memory:0};
        }

        result[arr[1]].files.push(arr[0]);
        result[arr[1]].files.sort(function(a,b){
            return a.localeCompare(b);
        })

        result[arr[1]].memory+=Number(arr[2].substr(0,(arr[2].length-2)));
    }
    for (var obj1 in result) {
        result[obj1].memory = result[obj1].memory.toFixed(2);
    }
    result = sortObj(result);


    console.log(JSON.stringify(result));

    //----------------------------------------------------------
    function sortObj(arr) {
        // Setup Arrays
        var sortedKeys = new Array();
        var sortedObj = {};

        // Separate keys and sort them
        for (var i in arr) {
            sortedKeys.push(i);
        }
        sortedKeys.sort();

        // Reconstruct sorted obj based on keys
        for (var i in sortedKeys) {
            sortedObj[sortedKeys[i]] = arr[sortedKeys[i]];
        }
        return sortedObj;
    }
}

solve([
    'sentinel .exe 15MB',
    'zoomIt .msi 3MB',
    'skype .exe 45MB',
    'trojanStopper .bat 23MB',
    'kindleInstaller .exe 120MB',
    'setup .msi 33.4MB',
    'winBlock .bat 1MB'
])