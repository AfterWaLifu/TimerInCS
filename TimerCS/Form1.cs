using System;
using System.Drawing;
using System.Windows.Forms;

namespace TimerCS
{
    public partial class Form1 : Form
    {
        NumericUpDown[] numerics;
        Label[] labels;
        Button button;
        System.Windows.Forms.Timer timer;
        int i = 0;

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
                l.Location = new Point( 3 + i * 2 , 12 + i * 30);
                labels[i] = l;

                this.Controls.Add(numerics[i]);
                this.Controls.Add(labels[i]);

            }

            labels[0].Text = "Hours" ;
            labels[1].Text = "Mins" ;
            labels[2].Text = "Secs" ;

            button = new Button();
            button.Text = "Start";
            button.Location = new Point(175, 20);
            button.Click += b_click;
            this.Controls.Add(button);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += t_tick;

        }

        private void b_click(object sender, EventArgs e){
            if (timer.Enabled) {
                timer.Stop();
                button.Text = "Start";
            }
            else {
                timer.Start();
                button.Text = "Stop";
            }
        }

        private void t_tick(object sender, EventArgs e){
            
        }

        private void secondsToOthers(){
            
        }

    }
}
