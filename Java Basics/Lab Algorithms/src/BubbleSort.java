import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

//import org.apache.commons.lang.time.StopWatch;

public class BubbleSort {

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

        //TODO: Write the sorting algorithm that you use for sorting the List's elements

        int tempNum = 0;
        boolean swap = true;
        int temp = numbersArr.size();
        int num = 0;
        do {


            for (int i = 0; i < temp - 1; i++) {
                if (numbersArr.get(i) > numbersArr.get(i + 1)) {
                    Collections.swap(numbersArr, i, i + 1);
                    num = i+1;
                    swap = true;

                }
                if (swap==false){
                    num =0;
                }
            }
            temp=num;
            swap = false;
        }while (temp!=0);

//        stopWatch.stop();
//        long time = stopWatch.getTime();

            System.out.println(numbersArr);
//        System.out.println(time/1000.0);
        }


    }

