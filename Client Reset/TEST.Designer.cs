
namespace Client_Reset
{
    partial class TEST
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
            this.progress3 = new Progress();
            this.progress2 = new Progress();
            this.progress1 = new Progress();
            this.SuspendLayout();
            // 
            // progress3
            // 
            this.progress3.HideLoading = true;
            this.progress3.Location = new System.Drawing.Point(618, 209);
            this.progress3.Maximum = 100;
            this.progress3.Minimum = 0;
            this.progress3.Name = "progress3";
            this.progress3.Size = new System.Drawing.Size(148, 32);
            this.progress3.TabIndex = 2;
            this.progress3.Text = "progress3";
            this.progress3.Value = 0;
            // 
            // progress2
            // 
            this.progress2.HideLoading = false;
            this.progress2.Location = new System.Drawing.Point(384, 209);
            this.progress2.Maximum = 100;
            this.progress2.Minimum = 0;
            this.progress2.Name = "progress2";
            this.progress2.Size = new System.Drawing.Size(233, 32);
            this.progress2.TabIndex = 1;
            this.progress2.Text = "progress2";
            this.progress2.Value = 45;
            // 
            // progress1
            // 
            this.progress1.HideLoading = false;
            this.progress1.Location = new System.Drawing.Point(150, 209);
            this.progress1.Maximum = 100;
            this.progress1.Minimum = 0;
            this.progress1.Name = "progress1";
            this.progress1.Size = new System.Drawing.Size(233, 32);
            this.progress1.TabIndex = 0;
            this.progress1.Text = "progress1";
            this.progress1.Value = 100;
            // 
            // TEST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progress3);
            this.Controls.Add(this.progress2);
            this.Controls.Add(this.progress1);
            this.Name = "TEST";
            this.Text = "TEST";
            this.ResumeLayout(false);

        }

        #endregion

        private Progress progress1;
        private Progress progress2;
        private Progress progress3;
    }
}