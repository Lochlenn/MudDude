namespace MudDude
{
    partial class Settings
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
            this.components = new System.ComponentModel.Container();
            this.btnSettingsOK = new System.Windows.Forms.Button();
            this.btnSettingsCancel = new System.Windows.Forms.Button();
            this.txtSettingsAddress = new System.Windows.Forms.TextBox();
            this.txtSettingsPort = new System.Windows.Forms.TextBox();
            this.lblSettingsAddress = new System.Windows.Forms.Label();
            this.lblSettingsPort = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // btnSettingsOK
            // 
            this.btnSettingsOK.Location = new System.Drawing.Point(692, 389);
            this.btnSettingsOK.Name = "btnSettingsOK";
            this.btnSettingsOK.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsOK.TabIndex = 0;
            this.btnSettingsOK.Text = "&OK";
            this.btnSettingsOK.UseVisualStyleBackColor = true;
            this.btnSettingsOK.Click += new System.EventHandler(this.btnSettingsOK_Click);
            // 
            // btnSettingsCancel
            // 
            this.btnSettingsCancel.Location = new System.Drawing.Point(598, 389);
            this.btnSettingsCancel.Name = "btnSettingsCancel";
            this.btnSettingsCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsCancel.TabIndex = 1;
            this.btnSettingsCancel.Text = "&Cancel";
            this.btnSettingsCancel.UseVisualStyleBackColor = true;
            this.btnSettingsCancel.Click += new System.EventHandler(this.btnSettingsCancel_Click);
            // 
            // txtSettingsAddress
            // 
            this.txtSettingsAddress.Location = new System.Drawing.Point(44, 85);
            this.txtSettingsAddress.Name = "txtSettingsAddress";
            this.txtSettingsAddress.Size = new System.Drawing.Size(100, 23);
            this.txtSettingsAddress.TabIndex = 2;
            // 
            // txtSettingsPort
            // 
            this.txtSettingsPort.Location = new System.Drawing.Point(164, 85);
            this.txtSettingsPort.Name = "txtSettingsPort";
            this.txtSettingsPort.Size = new System.Drawing.Size(37, 23);
            this.txtSettingsPort.TabIndex = 3;
            // 
            // lblSettingsAddress
            // 
            this.lblSettingsAddress.AutoSize = true;
            this.lblSettingsAddress.Location = new System.Drawing.Point(44, 67);
            this.lblSettingsAddress.Name = "lblSettingsAddress";
            this.lblSettingsAddress.Size = new System.Drawing.Size(49, 15);
            this.lblSettingsAddress.TabIndex = 4;
            this.lblSettingsAddress.Text = "Address";
            // 
            // lblSettingsPort
            // 
            this.lblSettingsPort.AutoSize = true;
            this.lblSettingsPort.Location = new System.Drawing.Point(164, 67);
            this.lblSettingsPort.Name = "lblSettingsPort";
            this.lblSettingsPort.Size = new System.Drawing.Size(29, 15);
            this.lblSettingsPort.TabIndex = 5;
            this.lblSettingsPort.Text = "Port";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSettingsPort);
            this.Controls.Add(this.lblSettingsAddress);
            this.Controls.Add(this.txtSettingsPort);
            this.Controls.Add(this.txtSettingsAddress);
            this.Controls.Add(this.btnSettingsCancel);
            this.Controls.Add(this.btnSettingsOK);
            this.Name = "Settings";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSettingsOK;
        private Button btnSettingsCancel;
        private TextBox txtSettingsAddress;
        private TextBox txtSettingsPort;
        private Label lblSettingsAddress;
        private Label lblSettingsPort;
        private ImageList imageList1;
    }
}