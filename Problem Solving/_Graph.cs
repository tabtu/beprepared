/*
 * Depth-First Search
 * 
 * 1, Find the relationship between target and options.
 * 2, Declare the boundary, including success and failure.
 * 3, Loop choices, (DDRR) in each loop round.
 * 
 * 
 * 1, 寻找结束目标和做选择的关系
 *    - 递归调用结果一般储存在函数外部
 *    - 2,3 步骤即是dfs算法描述
 * 2, 确定结束边界(成功/越界)
 *    - 将成功结果保存在路径表
 *    - 越界直接回滚上一级递归
 * 3, 循环做选择并将结果复制到路径表, 循环内容如下:
 *    - 做选择,添加到当前路径(do)
 *    - 修整可选择项, 移出不必要项目(dismiss)
 *    - 递归, 传入上一次结果和修整后可选择项目(recursive)
 *    - 还原选择项目, 还原路径(rollback)
 * 
 * 算法模板:
 * ---------------------------------
IList<IList<T>> paths;
void dfs_backtrack(TR target, IList<T> curpts, IList<T> options) {
    if (/succed/) {
        paths.Add(new List<T>(curpts));
    }
    if (/boundary/) {
        return;
    }
    // deep seek with options
    for (int i = 0; i < options.Length; i++) {
        curpts.Add(options[i]);
        target = dooption(target, options[i]);

        // TODO: decrease options if possible
        IList<T> next_options = cutbranches(options);

        dfs_backtrack(target, curpts, next_options);

        target = rollback(target, options[i]);
        curpts.RemoveAt(curpts.Count - 1);
    }
}
* ---------------------------------
* 
* Problems:
* - Change in a Foreign Currency
* - Palindrome Partitioning
* - Permutations
* - N Queens
* 
*/








/* 
 * Breadth-First Search
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * Problems:
 * - Minimizing Permutations
 * - Palindrome Partitioning II
 * - Serialize and Deserialize Binary Tree
 * 
 * 
 * 
 * spining tree
 * 
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;

namespace coding
{
    public class _Graph
    {




        //static void Main(string[] args)
        //{
        //}
    }
}
