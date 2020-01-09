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
        public void TraverseForCalculate(IMathematicalOperation visitable)
        {
            throw new NotImplementedException();
        }

        public void Visit(AddOperator visitable)
        {
            throw new NotImplementedException();
        }

        public void Visit(SubstracOperator visitable)
        {
            throw new NotImplementedException();
        }

        public void Visit(MultipicationOperator visitable)
        {
            throw new NotImplementedException();
        }

        public void Visit(DivisionOperator visitable)
        {
            throw new NotImplementedException();
        }

        public void Visit(PowerOperator visitable)
        {
            throw new NotImplementedException();
        }

        public void Visit(FactorialFunc visitable)
        {
            throw new NotImplementedException();
        }

        public void Visit(ExponentialFun visitable)
        {
            throw new NotImplementedException();
        }

        public void Visit(SinFunc visitable)
        {
            throw new NotImplementedException();
        }

        public void Visit(CosFunc visitable)
        {
            throw new NotImplementedException();
        }

        public void Visit(TanFunc visitable)
        {
            throw new NotImplementedException();
        }
    }
}
