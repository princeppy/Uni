package Default;

import sun.util.resources.cldr.wal.CalendarData_wal_ET;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.Period;
import java.time.chrono.ChronoLocalDateTime;
import java.time.format.DateTimeFormatter;
import java.time.temporal.ChronoUnit;
import java.util.Calendar;
import java.util.Date;
import java.util.Scanner;


/**
 * Created by Heisenberg on 12/22/2014.
 */
public class _07_DaysBetweenTwoDates {
    public static void main(String[] args) throws ParseException{
        Scanner scan = new Scanner(System.in);
        String date1 = scan.nextLine();
        String date2 = scan.nextLine();

        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd.MM.yyyy");
        CharSequence date01 = date1;
        CharSequence date02 = date2;
        LocalDate startDate = LocalDate.parse(date01,formatter);
        LocalDate endDate = LocalDate.parse(date02,formatter);


//        DateFormat format = new SimpleDateFormat("dd.MM.yyyy");
//
//        Date startDate = format.parse(date1);
//        Date endDate = format.parse(date2);
        long days = ChronoUnit.DAYS.between(startDate,endDate);




        System.out.printf("The days between %s and %s are: %s", date1, date2, days);


    }
}
