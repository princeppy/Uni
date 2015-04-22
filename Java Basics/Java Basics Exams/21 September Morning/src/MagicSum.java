import java.awt.*;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

/**
 * Created by Heisenberg on 2/6/2015.
 */
public class MagicSum {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int module = Integer.parseInt(scan.nextLine());
        int sum = Integer.MIN_VALUE;
        ArrayList<Integer> list = new ArrayList<Integer>();
        String line = scan.nextLine();
        String finalStr = "";
        int counter = 0;

        while (!line.equals("End")) {
            list.add(Integer.parseInt(line));
            line = scan.nextLine();

        }
        int tempSum = 0;
        for (int i = 0; i < list.size(); i++) {
            tempSum = 0;
            for (int j = i + 1; j < list.size(); j++) {

                for (int k = j + 1; k < list.size(); k++) {
                    tempSum = list.get(i) + list.get(j) + list.get(k);
                    if (tempSum > sum && tempSum % module == 0) {
                        counter++;
                        sum = tempSum;
                        finalStr = (list.get(i).toString()+" + " + list.get(j).toString()+" + " + list.get(k).toString());
                    }

                    tempSum = 0;
                }

            }

        }
        if (counter!=0){
            System.out.println("("+finalStr+")"+" % "+module + " = 0");
        }
        else {
            System.out.println("No");
        }

    }
}
