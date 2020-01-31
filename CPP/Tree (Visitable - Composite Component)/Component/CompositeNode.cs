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
    [DebuggerDisplay("{ToString(),nq}")]
    public abstract class CompositeNode : Component
    {
        //Fields
        public IMathematicalOperation operatorType;
        public Component LeftNode;
        public Component RightNode;

        public int NodeNumber { get; } = FormulaParse.nodeCounter;
        public decimal Data { get; set; }
        public string Symbol { get; set; }
        public string InFixFormula { get; set; }
        public CompositeNode Parent { get; set; }

        public string GraphVizFormula
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
        public abstract void Evaluate(IVisitor c);
        public abstract bool OneInput();

        public override string ToString()
        {
            return $"Object Type: {this.GetType().Name}"
                   + $" | Data: {this.Data.ToString()}"
                   + $" | Parent: {(this.Parent?.GetType().Name) ?? "Null"}"
                   + $" | RightNode: {RightNode.GetType().Name}"
                   + $" | LeftNode: {LeftNode.GetType().Name}";
        }


        
    }
}
