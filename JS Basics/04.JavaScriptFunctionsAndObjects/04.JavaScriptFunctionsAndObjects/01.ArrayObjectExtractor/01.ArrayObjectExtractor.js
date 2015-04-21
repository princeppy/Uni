var arr = [
    "Pesho",
    4,
    4.21,
    {name: 'Valyo', age: 16},
    {
        type: 'fish', model: 'zlatna ribka'
    },
    [1, 2, 3],
    "Gosho",
    {name: 'Penka', height: 1.65}
]

function extractObjects(arr) {
    arr.forEach(function (el) {
        if (el.toString() === '[object Object]') {
            console.log(el);
        }
    })
}
extractObjects(arr);