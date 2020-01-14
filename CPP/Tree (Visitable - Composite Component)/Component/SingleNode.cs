using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Visitable.Node;
using CPP.Visitor;

namespace CPP.Visitable.Node
{
    public class SingleNode : Component
    {
        
        public bool IsVariable;
        public double Data { get; set; }
        public string InFixFormula { get; set; }

        public CompositeNode Parent { get; set; }
        

        public SingleNode(CompositeNode parent)
        {
            Parent = parent;
            IsVariable = true;
            InFixFormula = "x";
        }

        public SingleNode(CompositeNode parent, double data)
        {
            Parent = parent;
            Data = data;
            InFixFormula = $"{data}";

        }

        public void Evaluate(IVisitor visitor)
        {
        }
    }
}
