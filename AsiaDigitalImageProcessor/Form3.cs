using AForge.Video;
using AForge.Video.DirectShow;
using Accord.Imaging.Filters;
using System;
using System.Drawing;
using System.Windows.Forms;
using HNUDIP;
using ImageProcess2;

namespace AsiaDigitalImageProcessor
{
    public partial class Form3 : Form
    {

        private FilterInfoCollection videoDevices; 
        private VideoCaptureDevice videoSource;
        private bool applyGrayscale = false, applySepia = false, applyInversion = false,
            applyFlipVertical = false, applyFlipHorizontal = false, applySmooth = false,
            applyGuassianBlur = false, applyMeanRemoval = false, applySharpen = false,
            applyEmbossLaplacian = false;

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

            if (applyFlipVertical)
            {

                Bitmap originalFrame = (Bitmap)eventArgs.Frame.Clone();
                Bitmap editedFrame = null;


                if (originalFrame != null)
                {
                    ImageProcess.FlipVertical(ref originalFrame, ref editedFrame);
                    frame = editedFrame;
                }


                originalFrame.Dispose();
            }

            if (applyFlipHorizontal)
            {
                Bitmap originalFrame = (Bitmap)eventArgs.Frame.Clone();
                Bitmap editedFrame = null;


                if (originalFrame != null)
                {
                    ImageProcess.Fliphorizontal(ref originalFrame, ref editedFrame);
                    frame = editedFrame;
                }


                originalFrame.Dispose();
            }

            if (applySmooth)
            {
                Bitmap editedFrame = new Bitmap(frame);
                BitmapFilter.Smooth(editedFrame);
                frame = editedFrame;
            }

            if (applyGuassianBlur)
            {
                Bitmap editedFrame = new Bitmap(frame);
                BitmapFilter.GaussianBlur(editedFrame);
                frame = editedFrame;
            }

            if (applyMeanRemoval)
            {
                Bitmap editedFrame = new Bitmap(frame);
                BitmapFilter.MeanRemoval(editedFrame);
                frame = editedFrame; ;
            }

            if (applySharpen)
            {
                Bitmap editedFrame = new Bitmap(frame);
                BitmapFilter.Sharpen(editedFrame);
                frame = editedFrame;
            }

            if (applyEmbossLaplacian)
            {
                Bitmap editedFrame = new Bitmap(frame);
                BitmapFilter.EmbossLaplacian(editedFrame);
                frame = editedFrame;
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
                applyFlipVertical = false;
                applyFlipHorizontal = false;
                applyEmbossLaplacian = false;
                applyGuassianBlur = false;
                applyInversion = false;
                applySmooth = false;
                applySharpen = false;
                applyMeanRemoval = false;
                applyGrayscale = true;
                applySepia = false;
                checkBoxSepia.Checked = false;
                checkBoxHorizontal.Checked = false;
                checkBoxSmooth.Checked = false;
                checkBoxMeanRemoval.Checked = false;
                checkBoxGaussian.Checked = false;
                checkBoxSharpen.Checked = false;
                checkBoxInversion.Checked = false;
                checkBoxEmboss.Checked = false;
                checkBoxFlipVert.Checked = false;

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
                applyFlipVertical = false;
                applyFlipHorizontal = false;
                applyEmbossLaplacian = false;
                applyGuassianBlur = false;
                applyInversion = false;
                applySmooth = false;
                applySharpen = false;
                applyMeanRemoval = false;
                applyGrayscale = false;
                applySepia = true;
                checkBoxHorizontal.Checked = false;
                checkBoxSmooth.Checked = false;
                checkBoxMeanRemoval.Checked = false;
                checkBoxGaussian.Checked = false;
                checkBoxSharpen.Checked = false;
                checkBoxInversion.Checked = false;
                checkBoxEmboss.Checked = false;
                checkBoxFlipVert.Checked = false;
                checkBoxGrayscale.Checked = false;
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
                applyFlipVertical = false;
                applyFlipHorizontal = false;
                applyEmbossLaplacian = false;
                applyGuassianBlur = false;
                applyInversion = true;
                applySmooth = false;
                applySharpen = false;
                applyMeanRemoval = false;
                applyGrayscale = false;
                applySepia = false;
                checkBoxHorizontal.Checked = false;
                checkBoxSmooth.Checked = false;
                checkBoxMeanRemoval.Checked = false;
                checkBoxGaussian.Checked = false;
                checkBoxSharpen.Checked = false;
                checkBoxEmboss.Checked = false;
                checkBoxFlipVert.Checked = false;
                checkBoxGrayscale.Checked = false;
                checkBoxSepia.Checked = false;
            }
            else
            {
                applyInversion = false;
            }
        }


