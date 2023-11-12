namespace YılanOyunu
{
    partial class FormOyun
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
            components = new System.ComponentModel.Container();
            pbCanvas = new PictureBox();
            label1 = new Label();
            lblPuan = new Label();
            timerOyun = new System.Windows.Forms.Timer(components);
            lblOyunSonuMetni = new Label();
            ((System.ComponentModel.ISupportInitialize)pbCanvas).BeginInit();
            SuspendLayout();
            // 
            // pbCanvas
            // 
            pbCanvas.BackColor = SystemColors.ActiveBorder;
            pbCanvas.Location = new Point(12, 12);
            pbCanvas.Name = "pbCanvas";
            pbCanvas.Size = new Size(499, 408);
            pbCanvas.TabIndex = 0;
            pbCanvas.TabStop = false;
            pbCanvas.Paint += pbCanvas_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(533, 24);
            label1.Name = "label1";
            label1.Size = new Size(100, 37);
            label1.TabIndex = 1;
            label1.Text = "Puan : ";
            // 
            // lblPuan
            // 
            lblPuan.AutoSize = true;
            lblPuan.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblPuan.Location = new Point(645, 24);
            lblPuan.Name = "lblPuan";
            lblPuan.Size = new Size(28, 37);
            lblPuan.TabIndex = 2;
            lblPuan.Text = "-";
            // 
            // timerOyun
            // 
            timerOyun.Tick += EkraniGuncelle;
            // 
            // lblOyunSonuMetni
            // 
            lblOyunSonuMetni.AutoSize = true;
            lblOyunSonuMetni.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblOyunSonuMetni.Location = new Point(13, 78);
            lblOyunSonuMetni.Name = "lblOyunSonuMetni";
            lblOyunSonuMetni.Size = new Size(79, 32);
            lblOyunSonuMetni.TabIndex = 3;
            lblOyunSonuMetni.Text = "label2";
            lblOyunSonuMetni.Visible = false;
            // 
            // FormOyun
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblOyunSonuMetni);
            Controls.Add(lblPuan);
            Controls.Add(label1);
            Controls.Add(pbCanvas);
            Name = "FormOyun";
            Text = "Yılan Oyunu - KodEgitimi.com";
            Load += FormOyun_Load;
            KeyDown += FormOyun_KeyDown;
            KeyUp += FormOyun_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pbCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbCanvas;
        private Label label1;
        private Label lblPuan;
        private System.Windows.Forms.Timer timerOyun;
        private Label lblOyunSonuMetni;
    }
}