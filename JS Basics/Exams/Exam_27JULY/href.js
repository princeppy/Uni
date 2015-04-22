function solve(input){
    var regex = new RegExp("\<a[^>]*(?=href\\s*=\\s*)(href\\s*=\\s*)((([\"]{1})([^\"]*))|(([']{1})([^']*))|([^\\s>]+))",'gm');
        var str = input.join(' ');

    var regexA = new RegExp("\<a[^>]+","g") ;

    var matches = str.match(regexA);

    var match;

    for (var obj in matches) {
        while(match = regex.exec(matches[obj])){
            if(match[5]!=undefined){
                console.log(match[5]);
            }
            if(match[9]!=undefined){
                console.log(match[9]);
            }
            if(match[8]!=undefined){
                console.log(match[8]);
            }
            //if(match[7]!=undefined){
            //    console.log(match[7]);
            //}
        }
    }
}


//solve(['<a href="http://softuni.bg" class="new"></a>']);
//solve(['<p>This text has no links</p>']);
solve(['<!DOCTYPE html>','<html>','<head>','<title>Hyperlinks</title>','<link href="theme.css" rel="stylesheet" />','</head>','<body>','<ul><li><a   href="/"  id="home">Home</a></li><li><a','class="selected" href=/courses>Courses</a>','</li><li><a href = ','\'/forum\' >Forum</a></li><li><a class="href"','onclick="go()" href= "#">Forum</a></li>','<li><a id="js" href =','"javascript:alert(\'hi yo\')" class="new">click</a></li>','<li><a id=\'nakov\' href =','http://www.nakov.com class=\'new\'>nak</a></li></ul>','<a href="#empty"></a>','<a id="href">href=\'fake\'<img src=\'http://abv.bg/i.gif\' ','alt=\'abv\'/></a><a href="#">&lt;a href=\'hello\'&gt;</a>','<!-- This code is commented:','<a href="#commented">commentex hyperlink</a> -->','</body>']);