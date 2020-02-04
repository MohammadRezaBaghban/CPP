using CPP.Visitable.Node;
using CPP.Visitor;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CPP.Visitable.Node;

namespace CPP
{
    public partial class Form1 : Form
    {
        Infix_Generator infixGenerator;
        FormulaParse formulaParser;
        Calculator calculator;
        Derivative derivationCalculator;
        List<int> selectedPonits;
        int countOfSelectedPoints = 0;

        CompositeNode rootOfBinaryTree;
        Visitable.Node.Component derivation;
        public Form1()
        {
            InitializeComponent();
            selectedPonits = new List<int>();
            formulaParser = new FormulaParse();
            infixGenerator = new Infix_Generator();
            calculator = new Calculator();
            derivationCalculator = new Derivative(new BinaryTree(),new Calculator());


            // Adding Horizontal and Vertical Seperator to Chart
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                IsMerged = true,
                Separator = new Separator
                {
                    StrokeThickness = 2,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(new double[] { 1 }),
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
                }
            });
            cartesianChart1.AxisY.Add(new Axis
            {
                IsMerged = true,
                Separator = new Separator
                {
                    StrokeThickness = 2,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(new double[] { 1 }),
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
                }
            });
            cartesianChart1.DisableAnimations = true;
            cartesianChart1.Zoom = ZoomingOptions.X;
            cartesianChart1.LegendLocation = LegendLocation.Top;
            
        }

        //Methods & Functions
        private void BtnParseRecursively_Click(object sender, EventArgs e)
        {

            rootOfBinaryTree = parseTheFormula(TbPrefixFormula.Text.Trim());

            if (rootOfBinaryTree != null)
            {
                infixGenerator.Calculate(rootOfBinaryTree);
                calculator.Calculate(rootOfBinaryTree);
                GenerateBinaryGraph(rootOfBinaryTree.GraphVizFormula,PbBinaryGraphRoot);
                LInfixFourmula.Text = rootOfBinaryTree.InFixFormula + " = " + $"{rootOfBinaryTree.Data:F3}";

                if (rootOfBinaryTree.InFixFormula.Contains("Exp") ||
                    rootOfBinaryTree.InFixFormula.Contains("!") 
                    )
                {
                    // To avoid OverFlow Exception
                    DrawGraphOnCanvas(rootOfBinaryTree, 10);
                }
                else if (rootOfBinaryTree.InFixFormula.Contains("Ln"))
                {
                    DrawGraphOnCanvas_PositiveDomain(rootOfBinaryTree, 200);

                }
                else
                {
                    DrawGraphOnCanvas(rootOfBinaryTree, 200);
                }

            }

        }

        public void GenerateBinaryGraph(string input,PictureBox pb)
        {
            string text = @"graph calculus {" + "\nnode[fontname = \"Arial\"]\n" + input + "\n" + "}";

            using (FileStream fs = new FileStream("ab.dot", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(text);
                }
            }

            if (File.Exists("ab.dot"))
            {
                Process dot = new Process();
                dot.StartInfo.FileName = "dot.exe";
                dot.StartInfo.Arguments = "-Tpng -oab.png ab.dot";
                dot.Start();
                dot.WaitForExit();
                pb.ImageLocation = "ab.png";
            }
            else
            {
                MessageBox.Show("File was not created successfullu");
            }
        }

        public void DrawGraphOnCanvas(Visitable.Node.Component root, int length)
        {
            var Function_Values = CalculateGraphPoints(calculator.Calculate(root, length));

            var graphLine = new LineSeries{
                Title = $"{root.InFixFormula}",
                Values = Function_Values,
                StrokeThickness = 3,
                PointGeometrySize = 1,
                Focusable = true,
                ForceCursor = true,
                Tag = Function_Values,
                //The Area Under the Graph
                Fill = System.Windows.Media.Brushes.Transparent,
            };
            cartesianChart1.Series.Add(graphLine);

        }

        public void DrawGraphOnCanvas_PositiveDomain(Visitable.Node.Component root, int length)
        {
            var Function_Values = CalculateGraphPoints(calculator.Calculate_PositiveDomain(root, length));

            var graphLine = new LineSeries
            {
                Title = $"{root.InFixFormula}",
                Values = Function_Values,
                StrokeThickness = 3,
                PointGeometrySize = 1,
                Focusable = true,
                ForceCursor = true,
                Tag = Function_Values,
                //The Area Under the Graph
                Fill = System.Windows.Media.Brushes.Transparent,
            };         

            cartesianChart1.Series.Add(graphLine);

        }

        public CompositeNode parseTheFormula(string formula)
        {
            if (formula.Length < 4)
            {
                MessageBox.Show("Please Enter a correct input");
                TbPrefixFormula.Text = "";
                return null;
            }
            else
            {
                formulaParser.EraseParsedList();

                formulaParser.ParseInputRecursively(ref formula);
                var list = formulaParser.GetParsedList();

                return formulaParser.Convert_ParsedList_To_BinaryTree(list);
            }
        }

        public ChartValues<ObservablePoint> CalculateGraphPoints(Dictionary<decimal, decimal> values)
        {
            var Function_Values = new ChartValues<ObservablePoint>();
            foreach (KeyValuePair<decimal, decimal> coordinate in values)
            {
                Function_Values.Add(new ObservablePoint(Convert.ToDouble(coordinate.Key), Convert.ToDouble(coordinate.Value)));
            }
            return Function_Values;
        }


        //Event Handlers
        private void BtnClearPlot_Click(object sender, EventArgs e)
        {
            cartesianChart1.Series.Clear();
        }

        private void Btn_Analytical_Derivation_Click(object sender, EventArgs e)
        {
            derivationCalculator.Calculate(rootOfBinaryTree);
            derivation = rootOfBinaryTree.Derivation;
            BinaryTree.Simplify(ref derivation, ref derivation.Parent);
            BinaryTree.Simplify(ref derivation, ref derivation.Parent);

            infixGenerator.Calculate(derivation);
            GenerateBinaryGraph(derivation.GraphVizFormula,PbBinaryGraphSecondary);

            if (derivation.InFixFormula.Contains("Exp") || derivation.InFixFormula.Contains("!"))
            {
                //To avoid OverFlow Exception
                DrawGraphOnCanvas(derivation, 10);
            }else if (derivation.InFixFormula.Contains("Ln"))
            {
                DrawGraphOnCanvas_PositiveDomain(derivation, 200);
            }
            else
            {
                DrawGraphOnCanvas(derivation, 200);
            }
        }

        private void Btn_NewtonDerivation_Click(object sender, EventArgs e)
        {
            var Function_Values = new ChartValues<ObservablePoint>();

            if (rootOfBinaryTree.InFixFormula.Contains("Exp") || rootOfBinaryTree.InFixFormula.Contains("!"))
            {
                Function_Values = CalculateGraphPoints(calculator.CalculateByNewton(rootOfBinaryTree, 10));
            }
            else if (rootOfBinaryTree.InFixFormula.Contains("Ln"))
            {
                Function_Values = CalculateGraphPoints(calculator.CalculateByNewton_PositiveDomain(rootOfBinaryTree, 200));
            }
            else
            {
                Function_Values = CalculateGraphPoints((calculator.CalculateByNewton(rootOfBinaryTree, 200)));
            }

            var graphLine = new LineSeries
            {
                Title = $"DerivationByNewton",
                Values = Function_Values,
                StrokeThickness = 3,
                PointGeometrySize = 1,
                Focusable = true,
                ForceCursor = true,
                Tag = Function_Values,
                //The Area Under the Graph
                Fill = System.Windows.Media.Brushes.Transparent,
            };

            cartesianChart1.Series.Add(graphLine);
        }     

        private void BtnRiemannIntegral_Click(object sender, EventArgs e)
        {
            if (rootOfBinaryTree == null)
            {
                MessageBox.Show("Please parse a valid function fisrt");
            }
            else
            {
                if (countOfSelectedPoints == 0)
                {
                    LblStartingPoint.Text = $"X1: ";
                    LblEndingPoint.Text = $"X2: ";
                    cartesianChart1.DataClick += cartesianChart1_DataClick;
                    MessageBox.Show("Select two point from the graph");
                }             
            }
        }

        private void cartesianChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            if(countOfSelectedPoints == 0)
            {
                selectedPonits.Add(Convert.ToInt32(chartPoint.X));
                LblStartingPoint.Text = $"X1: {Convert.ToInt32(chartPoint.X)}";
                countOfSelectedPoints++;
            }else if(countOfSelectedPoints == 1)
            {
                selectedPonits.Add(Convert.ToInt32(chartPoint.X));
                LblEndingPoint.Text = $"X2: {Convert.ToInt32(chartPoint.X)}";
                countOfSelectedPoints++;
            }

            if (countOfSelectedPoints == 2)
            {
                cartesianChart1.DataClick -= cartesianChart1_DataClick;
                var Function_Values = CalculateGraphPoints(calculator.CalculateByRange(rootOfBinaryTree, selectedPonits[0], selectedPonits[1]));

                decimal areaUnderGraph = 0m;
                foreach(var point in Function_Values)
                {
                    areaUnderGraph += Convert.ToDecimal(point.Y);
                }

                var graphLine = new LineSeries
                {
                    Title = $"Riemann Integral",
                    Values = Function_Values,
                    StrokeThickness = 3,
                    PointGeometrySize = 1,
                    Focusable = true,
                    ForceCursor = true,
                    Tag = Function_Values,                    
                    //The Area Under the Graph
                    AreaLimit = 0,
                };
                LblRiemannArea.Visible = true;
                LblRiemannArea.Text = $"Area: {areaUnderGraph:F3}";
                cartesianChart1.Series.Add(graphLine);
                countOfSelectedPoints = 0;
            }

        }

        private void BtnMaclaurinSeries_Click(object sender, EventArgs e)
        {
            if (rootOfBinaryTree == null)
            {
                MessageBox.Show("Please parse a valid function fisrt");
            }
            else
            {
                var maclaurinFunctions = derivationCalculator.MaclaurinSeries(rootOfBinaryTree);

                List<ChartValues<ObservablePoint>> listOfcharValues = new List<ChartValues<ObservablePoint>>();
                for (int i = 0; i < 9; i++)
                {
                    if (maclaurinFunctions[i].GraphVizFormula.Contains("Exp") || maclaurinFunctions[i].GraphVizFormula.Contains("!"))
                    {
                        //To avoid OverFlow Exception
                        listOfcharValues.Add(CalculateGraphPoints(calculator.Calculate(maclaurinFunctions[i], 10)));
                    }
                    else if (maclaurinFunctions[i].GraphVizFormula.Contains("Ln"))
                    {
                        listOfcharValues.Add(CalculateGraphPoints(calculator.Calculate_PositiveDomain(maclaurinFunctions[i], 200)));
                    }
                    else
                    {
                        listOfcharValues.Add(CalculateGraphPoints(calculator.Calculate(maclaurinFunctions[i], 200)));
                    }
                }

                List<LineSeries> lineSeries = new List<LineSeries>();
                for (int i = 0; i < 9; i++)
                {
                    var graphLine = new LineSeries
                    {
                        Title = $"Maclaurin Degree-{i+1}",
                        Values = listOfcharValues[i],
                        StrokeThickness = 3,
                        PointGeometrySize = 1,
                        Focusable = true,
                        ForceCursor = true,
                        Tag = listOfcharValues[i],
                        //The Area Under the Graph
                        Fill = System.Windows.Media.Brushes.Transparent,
                    };
                    lineSeries.Add(graphLine);
                }

                cartesianChart1.Series.AddRange(lineSeries);
                GenerateBinaryGraph(maclaurinFunctions[maclaurinFunctions.Count - 1].GraphVizFormula, PbBinaryGraphSecondary);
            }
        }
    }


}
