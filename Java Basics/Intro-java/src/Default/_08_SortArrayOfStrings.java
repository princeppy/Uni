package Default;

import java.util.*;

public class _08_SortArrayOfStrings {
    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        System.out.println("Enter the length of the string:");
        int n = Integer.parseInt(scan.nextLine());

        List<String> list = new ArrayList<String>();

        for (int i = 0; i < n; i++) {
            list.add(scan.nextLine());
        }

        Collections.sort(list);

        int size = list.size();

        System.out.print("The list in alphabetical order is: ");

        for (String s : list) {
            if (--size != 0) {
                System.out.print(s + ", ");
            } else {
                System.out.print(s);
            }
        }
    }
}

