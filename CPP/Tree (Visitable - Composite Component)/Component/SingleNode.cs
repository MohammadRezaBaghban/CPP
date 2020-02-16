using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Visitable.Node;
using CPP.Visitor;

namespace CPP.Visitable.Node
{
    [DebuggerDisplay("{ToString, nq}")]
    public class SingleNode : Component
    {

        //Fields
        public bool IsVariable;
        public override string GraphVizFormula {
            get => $"node{NodeNumber} [ label = \"{Symbol}\" ]";         
        }

        //Constructors
        public SingleNode(Component parent) =>
            (Parent, IsVariable, InFixFormula, Symbol, NodeNumber) = (parent, true, "x", "x", ++FormulaParse.nodeCounter);
        
        public SingleNode(Component parent, decimal data) =>
            (Parent, Data, Symbol, NodeNumber) = (parent, data, data.ToString(), ++FormulaParse.nodeCounter);
        
        //Methods
        public override void Evaluate(IVisitor visitor)
        {

        }

        public void Derivative(IVisitor visitor)
        {
            
        }

        public override string ToString() => IsVariable ? $"Variable X" : $"Number {Data}";              
    }
}
