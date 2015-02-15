import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class SelectionSort {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] numbers = scan.nextLine().replace("[", "").replace("]", "").split(", ");
        ArrayList<Integer> numbersArr = new ArrayList<Integer>();

        //DONE: Parse the numbers and add them to the list
        for (int i = 0; i < numbers.length; i++) {
            numbersArr.add(Integer.parseInt(numbers[i]));
        }


//        StopWatch stopWatch = new StopWatch();
//        stopWatch.start();
        ArrayList<Integer> newList = new ArrayList<Integer>();
        //TODO: Write the sorting algorithm that you use for sorting the List's elements
        for (int i = 0; i < numbersArr.size()-1; i++) {
            int minIndex = i;

            for (int j = i+1; j < numbersArr.size(); j++) {

                if (numbersArr.get(j)<numbersArr.get(minIndex)){
                    minIndex=j;
                }
            }

            if (minIndex!=i){
                Collections.swap(numbersArr,minIndex,i);
            }

        }


//        stopWatch.stop();
//        long time = stopWatch.getTime();

        System.out.println(numbersArr);
//        System.out.println(time/1000.0);
    }
}
