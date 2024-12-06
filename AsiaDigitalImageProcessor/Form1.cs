using Accord.Imaging;
using Accord.Imaging.Filters;
using Accord.Statistics.Visualizations;
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
using HNUDIP;
using ImageProcess2;
using System.Diagnostics;

namespace AsiaDigitalImageProcessor
{
    public partial class Form1 : Form
    {
        
        public Bitmap originalImage, editedImage;
        private string sourcepath, sourceFilePath, projectDirectory, uploadDirectory, fileName, destinationFilePath;


        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SaveOriginalImage();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //Uploaded Image saved in bin/Debug/UploadedImages
        private void SaveOriginalImage()
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

                        LoadImage(destinationFilePath);
                        
                        pictureBox1.Image = new Bitmap(destinationFilePath);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


                        MessageBox.Show("Image uploaded and displayed successfully!", "Success");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error uploading image: " + ex.Message, "Error");
                    }
                }
            }

        }

        private void LoadImage(string filePath)
        {
            originalImage = (Bitmap)Bitmap.FromFile(filePath);

        }

        //This button2 is for Copy Image
        private void button2_Click(object sender, EventArgs e)
        {
            CopyImage();
        }

        private void CopyImage()
        {
            if (originalImage != null)
            {
                editedImage = (Bitmap)originalImage.Clone();
                pictureBox2.Image = editedImage;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        //This button3 is for Greyscale
        private void button3_Click(object sender, EventArgs e)
        {
            ApplyGreyscale();
        }

        private void ApplyGreyscale()
        {
            if (originalImage == null) return;

            Grayscale grayscaleFilter = new Grayscale(0.2126, 0.7152, 0.0722);
            editedImage = grayscaleFilter.Apply(originalImage);
            pictureBox2.Image = editedImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //This button4 is for Color Inversion
        private void button4_Click(object sender, EventArgs e)
        {
            ApplyInversion();
        }

        private void ApplyInversion()
        {
            if (originalImage == null) return;

            Bitmap formattedImage = EnsureSupportedFormat(originalImage);

            
            Invert inversionFilter = new Invert();
            editedImage = inversionFilter.Apply(formattedImage);
            pictureBox2.Image = editedImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private Bitmap EnsureSupportedFormat(Bitmap image)
        {
            if (image.PixelFormat != System.Drawing.Imaging.PixelFormat.Format24bppRgb)
            {
                // Convert the image to 24bppRgb format
                Bitmap newImage = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    g.DrawImage(image, new Rectangle(0, 0, newImage.Width, newImage.Height));
                }
                return newImage;
            }
            return image; 
        }

        //This button5 is for Histogram
        private void button5_Click(object sender, EventArgs e)
        {
            DisplayHistogram();
        }

        private void DisplayHistogram()
        {
            if (editedImage == null) return;

            try
            {
                // Create an image statistics object
                ImageStatistics stats = new ImageStatistics(editedImage);

                // Check if the image is grayscale
                bool isGrayscale = editedImage.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed;

                // Create a new bitmap to draw the histogram
                int width = pictureBox3.Width;
                int height = pictureBox3.Height;
                Bitmap histogramImage = new Bitmap(width, height);

                // Find the maximum value in the histograms for scaling
                int maxHistogramValue;

                if (isGrayscale)
                {
                    int[] grayValues = stats.Gray.Values;

                    maxHistogramValue = grayValues.Max();
                    // Draw the grayscale histogram
                    using (Graphics g = Graphics.FromImage(histogramImage))
                    {
                        for (int i = 0; i < grayValues.Length; i++)
                        {
                            float barHeight = (float)grayValues[i] / maxHistogramValue * height;
                            g.DrawLine(Pens.Black, i, height, i, height - barHeight);
                        }
                    }
                    pictureBox3.Image = histogramImage;

                    MessageBox.Show("Histogram Grayscale calculated and displayed.");
                }
                else
                {
                    // Get histogram data for RGB channels
                    int[] redValues = stats.Red.Values;
                    int[] greenValues = stats.Green.Values;
                    int[] blueValues = stats.Blue.Values;

                    // Find the maximum value across all histograms
                    maxHistogramValue = Math.Max(Math.Max(redValues.Max(), greenValues.Max()), blueValues.Max());

                    // Draw the RGB histograms
                    using (Graphics g = Graphics.FromImage(histogramImage))
                    {
                        g.Clear(Color.White); // Clear background

                        // Draw the red channel histogram
                        for (int i = 0; i < redValues.Length; i++)
                        {
                            float barHeight = (float)redValues[i] / maxHistogramValue * height;
                            g.DrawLine(Pens.Red, i, height, i, height - barHeight);
                        }

                        // Draw the green channel histogram
                        for (int i = 0; i < greenValues.Length; i++)
                        {
                            float barHeight = (float)greenValues[i] / maxHistogramValue * height;
                            g.DrawLine(Pens.Green, i, height, i, height - barHeight);
                        }

                        // Draw the blue channel histogram
                        for (int i = 0; i < blueValues.Length; i++)
                        {
                            float barHeight = (float)blueValues[i] / maxHistogramValue * height;
                            g.DrawLine(Pens.Blue, i, height, i, height - barHeight);
                        }

                        MessageBox.Show("Histogram RGB calculated and displayed.");
                    }
                }


                // Display the histogram in the PictureBox
                pictureBox3.Image = histogramImage;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating histogram: " + ex.Message);
            }

        }

        //This button6 is for Sepia
        private void button6_Click(object sender, EventArgs e)
        {
            ApplySepia();
        }

        private void ApplySepia()
        {
            if (originalImage == null) return;

            Sepia sepiaFilter = new Sepia();
            editedImage = sepiaFilter.Apply(originalImage);
            pictureBox2.Image = editedImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        private void button9_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;
            ImageProcess.FlipVertical(ref originalImage, ref editedImage);
            pictureBox2.Image = editedImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;
            ImageProcess.Fliphorizontal(ref originalImage, ref editedImage);
            pictureBox2.Image = editedImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;
            ImageProcess.Scale(ref originalImage, ref editedImage, 200, 200);
            pictureBox2.Image = editedImage;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;
            ImageProcess.Scale(ref originalImage, ref editedImage, 1280, 900);
            pictureBox2.Image = editedImage;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;

            editedImage = new Bitmap(originalImage);
            BitmapFilter.Smooth(editedImage);
            pictureBox2.Image = editedImage;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;

            editedImage = new Bitmap(originalImage);
            BitmapFilter.GaussianBlur(editedImage);
            pictureBox2.Image = editedImage;
        }


        private void button15_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;

            editedImage = new Bitmap(originalImage);
            BitmapFilter.MeanRemoval(editedImage);
            pictureBox2.Image = editedImage;
        }


        private void button16_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;

            editedImage = new Bitmap(originalImage);
            BitmapFilter.Sharpen(editedImage);
            pictureBox2.Image = editedImage;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
                return;

            editedImage = new Bitmap(originalImage);
            BitmapFilter.EmbossLaplacian(editedImage);
            pictureBox2.Image = editedImage;
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (originalImage == null) return;
            ImageProcess.Rotate(ref originalImage, ref editedImage, trackBar1.Value);
            pictureBox2.Image = editedImage;
            
        }



        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (originalImage == null) return;
            ImageProcess.Threshold(ref originalImage, ref editedImage, trackBar2.Value);
            pictureBox2.Image = editedImage;

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            if (originalImage == null) return;
            ImageProcess.Brightness(ref originalImage, ref editedImage, trackBar2.Value);
            pictureBox2.Image = editedImage;
        }


        private void SaveImage_Click(object sender, EventArgs e)
        {
            string sourcepath = AppDomain.CurrentDomain.BaseDirectory;
            string uploadDirectory2 = Path.Combine(sourcepath, "SaveEditedImages");


            if (!Directory.Exists(uploadDirectory2))
            {
                Directory.CreateDirectory(uploadDirectory2);
            }

            
            fileName = Path.GetFileName(sourceFilePath);
            destinationFilePath = Path.Combine(uploadDirectory2, fileName);

            SaveImages(destinationFilePath);
            MessageBox.Show($"Image saved successfully at:\n{destinationFilePath}", "Save Location", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Save Edited Image
        private void SaveImages(string outputPath)
        {
            if (editedImage != null)
            {
                editedImage.Save(outputPath);
                MessageBox.Show("Image saved successfully!");
            }
            else
            {
                MessageBox.Show("No edited image to save.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();
            secondForm.StartPosition = FormStartPosition.CenterScreen;
            secondForm.Show();

            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 thirdForm = new Form3();
            thirdForm.StartPosition = FormStartPosition.CenterScreen;
            thirdForm.Show();

            this.Hide();
        }
    }
}
