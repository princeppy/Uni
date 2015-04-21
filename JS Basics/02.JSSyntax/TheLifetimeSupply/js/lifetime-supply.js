function calcLifetimeSupply(age, maxAge,favFood,favFoodPerDay) {
    var ageLeft = maxAge-age;
    var daysLeft = ageLeft*365;
    var foodLifetime =  daysLeft*favFoodPerDay;

    document.getElementById('lifetime-supply').innerHTML = Math.round(foodLifetime) +'kg of ' + favFood +' would be enough until I am ' + maxAge + 'years old';
}