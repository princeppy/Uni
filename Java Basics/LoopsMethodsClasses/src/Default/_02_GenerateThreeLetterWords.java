package Default;

import java.util.Scanner;

/**
 * Created by Heisenberg on 12/17/2014.
 */
public class _02_GenerateThreeLetterWords {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        System.out.println("Enter the string");
        String str = scan.nextLine();

        for (int i = 0; i < str.length(); i++) {
            for (int j = 0; j < str.length(); j++) {
                for (int k = 0; k < str.length(); k++) {
                    System.out.printf("%s%s%s\n",str.charAt(i),str.charAt(j),str.charAt(k));
                }
            }
        }
    }
}
