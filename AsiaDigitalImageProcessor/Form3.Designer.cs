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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWebcam)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxWebcam
            // 
            this.pictureBoxWebcam.Location = new System.Drawing.Point(366, 27);
            this.pictureBoxWebcam.Name = "pictureBoxWebcam";
            this.pictureBoxWebcam.Size = new System.Drawing.Size(379, 276);
            this.pictureBoxWebcam.TabIndex = 0;
            this.pictureBoxWebcam.TabStop = false;
            this.pictureBoxWebcam.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // checkBoxGrayscale
            // 
            this.checkBoxGrayscale.AutoSize = true;
            this.checkBoxGrayscale.Location = new System.Drawing.Point(204, 53);
            this.checkBoxGrayscale.Name = "checkBoxGrayscale";
            this.checkBoxGrayscale.Size = new System.Drawing.Size(73, 17);
            this.checkBoxGrayscale.TabIndex = 1;
            this.checkBoxGrayscale.Text = "Greyscale";
            this.checkBoxGrayscale.UseVisualStyleBackColor = true;
            this.checkBoxGrayscale.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxSepia
            // 
            this.checkBoxSepia.AutoSize = true;
            this.checkBoxSepia.Location = new System.Drawing.Point(204, 93);
            this.checkBoxSepia.Name = "checkBoxSepia";
            this.checkBoxSepia.Size = new System.Drawing.Size(53, 17);
            this.checkBoxSepia.TabIndex = 2;
            this.checkBoxSepia.Text = "Sepia";
            this.checkBoxSepia.UseVisualStyleBackColor = true;
            this.checkBoxSepia.CheckedChanged += new System.EventHandler(this.checkBoxSepia_CheckedChanged);
            // 
            // checkBoxInversion
            // 
            this.checkBoxInversion.AutoSize = true;
            this.checkBoxInversion.Location = new System.Drawing.Point(204, 131);
            this.checkBoxInversion.Name = "checkBoxInversion";
            this.checkBoxInversion.Size = new System.Drawing.Size(69, 17);
            this.checkBoxInversion.TabIndex = 3;
            this.checkBoxInversion.Text = "Inversion";
            this.checkBoxInversion.UseVisualStyleBackColor = true;
            this.checkBoxInversion.CheckedChanged += new System.EventHandler(this.checkBoxInversion_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "StartWebCam";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(23, 381);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBoxWebcam
            // 
            this.comboBoxWebcam.FormattingEnabled = true;
            this.comboBoxWebcam.Location = new System.Drawing.Point(23, 53);
            this.comboBoxWebcam.Name = "comboBoxWebcam";
            this.comboBoxWebcam.Size = new System.Drawing.Size(121, 21);
            this.comboBoxWebcam.TabIndex = 7;
            this.comboBoxWebcam.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxWebcam);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxInversion);
            this.Controls.Add(this.checkBoxSepia);
            this.Controls.Add(this.checkBoxGrayscale);
            this.Controls.Add(this.pictureBoxWebcam);
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
    }
}