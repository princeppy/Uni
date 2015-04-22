import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _10_ExtractAllUniqueWords {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine().toLowerCase();

        Pattern regex = Pattern.compile("\\w+");

        Matcher match = regex.matcher(text);
        TreeSet<String> map = new TreeSet<String>();


        while (match.find()) {
            map.add(match.group());
        }

        System.out.println(map.toString().replace("[","").replace("]","").replace(",",""));
    }
}
