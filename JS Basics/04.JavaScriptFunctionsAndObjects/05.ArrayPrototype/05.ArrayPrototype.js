var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
var arr1 = ['hi', 'bye', 'hello' ];


Array.prototype.removeItem = function(x){
    var arrModified = this.filter(function(a){
        if(!(a===x)){
            return a;
        }
    })
    return arrModified;
}

console.log(arr.removeItem(1).join(', '));
console.log(arr1.removeItem('bye').join(', '));