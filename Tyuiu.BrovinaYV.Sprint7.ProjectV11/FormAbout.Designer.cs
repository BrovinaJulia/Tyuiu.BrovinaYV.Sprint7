
namespace Tyuiu.BrovinaYV.Sprint7.ProjectV11
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.label_BYV = new System.Windows.Forms.Label();
            this.buttonClose_BYV = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_BYV
            // 
            this.label_BYV.AutoSize = true;
            this.label_BYV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_BYV.Location = new System.Drawing.Point(241, 21);
            this.label_BYV.Name = "label_BYV";
            this.label_BYV.Size = new System.Drawing.Size(363, 153);
            this.label_BYV.TabIndex = 2;
            this.label_BYV.Text = resources.GetString("label_BYV.Text");
            // 
            // buttonClose_BYV
            // 
            this.buttonClose_BYV.Location = new System.Drawing.Point(500, 208);
            this.buttonClose_BYV.Name = "buttonClose_BYV";
            this.buttonClose_BYV.Size = new System.Drawing.Size(104, 28);
            this.buttonClose_BYV.TabIndex = 4;
            this.buttonClose_BYV.Text = "OK";
            this.buttonClose_BYV.UseVisualStyleBackColor = true;
            this.buttonClose_BYV.Click += new System.EventHandler(this.buttonClose_BYV_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(222, 224);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 239);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonClose_BYV);
            this.Controls.Add(this.label_BYV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(627, 278);
            this.MinimumSize = new System.Drawing.Size(627, 278);
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Об авторе";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_BYV;
        private System.Windows.Forms.Button buttonClose_BYV;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}