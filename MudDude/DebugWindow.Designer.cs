namespace MudDude
{
    partial class DebugWindow
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
            this.rtbDebugText = new System.Windows.Forms.RichTextBox();
            this.btnDebugClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbDebugText
            // 
            this.rtbDebugText.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rtbDebugText.Location = new System.Drawing.Point(10, 16);
            this.rtbDebugText.Name = "rtbDebugText";
            this.rtbDebugText.Size = new System.Drawing.Size(915, 524);
            this.rtbDebugText.TabIndex = 0;
            this.rtbDebugText.Text = "";
            this.rtbDebugText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbDebugText_KeyPress);
            // 
            // btnDebugClose
            // 
            this.btnDebugClose.Location = new System.Drawing.Point(850, 546);
            this.btnDebugClose.Name = "btnDebugClose";
            this.btnDebugClose.Size = new System.Drawing.Size(75, 23);
            this.btnDebugClose.TabIndex = 1;
            this.btnDebugClose.Text = "Close";
            this.btnDebugClose.UseVisualStyleBackColor = true;
            this.btnDebugClose.Click += new System.EventHandler(this.btnDebugClose_Click);
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 578);
            this.Controls.Add(this.btnDebugClose);
            this.Controls.Add(this.rtbDebugText);
            this.Name = "DebugWindow";
            this.Text = "DebugWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox rtbDebugText;
        private Button btnDebugClose;
    }
}