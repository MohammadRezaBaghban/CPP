using CPP.Visitable.Node;
using CPP.Visitor;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                LInfixFourmula.Text = rootOfBinaryTree.InFixFormula + " = " + rootOfBinaryTree.Data.ToString();
                
                if (LInfixFourmula.Text.Contains("Exp"))
                {
                    DrawGraphOnCanvas(10);
                }
                else
                {
                    DrawGraphOnCanvas(500);
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

            var values = new ChartValues<ObservablePoint>();
            foreach (KeyValuePair<decimal, decimal> coordinate in graphCoordinates)
            {
                values.Add(new ObservablePoint(Convert.ToDouble(coordinate.Key), Convert.ToDouble(coordinate.Value)));

            }

            cartesianChart1.Series = new LiveCharts.SeriesCollection()
            {
                new LineSeries
                {
                    Title = $"{rootOfBinaryTree.InFixFormula}",
                    Values = values,
                    PointGeometrySize = 1,
                    Focusable = true,
                    ForceCursor = true,
                    Tag = graphCoordinates,
                    //The Area Under the Graph
                    Fill = System.Windows.Media.Brushes.Transparent,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection {2},
                    
                },
                new ColumnSeries
                {
                    Values = new ChartValues<decimal> { Convert.ToInt64(graphCoordinates.Values.Max()) },
                    Fill = System.Windows.Media.Brushes.Transparent,
                },           
            };

            cartesianChart1.LegendLocation = LegendLocation.Top;
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
