import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _11_MostFrequentWord {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine().toLowerCase();

        Pattern regex = Pattern.compile("\\w+");

        Matcher match = regex.matcher(text);
        TreeMap<String, Integer> map = new TreeMap<String, Integer>();

        while (match.find()) {

            if (map.containsKey(match.group())) {
                map.put(match.group(), map.get(match.group()) + 1);
            } else {
                map.put(match.group(), 1);
            }
        }
        Object max = sortByValueDescending(map).values().toArray()[0];
        for (Object frequentWord : sortByValueDescending(map).keySet()) {
            if ((Integer) sortByValueDescending(map).get(frequentWord) >= (Integer) max) {
                System.out.println(frequentWord + " -> " + sortByValueDescending(map).get(frequentWord) + " times");
            }
        }

        System.out.println();


    }

    public static Map sortByValueDescending(Map unsortMap) {
        List list = new LinkedList(unsortMap.entrySet());

        Collections.sort(list, new Comparator() {
            public int compare(Object o1, Object o2) {
                return -((Comparable) ((Map.Entry) (o1)).getValue())        //The - in front of ((Compareable... is for descending sort.
                        .compareTo(((Map.Entry) (o2)).getValue());
            }
        });

        Map sortedMap = new LinkedHashMap();
        for (Iterator it = list.iterator(); it.hasNext(); ) {
            Map.Entry entry = (Map.Entry) it.next();
            sortedMap.put(entry.getKey(), entry.getValue());
        }
        return sortedMap;
    }
}
