/**
 * https://leetcode.com/problems/add-two-numbers
 * 
 * 
 * 
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode node = new ListNode();
        return withCarrier(l1, l2, 0);
    }
    
    private ListNode withCarrier(ListNode l1, ListNode l2, int carry) {
        ListNode node = new ListNode();
        if(l1 == null && l2 == null) {
            if(carry == 0)
                return null;
            else 
                return new ListNode(carry, null);
        } else if (l1 == null) {
            int val = l2.val + carry;
            carry = val / 10;
            val = val % 10;
            node.val = val;
            node.next = withCarrier(l1, l2.next, carry);
            return node;
        } else if(l2 == null) {
            int val = l1.val + carry;
            carry = val / 10;
            val = val % 10;
            node.val = val;
            node.next = withCarrier(l1.next, l2, carry);
            return node;
        } else {
            int v1 = l1.val;
            int v2 = l2.val;
            int sum = v1 + v2 + carry;
            carry = sum / 10;
            sum = sum % 10;
            node.val = sum;
            node.next = withCarrier(l1.next, l2.next, carry);
            return node;
        }
    }
}