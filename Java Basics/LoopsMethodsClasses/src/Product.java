import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.math.BigDecimal;

/**
 * Created by Heisenberg on 2/2/2015.
 */
public class Product {

    private String name;
    private BigDecimal price;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public BigDecimal getPrice() {
        return price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }

    public Product() {
        this.getName();
        this.getPrice();
    }

    public String toString() {
        return this.getPrice() + " " + this.getName();
    }


}


