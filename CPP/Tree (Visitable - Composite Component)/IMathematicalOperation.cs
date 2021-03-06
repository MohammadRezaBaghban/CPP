﻿using CPP.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP
{
    public interface IMathematicalOperation 
    {
        void Evaluate(IVisitor visitor);

        decimal Data { get; set; }

        string Symbol { get; set; }
    }
}
