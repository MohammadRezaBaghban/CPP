using CPP.Functions;
using CPP.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Tree__Visitable___Composite_Component_.Functions
{
    public class LogarithmFunc : Function
    {
        public LogarithmFunc()
        {
            Symbol = "Ln";
        }

        public override void Evaluate(IVisitor c)
        {
            c.Visit(this);
        }

    }
}
