// https://www.hackerrank.com/challenges/java-string-tokens/problem?isFullScreen=true

import java.util.*;

public class Solution {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String s = scan.nextLine();
        // Write your code here.

        String[] strs = s.split("[ !,?._'@]+");

        System.out.println(strs.length);
        for (String str : strs) {
            System.out.println(str);
        }

        scan.close();
    }
}
