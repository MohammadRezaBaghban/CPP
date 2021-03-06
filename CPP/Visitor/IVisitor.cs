﻿using CPP.Functions;
using CPP.Operations;
using CPP.Tree__Visitable___Composite_Component_.Functions;
using CPP.Visitable.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP.Visitor
{
    public interface IVisitor
    {
        void Calculate(Component visitable);

        void Visit(AddOperator visitable);

        void Visit(SubstractOperator visitable);

        void Visit(MultiplicationOperator visitable);

        void Visit(DivisionOperator visitable);

        void Visit(PowerOperator visitable);

        void Visit(FactorialFunc visitable);

        void Visit(ExponentialFun visitable);

        void Visit(SinFunc visitable);

        void Visit(CosFunc visitable);

        void Visit(TanFunc visitable);

        void Visit(LogarithmFunc visitable);
    }
    
}

