#region TreeSortFile
using System.Collections.Generic;

namespace Benchmarkus.SortingAlgorithms.Algorithms
{
    #region TreeSort
    /// <summary>
    /// Provides a static implementation of the TreeSort algorithm using a Binary Search Tree.
    /// </summary>
    public static class TreeSort
    {
        #region SortMethod
        /// <summary>
        /// Sorts an integer array using TreeSort (BST + in-order traversal).
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void Sort(int[] array)
        {
            // Build BST
            TreeNode? root = null;
            for (int i = 0; i < array.Length; i++)
            {
                root = Insert(root, array[i]);
            }

            // In-order traversal to place elements back into the array in sorted order
            var sortedValues = new List<int>();
            InOrder(root, sortedValues);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = sortedValues[i];
            }
        }
        #endregion

        #region InsertMethod
        private static TreeNode Insert(TreeNode? node, int value)
        {
            if (node == null)
                return new TreeNode(value);

            if (value < node.Value)
                node.Left = Insert(node.Left, value);
            else
                node.Right = Insert(node.Right, value);

            return node;
        }
        #endregion

        #region InOrderMethod
        private static void InOrder(TreeNode? node, List<int> result)
        {
            if (node == null) return;
            InOrder(node.Left, result);
            result.Add(node.Value);
            InOrder(node.Right, result);
        }
        #endregion

        #region TreeNodeClass
        private class TreeNode
        {
            public int Value;
            public TreeNode? Left;
            public TreeNode? Right;

            public TreeNode(int value)
            {
                Value = value;
            }
        }
        #endregion
    }
    #endregion
}
#endregion