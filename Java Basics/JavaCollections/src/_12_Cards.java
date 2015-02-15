import java.util.LinkedHashMap;
import java.util.Scanner;

/**
 * Created by Heisenberg on 2/4/2015.
 */
public class _12_Cards {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] text = scan.nextLine().split("\u2660"+"[ ]{0,1}"+"|\u2663"+"[ ]{0,1}"+ "|\u2665"+"[ ]{0,1}"+ "|\u2666"+"[ ]{0,1}");

        LinkedHashMap<String, Double> map = new LinkedHashMap<String, Double>();

        for (int i = 0; i < text.length; i++) {
            if (map.containsKey(text[i])){
                map.put(text[i],map.get(text[i])+1);

            }
            else{
                map.put(text[i],1d);
            }

        }
        for (String card : map.keySet()) {
            System.out.printf("%s -> %.2f",card,(map.get(card)/text.length*100));
            System.out.println("%");
        }
    }
}
