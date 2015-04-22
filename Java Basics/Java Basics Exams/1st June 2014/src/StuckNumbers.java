import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Heisenberg on 19.1.2015 г..
 */
public class StuckNumbers {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int n = scan.nextInt();
        int counter = 0;
        List<Integer> list = new ArrayList<Integer>();

        for (int i = 0; i < n; i++) {
            list.add(scan.nextInt());
        }

        StringBuilder str = new StringBuilder();

        for (int i = 0; i < list.size(); i++) {
            for (int j = 0; j < list.size(); j++) {
                for (int k = 0; k < list.size(); k++) {
                    for (int l = 0; l < list.size(); l++) {
                        if (list.get(i) != list.get(j) & list.get(i) != list.get(k)&list.get(i) != list.get(l)&list.get(j) != list.get(k)&list.get(j) != list.get(l)&list.get(k) != list.get(l)) {
                            if ((list.get(i).toString() + list.get(j).toString()).equals((list.get(k).toString() + list.get(l).toString()))) {
//                                System.out.println(list.get(i) + "|" + list.get(j) + "==" + list.get(k) + "|" + list.get(l));
                                str.append(list.get(i));
                                str.append("|");
                                str.append(list.get(j));
                                str.append("==");
                                str.append(list.get(k));
                                str.append("|");
                                str.append(list.get(l));
                                counter++;
                                System.out.println(str);
                                str.delete(0,str.length());
                            }
                        }

                    }


                }


            }
            if (counter == 0) {
                System.out.println("No");
            }
        }
    }
}