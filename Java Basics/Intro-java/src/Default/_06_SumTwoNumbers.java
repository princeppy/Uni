package Default;

import java.text.Format;
import java.util.Formatter;
import java.util.Scanner;

public class _06_SumTwoNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.println("Enter the first number:");
        int a = Integer.parseInt(scan.nextLine());
        System.out.println("Enter the second number:");
        int b = Integer.parseInt(scan.nextLine(),16);

        Formatter f = new Formatter();                                    //First option
        f.format("The sum of the two numbers is: %s",a+b);
        System.out.println(f);

        System.out.printf("The sum of the two numbers is: %s\n", a + b);  //Second option
    }


}
