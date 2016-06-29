﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace System
{
    public static partial class ITreeNodeHelper
    {
        /// <summary>
        /// traverse every item in the tree node recursively.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public static IEnumerable<T> EnumerateRecursively<T>(ITreeNode<T> treeNode)
            where T : ITreeNode<T>
        {
            yield return treeNode.Self;
            for (int i = 0; i < treeNode.Children.Count; i++)
            {
                var child = treeNode.Children[i];
                var enumerable = EnumerateRecursively(child);
                foreach (var item in enumerable)
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// traverse every item in the tree node non-recursively.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        public static IEnumerable<T> EnumerateNonRecursively<T>(ITreeNode<T> treeNode)
            where T : ITreeNode<T>
        {
            var stack = new Stack<ITreeNode<T>>();
            stack.Push(treeNode);
            while (stack.Count > 0)
            {
                ITreeNode<T> current = stack.Pop();
                foreach (var item in current.Children)
                {
                    stack.Push(item);
                }
                yield return current.Self;
            }
        }

    }
}
