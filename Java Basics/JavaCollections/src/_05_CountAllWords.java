import jdk.nashorn.internal.runtime.regexp.joni.Regex;

import java.util.Scanner;
import java.util.regex.*;


public class _05_CountAllWords {
    public static void main(String[] args) {
        System.out.println("Input text to find the words in it: ");
        Scanner scan = new Scanner(System.in);
        String sentence = scan.nextLine();
        int counter = 0;

        Pattern word = Pattern.compile("\\w+");

        Matcher match = word.matcher(sentence);

        while (match.find()){
            counter++;
        }

        System.out.printf("The number of the words in the text is: %s", counter);
    }
}
