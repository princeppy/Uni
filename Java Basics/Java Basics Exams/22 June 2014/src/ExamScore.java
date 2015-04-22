import java.awt.*;
import java.awt.List;
import java.awt.geom.Arc2D;
import java.util.*;

/**
 * Created by Heisenberg on 2/6/2015.
 */
public class ExamScore {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] header = new String[3];
        for (int i = 0; i < header.length; i++) {
            header[i] = scan.nextLine();
//            System.out.println(header[i]);
        }

        String line = scan.nextLine();

        TreeMap<Integer,String> mapNames = new TreeMap<Integer, String>();
        TreeMap<Integer,Double> mapGrades = new TreeMap<Integer, Double>();

        while (!line.contains("-")){
            String[] str = line.split("[ \\|]+");
            ArrayList<String> list = new ArrayList<String>();
            for (int i = 0; i < str.length; i++) {
                if (!str[i].equals("")){
                    list.add(str[i]);
                }

            }
            if (mapNames.containsKey(Integer.parseInt(list.get(2)))){
                mapNames.put(Integer.parseInt(list.get(2)),mapNames.get(Integer.parseInt(list.get(2)))+", "+list.get(0)+" "+list.get(1));
            }
            else{
                mapNames.put(Integer.parseInt(list.get(2)),list.get(0)+" "+list.get(1));
            }


            if (mapGrades.containsKey(Integer.parseInt(list.get(2)))){
                mapGrades.put(Integer.parseInt(list.get(2)), mapGrades.get(Integer.parseInt(list.get(2)))+Double.parseDouble(list.get(3)));
            }
            else{
                mapGrades.put(Integer.parseInt(list.get(2)), Double.parseDouble(list.get(3)));
            }


            line = scan.nextLine();
        }

        for (Integer integer : mapNames.keySet()) {
            String[] s = mapNames.get(integer).split(", ");
            ArrayList<String> list = new ArrayList<String>(Arrays.asList(s));
            Collections.sort(list);

            System.out.printf("%s -> %s; avg=%.2f\n",integer,list,mapGrades.get(integer)/s.length);
//            System.out.println(integer + " -> ["+mapNames.get(integer)+"]; "+"avg="+mapGrades.get(integer));
        }
//        System.out.println(mapNames);
//        System.out.println(mapGrades);
    }
}
