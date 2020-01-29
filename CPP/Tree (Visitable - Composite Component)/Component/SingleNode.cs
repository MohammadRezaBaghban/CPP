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
        
        public bool IsVariable;
        public decimal Data { get; set; }
        public string InFixFormula { get; set; }

        public CompositeNode Parent { get; set; }
        

        public SingleNode(CompositeNode parent)
        {
            Parent = parent;
            IsVariable = true;
            InFixFormula = "x";
        }

        public SingleNode(CompositeNode parent, decimal data)
        {
            Parent = parent;
            Data = data;
            InFixFormula = $"{data}";

        }

        public void Evaluate(IVisitor visitor)
        {
        }

        public override string ToString()
        {
            return $"Object Type: {this.GetType().Name}"
                   + $" | Data: {this.Data.ToString()}"
                   + $" | Parent: {(this.Parent.GetType().Name)??"Null"}"
                   ;
        }

    }
}
