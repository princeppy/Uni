import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;


public class _01_SortArrayOfNums {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        System.out.println("Input the list. Comma delimited (example: 2,5,-1,0,-4)");

        String str = scan.nextLine();
        ArrayList<Integer> list = new ArrayList<Integer>();

        for (String item : str.split(",")) {
            list.add(Integer.parseInt(item));
        }

        Collections.sort(list);
        System.out.printf("The sorted list is: ");
        for (int i = 0; i < list.size(); i++) {
            if (i!=list.size()-1) {
                System.out.printf("%s,", list.get(i));
            }
            else{
                System.out.println(list.get(i));
            }
        }


    }
}
