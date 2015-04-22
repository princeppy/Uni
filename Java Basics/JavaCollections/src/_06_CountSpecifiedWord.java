import sun.security.krb5.internal.PAData;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _06_CountSpecifiedWord {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int counter = 0;
        System.out.println("Input a word to find in the text");
        String wordToFind = scan.nextLine();
        System.out.println("Input the text to search in");
        String text = scan.nextLine();

        Pattern regex = Pattern.compile("\\b" + wordToFind + "\\b", Pattern.CASE_INSENSITIVE);

        Matcher match = regex.matcher(text);

        while (match.find()){
            counter++;
        }

        System.out.printf("The number of times the word \"%s\" is in the text is: %s",wordToFind,counter);
    }
}
