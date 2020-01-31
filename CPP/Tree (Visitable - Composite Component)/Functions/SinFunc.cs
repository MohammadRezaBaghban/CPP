using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Visitable.Node;
using CPP.Visitor;

namespace CPP.Functions
{
    public class SinFunc : Function
    {
        public SinFunc()
        {
            Symbol = "Sin";
        }

        public override void Evaluate(IVisitor c)
        {
            c.Visit(this);
        }
    }
}
