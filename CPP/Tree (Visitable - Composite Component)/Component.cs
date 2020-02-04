using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Visitor;

namespace CPP.Visitable.Node
{
    public abstract class Component : IMathematicalOperation,ICloneable
    {
        public Component Parent;

        public Component LeftNode;

        public Component RightNode;

        public Component Derivation;

        public int NodeNumber { get; set; } = ++FormulaParse.nodeCounter;

        public decimal Data { get; set; }

        public string Symbol { get; set; }

        public string InFixFormula { get; set; }

        public virtual string GraphVizFormula { get; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public abstract void Evaluate(IVisitor visitor);
    }
}
