namespace LED_Planer
{
    partial class FrmExport
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
            this.btn1000JsonPoints = new System.Windows.Forms.Button();
            this.txtOutout = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn1000JsonPoints
            // 
            this.btn1000JsonPoints.Location = new System.Drawing.Point(13, 13);
            this.btn1000JsonPoints.Name = "btn1000JsonPoints";
            this.btn1000JsonPoints.Size = new System.Drawing.Size(203, 37);
            this.btn1000JsonPoints.TabIndex = 0;
            this.btn1000JsonPoints.Text = "JSON 1000 RGB Points";
            this.btn1000JsonPoints.UseVisualStyleBackColor = true;
            this.btn1000JsonPoints.Click += new System.EventHandler(this.btn1001JsonRGBPoints_Click);
            // 
            // txtOutout
            // 
            this.txtOutout.Location = new System.Drawing.Point(222, 12);
            this.txtOutout.Multiline = true;
            this.txtOutout.Name = "txtOutout";
            this.txtOutout.Size = new System.Drawing.Size(952, 551);
            this.txtOutout.TabIndex = 1;
            // 
            // FrmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 575);
            this.Controls.Add(this.txtOutout);
            this.Controls.Add(this.btn1000JsonPoints);
            this.Name = "FrmExport";
            this.Text = "frmExport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1000JsonPoints;
        private System.Windows.Forms.TextBox txtOutout;
    }
}