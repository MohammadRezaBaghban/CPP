using CPP.Visitor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPP
{
    public partial class Form1 : Form
    {
        FormulaParse fp;
        public Form1()
        {
            InitializeComponent();
            fp = new FormulaParse();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var input = TbText.Text.Trim();
            //if (input.Length < 4)
            //{
            //    MessageBox.Show("Please Enter a correct input");
            //    TbText.Text = "";
            //}
            //else
            //{
            //    MessageBox.Show(fp.CreateTree(input).ToString());

            //}
        }

        private void BtnParseRecursively_Click(object sender, EventArgs e)
        {
            var input = TbPrefixFormula.Text.Trim();

            if (input.Length < 4)
            {
                MessageBox.Show("Please Enter a correct input");
                TbPrefixFormula.Text = "";
            }
            else
            {

                LBContainingElement.Items.Clear();
                fp.EraseParsedList();
                fp.ParseInputRecursively(ref input);
                var list = fp.GetParsedList();
                foreach(var i in list)
                {
                    LBContainingElement.Items.Add(i);
                }
                
                var rootOfBinaryTree = fp.Convert_ParsedList_To_BinaryTree(list);



                var calculator = new Calculate();
                var infixGenerator = new Infix_Generator();

                infixGenerator.TraverseForCalculate(rootOfBinaryTree);
                calculator.TraverseForCalculate(rootOfBinaryTree);

                LBContainingElement.Items.Add("=");
                LBContainingElement.Items.Add(rootOfBinaryTree.Data);
                TbInfixFourmula.Text = rootOfBinaryTree.InFixFormula;

            }
        }
    }


}
