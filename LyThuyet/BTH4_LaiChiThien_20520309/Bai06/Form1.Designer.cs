namespace Bai06
{
    partial class Form1
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
            this.groupSaoChep = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupTienTrinh = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupSaoChep.SuspendLayout();
            this.groupTienTrinh.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSaoChep
            // 
            this.groupSaoChep.Controls.Add(this.button3);
            this.groupSaoChep.Controls.Add(this.button2);
            this.groupSaoChep.Controls.Add(this.button1);
            this.groupSaoChep.Controls.Add(this.textBox2);
            this.groupSaoChep.Controls.Add(this.textBox1);
            this.groupSaoChep.Controls.Add(this.label2);
            this.groupSaoChep.Controls.Add(this.label1);
            this.groupSaoChep.Location = new System.Drawing.Point(12, 23);
            this.groupSaoChep.Name = "groupSaoChep";
            this.groupSaoChep.Size = new System.Drawing.Size(909, 217);
            this.groupSaoChep.TabIndex = 0;
            this.groupSaoChep.TabStop = false;
            this.groupSaoChep.Text = "Sao chép tập tin";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(329, 166);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Sao chép";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(791, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(791, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(329, 108);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(456, 22);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(329, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(456, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Đường Dẫn Thư Mục Nguồn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường Dẫn Thư Mục Nguồn";
            // 
            // groupTienTrinh
            // 
            this.groupTienTrinh.Controls.Add(this.label3);
            this.groupTienTrinh.Controls.Add(this.progressBar1);
            this.groupTienTrinh.Location = new System.Drawing.Point(12, 258);
            this.groupTienTrinh.Name = "groupTienTrinh";
            this.groupTienTrinh.Size = new System.Drawing.Size(909, 104);
            this.groupTienTrinh.TabIndex = 0;
            this.groupTienTrinh.TabStop = false;
            this.groupTienTrinh.Text = "Tiến trình sao chép";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(24, 43);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(857, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 375);
            this.Controls.Add(this.groupTienTrinh);
            this.Controls.Add(this.groupSaoChep);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupSaoChep.ResumeLayout(false);
            this.groupSaoChep.PerformLayout();
            this.groupTienTrinh.ResumeLayout(false);
            this.groupTienTrinh.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSaoChep;
        private System.Windows.Forms.GroupBox groupTienTrinh;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

