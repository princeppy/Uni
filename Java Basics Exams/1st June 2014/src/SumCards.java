import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

/**
 * Created by Heisenberg on 19.1.2015 г..
 */
public class SumCards {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String str = scan.nextLine();

        String[] values = {"0","1","2","3","4","5","6","7","8","9","10","11","J","Q","K","A"};

        String[] arr = str.split("([SCHD] )|([SCHD])");

        int sum = 0;

        for (int i = 0; i < arr.length; i++) {
            int counter = 1;
            for (int j = i; j < arr.length-1; j++) {
                if (arr[i].equals(arr[j+1])){
                    counter++;
                    i=j+1;
                }
                else{
                    i=j;
                    break;
                }
            }
            for (int j = 0; j < values.length; j++) {

                if (arr[i].equals(values[j]))
                {
                    if (counter>1){
                        sum = sum + j*counter*2;
                    }
                    else{
                        sum = sum + j;
                    }
                    break;
                }
            }
//            System.out.println(arr[i]+" "+counter);
        }

        System.out.println(sum);
    }


}
