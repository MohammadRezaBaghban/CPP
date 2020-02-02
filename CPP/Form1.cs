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
        Calculate calculator;
        Derivative derivationCalculator;

        CompositeNode rootOfBinaryTree;
        Visitable.Node.Component derivation;
        public Form1()
        {
            InitializeComponent();
            formulaParser = new FormulaParse();
            infixGenerator = new Infix_Generator();
            calculator = new Calculate();
            derivationCalculator = new Derivative(new BinaryTree());


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


        private void BtnParseRecursively_Click(object sender, EventArgs e)
        {

            rootOfBinaryTree = parseTheFormula(TbPrefixFormula.Text.Trim());

            if (rootOfBinaryTree != null)
            {
                infixGenerator.TraverseForCalculate(rootOfBinaryTree);
                calculator.TraverseForCalculate(rootOfBinaryTree);
                GenerateBinaryGraph(rootOfBinaryTree.GraphVizFormula);
                LInfixFourmula.Text = rootOfBinaryTree.InFixFormula + " = " + rootOfBinaryTree.Data.ToString();

                if (LInfixFourmula.Text.Contains("Exp") ||
                    LInfixFourmula.Text.Contains("!") 
                    )
                {
                    // To avoid OverFlow Exception
                    DrawGraphOnCanvas(rootOfBinaryTree, 10);
                }
                else if (LInfixFourmula.Text.Contains("Ln"))
                {
                    DrawGraphOnCanvas_PositiveDomain(rootOfBinaryTree, 1000);

                }
                else
                {
                    DrawGraphOnCanvas(rootOfBinaryTree, 1000);
                }

            }

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

        public void DrawGraphOnCanvas(Visitable.Node.Component root, int length)
        {
            Dictionary<decimal, decimal> graphCoordinates = calculator.TraverseForCalculate(root, length);

            var Function_Values = new ChartValues<ObservablePoint>();

            //Add the coordinate of function to Chart value of Graph in order to show them
            foreach (KeyValuePair<decimal, decimal> coordinate in graphCoordinates)
            {
                Function_Values.Add(new ObservablePoint(Convert.ToDouble(coordinate.Key), Convert.ToDouble(coordinate.Value)));

            }
            var graphLine = new LineSeries{
                Title = $"{root.InFixFormula}",
                Values = Function_Values,
                StrokeThickness = 3,
                PointGeometrySize = 1,
                Focusable = true,
                ForceCursor = true,
                Tag = graphCoordinates,
                //The Area Under the Graph
                Fill = System.Windows.Media.Brushes.Transparent,
            };
            var Line = new LiveCharts.SeriesCollection()
            {
                new ColumnSeries
                {
                    Title = "",
                    Values = new ChartValues<decimal> { Convert.ToInt64(graphCoordinates.Values.Max()) },
                    Fill = System.Windows.Media.Brushes.Transparent,
                },
            };

            cartesianChart1.Series.Add(graphLine);

        }


        public void DrawGraphOnCanvas_PositiveDomain(Visitable.Node.Component root, int length)
        {
            Dictionary<decimal, decimal> graphCoordinates = calculator.TraverseForCalculate_PositiveDomain(root, length);

            var Function_Values = new ChartValues<ObservablePoint>();

            //Add the coordinate of function to Chart value of Graph in order to show them
            foreach (KeyValuePair<decimal, decimal> coordinate in graphCoordinates)
            {
                Function_Values.Add(new ObservablePoint(Convert.ToDouble(coordinate.Key), Convert.ToDouble(coordinate.Value)));

            }
            var graphLine = new LineSeries
            {
                Title = $"{root.InFixFormula}",
                Values = Function_Values,
                StrokeThickness = 3,
                PointGeometrySize = 1,
                Focusable = true,
                ForceCursor = true,
                Tag = graphCoordinates,
                //The Area Under the Graph
                Fill = System.Windows.Media.Brushes.Transparent,
            };
            var Line = new LiveCharts.SeriesCollection()
            {
                new ColumnSeries
                {
                    Title = "",
                    Values = new ChartValues<decimal> { Convert.ToInt64(graphCoordinates.Values.Max()) },
                    Fill = System.Windows.Media.Brushes.Transparent,
                },
            };

            cartesianChart1.Series.Add(graphLine);

        }
        public void GenerateBinaryGraph(string input)
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
                PbBinaryGraph.ImageLocation = "ab.png";
            }
            else
            {
                MessageBox.Show("File was not created successfullu");
            }
        }

        private void CanvasPainting()
        {
            // List<Point> point = new List<Point>();
            //using (Pen dashed_pen = new Pen(Color.Black, 1))
            //{
            //    dashed_pen.DashStyle = DashStyle.Dash;  
            //    //Mark the center of Canvas
            //    g.FillEllipse(Brushes.Red, canvasCenterX-5, canvasCenterY-5, 10, 10);
            //    // Horizantal Line
            //    g.DrawLine(dashed_pen,0,canvasCenterY-1,canvasWidth,canvasCenterY-1);
            //    //Vertical Line
            //    g.DrawLine(dashed_pen, canvasCenterX, 0, canvasCenterX, canvasHeight);
            //}


            ////Scaling for the value between -1 and 1
            //if ((coordinate.Value >= 0 && coordinate.Value < 1) ||
            //    (coordinate.Value <= 0 && coordinate.Value > -1))
            //{
            //    point.Add(new Point(
            //        Convert.ToInt32(coordinate.Key) + canvasCenterX,
            //        (Convert.ToInt32(coordinate.Value * -100)) + canvasCenterY)
            //        );
            //}
            //else
            //{
            //    point.Add(new Point(Convert.ToInt32(coordinate.Key) + canvasCenterX,
            //    (Convert.ToInt32(-coordinate.Value)) + canvasCenterY));
            //}
            //g.DrawLines(brush,point.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            derivationCalculator.TraverseForCalculate(rootOfBinaryTree);
            derivation = rootOfBinaryTree.Derivation;
            infixGenerator.TraverseForCalculate(derivation);
            GenerateBinaryGraph(derivation.GraphVizFormula);

            if (derivation.InFixFormula.Contains("Exp") || LInfixFourmula.Text.Contains("!"))
            {
                //To avoid OverFlow Exception
                DrawGraphOnCanvas(derivation, 10);
            }else if (LInfixFourmula.Text.Contains("Ln"))
            {
                DrawGraphOnCanvas_PositiveDomain(derivation, 1000);

            }
            else
            {
                DrawGraphOnCanvas(derivation, 1000);
            }
        }

        private void BtnClearPlot_Click(object sender, EventArgs e)
        {
            cartesianChart1.Series.Clear();
        }
    }


}
