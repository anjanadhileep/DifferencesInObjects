using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FindDifference
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] empValues1 = new string[6];
            string[] empValues2 = new string[6];
            string[] empNames = new string[6];
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("InputXML.xml");
            XmlNodeList nodeList;
            nodeList = xmlDoc.DocumentElement.SelectNodes("employee");
            
            int j = 0;
            foreach (XmlNode employee in nodeList)
            {
                int i = 0;
                foreach(XmlNode emp in employee)
                {
                    if (j == 0)
                    {
                        empValues1[i] = emp.InnerText.ToString();
                        empNames[i] = emp.Name.ToString();
                        i++;
                    }
                    else
                    {
                        empValues2[i] = emp.InnerText.ToString();
                        i++;
                    }
                    
                }
                j++;
            }
            StringBuilder Difference = new StringBuilder();
           
            for (j = 0; j < empValues1.Length; j++)
            {
                if(!(empValues1[j].ToString().ToUpper()==empValues2[j].ToString().ToUpper()))
                {
                    Difference.Append(empNames[j].ToString() + " Value Changed from ");
                    Difference.Append(empValues1[j].ToString());
                    Difference.Append(" to ");
                    Difference.Append(empValues2[j].ToString());
                    Difference.Append("           ");
                    Difference.Append("\n\n");
                    
                }
            }
            Label lbl = new Label();
            lbl.Width = 700;
            lbl.Height = 200;
            lbl.Text = Difference.ToString();
            panel1.Controls.Add(lbl);
            panel1.Visible = true;
            ValueDiff.Visible = true;
            lbl.Visible = true;
        }
    }
}
