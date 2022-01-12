/* https://leetcode.com/problems/n-queens
 * 
 * 
 * 
 * 
 */

public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        NQueens nq = new NQueens(n);
        nq.Calculate_NQueens();
        return nq.GetResultString();
    }

    class NQueens
    {
        private int N;
        // result list
        private List<bool[,]> result;

        public NQueens(int size)
        {
            N = size;
            result = new List<bool[,]>();
        }

        public List<bool[,]> GetResult()
        {
            return result;
        }

        public IList<IList<string>> GetResultString()
        {
            IList<IList<string>> res = new List<IList<string>>();
            foreach (bool[,] bd in result)
            {
                IList<string> sbd = new List<string>();
                for (int i = 0; i < N; i++)
                {
                    string rowStr = "";
                    for (int j = 0; j < N; j++)
                    {
                        rowStr += bd[i, j] == true ? "Q" : ".";
                    }
                    sbd.Add(rowStr);
                }
                res.Add(sbd);
            }
            return res;
        }

        public void Calculate_NQueens()
        {
            bool[,] board = new bool[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    board[i, j] = false;
                }
            }
            nqueen_backtrack(board, 0);
        }

        public void nqueen_backtrack(bool[,] board, int row)
        {
            if (row == N)
            {
                bool[,] tmp = new bool[N, N];
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        tmp[i, j] = board[i, j];
                    }
                }
                result.Add(tmp);
            }

            for (int col = 0; col < N; col++)
            {
                if (!isValid(board, row, col))
                {
                    continue;
                }
                // Do choice
                board[row, col] = true;
                // The next level
                nqueen_backtrack(board, row + 1);
                // Remove choice
                board[row, col] = false;
            }
        }

        private bool isValid(bool[,] board, int row, int col)
        {
            // same row check, if have any other queen.
            for (int i = 0; i < N; i++)
            {
                if (board[i, col] == true) return false;
            }
            // left up check
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == true) return false;
            }
            // right up check
            for (int i = row - 1, j = col + 1; i >= 0 && j < N; i--, j++)
            {
                if (board[i, j] == true) return false;
            }
            return true;
        }
    }
}