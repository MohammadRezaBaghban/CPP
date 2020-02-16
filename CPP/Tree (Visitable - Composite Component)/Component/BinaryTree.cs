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

        public BinaryTree() => _root = null;

        public Component InsertNode(Component root, Component node)
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

        public Component InsertCompositeNode(Component root, Component newNode)
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
                            return InsertNode(root.Parent, newNode);
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
                                return InsertNode(root.Parent, newNode);
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
                                return InsertNode(root.Parent, newNode);
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
                            return InsertNode(root.Parent, newNode);
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
                                return InsertNode(root.Parent, newNode);
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
                                return InsertNode(root.Parent, newNode);
                            }
                        }
                    }
                    
                }
                
                return newNode;
            }
        }

        internal Component InsertSingleNode(Component root, SingleNode singleNode)
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
                        return InsertNode(root.Parent, singleNode);
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
                        return InsertNode(root.Parent, singleNode);
                    }
                    else
                    {
                        return singleNode.Parent;
                    }
                    
                }
            }
            
        }

        public static void Simplify(ref Component visitable, ref Component root)
        {
            SingleNode single = visitable as SingleNode;
            if (single != null)
            {
                if (!single.IsVariable)
                {
                    if (single.Data == 1)
                    {
                        if (root is MultiplicationOperator)
                        {
                            if (root.Parent == null)
                            {
                                if (root.LeftNode == visitable)
                                {
                                    root.RightNode.Parent = null;
                                    root = root.RightNode;
                                    visitable = null;
                                }
                                else
                                {
                                    root.LeftNode.Parent = null;
                                    root = root.RightNode;
                                    visitable = null;
                                }
                            }
                            else
                            {
                                if (root.LeftNode == visitable)
                                {
                                    root.RightNode.Parent = root.Parent;
                                    root = root.RightNode;
                                    visitable = null;
                                }
                                else
                                {
                                    root.LeftNode.Parent = root.Parent;
                                    root = root.LeftNode;
                                    visitable = null;
                                }
                            }
                        }

                        if (root is PowerOperator)
                        {
                            if (root.Parent == null)
                            {
                                if (root.RightNode == visitable)
                                {
                                    root.LeftNode = null;
                                    root = root.LeftNode;
                                    visitable = null;
                                }
                                else
                                {
                                    root = visitable;
                                    visitable.Parent = null;
                                }
                            }
                            else
                            {
                                if (root.RightNode == visitable)
                                {
                                    root.LeftNode.Parent = root.Parent;
                                    root = root.LeftNode;
                                    visitable = null;
                                }
                                else
                                {
                                    visitable.Parent = root.Parent;
                                    root = visitable;
                                }
                            }

                        }
                    }

                    if (single.Data == 0)
                    {
                        if (root is MultiplicationOperator)
                        {
                            if (root.Parent == null)
                            {
                                root = visitable;
                                visitable.Parent = null;
                            }
                            else
                            {
                                visitable.Parent = root.Parent;
                                root = visitable;
                            }
                        }

                        if (root is AddOperator || root is SubstractOperator)
                        {
                            if (root.Parent == null)
                            {
                                if (root.LeftNode == visitable)
                                {
                                    root.RightNode.Parent = null;
                                    root = root.RightNode;
                                    visitable = null;
                                }
                                else
                                {
                                    root.LeftNode.Parent = null;
                                    root = root.LeftNode;
                                    visitable = null;
                                }
                            }
                            else
                            {
                                if (root.LeftNode == visitable)
                                {
                                    root.RightNode.Parent = root.Parent;
                                    root = root.RightNode;
                                    visitable = null;
                                }
                                else
                                {
                                    root.LeftNode.Parent = root.Parent;
                                    root = root.LeftNode;
                                    visitable = null;
                                }
                            }
                        }


                    }

                }
            }
            else
            {

                if (visitable is Function)
                {
                    Simplify(ref visitable.LeftNode, ref visitable);
                }
                else
                {
                    if (visitable.LeftNode != null)
                    {
                        Simplify(ref visitable.LeftNode, ref visitable);
                    }
                    if (visitable.RightNode != null)
                    {
                        Simplify(ref visitable.RightNode, ref visitable);
                    }

                }
            }
        }
    }
}
