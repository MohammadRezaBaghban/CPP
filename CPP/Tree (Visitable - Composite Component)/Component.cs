﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Visitor;

namespace CPP.Visitable.Node
{
    public interface Component : IMathematicalOperation
    {
        CompositeNode Parent { get; set; }

        decimal Data { get; set; }

        string InFixFormula { get; set; }


    }
}
