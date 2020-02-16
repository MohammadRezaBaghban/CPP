using CPP.Visitable.Node;
using CPP.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Functions
{
    public class ExponentialFun : Function
    {
        public ExponentialFun() => Symbol = "Exp";

        public override void Evaluate(IVisitor c) => c.Visit(this);
    }
}
