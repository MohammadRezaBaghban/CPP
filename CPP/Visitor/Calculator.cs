using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPP.Functions;
using CPP.Operations;
using CPP.Tree__Visitable___Composite_Component_.Functions;
using CPP.Visitable.Node;
using CPP.Visitor;

namespace CPP.Visitor
{
    class Calculator : IVisitor
    {
        decimal coordinateValue = 10;

        public Dictionary<decimal, decimal> Calculate(IMathematicalOperation visitable,int lastX)
        {
            Dictionary<decimal, decimal> graphValues = new Dictionary<decimal, decimal>();

            var MaximumX = lastX / 2;
            var MinimumX = -MaximumX;

            for (int current_X_value = MinimumX; current_X_value <= MaximumX; current_X_value++)
            {                
                coordinateValue = current_X_value;
                Calculate(visitable);
                graphValues.Add(current_X_value,visitable.Data);
            }

            coordinateValue = 10;
            return graphValues;

        }

        public Dictionary<decimal, decimal> Calculate_PositiveDomain(IMathematicalOperation visitable, int lastX)
        {
            Dictionary<decimal, decimal> graphValues = new Dictionary<decimal, decimal>();

            var MaximumX = lastX / 2;
            var MinimumX = 1;

            for (int current_X_value = MinimumX; current_X_value <= MaximumX; current_X_value++)
            {
                coordinateValue = current_X_value;
                Calculate(visitable);
                graphValues.Add(current_X_value, visitable.Data);
            }

            coordinateValue = 10;
            return graphValues;

        }

        public Dictionary<decimal, decimal> CalculateByRange(IMathematicalOperation visitable, int firstX,int lastX)
        {
            Dictionary<decimal, decimal> graphValues = new Dictionary<decimal, decimal>();

            var MinimumX = firstX;
            var MaximumX = lastX;

            for (int current_X_value = MinimumX; current_X_value <= MaximumX; current_X_value++)
            {
                coordinateValue = current_X_value;
                Calculate(visitable);
                graphValues.Add(current_X_value, visitable.Data);
            }

            coordinateValue = 10;
            return graphValues;

        }

        public Dictionary<decimal, decimal> CalculateByNewton_PositiveDomain(IMathematicalOperation visitable, int lastX)
        {
            Dictionary<decimal, decimal> graphValues = new Dictionary<decimal, decimal>();

            var MaximumX = lastX / 2;
            var MinimumX = 1;

            for (int current_X_value = MinimumX; current_X_value <= MaximumX; current_X_value++)
            {
                coordinateValue = current_X_value;
                Calculate(visitable);
                var fxValue = visitable.Data;

                coordinateValue = current_X_value + 2;
                Calculate(visitable);
                var fxhValue = visitable.Data;

                var newtonDiff = (fxhValue - fxValue) / 2;

                graphValues.Add(current_X_value + 1, newtonDiff);
            }

            coordinateValue = 10;
            return graphValues;

        }
        
        public Dictionary<decimal, decimal> CalculateByNewton(IMathematicalOperation visitable, int lastX)
        {
            Dictionary<decimal, decimal> graphValues = new Dictionary<decimal, decimal>();

            var MaximumX = lastX / 2;
            var MinimumX = -MaximumX;

            for (int current_X_value = MinimumX; current_X_value <= MaximumX; current_X_value++)
            {
                coordinateValue = current_X_value;
                Calculate(visitable);
                var fxValue = visitable.Data;

                coordinateValue = current_X_value+2;
                Calculate(visitable);
                var fxhValue = visitable.Data;

                var newtonDiff = (fxhValue - fxValue) / 2;

                graphValues.Add(current_X_value+1, newtonDiff);
            }

            coordinateValue = 10;
            return graphValues;

        }



        public void Calculate(IMathematicalOperation visitable)
        {
            SingleNode single = visitable as SingleNode;
            if (single != null)
            {             
                if (single.IsVariable)
                {
                    single.Data = coordinateValue;
                }
            }
            else
            {
                CompositeNode compositeNode = visitable as CompositeNode;
                if (compositeNode is Function)
                {
                    Calculate(compositeNode.LeftNode);
                    compositeNode.Evaluate(this);
                }
                else
                {

                    Calculate(compositeNode.LeftNode);
                    Calculate(compositeNode.RightNode);
                    visitable.Evaluate(this);
                }
            }
        }

        public void Visit(AddOperator visitable) => visitable.Data = visitable.LeftNode.Data + visitable.RightNode.Data;

        public void Visit(SubstractOperator visitable) => visitable.Data = visitable.LeftNode.Data - visitable.RightNode.Data;

        public void Visit(MultiplicationOperator visitable) => visitable.Data = visitable.LeftNode.Data * visitable.RightNode.Data;

        public void Visit(DivisionOperator visitable)
        {
            if (visitable.RightNode.Data == 0)
            {
                visitable.Data = visitable.LeftNode.Data / 0.1m;
            }
            else
            {
                visitable.Data = visitable.LeftNode.Data / visitable.RightNode.Data;
            }
            
        }

        public void Visit(PowerOperator visitable) => visitable.Data = Convert.ToDecimal(Math.Pow(Convert.ToDouble(visitable.LeftNode.Data), Convert.ToDouble(visitable.RightNode.Data)));

        public void Visit(ExponentialFun visitable) => visitable.Data = Convert.ToDecimal(Math.Exp(Convert.ToDouble(visitable.LeftNode.Data)));

        public void Visit(LogarithmFunc visitable) => visitable.Data = Convert.ToDecimal(Math.Log10(Convert.ToDouble(visitable.LeftNode.Data)));


        public void Visit(SinFunc visitable) => visitable.Data = Convert.ToDecimal(Math.Sin(Convert.ToDouble(visitable.LeftNode.Data) * Math.PI/180));

        public void Visit(CosFunc visitable) => visitable.Data = Convert.ToDecimal(Math.Cos(Convert.ToDouble(visitable.LeftNode.Data) * Math.PI/180));

        public void Visit(TanFunc visitable) => visitable.Data = Convert.ToDecimal(Math.Tan(Convert.ToDouble(visitable.LeftNode.Data) * Math.PI/180));

        public void Visit(FactorialFunc visitable)
        {
            int factorial = 1;
            for (int i = 1; i <= visitable.LeftNode.Data; i++)
            {
                factorial *= i;
            }
            visitable.Data = factorial;


        }

    }
}
