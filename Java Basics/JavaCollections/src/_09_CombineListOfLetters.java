import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;


public class _09_CombineListOfLetters {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        System.out.println("Enter the number of lists to be checked");
        int numberOfWords = Integer.parseInt(scan.nextLine());
        System.out.println("Enter the lists. Each on new line");
        String[] arrayOne = scan.nextLine().split(" ");

        ArrayList<String> list = new ArrayList<String>();
        for (int i = 0; i < arrayOne.length; i++) {
            list.add(arrayOne[i]);
        }

        for (int i = 0; i < numberOfWords-1; i++) {
            ArrayList<String> copy = (ArrayList<String>) list.clone();
            String[] arrayTwo = scan.nextLine().split(" ");
            for (int j = 0; j < arrayTwo.length; j++) {
                if (!copy.contains(arrayTwo[j])) {
                    list.add(arrayTwo[j]);
                }
            }
        }
        System.out.println("The combine list is:");
        printArray(list);
    }

    static void printArray(ArrayList<String> array) {
        for (int i = 0; i < array.size(); i++) {
            if (i != array.size() - 1) {
                System.out.printf("%s ", array.get(i));
            } else {
                System.out.printf("%s", array.get(i));
            }

        }
    }
}
