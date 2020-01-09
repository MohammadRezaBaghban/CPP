using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Visitable.Node;
using CPP.Visitor;

namespace CPP.Functions
{
    public abstract class Function : CompositeNode
    {        
        public override bool OneInput() => true;
    }
}
