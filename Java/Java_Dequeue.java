import java.util.*;

public class test {
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        Deque deque = new ArrayDeque<>();
        Map<Integer, Integer> map = new HashMap<Integer, Integer>();
        int n = in.nextInt();
        int m = in.nextInt();

        int res = 0;
        for (int i = 0; i < n; i++) {
            final int num = in.nextInt();
            deque.addLast(num);
            if (map.containsKey(num)) {
                map.put(num, map.get(num).intValue() + 1);
            } else {
                map.put(num, 1);
            }

            if (deque.size() == m + 1) {
                final int key = (int) deque.removeFirst();
                final int v = map.get(key);
                if (v == 1) {
                    map.remove(key);
                } else {
                    map.put(key, v - 1);
                }
            }

            final int cnt = map.size();
            if (cnt > res) {
                res = cnt;
            }
        }
        System.out.println(res);
    }
}
