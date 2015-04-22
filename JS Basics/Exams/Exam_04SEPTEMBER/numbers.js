function solve(input) {
    var arr = input[0].split(/\D+/g);
    var numbers = [];
    for (var i in arr) {
        if(arr[i]!=undefined&&arr[i]!='')
        numbers.push('0x'+(Number(arr[i])+0x10000).toString(16).substr(-4).toUpperCase());
    }
    console.log(numbers.join('-'));
}

solve(['5tffwj(//*7837xzc2---34rlxXP%$”.']);

solve(['482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312']);

solve(['20']);