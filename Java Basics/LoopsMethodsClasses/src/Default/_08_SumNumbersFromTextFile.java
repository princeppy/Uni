package Default;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;

/**
 * Created by Heisenberg on 12/23/2014.
 */
public class _08_SumNumbersFromTextFile {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        try (BufferedReader br = new BufferedReader(new FileReader("input.txt"));) {
            String line = br.readLine();
            double sum = 0;
            while (line != null) {
                sum = sum + Double.parseDouble(line);
                line = br.readLine();
            }
            System.out.println(sum);
            br.close();
        } catch (IOException ioex) {
            System.err.println("(missing file)");
        }
    }
}

