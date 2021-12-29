/* https://leetcode.com/problems/string-to-integer-atoi
 *
 * Scan from top-right (row++ if element < target; column-- if element > target), since matrix is sorted from top-left to bottom-right.
 * O(n)
 * 
 */

public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int row = matrix.Length;
        int col = matrix[0].Length;

        int rowIndex = 0;
        int colIndex = col - 1;

        while (rowIndex < row && colIndex >= 0)
        {
            int ele = matrix[rowIndex][colIndex];
            if (ele == target)
            {
                return true;
            }
            else if (ele < target)
            {
                rowIndex++;
            }
            else
            {
                colIndex--;
            }
        }
        return false;
    }
}