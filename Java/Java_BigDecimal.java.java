import java.math.BigDecimal;
import java.util.*;

class Solution {
    public static void main(String[] args) {
        // Input
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        String[] s = new String[n + 2];
        for (int i = 0; i < n; i++) {
            s[i] = sc.next();
        }
        sc.close();

        // Write your code here
        for (int i = 1; i < n; i++) {
            for (int j = i; j >= 1; j--) {
                BigDecimal a = new BigDecimal(s[j]);
                BigDecimal b = new BigDecimal(s[j - 1]);
                if (a.compareTo(b) > 0) {
                    String temp = s[j];
                    s[j] = s[j - 1];
                    s[j - 1] = temp;

                } else {
                    break;
                }
            }
        }

        // Output
        for (int i = 0; i < n; i++) {
            System.out.println(s[i]);
        }
    }
}