import java.awt.*;
import java.util.*;

/**
 * Created by Heisenberg on 2/6/2015.
 */
public class StraightFlush {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] cards = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", null, null, null, null};

        String[] line = scan.nextLine().split("[, ]+");

        HashSet<String> straights = new HashSet<String>(Arrays.asList(line));
//        System.out.println(straights);
        int counter = 0;


        for (String s : straights) {
            String card = s.substring(0, s.length() - 1);
            String face = s.substring(s.length() - 1);

            if (straights.containsAll(straight(card, face))) {

                System.out.println(straight(card, face));
                counter++;
            }
        }
        if (counter == 0) {
            System.out.println("No Straight Flushes");
        }
    }

    public static ArrayList<String> straight(String card, String face) {
        ArrayList<String> flush = new ArrayList<String>();
        String[] cards = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", null, null, null, null};
        for (int i = 0; i < cards.length-5; i++) {
            if (card.equals(cards[i])) {
                for (int j = i; j < i+5; j++) {
                    flush.add(cards[j] + face);
                }
                break;
            }
        }
        if (flush.isEmpty()) {
            return new ArrayList<String>() {{
                add(null);
                add(null);
                add(null);
                add(null);
                add(null);
            }};
        }
        else{
            return flush;
        }
    }
}
