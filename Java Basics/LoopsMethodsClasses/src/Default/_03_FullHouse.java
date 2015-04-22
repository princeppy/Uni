package Default;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Heisenberg on 12/18/2014.
 */
public class _03_FullHouse {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] face = new String[]{"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        char[] suit = new char[]{'\u2663', '\u2666', '\u2665', '\u2660'};
        List<String> tripleCards = new ArrayList<String>();
        List<String> doubleCards = new ArrayList<String>();
        List<String> combos = new ArrayList<String>();


        for (int m = 0; m < face.length; m++) {
            for (int i = 0; i < suit.length - 2; i++) {
                for (int j = i + 1; j < suit.length - 1; j++) {
                    for (int k = j + 1; k < suit.length; k++) {
                        String str = String.format("%s%s %s%s %s%s ", face[m], suit[i], face[m], suit[j], face[m], suit[k]);
                        tripleCards.add(str);
                    }
                }
            }
        }

        for (int m = 0; m < face.length; m++) {
            for (int i = 0; i < suit.length - 1; i++) {
                for (int j = i + 1; j < suit.length; j++) {
                    String str = String.format("%s%s %s%s", face[m], suit[i], face[m], suit[j]);
                    doubleCards.add(str);

                }
            }
        }
        int count = 0;
        for (int i = 0; i < tripleCards.size(); i++) {
            for (int j = 0; j < doubleCards.size(); j++) {
                if (tripleCards.get(i).charAt(0)!=doubleCards.get(j).charAt(0)){
//                    System.out.println(tripleCards.get(i)+doubleCards.get(j));
                    combos.add(tripleCards.get(i)+doubleCards.get(j));
//                    count++;
                }
            }
        }

        List<String> bins = new ArrayList<String>();
        List<String> finalStr = new ArrayList<String>();
        for (int i = 0; i < 31; i++) {

            String bin = Integer.toBinaryString(i);
            bin = String.format("%5s",bin);
            bin = bin.replace('0', ' ');
            bin = bin.replace('1', '*');
            CharSequence space = " ";
            CharSequence spaceReplace = " -";
            CharSequence asteriks = "*";
            CharSequence asteriksReplace = "*-";

            bin = bin.replace(space,spaceReplace);
            bin = bin.replace(asteriks,asteriksReplace);
            bins.add(bin);
//            System.out.println(bin);
        }
        String str1 = new String();
        for (int i = 0; i < combos.size(); i++) {
            String[] arr = combos.get(i).split(" ");

            for (int j = 0; j < bins.size(); j++) {
                str1 = "";
                for (int k = 0; k < 5; k++) {

                    String[] str = bins.get(j).split("-");
                    if (str[k].equals(" ")) {
                        str[k] = arr[k];

//                        System.out.println(str);

                    }

                    str1 = str1 + str[k]+ " ";
                }
                System.out.println(str1);
                count++;
            }



        }
        System.out.println("* * * * *");
        System.out.printf("Total full houses in a deck of cards: %s", count+1);

    }
}