        private void checkBoxFlipVert_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFlipVert.Checked)
            {
                applyFlipVertical = true;
                applyFlipHorizontal = false;
                applyEmbossLaplacian = false;
                applyGuassianBlur = false;
                applyInversion = false;
                applySmooth = false;
                applySharpen = false;
                applyMeanRemoval = false;
                applyGrayscale = false;
                applySepia = false;
                checkBoxGrayscale.Checked = false;
                checkBoxSepia.Checked = false;
                checkBoxHorizontal.Checked = false;
                checkBoxSmooth.Checked = false;
                checkBoxMeanRemoval.Checked = false;
                checkBoxGaussian.Checked = false;
                checkBoxSharpen.Checked = false;
                checkBoxInversion.Checked = false;
                checkBoxEmboss.Checked = false;
            }
            else
            {
                applyFlipVertical = false;
            }
        }

        private void checkBoxHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHorizontal.Checked)
            {
                applyFlipVertical = false;
                applyFlipHorizontal = true;
                applyEmbossLaplacian = false;
                applyGuassianBlur = false;
                applyInversion = false;
                applySmooth = false;
                applySharpen = false;
                applyMeanRemoval = false;
                applyGrayscale = false;
                applySepia = false;
                checkBoxSmooth.Checked = false;
                checkBoxMeanRemoval.Checked = false;
                checkBoxGaussian.Checked = false;
                checkBoxSharpen.Checked = false;
                checkBoxEmboss.Checked = false;
                checkBoxFlipVert.Checked = false;
                checkBoxGrayscale.Checked = false;
                checkBoxSepia.Checked = false;
                checkBoxInversion.Checked=false;
            }
            else
            {
                applyFlipHorizontal = false;
            }

        }

        private void checkBoxSmooth_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSmooth.Checked)
            {
                applyFlipVertical = false;
                applyFlipHorizontal = false;
                applyEmbossLaplacian = false;
                applyGuassianBlur = false;
                applyInversion = false;
                applySmooth = true;
                applySharpen = false;
                applyMeanRemoval = false;
                applyGrayscale = false;
                applySepia = false;
                checkBoxMeanRemoval.Checked = false;
                checkBoxGaussian.Checked = false;
                checkBoxSharpen.Checked = false;
                checkBoxEmboss.Checked = false;
                checkBoxFlipVert.Checked = false;
                checkBoxGrayscale.Checked = false;
                checkBoxSepia.Checked = false;
                checkBoxInversion.Checked = false;
                checkBoxHorizontal.Checked = false;
            }
            else
            {
                applySmooth = false;
            }
        }

        private void checkBoxMeanRemoval_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMeanRemoval.Checked)
            {
                applyFlipVertical = false;
                applyFlipHorizontal = false;
                applyEmbossLaplacian = false;
                applyGuassianBlur = false;
                applyInversion = false;
                applySmooth = false;
                applySharpen = false;
                applyMeanRemoval = true;
                applyGrayscale = false;
                checkBoxGaussian.Checked = false;
                checkBoxSharpen.Checked = false;
                checkBoxEmboss.Checked = false;
                checkBoxFlipVert.Checked = false;
                checkBoxGrayscale.Checked = false;
                checkBoxSepia.Checked = false;
                checkBoxInversion.Checked = false;
                checkBoxHorizontal.Checked = false;
                checkBoxSmooth.Checked = false;
            }
            else
            {
                applyMeanRemoval = false;
            }
        }

        private void checkBoxGaussian_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGaussian.Checked)
            {
                applyFlipVertical = false;
                applyFlipHorizontal = false;
                applyEmbossLaplacian = false;
                applyGuassianBlur = true;
                applyInversion = false;
                applySmooth = false;
                applySharpen = false;
                applyMeanRemoval = false;
                applyGrayscale = false;
                applySepia = false;
                checkBoxMeanRemoval.Checked = false;
                checkBoxSharpen.Checked = false;
                checkBoxEmboss.Checked = false;
                checkBoxFlipVert.Checked = false;
                checkBoxGrayscale.Checked = false;
                checkBoxSepia.Checked = false;
                checkBoxInversion.Checked = false;
                checkBoxHorizontal.Checked = false;
                checkBoxSmooth.Checked = false;
            }
            else
            {
                applyGuassianBlur = false;
            }
        }

        private void checkBoxSharpen_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSharpen.Checked)
            {
                applyFlipVertical = false;
                applyFlipHorizontal = false;
                applyEmbossLaplacian = false;
                applyGuassianBlur = false;
                applyInversion = false;
                applySmooth = false;
                applySharpen = true;
                applyMeanRemoval = false;
                applyGrayscale = false;
                applySepia = false;
                checkBoxMeanRemoval.Checked = false;
                checkBoxGaussian.Checked = false;
                checkBoxEmboss.Checked = false;
                checkBoxFlipVert.Checked = false;
                checkBoxGrayscale.Checked = false;
                checkBoxSepia.Checked = false;
                checkBoxInversion.Checked = false;
                checkBoxHorizontal.Checked = false;
                checkBoxSmooth.Checked = false;
            }
            else
            {
                applySharpen = false;
            }
        }


        private void checkBoxEmboss_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEmboss.Checked)
            {
                applyFlipVertical = false;
                applyFlipHorizontal = false;
                applyEmbossLaplacian = true;
                applyGuassianBlur = false;
                applyInversion = false;
                applySmooth = false;
                applySharpen = false;
                applyMeanRemoval = false;
                applyGrayscale = false;
                applySepia = false;
                checkBoxMeanRemoval.Checked = false;
                checkBoxGaussian.Checked = false;
                checkBoxSharpen.Checked = false;
                checkBoxFlipVert.Checked = false;
                checkBoxGrayscale.Checked = false;
                checkBoxSepia.Checked = false;
                checkBoxInversion.Checked = false;
                checkBoxHorizontal.Checked = false;
                checkBoxSmooth.Checked = false;
            }
            else
            {
                applyEmbossLaplacian = false;
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
