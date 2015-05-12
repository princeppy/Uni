function mnoooGigiBaiti(input) {

    var result = [];
    for (var obj in input) {

        var arr = input[obj].split(/\s+/);
        var name = arr[0].trim();
        var extension = arr[1].trim();
        var size = arr[2].trim();
        size = parseFloat(size);


        var extensionExist = false;

        for (var j in result) {

            if (result[j].extension === extension) {

                result[j].memory += size;
                if (result[j].files.indexOf(name) < 0) {
                    result[j].files.push(name);
                }
                extensionExist = true;
            }
            result[j].files.sort(function (a, b) {
                return a.localeCompare(b);
            });
        }
        if (!extensionExist) {
            result.push({'extension': extension, 'files': [name], 'memory': size});
        }
    }
    result.sort(function (a, b) {
        return a.extension.localeCompare(b.extension);
    })
    var finalResult = {};
    for (var obj1 in result) {
        finalResult[result[obj1].extension] = {'files': result[obj1].files, 'memory': result[obj1].memory.toFixed(2)}
    }
    console.log(JSON.stringify(finalResult));


}
mnoooGigiBaiti([
    'sentinel .exe 15MB',
    'zoomIt .msi 3MB',
    'skype .exe 45MB',
    'trojanStopper .bat 23MB',
    'kindleInstaller .exe 120MB',
    'setup .msi 33.4MB',
    'winBlock .bat 1MB'

])