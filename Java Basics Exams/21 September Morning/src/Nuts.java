import java.awt.*;
import java.awt.datatransfer.StringSelection;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;

/**
 * Created by Heisenberg on 2/6/2015.
 */
public class Nuts {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n = Integer.parseInt(scan.nextLine());
        TreeMap<String, LinkedHashMap<String, String>> map = new TreeMap<String, LinkedHashMap<String, String>>();

        for (int i = 0; i < n; i++) {
            String[] line = scan.nextLine().split(" ");
            if (map.containsKey(line[0])) {
                int kilos = Integer.parseInt(line[2].replaceAll("kg", ""));
                LinkedHashMap<String, String> mapIn = map.get(line[0]);
                if (mapIn.containsKey(line[1])) {
                    kilos = kilos + Integer.parseInt(mapIn.get((line[1])).replaceAll("kg", ""));
                    mapIn.put(line[1], kilos + "kg");
                    map.put(line[0], mapIn);
                } else {
                    mapIn.put(line[1], kilos + "kg");
                    map.put(line[0], mapIn);
                }

            } else {
                int kilos = Integer.parseInt(line[2].replaceAll("kg", ""));
                LinkedHashMap<String, String> mapIn = new LinkedHashMap<String, String>();
                mapIn.put(line[1], line[2]);
                map.put(line[0],mapIn);
            }


        }
        for (String key : map.keySet()) {
            System.out.println(key+": "+map.get(key).toString().replace("{","").replace("}","").replace("=","-"));
        }
    }
}
