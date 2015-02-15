import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class InsertionSortRecursion {
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
        ArrayList<Integer> sortedList = new ArrayList<Integer>();
int index = 0;

        insertionSort(sortedList, numbersArr, index);


//        stopWatch.stop();
//        long time = stopWatch.getTime();

        System.out.println(sortedList);
//        System.out.println(time/1000.0);
    }

    static void insertionSort(ArrayList<Integer> sortedList, ArrayList<Integer> list, int index) {
        if (index >= list.size()) {
            return;
        }
        sortedList.add(list.get(index));
        int indexSwap = sortedList.size() - 1;
        for (int i = sortedList.size() - 2; i >= 0; i--) {
            if (list.get(index) < sortedList.get(i)) {
                Collections.swap(sortedList, indexSwap, i);
                indexSwap = i;
            } else {
                break;
            }
        }
        insertionSort(sortedList, list, index + 1);
    }
}
