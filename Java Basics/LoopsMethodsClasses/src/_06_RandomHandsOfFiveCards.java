import java.util.Random;
import java.util.Scanner;

/**
 * Created by Heisenberg on 12/20/2014.
 */
public class _06_RandomHandsOfFiveCards {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] face = new String[]{"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        char[] suit = new char[]{'\u2663', '\u2666', '\u2665', '\u2660'};
        int n = scan.nextInt();

        for (int  i= 0; i < n; i++) {
            for (int j = 0; j < 5; j++) {
                Random rand = new Random();
                System.out.printf("%s%s ",face[rand.nextInt(face.length-1)+0],suit[rand.nextInt(suit.length-1)+0]);
            }
            System.out.println();
        }
    }
}
