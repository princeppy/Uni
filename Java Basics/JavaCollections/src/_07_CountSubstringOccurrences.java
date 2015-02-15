import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _07_CountSubstringOccurrences {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int counter = 0;
        System.out.println("Input word to find: ");
        String wordToFind = scan.nextLine();
        System.out.println("Input text to find the words in it: ");
        String text = scan.nextLine();

        Pattern word = Pattern.compile("(?=("+wordToFind+"))",Pattern.CASE_INSENSITIVE); //The pattern is case insensitive
        Matcher match = word.matcher(text);

        while (match.find()) {
            counter++;
        }
        System.out.printf("The number of occurrences of \"%s\" in the text are: %s",wordToFind, counter);
    }
}




