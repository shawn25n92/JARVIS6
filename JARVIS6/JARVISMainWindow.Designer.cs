namespace JARVIS6
{
    partial class JARVISMainWindow
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
            this.TestButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TestButton1
            // 
            this.TestButton1.Location = new System.Drawing.Point(12, 12);
            this.TestButton1.Name = "TestButton1";
            this.TestButton1.Size = new System.Drawing.Size(230, 23);
            this.TestButton1.TabIndex = 0;
            this.TestButton1.Text = "Click Me To Do Something";
            this.TestButton1.UseVisualStyleBackColor = true;
            this.TestButton1.Click += new System.EventHandler(this.TestButton1_Click);
            // 
            // JARVISMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 583);
            this.Controls.Add(this.TestButton1);
            this.Name = "JARVISMainWindow";
            this.Text = "JARVISMainWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TestButton1;
    }
}