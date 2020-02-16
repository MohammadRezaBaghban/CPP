using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Visitable.Node;
using CPP.Visitor;

namespace CPP.Operations
{
    public class MultiplicationOperator : Operation
    {
        public MultiplicationOperator() => Symbol = "*";

        public override void Evaluate(IVisitor c) => c.Visit(this);
    }
}
