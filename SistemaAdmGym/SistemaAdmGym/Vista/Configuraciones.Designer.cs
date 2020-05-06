namespace SistemaAdmGym.Vista
{
    partial class Configuraciones
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
            this.cxFlatStatusBar = new CxFlatUI.CxFlatStatusBar();
            this.cxFlatTabControl = new CxFlatUI.CxFlatTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cxFlatTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cxFlatStatusBar
            // 
            this.cxFlatStatusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cxFlatStatusBar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cxFlatStatusBar.Location = new System.Drawing.Point(0, 0);
            this.cxFlatStatusBar.Name = "cxFlatStatusBar";
            this.cxFlatStatusBar.Size = new System.Drawing.Size(980, 40);
            this.cxFlatStatusBar.TabIndex = 15;
            this.cxFlatStatusBar.Text = "Configuraciones";
            this.cxFlatStatusBar.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            // 
            // cxFlatTabControl
            // 
            this.cxFlatTabControl.Controls.Add(this.tabPage1);
            this.cxFlatTabControl.Controls.Add(this.tabPage2);
            this.cxFlatTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cxFlatTabControl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cxFlatTabControl.ItemSize = new System.Drawing.Size(120, 40);
            this.cxFlatTabControl.Location = new System.Drawing.Point(0, 46);
            this.cxFlatTabControl.Multiline = true;
            this.cxFlatTabControl.Name = "cxFlatTabControl";
            this.cxFlatTabControl.SelectedIndex = 0;
            this.cxFlatTabControl.ShowToolTips = true;
            this.cxFlatTabControl.Size = new System.Drawing.Size(980, 534);
            this.cxFlatTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.cxFlatTabControl.TabIndex = 16;
            this.cxFlatTabControl.ThemeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(208)))));
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(980, 494);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basica";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(980, 494);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "productos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(23, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 212);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Configuraciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(980, 580);
            this.Controls.Add(this.cxFlatTabControl);
            this.Controls.Add(this.cxFlatStatusBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1040);
            this.Name = "Configuraciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuraciones";
            this.cxFlatTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CxFlatUI.CxFlatStatusBar cxFlatStatusBar;
        private CxFlatUI.CxFlatTabControl cxFlatTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}