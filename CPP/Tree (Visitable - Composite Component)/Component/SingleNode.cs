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
        public override string GraphVizFormula{
            get{                
                return $"node{NodeNumber} [ label = \"{Symbol}\" ]";
            }           
        }

        //Constructors
        public SingleNode(Component parent)
        {
            Parent = parent;
            IsVariable = true;
            InFixFormula = "x";
            Symbol = InFixFormula;
            NodeNumber = ++FormulaParse.nodeCounter;
        }
        public SingleNode(Component parent, decimal data)
        {
            Parent = parent;
            Data = data;
            InFixFormula = $"{data}";
            Symbol = InFixFormula;            
            NodeNumber = ++FormulaParse.nodeCounter;

        }


        //Methods
        public override void Evaluate(IVisitor visitor)
        {

        }

        public void Derivative(IVisitor visitor)
        {
            
        }

        public override string ToString()
        {
            if (IsVariable)
            {
                return $"Variable X";
            }
            else
            {
                return $"Number {Data}";
            }
                          
        }

        

       
    }
}
