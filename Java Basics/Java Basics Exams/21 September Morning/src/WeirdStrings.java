import java.awt.*;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Heisenberg on 2/6/2015.
 */
public class WeirdStrings {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String str = scan.nextLine();

        str = str.replaceAll("[)(/\\| ]+", "");

        Pattern regex = Pattern.compile("[a-zA-Z]+");
        Matcher match = regex.matcher(str);
        ArrayList<String> list = new ArrayList<String>();

        while (match.find()) {
            list.add(match.group());
        }
        int sum = 0;
        int tempSum = 0;
        String word1 = "";
        String word2 = "";
        for (int i = 0; i < list.size() - 1; i++) {
            tempSum = findSum(list.get(i) + list.get(i + 1));
            if (tempSum>=sum){
                sum = tempSum;
                word1 = list.get(i);
                word2 = list.get(i+1);
            }
            tempSum = 0;
        }

        System.out.println(word1);
        System.out.println(word2);
//        System.out.println(list);
    }

    static int findSum(String str) {
        str = str.toLowerCase();
        char[] arr = str.toCharArray();
        int sum = 0;
        for (int i = 0; i < arr.length; i++) {
            sum += arr[i] - 96;
        }
        return sum;
    }
}
