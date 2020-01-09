using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Functions;
using CPP.Operations;
using CPP.Visitor;

namespace CPP.Visitable.Node
{
    public abstract class CompositeNode : Component
    {
        //Fields
        public IMathematicalOperation operatorType;             
        public Component LeftNode;
        public Component RightNode;

        public double Data { get; set; }
        public CompositeNode Parent { get; set; }

        //Methods
        public abstract void Evaluate(IVisitor c);
        public abstract bool OneInput();

    }
}
