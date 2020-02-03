﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Visitable.Node;
using CPP.Visitor;

namespace CPP.Visitable.Node
{
    [DebuggerDisplay("{ToString, nq}")]
    public class SingleNode : Component
    {

        //Fields
        public bool IsVariable;
        public int NodeNumber { get; set;}
        public decimal Data { get; set; }
        public string Symbol { get; set; }
        public string InFixFormula { get; set; }
        public string GraphVizFormula => $"node{NodeNumber} [ label = \"{Symbol}\" ]";
        public Component Derivation { get; set; }
        public CompositeNode Parent { get; set; }

        //Constructors
        public SingleNode(CompositeNode parent)
        {
            Parent = parent;
            IsVariable = true;
            InFixFormula = "x";
            Symbol = InFixFormula;
            NodeNumber = ++FormulaParse.nodeCounter;
        }
        public SingleNode(CompositeNode parent, decimal data)
        {
            Parent = parent;
            Data = data;
            InFixFormula = $"{data}";
            Symbol = InFixFormula;            
            NodeNumber = ++FormulaParse.nodeCounter;

        }


        //Methods
        public void Evaluate(IVisitor visitor)
        {
        }
        public void Derivative(IVisitor visitor)
        {
            
        }
        public void IncreaseNodeNumber() =>  NodeNumber = ++FormulaParse.nodeCounter;
        public override string ToString()
        {
            if (IsVariable)
            {
                return $"Variable X";
            }
            else
            {
                return $"Number {Data}";
            }
                          
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
