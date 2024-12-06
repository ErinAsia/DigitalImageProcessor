namespace AsiaDigitalImageProcessor
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxWebcam = new System.Windows.Forms.PictureBox();
            this.checkBoxGrayscale = new System.Windows.Forms.CheckBox();
            this.checkBoxSepia = new System.Windows.Forms.CheckBox();
            this.checkBoxInversion = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBoxWebcam = new System.Windows.Forms.ComboBox();
            this.checkBoxFlipVert = new System.Windows.Forms.CheckBox();
            this.checkBoxHorizontal = new System.Windows.Forms.CheckBox();
            this.checkBoxSmooth = new System.Windows.Forms.CheckBox();
            this.checkBoxMeanRemoval = new System.Windows.Forms.CheckBox();
            this.checkBoxGaussian = new System.Windows.Forms.CheckBox();
            this.checkBoxSharpen = new System.Windows.Forms.CheckBox();
            this.checkBoxEmboss = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWebcam)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxWebcam
            // 
            this.pictureBoxWebcam.Location = new System.Drawing.Point(435, 65);
            this.pictureBoxWebcam.Name = "pictureBoxWebcam";
            this.pictureBoxWebcam.Size = new System.Drawing.Size(745, 563);
            this.pictureBoxWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxWebcam.TabIndex = 7;
            this.pictureBoxWebcam.TabStop = false;
            // 
            // checkBoxGrayscale
            // 
            this.checkBoxGrayscale.AutoSize = true;
            this.checkBoxGrayscale.Location = new System.Drawing.Point(272, 65);
            this.checkBoxGrayscale.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxGrayscale.Name = "checkBoxGrayscale";
            this.checkBoxGrayscale.Size = new System.Drawing.Size(91, 20);
            this.checkBoxGrayscale.TabIndex = 1;
            this.checkBoxGrayscale.Text = "Greyscale";
            this.checkBoxGrayscale.UseVisualStyleBackColor = true;
            this.checkBoxGrayscale.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxSepia
            // 
            this.checkBoxSepia.AutoSize = true;
            this.checkBoxSepia.Location = new System.Drawing.Point(272, 93);
            this.checkBoxSepia.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSepia.Name = "checkBoxSepia";
            this.checkBoxSepia.Size = new System.Drawing.Size(65, 20);
            this.checkBoxSepia.TabIndex = 2;
            this.checkBoxSepia.Text = "Sepia";
            this.checkBoxSepia.UseVisualStyleBackColor = true;
            this.checkBoxSepia.CheckedChanged += new System.EventHandler(this.checkBoxSepia_CheckedChanged);
            // 
            // checkBoxInversion
            // 
            this.checkBoxInversion.AutoSize = true;
            this.checkBoxInversion.Location = new System.Drawing.Point(272, 121);
            this.checkBoxInversion.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxInversion.Name = "checkBoxInversion";
            this.checkBoxInversion.Size = new System.Drawing.Size(83, 20);
            this.checkBoxInversion.TabIndex = 3;
            this.checkBoxInversion.Text = "Inversion";
            this.checkBoxInversion.UseVisualStyleBackColor = true;
            this.checkBoxInversion.CheckedChanged += new System.EventHandler(this.checkBoxInversion_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 110);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "StartWebCam";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 161);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(31, 469);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 28);
            this.button3.TabIndex = 6;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBoxWebcam
            // 
            this.comboBoxWebcam.Location = new System.Drawing.Point(31, 65);
            this.comboBoxWebcam.Name = "comboBoxWebcam";
            this.comboBoxWebcam.Size = new System.Drawing.Size(141, 24);
            this.comboBoxWebcam.TabIndex = 0;
            // 
            // checkBoxFlipVert
            // 
            this.checkBoxFlipVert.AutoSize = true;
            this.checkBoxFlipVert.Location = new System.Drawing.Point(272, 149);
            this.checkBoxFlipVert.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxFlipVert.Name = "checkBoxFlipVert";
            this.checkBoxFlipVert.Size = new System.Drawing.Size(94, 20);
            this.checkBoxFlipVert.TabIndex = 8;
            this.checkBoxFlipVert.Text = "Flipvertical";
            this.checkBoxFlipVert.UseVisualStyleBackColor = true;
            this.checkBoxFlipVert.CheckedChanged += new System.EventHandler(this.checkBoxFlipVert_CheckedChanged);
            // 
            // checkBoxHorizontal
            // 
            this.checkBoxHorizontal.AutoSize = true;
            this.checkBoxHorizontal.Location = new System.Drawing.Point(272, 177);
            this.checkBoxHorizontal.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxHorizontal.Name = "checkBoxHorizontal";
            this.checkBoxHorizontal.Size = new System.Drawing.Size(111, 20);
            this.checkBoxHorizontal.TabIndex = 9;
            this.checkBoxHorizontal.Text = "FlipHorizontal";
            this.checkBoxHorizontal.UseVisualStyleBackColor = true;
            this.checkBoxHorizontal.CheckedChanged += new System.EventHandler(this.checkBoxHorizontal_CheckedChanged);
            // 
            // checkBoxSmooth
            // 
            this.checkBoxSmooth.AutoSize = true;
            this.checkBoxSmooth.Location = new System.Drawing.Point(272, 205);
            this.checkBoxSmooth.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSmooth.Name = "checkBoxSmooth";
            this.checkBoxSmooth.Size = new System.Drawing.Size(75, 20);
            this.checkBoxSmooth.TabIndex = 10;
            this.checkBoxSmooth.Text = "Smooth";
            this.checkBoxSmooth.UseVisualStyleBackColor = true;
            this.checkBoxSmooth.CheckedChanged += new System.EventHandler(this.checkBoxSmooth_CheckedChanged);
            // 
            // checkBoxMeanRemoval
            // 
            this.checkBoxMeanRemoval.AutoSize = true;
            this.checkBoxMeanRemoval.Location = new System.Drawing.Point(272, 233);
            this.checkBoxMeanRemoval.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxMeanRemoval.Name = "checkBoxMeanRemoval";
            this.checkBoxMeanRemoval.Size = new System.Drawing.Size(118, 20);
            this.checkBoxMeanRemoval.TabIndex = 11;
            this.checkBoxMeanRemoval.Text = "MeanRemoval";
            this.checkBoxMeanRemoval.UseVisualStyleBackColor = true;
            this.checkBoxMeanRemoval.CheckedChanged += new System.EventHandler(this.checkBoxMeanRemoval_CheckedChanged);
            // 
            // checkBoxGaussian
            // 
            this.checkBoxGaussian.AutoSize = true;
            this.checkBoxGaussian.Location = new System.Drawing.Point(272, 261);
            this.checkBoxGaussian.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxGaussian.Name = "checkBoxGaussian";
            this.checkBoxGaussian.Size = new System.Drawing.Size(86, 20);
            this.checkBoxGaussian.TabIndex = 12;
            this.checkBoxGaussian.Text = "Gaussian";
            this.checkBoxGaussian.UseVisualStyleBackColor = true;
            this.checkBoxGaussian.CheckedChanged += new System.EventHandler(this.checkBoxGaussian_CheckedChanged);
            // 
            // checkBoxSharpen
            // 
            this.checkBoxSharpen.AutoSize = true;
            this.checkBoxSharpen.Location = new System.Drawing.Point(272, 289);
            this.checkBoxSharpen.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSharpen.Name = "checkBoxSharpen";
            this.checkBoxSharpen.Size = new System.Drawing.Size(80, 20);
            this.checkBoxSharpen.TabIndex = 13;
            this.checkBoxSharpen.Text = "Sharpen";
            this.checkBoxSharpen.UseVisualStyleBackColor = true;
            this.checkBoxSharpen.CheckedChanged += new System.EventHandler(this.checkBoxSharpen_CheckedChanged);
            // 
            // checkBoxEmboss
            // 
            this.checkBoxEmboss.AutoSize = true;
            this.checkBoxEmboss.Location = new System.Drawing.Point(272, 317);
            this.checkBoxEmboss.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxEmboss.Name = "checkBoxEmboss";
            this.checkBoxEmboss.Size = new System.Drawing.Size(79, 20);
            this.checkBoxEmboss.TabIndex = 14;
            this.checkBoxEmboss.Text = "Emboss";
            this.checkBoxEmboss.UseVisualStyleBackColor = true;
            this.checkBoxEmboss.CheckedChanged += new System.EventHandler(this.checkBoxEmboss_CheckedChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 704);
            this.Controls.Add(this.checkBoxEmboss);
            this.Controls.Add(this.checkBoxSharpen);
            this.Controls.Add(this.checkBoxGaussian);
            this.Controls.Add(this.checkBoxMeanRemoval);
            this.Controls.Add(this.checkBoxSmooth);
            this.Controls.Add(this.checkBoxHorizontal);
            this.Controls.Add(this.checkBoxFlipVert);
            this.Controls.Add(this.comboBoxWebcam);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxInversion);
            this.Controls.Add(this.checkBoxSepia);
            this.Controls.Add(this.checkBoxGrayscale);
            this.Controls.Add(this.pictureBoxWebcam);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.Text = "Form3";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWebcam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxWebcam;
        private System.Windows.Forms.CheckBox checkBoxGrayscale;
        private System.Windows.Forms.CheckBox checkBoxSepia;
        private System.Windows.Forms.CheckBox checkBoxInversion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBoxWebcam;
        private System.Windows.Forms.CheckBox checkBoxFlipVert;
        private System.Windows.Forms.CheckBox checkBoxHorizontal;
        private System.Windows.Forms.CheckBox checkBoxSmooth;
        private System.Windows.Forms.CheckBox checkBoxMeanRemoval;
        private System.Windows.Forms.CheckBox checkBoxGaussian;
        private System.Windows.Forms.CheckBox checkBoxSharpen;
        private System.Windows.Forms.CheckBox checkBoxEmboss;
    }
}