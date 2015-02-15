package Default;


import com.itextpdf.text.*;
import com.itextpdf.text.Font;
import com.itextpdf.text.pdf.*;



import java.awt.*;
import java.awt.print.PrinterException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Scanner;

public class _09_GenerateAPDFByExternalLibrary {
    public static void main(String[] args) throws IOException, DocumentException {
        Scanner scan = new Scanner(System.in);

        String[] cards = new String[]{"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};

        Character[] suits = new Character[]{'\u2663', '\u2666', '\u2665', '\u2660'};

        // Create document
        Document document = new Document();
        // Write on the document
        PdfWriter writer = PdfWriter.getInstance(document, new FileOutputStream("Cards.pdf"));
        // Open the document
        document.open();
        // Change the font
        BaseFont bf = BaseFont.createFont("C:\\Windows\\Fonts\\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        Font font = new Font(bf, 16);


        // Create the table
        PdfPTable table = new PdfPTable(8);


        for (int i = 0; i < cards.length; i++) {

            for (int j = 0; j < suits.length; j++) {
                PdfPCell emptyCell = new PdfPCell();
                emptyCell.setBorderWidthTop(2);
                emptyCell.setBorder(0);

                PdfPCell cell = new PdfPCell();
                cell.setHorizontalAlignment(Element.ALIGN_CENTER);
                cell.setBorder(0);

                PdfPTable nestedTable = new PdfPTable(1);
                nestedTable.setWidthPercentage(100);

                PdfPCell cellNested = new PdfPCell();

                cellNested.setPaddingTop(30);
                cellNested.setPaddingBottom(30);
                cellNested.setHorizontalAlignment(Element.ALIGN_CENTER);

                cellNested.setVerticalAlignment(Element.ALIGN_CENTER);

                if (suits[j] == '\u2666' | suits[j] == '\u2665') {
                    Font font1 = new Font(bf, 16, Font.NORMAL, BaseColor.RED);

                    cellNested.setPhrase(new Phrase(cards[i] + suits[j], font1));

                    nestedTable.addCell(cellNested);

                    cell.addElement(nestedTable);
                } else {
                    cellNested.setPhrase(new Phrase(cards[i] + suits[j], font));

                    nestedTable.addCell(cellNested);

                    cell.addElement(nestedTable);
                }

                table.addCell(cell);
                table.addCell(emptyCell);
            }

            PdfPCell cellRow = new PdfPCell();
            cellRow.setColspan(8);
            cellRow.setFixedHeight(16);
            cellRow.setBorder(0);
            table.addCell(cellRow);
        }
        float[] colWidths = {5, 1, 5, 1, 5, 1, 5, 1};
        table.setWidths(colWidths);
        table.setWidthPercentage(50);

        // Add the table
        document.add(table);

        // Close the document
        document.close();
    }

}
