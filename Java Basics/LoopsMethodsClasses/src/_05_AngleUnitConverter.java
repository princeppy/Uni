import java.util.Scanner;

/**
 * Created by Heisenberg on 12/19/2014.
 */
public class _05_AngleUnitConverter {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        Double n = scan.nextDouble();

        for (int i = 0; i < n; i++) {
            int value = scan.nextInt();
            String str = scan.nextLine();
            if ((str.charAt((str.length()-1))=='g')){
                System.out.printf("%.6f %s\n", value / 57.295779513082320876798154814105, "rad");
            }
            else {
                System.out.printf("%.6f %s\n",value*57.295779513082320876798154814105,"deg");
            }
        }
    }
}
