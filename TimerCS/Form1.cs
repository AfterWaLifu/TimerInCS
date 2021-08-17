using System;
using System.Media;
using System.Drawing;
using System.Windows.Forms;

namespace TimerCS
{
    public partial class Form1 : Form
    {
        #region Definitions

        /// <summary>
        /// Controls to set time
        /// </summary>
        NumericUpDown[] numerics;

        /// <summary>
        /// Just labels + label to display time
        /// </summary>
        Label[] labels;
        Label timeLeft;

        /// <summary>
        /// Main button to do
        /// </summary>
        Button button;
        Button newTime;

        /// <summary>
        /// Timer to count
        /// </summary>
        System.Windows.Forms.Timer timer;

        /// <summary>
        /// sound that plays when time is over
        /// </summary>
        SoundPlayer soundOfTheEnd;

        /// <summary>
        /// Time that user set
        /// </summary>
        int hours = 0;
        int mins = 0;
        int secs = 0;

        #endregion

        public Form1()
        {
            InitializeComponent();
            init();
        }

        #region Methods related with form

        /// <summary>
        /// Initializing of controls
        /// </summary>
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
            button.Location = new Point(175, 8);
            button.Click += b_click;
            this.Controls.Add(button);

            newTime = new Button();
            newTime.Text = "Refresh";
            newTime.Location = new Point(175, 68);
            newTime.Click += nt_click;
            this.Controls.Add(newTime);

            timeLeft = new Label();
            timeLeft.Location = new Point(180, 34);
            timeLeft.Size = new Size(100, 30);
            timeLeft.Text = "Time left: ";
            this.Controls.Add(timeLeft);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += t_tick;

            soundOfTheEnd = new SoundPlayer("resources\\sound.wav");

        }

        /// <summary>
        /// Button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b_click(object sender, EventArgs e){
            if (timer.Enabled) {
                timer.Stop();
                button.Text = "Start";
            }
            else {
                if (hours == 0 && mins == 0 && secs == 0) timeRead();
                timer.Start();
                button.Text = "Stop";
            }
        }
        
        /// <summary>
        /// Click of refresh button
        /// </summary>
        private void nt_click(object sender, EventArgs e){
            timeRead();
            timeDisplay();
        }

        /// <summary>
        /// timer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t_tick(object sender, EventArgs e){
            
            timeDisplay();

            if (secs == 0){
                if (mins == 0){
                    if (hours == 0){
                        timer.Stop();
                        soundOfTheEnd.Play();
                        MessageBox.Show("Time is over");
                        button.Text = "Start";
                        timeDisplay();
                        return;
                    }
                    hours--;
                    mins = 59;
                }
                mins--;
                secs = 59;
            }
            else secs--;

        }

        #endregion

        #region everything else
        
        /// <summary>
        /// Updating timer on form
        /// </summary>
        private void timeDisplay(){
            timeLeft.Text = $"Time left:\n{hours}h {mins}m {secs}s";
        }

        /// <summary>
        /// Read time from numerics
        /// </summary>
        private void timeRead(){
            hours = Convert.ToInt32(numerics[0].Value);
            mins = Convert.ToInt32(numerics[1].Value);
            secs = Convert.ToInt32(numerics[2].Value);
        }

        #endregion
    }
}
