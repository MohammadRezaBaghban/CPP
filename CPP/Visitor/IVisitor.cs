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
        void TraverseForCalculate(IMathematicalOperation visitable);

        void Visit(AddOperator visitable);

        void Visit(SubstracOperator visitable);

        void Visit(MultipicationOperator visitable);

        void Visit(DivisionOperator visitable);

        void Visit(PowerOperator visitable);

        void Visit(FactorialFunc visitable);

        void Visit(ExponentialFun visitable);

        void Visit(SinFunc visitable);

        void Visit(CosFunc visitable);

        void Visit(TanFunc visitable);
    }
    
}

