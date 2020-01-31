using CPP.Visitable.Node;
using CPP.Visitor;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace CPP
{
    public partial class Form1 : Form
    {
        Infix_Generator infixGenerator;
        FormulaParse formulaParser;
        Calculate calculator;
        CompositeNode rootOfBinaryTree;
        public Form1()
        {
            InitializeComponent();
            formulaParser = new FormulaParse();
            infixGenerator = new Infix_Generator();
            calculator = new Calculate();

            //cartesianChart1.Series.Clear();
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

                if (LInfixFourmula.Text.Contains("Exp"))
                {
                    // To avoid OverFlow Exception
                    DrawGraphOnCanvas(10);
                }
                else
                {
                    DrawGraphOnCanvas(1000);
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

        public void DrawGraphOnCanvas(int length)
        {
            Dictionary<decimal, decimal> graphCoordinates = calculator.TraverseForCalculate(rootOfBinaryTree, length);

            var Function_Values = new ChartValues<ObservablePoint>();
            var Vertical_YLine = new ChartValues<ObservablePoint>();
            var Horizontal_XLine = new ChartValues<ObservablePoint>();

            //Add the coordinate of function to Chart value of Graph in order to show them
            foreach (KeyValuePair<decimal, decimal> coordinate in graphCoordinates)
            {
                Function_Values.Add(new ObservablePoint(Convert.ToDouble(coordinate.Key), Convert.ToDouble(coordinate.Value)));
                Vertical_YLine.Add(new ObservablePoint(0, Convert.ToDouble(coordinate.Value)));
                Horizontal_XLine.Add(new ObservablePoint(Convert.ToDouble(coordinate.Key), 0));

            }
            cartesianChart1.Series = new LiveCharts.SeriesCollection()
            {
                new LineSeries
                {
                    Title = $"{rootOfBinaryTree.InFixFormula}",
                    Values = Function_Values,
                    StrokeThickness = 3,
                    PointGeometrySize = 1,
                    Focusable = true,
                    ForceCursor = true,
                    Tag = graphCoordinates,
                    //The Area Under the Graph
                    Fill = System.Windows.Media.Brushes.Transparent,


                },


                new ColumnSeries
                {
                    Title = "",
                    Values = new ChartValues<decimal> { Convert.ToInt64(graphCoordinates.Values.Max()) },
                    Fill = System.Windows.Media.Brushes.Transparent,
                },   
        };



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

        public void GenerateBinaryGraph(string input)
        {
            string text = @"graph calculus {" + "\nnode[fontname = \"Arial\"]\n" + input + "\n"+ "}";
            
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

         
    }


}
