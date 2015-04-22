import java.util.Scanner;

/**
 * Created by Heisenberg on 2/6/2015.
 */
public class Durts {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int centerX = scan.nextInt();
        int centerY = scan.nextInt();
        scan.nextLine();

        int radius = Integer.parseInt(scan.nextLine());
        int pointsNumber = Integer.parseInt(scan.nextLine());

        int[] pointX = new int[pointsNumber];
        int[] pointY = new int[pointsNumber];

        for (int i = 0; i < pointsNumber; i++) {
            pointX[i] = scan.nextInt();
            pointY[i] =scan.nextInt();
            checkPoint(pointX[i],pointY[i],radius,centerX,centerY);

        }
        scan.nextLine();




    }

    static void checkPoint(int pointX, int pointY,int radius, int centerX,int centerY){
        if ((pointX>=centerX-radius&&pointX<=centerX+radius)&&(pointY>=centerY-radius/2&&pointY<=centerY+radius/2)||
                (pointX>=centerX-radius/2&&pointX<=centerX+radius/2)&&(pointY>=centerY-radius&&pointY<=centerY+radius)  ){
            System.out.println("yes");
        }else{
            System.out.println("no");
        }
    }
}
