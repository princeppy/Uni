import java.util.Scanner;


public class _03_LargestSequenceOfEqualStrings {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] str = scan.nextLine().split("\\s");

        int counter = 0;

        String value = "";

        for (int i = 0; i < str.length - 1; i++) {
            int tempCounter = 1;
            for (int j = i + 1; j < str.length; j++) {
                if (str[i].equals(str[j])) {
                    tempCounter++;
                }
            }
            if (tempCounter > counter) {
                counter = tempCounter;
                value = str[i];
            }
        }
        printSequence(str,counter,value);
    }

    public static void printSequence(String[] str, int counter, String value) {
        System.out.printf("%s","The longest sequence of equal strings is: ");
        if (str.length == 1) {
            System.out.println(str[0]);
        } else {
            for (int i = 0; i < counter; i++) {
                if (i != counter - 1) {
                    System.out.printf("%s ", value);
                } else {
                    System.out.println(value);
                }
            }
        }
    }
}
