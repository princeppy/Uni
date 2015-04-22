function addCompSkill(){

    var counter = getCounter("container-skills")["counter"];
    var parent = getCounter("container-skills")["parent"];


    var inputSkills = document.getElementById("counterSkills");
    inputSkills.value = counter;



    var container = document.createElement("div");
    container.id= "skill-"+counter;

    var input = document.createElement("input");
    input.id="prog-lang-" + counter;
    input.name = "prog-lang-" + counter;
    input.type = "text";

    var select = document.createElement("select");
    select.name = "level-" + counter;
    select.id = "level-" + counter;

    var optionOne = document.createElement("option");
    optionOne.value = "beginner";
    optionOne.innerText = "Beginner";

    var optionTwo = document.createElement("option");
    optionTwo.value = "intermediate";
    optionTwo.innerText = "Intermediate";

    var optionThree = document.createElement("option");
    optionThree.value = "advanced";
    optionThree.innerText = "Advanced";

    select.appendChild(optionOne);
    select.appendChild(optionTwo);
    select.appendChild(optionThree);


    container.appendChild(input);
    container.appendChild(select);


    parent.appendChild(container);

}

function removeCompSkill(){

    var parent = document.getElementById("container-skills");

    var temp = parent.lastElementChild;

    var arr = temp.id.split("-");

    var counter = Number(arr[arr.length-1]);

    var divToRemove = document.getElementById("skill-"+counter);

    if(counter>1){
        parent.removeChild(divToRemove);
    }
}


function addLanguage(){


    var counter = getCounter("container-language")["counter"];
    var parent = getCounter("container-language")["parent"];

    var inputLanguages = document.getElementById("counterLanguages");
    inputLanguages.value = counter;

    var container = document.createElement("div");
    container.id= "language-"+counter;

    var input = document.createElement("input");
    input.id="lang-" + counter;
    input.name = "lang-" + counter;
    input.type = "text";


    container.appendChild(input);

    var select = createSelect(counter, "-Comprehension-","lang-level-");
    container.appendChild(select);

    select = createSelect(counter, "-Reading-","reading-");
    container.appendChild(select);

    select = createSelect(counter, "-Writing-","writing-");
    container.appendChild(select);

    parent.appendChild(container);
}


function createSelect(counter, text, name){
    var select = document.createElement("select");
    select.name = name + counter;
    select.id = name + counter;

    var optionOne = document.createElement("option");
    optionOne.selected = "selected";
    optionOne.disabled = "disabled";
    optionOne.innerText = text;

    var optionTwo = document.createElement("option");
    optionTwo.value = "beginner";
    optionTwo.innerText = "Beginner";

    var optionThree = document.createElement("option");
    optionThree.value = "intermediate";
    optionThree.innerText = "Intermediate";

    var optionFour = document.createElement("option");
    optionFour.value = "advanced";
    optionFour.innerText = "Advanced";

    select.appendChild(optionOne);
    select.appendChild(optionTwo);
    select.appendChild(optionThree);
    select.appendChild(optionFour);

    return select;
}

function removeLanguage(){
    var parent = document.getElementById("container-language");

    var temp = parent.lastElementChild;

    var arr = temp.id.split("-");

    var counter = Number(arr[arr.length-1]);

    var divToRemove = document.getElementById("language-"+counter);

    if(counter>1){
        parent.removeChild(divToRemove);
    }
}


function getCounter(text){

    var parent = document.getElementById(text);

    var temp = parent.lastElementChild;

    var arr = temp.id.split("-");

    var counter = Number(arr[arr.length-1])+1;


    return {"counter":counter,"parent":parent};
}