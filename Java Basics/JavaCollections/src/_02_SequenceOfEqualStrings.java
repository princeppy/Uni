import com.sun.org.apache.xpath.internal.SourceTree;

import java.util.*;


public class _02_SequenceOfEqualStrings {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] str = scan.nextLine().split("\\s");

        LinkedHashMap<String, Integer> map = new LinkedHashMap<String, Integer>();

        for (int i = 0; i < str.length; i++) {
            int counter = 1;
            for (int j = i + 1; j < str.length; j++) {
                if (str[i].equals(str[j])) {
                    counter++;
                    i = j - 1;
                } else {
                    i = j - 1;
                    break;
                }
            }
            map.put(str[i], counter);
            printMap(map);
            map.clear();
        }


    }

    public static void printMap(LinkedHashMap<String, Integer> map) {
        for (String key : map.keySet()) {
            for (int i = 0; i < map.get(key); i++) {
                if (i != map.get(key) - 1) {
                    System.out.printf("%s ", key);
                } else {
                    System.out.println(key);
                }
            }
        }
    }


}
