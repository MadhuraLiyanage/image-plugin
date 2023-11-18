
namespace ImageTesting
{
    partial class FormImage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxOrgImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxConImage = new System.Windows.Forms.PictureBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonResize = new System.Windows.Forms.Button();
            this.buttonBlurImage = new System.Windows.Forms.Button();
            this.buttonGrayImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrgImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOrgImage
            // 
            this.pictureBoxOrgImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOrgImage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxOrgImage.Name = "pictureBoxOrgImage";
            this.pictureBoxOrgImage.Size = new System.Drawing.Size(481, 329);
            this.pictureBoxOrgImage.TabIndex = 0;
            this.pictureBoxOrgImage.TabStop = false;
            // 
            // pictureBoxConImage
            // 
            this.pictureBoxConImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxConImage.Location = new System.Drawing.Point(569, 12);
            this.pictureBoxConImage.Name = "pictureBoxConImage";
            this.pictureBoxConImage.Size = new System.Drawing.Size(481, 329);
            this.pictureBoxConImage.TabIndex = 1;
            this.pictureBoxConImage.TabStop = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonLoad.Location = new System.Drawing.Point(12, 347);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(199, 66);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load Image";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonResize
            // 
            this.buttonResize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonResize.Location = new System.Drawing.Point(569, 347);
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.Size = new System.Drawing.Size(150, 66);
            this.buttonResize.TabIndex = 3;
            this.buttonResize.Text = "Resize Image";
            this.buttonResize.UseVisualStyleBackColor = true;
            this.buttonResize.Click += new System.EventHandler(this.buttonResize_Click);
            // 
            // buttonBlurImage
            // 
            this.buttonBlurImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonBlurImage.Location = new System.Drawing.Point(733, 347);
            this.buttonBlurImage.Name = "buttonBlurImage";
            this.buttonBlurImage.Size = new System.Drawing.Size(150, 66);
            this.buttonBlurImage.TabIndex = 4;
            this.buttonBlurImage.Text = "Blur Image";
            this.buttonBlurImage.UseVisualStyleBackColor = true;
            this.buttonBlurImage.Click += new System.EventHandler(this.buttonBlurImage_Click);
            // 
            // buttonGrayImage
            // 
            this.buttonGrayImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonGrayImage.Location = new System.Drawing.Point(900, 347);
            this.buttonGrayImage.Name = "buttonGrayImage";
            this.buttonGrayImage.Size = new System.Drawing.Size(150, 66);
            this.buttonGrayImage.TabIndex = 5;
            this.buttonGrayImage.Text = "Grayscale Image";
            this.buttonGrayImage.UseVisualStyleBackColor = true;
            this.buttonGrayImage.Click += new System.EventHandler(this.buttonGrayImage_Click);
            // 
            // FormImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 439);
            this.Controls.Add(this.buttonGrayImage);
            this.Controls.Add(this.buttonBlurImage);
            this.Controls.Add(this.buttonResize);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.pictureBoxConImage);
            this.Controls.Add(this.pictureBoxOrgImage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormImage";
            this.Text = "Process Image";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrgImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOrgImage;
        private System.Windows.Forms.PictureBox pictureBoxConImage;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonResize;
        private System.Windows.Forms.Button buttonBlurImage;
        private System.Windows.Forms.Button buttonGrayImage;
    }
}

