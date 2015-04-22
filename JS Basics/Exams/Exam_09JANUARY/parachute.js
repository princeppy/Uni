function solve(args) {

    var line;
    var index;
    var row=0;

    for (var p in args) {
        row+=1;
      if(args[p].indexOf('o')>=0){
          line=args[p];
          index = args[p].indexOf('o');
          break;
      }
    }
    for (var i = row; i < args.length; i++) {
        var line = args[i];
        var regexRight = new RegExp('>', 'g');

        if (regexRight.test(line)) {
            var countRight = line.match(regexRight).length;
        }
        else {
            countRight = 0;
        }

        var regexLeft = new RegExp('<', 'g');

        if (regexLeft.test(line)) {
            var countLeft = line.match(regexLeft).length;
        }
        else {
            countLeft = 0;
        }

        var changePosition = countRight-countLeft;
        var index1 = changePosition+index;
        var substring = line.substring(index,index1);
        index = index1;

        if(line[index1]==='/'||line[index1]==='\\'||line[index1]==='|'){
            console.log('Got smacked on the rock like a dog!');
            console.log(row+' '+index1);
            break;
        }
        if(line[index1]==='_'){
            console.log('Landed on the ground like a boss!');
            console.log(row+' '+index1);
            break;
        }
        if(line[index1]==='~'){
            console.log('Drowned in the water like a cat!');
            console.log(row+' '+index1);
            break;
        }
        row++;
    }
//console.log(args);
}

//solve([
//    "--o----------------------",
//    ">------------------------",
//    ">------------------------",
//    ">-----------------/|-----",
//    "-----------------/--|----",
//    ">---------/|----/----|---",
//    "---------/--|--/------|--",
//    "<-------/----|/--------|-",
//    "|------/----------------|",
//    "-|____/------------------"
//
//])

//solve([
//    '-------------o-<<--------',
//    '-------->>>>>------------',
//    '---------------->-<---<--',
//    '------<<<<<-------/|--<--',
//    '--------------<--/-<|----',
//    '>>--------/|----/<-<-|---',
//    '---------/<-|--/------|--',
//    '<-------/----|/--------|-',
//    '|------/--------------<-|',
//    '-|___~/------<-----------'
//]);
