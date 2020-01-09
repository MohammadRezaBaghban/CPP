using CPP.Functions;
using CPP.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Visitor
{
    public interface IVisitor
    {
        double TraverseForCalculate(IMathematicalOperation visitable);

        double Visit(AddOperator visitable);

        double Visit(SubstracOperator visitable);

        double Visit(MultipicationOperator visitable);

        double Visit(DivisionOperator visitable);

        double Visit(PowerOperator visitable);

        double Visit(FactorialFunc visitable);

        double Visit(ExponentialFun visitable);

        double Visit(SinFunc visitable);

        double Visit(CosFunc visitable);

        double Visit(TanFunc visitable);
    }
    
}

