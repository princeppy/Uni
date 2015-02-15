import javafx.scene.shape.PathElement;

import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Heisenberg on 2/6/2015.
 */
public class CognateWords {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();

        Pattern regex = Pattern.compile("[a-zA-Z]+");
        Matcher match = regex.matcher(line);
        ArrayList<String> list = new ArrayList<String>();
        while (match.find()) {
            list.add(match.group());
        }
        ArrayList<String> listFinal = new ArrayList<String>();
        for (int i = 0; i < list.size(); i++) {
            for (int j = 0; j < list.size(); j++) {
                for (int k = 0; k < list.size(); k++) {
                    if ((list.get(i) + list.get(j)).equals(list.get(k))) {
                        if (!listFinal.contains(list.get(i) + "|" + list.get(j) + "=" + list.get(k))) {
                            listFinal.add(list.get(i) + "|" + list.get(j) + "=" + list.get(k));
                        }
                    }

                }

            }

        }
        if (listFinal.isEmpty()){
            System.out.println("No");
        }else{
            for (String s : listFinal) {
                System.out.println(s);
            }
        }

    }
}

