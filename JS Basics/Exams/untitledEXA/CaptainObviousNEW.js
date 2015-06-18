function eeeeebaaaaasiKapitana(input) {
    var sentences = input[0].split(/[.!?]/);
    var pattern = /[^A-Za-z]+/;
    var wordsCount = [];
    for (var i in sentences) {
        var words = sentences[i].split(/\W+/);
        words = words.filter(function (a) {
            return a != '';
        });
        for (var j in words) {
            var match = words[j].match(pattern);
            if (!match) {
                var word = words[j].toLowerCase();
                if (wordsCount[word] == undefined) {
                    wordsCount[word] = 1;
                }
                else {
                    wordsCount[word]++;
                }
            }
        }
    }
    var wordsCountBigger3 = [];

    var c = 0;
    for (var obj in wordsCount) {
        if (wordsCount[obj] >= 3) {
            wordsCountBigger3[obj] = wordsCount[obj];
            c++;

        }
    }
    var wordsRepeat = [];

    for (var obj5 in wordsCount) {
        if (wordsCount[obj5] > 1) {
            wordsRepeat[obj5] = wordsCount[obj5];

        }
    }
    //console.log(wordsCountBigger3);
    if (c == 0) {
        console.log('No words');
    }
    else {


        var sentences2 = input[1].split(/[!?.]/);
        var match = input[1].match(/[!?.]/g);


        //console.log(match);
        var countSentence = 0;
        for (var i = 0; i < sentences2.length; i++) {
            var counter = 0;
            var sentenceFound = false;
            var wordsToSearch = sentences2[i].split(/\W+/);
            wordsToSearch = wordsToSearch.filter(function (a) {
                return a != '';
            })

            for (var obj1 in wordsToSearch) {
                for (var obj2 in wordsCountBigger3) {
                    //console.log(wordsToSearch[obj1]);
                    //console.log(obj2);
                    if (wordsToSearch[obj1].toLowerCase() == obj2) {


                        counter++;


                    }
                    if(counter>=2){
                        console.log(sentences2[i].trim() + match[i]);
                        sentenceFound = true;
                        countSentence++;
                        break;
                    }
                }
                if (sentenceFound) {
                    break;
                }
            }
        }
    }
    if (countSentence == 0) {
        console.log('No sentences');
    }
}

eeeeebaaaaasiKapitana([
    'Captain Obvious was walking down the street. As the captain was walking a person came and told him: You are Captain Obvious! He replied: Thank you CAPTAIN OBVIOUS you are the man!',
    'The captain was walking and he was obvious. He did not know what was going to happen to you in the future. Was he curious? We do not know.'
])

eeeeebaaaaasiKapitana(['Why, why is he so crazy, so so crazy? Why?',
    'There are no words that you should be matching. You should be careful.'
])