var str = 'HelloWorld';
function letterSort(str, sortOrder) {
    var arr = str.split('');
    if(sortOrder===true){
        arr.sort(function(a, b)
        {
            var x = a.toLowerCase(), y = b.toLowerCase();

            return x < y ? -1 : x > y ? 1 : 0;
        })
    }else{
        arr.sort(function(a, b)
        {
            var x = b.toLowerCase(), y = a.toLowerCase();

            return x < y ? -1 : x > y ? 1 : 0;
        })
    }
    console.log(arr.join(''));
}
letterSort(str,true);
letterSort(str,false);