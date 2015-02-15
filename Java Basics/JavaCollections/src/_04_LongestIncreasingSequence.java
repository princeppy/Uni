import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class _04_LongestIncreasingSequence {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] str = scan.nextLine().split("\\s");

        Integer[] arrInt = new Integer[str.length];

        for (int i = 0; i < arrInt.length; i++) {
            arrInt[i] = Integer.parseInt(str[i]);
        }

        int counter = 0;
        int tempCounter = 0;
        int maxCounter = 0;
        int index = -1;
        int indexMax = 0;
        ArrayList<ArrayList<Integer>> list = new ArrayList<ArrayList<Integer>>();
        for (int i = 0; i < arrInt.length; i++) {
            tempCounter = 1;
            ArrayList<Integer> tempArr = new ArrayList<Integer>();
            tempArr.add(arrInt[i]);
            for (int j = i + 1; j < arrInt.length; j++) {
                if (arrInt[i] < arrInt[j]) {
                    tempArr.add(arrInt[j]);
                    tempCounter++;
                    i = j;
                } else {
                    break;
                }
            }

            if (tempArr.size() > 1) {
                list.add(tempArr);
                counter = tempCounter;
                index++;
            }

            if (counter > maxCounter) {
                maxCounter = counter;
                indexMax = index;
            }
        }

        if (list.size() > 0) {
            printSequence(list);
            System.out.println("The longest increasing sequence is: " + maxCounter + list.get(indexMax));
        }
    }

    static void printSequence(ArrayList<ArrayList<Integer>> list) {

        for (int i = 0; i < list.size(); i++) {
            for (int j = 0; j < list.get(i).size(); j++) {
                System.out.printf("%s ", list.get(i).get(j));
            }
            System.out.println();
        }
    }
}
