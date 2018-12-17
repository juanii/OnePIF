using System.Collections.Generic;

namespace OnePIF
{
    public class TreeNode<T>
    {
        public TreeNode()
        {
            Children = new List<TreeNode<T>>();
        }

		public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Children { get; set; }
        public T AssociatedObject { get; set; }
    }
}
