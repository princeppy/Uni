var mounts = [
    'Alaska Range',
    'Alborz',
    'Andes',
    'Andes',
    'Andes',
    'Andes',
    'Andes',
    'Andes',
    'Andes',
    'Balkan Mountains',
    'Balkan Mountains',
    'Balkan Mountains',
    'Caucasus',
    'Caucasus',
    'Caucasus',
    'Cordillera Neovolcanica',
    'Ellsworth Mountains',
    'Executive Committee Range',
    'Himalayas',
    'Himalayas',
    'Himalayas',
    'Himalayas',
    'Himalayas',
    'Jayawijaya Mountains',
    'Karakoram',
    'Kenyan Highlands',
    'Kilimanjaro',
    'Kilimanjaro Region',
    'Maoke Mountains',
    'Pirin',
    'Pirin',
    'Pirin',
    'Pirin',
    'Pirin',
    'Pirin',
    'Rila',
    'Rila',
    'Rila',
    'Rila',
    'Saint Elias Mountains',
    'Sentinel Range',
    'Sentinel Range',
    'Southern Highlands',
    'The Sudirman Range',
    'Trans-Mexican Volcanic Belt',
    'Rhodope Mountains',
    'Rhodope Mountains',
    'Rhodope Mountains',
    'Rhodope Mountains',
    'Vitosha',
    'Strandza',
    'Monte Rosa'
]

var peaks = [
    'Mount McKinley',
    'Damavand',
    'Aconcagua',
    'Monte Pissis',
    'Ojos del Salado',
    'Cerro Bonete',
    'Galán',
    'Mercedario',
    'Pissis',
    'Botev',
    'Vezhen',
    'Kom',
    'Shkhara',
    'Dykh-Tau',
    'Elbrus',
    'NULL',
    'Vinson Massif',
    'Mount Sidley',
    'Everest',
    'Kangchenjunga',
    'Lhotse',
    'Makalu',
    'Cho Oyu',
    'Julianatop',
    'K2',
    'Mount Kenya',
    'Kilimanjaro',
    'Mawenzi',
    'Puncak Trikora',
    'Vihren',
    'Kutelo',
    'Banski Suhodol',
    'Golyam Polezhan',
    'Kamenitsa',
    'Malak Polezhan',
    'Malka Musala',
    'Orlovets',
    'Musala',
    'Malyovitsa',
    'Mount Logan',
    'Mount Tyree',
    'Mount Shinn',
    'Mount Giluwe',
    'Carstensz Pyramid',
    'Pico de Orizaba',
    'Golyam Perelik',
    'Shirokolashki Snezhnik',
    'Golyam Persenk',
    'Batashki Snezhnik',
    'NULL',
    'NULL',
    'NULL'
]

var elevations = [
    6194,
    5610,
    6962,
    6793,
    6893,
    6759,
    5912,
    6720,
    6795,
    2376,
    2198,
    2016,
    5193,
    5205,
    5642,
    0,
    4897,
    4285,
    8848,
    8586,
    8516,
    8462,
    8201,
    4760,
    8611,
    5199,
    5895,
    5149,
    4750,
    2914,
    2908,
    2884,
    2851,
    2822,
    2822,
    2902,
    2685,
    2925,
    2729,
    5959,
    4852,
    4661,
    4368,
    4884,
    5636,
    2191,
    2188,
    2091,
    2082,
    0,
    0,
    0,
]

function processArray(mount, peaks,elevations){
    var json = [];
    for(var i = 0;i<mount.length;i++){
        if(json[mount[i]]){
            if(peaks[i]!='NULL')
            json[mount[i]].push({"name":peaks[i],"elevation":elevations[i]})
            //else
                //json[mount[i]].push({"name":'',"elevation":0})

        }else{
            json[mount[i]]=[];
            if(peaks[i]!='NULL')
            json[mount[i]].push({"name": peaks[i],"elevation":elevations[i]})
            //else
                //json[mount[i]].push({"name":'',"elevation":0})
        }
    }
var final = {mountains:[]};
    for (var obj in json) {
        var tempObj = {name:obj,peaks:json[obj]}
        //tempObj.name = obj;
        ////for (var obj1 in json[obj]) {
        ////    tempObj.peaks.push(json[obj].join(', '))
        ////}
        ////for (var obj1 in json[obj]) {
        //tempObj.peaks.push(json[obj])
        //}
        final.mountains.push(tempObj)
    }

    console.log(JSON.stringify(final));
    
    
    

}

processArray(mounts,peaks,elevations);