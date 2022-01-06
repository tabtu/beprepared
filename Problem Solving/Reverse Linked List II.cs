/* https://leetcode.com/problems/reverse-linked-list-ii/
 * 
 * 
 * 
 * 
 */




/*
var lowestCommonAncestor = function(root, p, q) {
   if(!root || root===p || root===q) return root;
   const left = lowestCommonAncestor(root.left,p,q);
   const right = lowestCommonAncestor(root.right,p,q);
   // if(!left && !right) return null;
   if(!left) return right;
   if(!right) return left;
   return root;
};
*/