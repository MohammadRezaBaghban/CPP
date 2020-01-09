using CPP.Visitable.Node;
using CPP.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Operations
{
    public abstract class Operation : CompositeNode
    {
        public override bool OneInput() => false;
    }

}
