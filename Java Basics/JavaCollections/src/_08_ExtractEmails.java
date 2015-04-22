import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _08_ExtractEmails {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        System.out.println("Input the text to search emails in:");
        String text = scan.nextLine();

        Pattern regex =  Pattern.compile("([A-Za-z0-9]+[A-Za-z0-9_.-]+(?<![._-]))(@[A-Za-z.-]+(?<![.-]))\\.([A-Za-z]{2,3})");
        Matcher match = regex.matcher(text);

        while (match.find()){
            System.out.println(match.group());
        }
    }
}
