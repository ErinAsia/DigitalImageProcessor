using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsiaDigitalImageProcessor
{
    public partial class Form2 : Form
    {

        private Bitmap imageB, imageA, colorgreen, resultImage;
        private string sourcepath, sourceFilePath, projectDirectory, uploadDirectory, fileName, destinationFilePath;

        //load imageB into first img slot
        private void button2_Click(object sender, EventArgs e)
        {
            string buttonName = "1";
            SaveOriginalImage(buttonName);
        }

        //load imageBackground
        private void button3_Click(object sender, EventArgs e)
        {
            string buttonName = "2";
            SaveOriginalImage(buttonName);
        }

        //Combines imgB to background via subtract button
        private void button4_Click(object sender, EventArgs e)
        {
            checkGreenColorImage();
        }

        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearPictureBoxes();

            Form1 form1 = new Form1();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();

            this.Close();
        }

        private void ClearPictureBoxes()
        {
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    if (pictureBox.Image != null)
                    {
                        pictureBox.Image.Dispose(); // Dispose of the image to free resources
                        pictureBox.Image = null;
                    }
                }
            }
        }

        private void SaveOriginalImage(string buttonName)
        {
            // Open a file dialog to select an image file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                openFileDialog.Title = "Select an Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    sourceFilePath = openFileDialog.FileName;

                    // Specify the destination folder within the project
                    projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    uploadDirectory = Path.Combine(projectDirectory, "UploadedImages");


                    if (!Directory.Exists(uploadDirectory))
                    {
                        Directory.CreateDirectory(uploadDirectory);
                    }

                    // Copy the file to the folder
                    fileName = Path.GetFileName(sourceFilePath);
                    destinationFilePath = Path.Combine(uploadDirectory, fileName);


                    try
                    {
                        File.Copy(sourceFilePath, destinationFilePath, true);

                        if(buttonName == "1")
                        {
                            imageB = new Bitmap(destinationFilePath);
                            pictureBox1.Image = imageB;
                            
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        }

                        else
                        {
                            imageA = new Bitmap(destinationFilePath);
                            pictureBox2.Image = imageA;
                            
                            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        }




                        MessageBox.Show("Image uploaded and displayed successfully!", "Success");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error uploading image: " + ex.Message, "Error");
                    }
                }
            }

        }

        private void checkGreenColorImage()
        {
            Color mygreen = Color.FromArgb(0,0,255);
            int greygreen = (mygreen.R + mygreen.G + mygreen.B) / 3;
            int threshold = 5;

            for (int i = 0; i < imageB.Width; i++)
            {
                for (int j = 0; j < imageB.Height; j++)
                {
                    Color pixel = imageB.GetPixel(i, j);
                    Color backpixel = imageA.GetPixel(i, j);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    int subtractvalue = Math.Abs(grey - greygreen);
                    if (subtractvalue > threshold)
                    {
                        resultImage.SetPixel(i, j, backpixel);
                    }
                    else
                    {
                        resultImage.SetPixel(i,j, pixel);
                    }

                }
            }

            pictureBox3.Image = resultImage;
        }


    }
}
