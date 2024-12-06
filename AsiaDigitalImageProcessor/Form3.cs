using AForge.Video;
using AForge.Video.DirectShow;
using Accord.Imaging.Filters;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsiaDigitalImageProcessor
{
    public partial class Form3 : Form
    {

        private FilterInfoCollection videoDevices; 
        private VideoCaptureDevice videoSource;
        private bool applyGrayscale = false, applySepia = false, applyInversion = false;

        public Form3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            LoadWebcamDevices();
        }

        private void LoadWebcamDevices()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count > 0)
                {
                    foreach (FilterInfo device in videoDevices)
                    {
                        comboBoxWebcam.Items.Add(device.Name);
                    }
                    comboBoxWebcam.SelectedIndex = 0; // Select the first device by default
                }
                else
                {
                    MessageBox.Show("No webcam devices found.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading webcam devices: " + ex.Message, "Error");
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (videoDevices == null || videoDevices.Count == 0) return;

            videoSource = new VideoCaptureDevice(videoDevices[comboBoxWebcam.SelectedIndex].MonikerString);
            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Clone the current frame
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
 
            // Apply filters based on user selection
            if (applyGrayscale)
            {
                Grayscale grayscaleFilter = new Grayscale(0.2126, 0.7152, 0.0722);
                frame = grayscaleFilter.Apply(frame);
            }

            if (applySepia)
            {
                Sepia sepiaFilter = new Sepia();
                frame = sepiaFilter.Apply(frame);
            }

            if (applyInversion)
            {
                Invert invertFilter = new Invert();
                frame = invertFilter.Apply(frame);
            }

            // Display the processed frame
            pictureBoxWebcam.Image = frame;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGrayscale.Checked)
            {
                applyGrayscale = true;
                applySepia = false;
                applyInversion = false;
                checkBoxSepia.Checked = false;
                checkBoxInversion.Checked = false;
            }
            else
            {
                applyGrayscale = false;
            }
        }

        private void checkBoxSepia_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSepia.Checked)
            {
                applySepia = true;
                applyGrayscale = false;
                applyInversion = false;
                checkBoxGrayscale.Checked = false;
                checkBoxInversion.Checked = false;
            }
            else
            {
                applySepia = false;
            }
        }

        private void checkBoxInversion_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBoxInversion.Checked)
            {
                applyInversion = true;
                applyGrayscale = false;
                applySepia = false;
                checkBoxGrayscale.Checked = false;
                checkBoxSepia.Checked = false;
            }
            else
            {
                applyInversion = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();

            this.Close();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();  // Gracefully stops the webcam
                videoSource.WaitForStop();  // Waits until the device stops completely
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
