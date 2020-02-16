using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Visitor;

namespace CPP.Operations
{
    public class AddOperator : Operation
    {
        public AddOperator() => Symbol = "+";

        public override void Evaluate(IVisitor c) => c.Visit(this);        
    }
}
