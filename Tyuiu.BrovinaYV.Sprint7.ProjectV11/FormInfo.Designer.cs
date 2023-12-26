
namespace Tyuiu.BrovinaYV.Sprint7.ProjectV11
{
    partial class FormInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInfo));
            this.label_BYV = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_BYV
            // 
            this.label_BYV.AutoSize = true;
            this.label_BYV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_BYV.Location = new System.Drawing.Point(12, 101);
            this.label_BYV.Name = "label_BYV";
            this.label_BYV.Size = new System.Drawing.Size(363, 153);
            this.label_BYV.TabIndex = 3;
            this.label_BYV.Text = resources.GetString("label_BYV.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(425, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 153);
            this.label1.TabIndex = 4;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(289, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 51);
            this.label2.TabIndex = 5;
            this.label2.Text = "Разработчик: Бровина Ю.В.\r\nГруппа АСОиУБ-23-2\r\n\r\n";
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 441);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_BYV);
            this.Name = "FormInfo";
            this.Text = "FormInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_BYV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}