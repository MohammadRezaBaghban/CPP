using CPP.Functions;
using CPP.Operations;
using CPP.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CPP.Visitable.Node
{
    public class BinaryTree
    {
        public CompositeNode _root;

        public BinaryTree()
        {
            _root = null;
        }   

        public CompositeNode InsertNode(CompositeNode root, Component node)
        {
            SingleNode singleNode = node as SingleNode;
            if (singleNode != null)
            {
                return InsertSingleNode(root, singleNode);
            }
            else
            {
                CompositeNode composite = node as CompositeNode;
                return InsertCompositeNode(root, composite);
            }
        }

        public CompositeNode InsertCompositeNode(CompositeNode root, CompositeNode newNode)
        {
            if (root == null)
            {
                this._root = (CompositeNode)newNode;
                return _root;
            }


            if (newNode is Function)
            {
                //Try to put the function on the left side of tree
                if(root is Function)
                {
                    if (root.LeftNode == null)
                    {
                        root.LeftNode = newNode;
                        root.LeftNode.Parent = root;
                    }                    
                    else
                    {
                        if (root.Parent != null)
                        {
                            return InsertCompositeNode(root.Parent, newNode);
                        }

                    }
                }
                else
                {
                    //Because of importance of Numerator and denominator in Division
                    //Because of importance of base and power in PowerOperator
                    if (root is DivisionOperator || root is PowerOperator)
                    {                       
                        if (root.LeftNode == null)
                        {
                            root.LeftNode = newNode;
                            root.LeftNode.Parent = root;
                        }
                        else if (root.RightNode == null)
                        {
                            root.RightNode = newNode;
                            root.RightNode.Parent = root;
                        }
                        {
                            if (root.Parent != null)
                            {
                                return InsertCompositeNode(root.Parent, newNode);
                            }

                        }
                    }
                    else
                    {//For the sake of having more balanced binary graph
                        if (root.RightNode == null)
                        {
                            root.RightNode = newNode;
                            root.RightNode.Parent = root;
                        }
                        else if (root.LeftNode == null)
                        {
                            root.LeftNode = newNode;
                            root.LeftNode.Parent = root;
                        }
                        else
                        {
                            if (root.Parent != null)
                            {
                                return InsertCompositeNode(root.Parent, newNode);
                            }

                        }
                    }

                    
                }
                
                
                return newNode;
            }
            else
            {
                //Try to put the operation on the right side of tree
                if(root is Function)
                {
                    if (root.LeftNode == null)
                    {
                        root.LeftNode = newNode;
                        root.LeftNode.Parent = root;

                    }
                    else
                    {
                        if (root.Parent != null)
                        {
                            return InsertCompositeNode(root.Parent, newNode);
                        }
                    }
                }
                else
                {

                    //Because of importance of Numerator and denominator in Division
                    //Because of importance of base and power in PowerOperator
                    if (root is DivisionOperator || root is PowerOperator)
                    {
                        if (root.LeftNode == null)
                        {
                            root.LeftNode = newNode;
                            root.LeftNode.Parent = root;
                        }
                        else if (root.RightNode == null)
                        {
                            root.RightNode = newNode;
                            root.RightNode.Parent = root;
                        }
                        {
                            if (root.Parent != null)
                            {
                                return InsertCompositeNode(root.Parent, newNode);
                            }

                        }
                    }
                    else
                    {
                        if (root.RightNode == null)
                        {
                            root.RightNode = newNode;
                            root.RightNode.Parent = root;
                        }
                        else if (root.LeftNode == null)
                        {
                            root.LeftNode = newNode;
                            root.LeftNode.Parent = root;

                        }
                        else
                        {
                            if (root.Parent != null)
                            {
                                return InsertCompositeNode(root.Parent, newNode);
                            }
                        }
                    }
                    
                }
                
                return newNode;
            }
        }

        internal CompositeNode InsertSingleNode(CompositeNode root, SingleNode singleNode)
        {
            //Try to put the signle node on the left side of tree as much as possible
            if(root is Function)
            {
                if (root.LeftNode == null)
                {
                    root.LeftNode = singleNode;
                    root.LeftNode.Parent = root;
                    return singleNode.Parent;
                }
                else
                {
                    //If both left and right node were full, insert it to the parent
                    if (root.Parent != null)
                    {
                        return InsertSingleNode(root.Parent, singleNode);
                    }
                    else
                    {
                        return singleNode.Parent;
                    }
                }
            }
            else
            {
                if (root.LeftNode == null)
                {
                    root.LeftNode = singleNode;
                    root.LeftNode.Parent = root;
                    return singleNode.Parent;
                }
                else if (root.RightNode == null)
                {
                    root.RightNode = singleNode;
                    root.RightNode.Parent = root;
                    return singleNode.Parent;
                }else
                {
                    //If both left and right node were full, insert it to the parent
                    if (root.Parent != null)
                    {
                        return InsertSingleNode(root.Parent, singleNode);
                    }
                    else
                    {
                        return singleNode.Parent;
                    }
                    
                }
            }
            
        }
    }
}
