using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Functions;
using CPP.Operations;

namespace CPP.Visitor
{
    public class Infix_Generator : IVisitor
    {
        public double TraverseForCalculate(IMathematicalOperation visitable)
        {
            throw new NotImplementedException();
        }

        public double Visit(AddOperator visitable)
        {
            throw new NotImplementedException();
        }

        public double Visit(SubstracOperator visitable)
        {
            throw new NotImplementedException();
        }

        public double Visit(MultipicationOperator visitable)
        {
            throw new NotImplementedException();
        }

        public double Visit(DivisionOperator visitable)
        {
            throw new NotImplementedException();
        }

        public double Visit(PowerOperator visitable)
        {
            throw new NotImplementedException();
        }

        public double Visit(FactorialFunc visitable)
        {
            throw new NotImplementedException();
        }

        public double Visit(ExponentialFun visitable)
        {
            throw new NotImplementedException();
        }

        public double Visit(SinFunc visitable)
        {
            throw new NotImplementedException();
        }

        public double Visit(CosFunc visitable)
        {
            throw new NotImplementedException();
        }

        public double Visit(TanFunc visitable)
        {
            throw new NotImplementedException();
        }
    }
}
