var people = [
    {firstname: 'George', lastname: 'Kolev', age: 32, hasSmartphone: false},
    {firstname: 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true},
    {firstname: 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true},
    {firstname: 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false}]


function findPerson(people) {
    var arrWithPhone = people.filter(function (a) {
        return a['hasSmartphone'] === true;
    })
    arrWithPhone.sort(function (a, b) {
        return a.age - b.age;
    })
    console.log("The youngest person with smartphone is " + arrWithPhone[0]['firstname'] + ' ' + arrWithPhone[0]['lastname']);
}

findPerson(people);