// https://www.hackerrank.com/challenges/java-lambda-expressions/problem

import java.io.*;
import java.util.*;

interface PerformOperation {
    boolean check(int a);
}

class MyMath {
    public static boolean checker(PerformOperation p, int num) {
        return p.check(num);
    }

    // Write your code here
    PerformOperation isOdd() {
        PerformOperation po = (int a) -> a % 2 == 0 ? false : true;
        return po;
    }

    PerformOperation isPrime() {
        PerformOperation po = (int a) -> {
            if (a == 1)
                return false;
            else {
                for (int i = 2; i < Math.sqrt(a); i++) {
                    if (a % i == 0)
                        return false;
                }
                return true;
            }
        };
        return po;
    }

    PerformOperation isPalindrome() {
        PerformOperation po = (int a) -> {
            String str = Integer.toString(a);
            String reverseStr = "";
            for (int i = 0; i < str.length(); i++) {
                reverseStr = str.charAt(i) + reverseStr;
            }
            return str.equals(reverseStr);
        };
        return po;
    }
}

public class Solution {
    public static void main(String[] args) throws IOException {
        MyMath ob = new MyMath();
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int T = Integer.parseInt(br.readLine());
        PerformOperation op;
        boolean ret = false;
        String ans = null;
        while (T-- > 0) {
            String s = br.readLine().trim();
            StringTokenizer st = new StringTokenizer(s);
            int ch = Integer.parseInt(st.nextToken());
            int num = Integer.parseInt(st.nextToken());
            if (ch == 1) {
                op = ob.isOdd();
                ret = ob.checker(op, num);
                ans = (ret) ? "ODD" : "EVEN";
            } else if (ch == 2) {
                op = ob.isPrime();
                ret = ob.checker(op, num);
                ans = (ret) ? "PRIME" : "COMPOSITE";
            } else if (ch == 3) {
                op = ob.isPalindrome();
                ret = ob.checker(op, num);
                ans = (ret) ? "PALINDROME" : "NOT PALINDROME";

            }
            System.out.println(ans);
        }
    }
}
