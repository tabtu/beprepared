// https://www.hackerrank.com/challenges/java-md5/problem

import java.io.*;
import java.util.*;
import java.security.MessageDigest;
import javax.xml.bind.DatatypeConverter;

public class Solution {

    public static void main(String[] args) {
        /*
         * Enter your code here. Read input from STDIN. Print output to STDOUT. Your
         * class should be named Solution.
         */
        Scanner scanner = new Scanner(System.in);
        String input = scanner.next();
        System.out.println(convertMD5(input));
    }

    public static String convertMD5(String str) {
        try {
            MessageDigest md = MessageDigest.getInstance("MD5");
            md.update(str.getBytes());
            byte[] digest = md.digest();
            return DatatypeConverter.printHexBinary(digest).toLowerCase();
        } catch (Exception e) {
            // throw e;
            return "";
        }
    }
}