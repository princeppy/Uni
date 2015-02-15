package Default;

import java.util.Scanner;

/**
 * Created by Heisenberg on 12/17/2014.
 */
public class _01_SymmetricNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        System.out.println("Enter the lower bound of the range");
        int low = scan.nextInt();
        System.out.println("Enter the upper bound of the range");
        int upper = scan.nextInt();
        boolean isSymmetric = true;

        for (int i = low; i <= upper; i++) {
            String str = String.valueOf(i);
            isSymmetric = true;
            for (int j = 0, k = str.length()-1; j < str.length() / 2; j++, k--) {
                if (str.charAt(j) != str.charAt(k)) {
                    isSymmetric = false;
                }
            }
            if (isSymmetric) {
                System.out.println(i);
            }
        }
    }
}
