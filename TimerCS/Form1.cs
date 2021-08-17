using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerCS
{
    public partial class Form1 : Form
    {
        NumericUpDown[] numerics;
        Label[] labels;
        Button starter;
        Timer timer;

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init(){
            numerics = new NumericUpDown[3];
            labels = new Label[3];

            for (int i = 0; i < 3; i++){
                NumericUpDown n = new NumericUpDown();
                n.Minimum = 0;
                n.Maximum = 60;
                n.Location = new Point( 50 , 8 + i * 30);
                numerics[i] = n;

                Label l = new Label();
                l.Location = new Point( 3 + i * 2 , 10 + i * 30);
                labels[i] = l;

                this.Controls.Add(numerics[i]);
                this.Controls.Add(labels[i]);

            }

            labels[0].Text = "Hours" ;
            labels[1].Text = "Mins" ;
            labels[2].Text = "Secs" ;

            

        }

    }
}
