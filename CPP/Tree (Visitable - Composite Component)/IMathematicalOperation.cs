using CPP.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP
{
    public interface IMathematicalOperation 
    {
        double evaluate(IVisitor visitor);

        double Data { get; set; }
    }
}
