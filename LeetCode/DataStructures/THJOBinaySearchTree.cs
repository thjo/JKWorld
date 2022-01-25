using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructures
{

    class THJOBinaySearchTree
    {
        THJOBNode root;

        public THJOBinaySearchTree()
        {
            root = null;
        }



        void Insert(int data)
        {
            root = InsertRec(root, data);
        }
        THJOBNode InsertRec(THJOBNode root, int data)
        {
            if( root == null )
            {
                root = new THJOBNode(data);
                return root;
            }

            if (root.data < data)
            {
                root.right = InsertRec(root.right, data);
            }
            else
                root.left = InsertRec(root.left, data);

            return root;
        }

        void Delete(int data)
        {
            root = DeleteRec(root, data);
        }
        THJOBNode DeleteRec(THJOBNode root, int data)
        {
            //Base case. If the tree is empty
            if (root == null)
                return root;

            //Otherwise, recur down the tree
            if (data > root.data)
                DeleteRec(root.right, data);
            else if (data < root.data)
                DeleteRec(root.left, data);
            else
            {
                //Case 1. If it is a  leaf node.
                //Case 2. If it has either one node left or right
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                //Case 3. If it has both childs
                //Get minimum value from right child nodes
                root.data = GetMinVal(root.right);

                //Delete
                root.right = DeleteRec(root.right, root.data);
            }
            return root;
        }
        int GetMinVal(THJOBNode root)
        {
            int minVal = root.data;
            while(root.left != null)
            {
                minVal = root.left.data;
                root = root.left;
            }

            return minVal;
        }

        void Inorder()
        {
            InorderRec(root);
        }
        void InorderRec(THJOBNode root)
        {
            if (root != null)
            {
                InorderRec(root.left);
                System.Diagnostics.Debug.WriteLine(root.data);
                InorderRec(root.right);
            }
        }
    }
}
