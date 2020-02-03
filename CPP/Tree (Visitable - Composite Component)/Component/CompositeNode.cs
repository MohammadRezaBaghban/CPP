using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Functions;
using CPP.Operations;
using CPP.Visitor;

namespace CPP.Visitable.Node
{
    [DebuggerDisplay("{ToString()}")]
    public abstract class CompositeNode : Component,ICloneable
    {
        //Fields
        public IMathematicalOperation operatorType;        
                     
        public override string GraphVizFormula
        {
            get
            {
                string temp = "";
                temp += $"node{NodeNumber} [ label = \"{Symbol}\" ]";
                if (LeftNode != null)
                {
                    temp += $"\nnode{NodeNumber} -- node{LeftNode.NodeNumber}\n";
                    temp += LeftNode.GraphVizFormula;
                }
                if (RightNode != null)
                {
                    temp += $"\nnode{NodeNumber} -- node{RightNode.NodeNumber}\n";
                    temp += RightNode.GraphVizFormula;
                }
                return temp;
            }
        }     

        //Methods
        public abstract bool OneInput();        

        public override string ToString()
        {
            return $"Object Type: {this.GetType().Name}"
                   + $" | Data: {this.Data.ToString()}"
                   + $" | Parent: {(this.Parent?.GetType().Name) ?? "Null"}"
                   + $" | RightNode: {RightNode.GetType().Name}"
                   + $" | LeftNode: {LeftNode.GetType().Name}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
