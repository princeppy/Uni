import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;

/**
 * Created by Heisenberg on 2/2/2015.
 */
public class _09_ListOfProducts {

    public static void main(String[] args) {
        try (BufferedReader br = new BufferedReader(new FileReader("input1.txt"));) {
            String line = br.readLine();
            ArrayList<Product> products = new ArrayList<Product>();  //This gets objects of type Product from the class Product

            while (line != null) {
                String[] lineArr = line.split(" ");
                Product product = new Product();
                product.setName(lineArr[0]);
                BigDecimal bd = new BigDecimal(lineArr[1]);
                product.setPrice(bd);
                products.add(product);
                line = br.readLine();
            }


            products.sort(Comparator.comparing(Product::getPrice).thenComparing(Product::getName)); //Sort by Price then by Name

//            Collections.sort(products, (Product p1, Product p2) -> p1.getPrice().compareTo(p2.getPrice())); //Lambda function for sorting by price

//            Collections.sort(products, (Product p1, Product p2) -> p1.getName().compareTo(p2.getName()));   //Lambda function for sorting by name.

            for (Product product : products) {
                System.out.println(product.toString());
            }
//            System.out.println(sum);
            br.close();
        } catch (IOException ioex) {
            System.err.println("(missing file)");
        }
    }
}
