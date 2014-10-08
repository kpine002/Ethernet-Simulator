namespace Ethernet_Simulation
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.kBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clearBtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(167)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(277, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ethernet Simulation Project";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(272, 50);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputBox.Size = new System.Drawing.Size(500, 500);
            this.outputBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.sBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.kBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(167)))), ((int)(((byte)(48)))));
            this.groupBox1.Location = new System.Drawing.Point(13, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 200);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VARIABLES";
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(49, 153);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(100, 26);
            this.xBox.TabIndex = 9;
            this.xBox.Text = "3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "X = ";
            this.toolTip1.SetToolTip(this.label6, "Selected Computers: amount of computers that will\r\nattempt to access the channel " +
        "at any given time slot\r\n[0 ~ X]");
            // 
            // sBox
            // 
            this.sBox.Location = new System.Drawing.Point(49, 121);
            this.sBox.Name = "sBox";
            this.sBox.Size = new System.Drawing.Size(100, 26);
            this.sBox.TabIndex = 7;
            this.sBox.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "S = ";
            this.toolTip1.SetToolTip(this.label4, "Slot Times: Amount of time a computer wil have to wait\r\nin order to attempt again" +
        ". [1 ~ S]");
            // 
            // kBox
            // 
            this.kBox.Location = new System.Drawing.Point(49, 89);
            this.kBox.Name = "kBox";
            this.kBox.Size = new System.Drawing.Size(100, 26);
            this.kBox.TabIndex = 5;
            this.kBox.Text = "512";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "K = ";
            this.toolTip1.SetToolTip(this.label5, "Bytes of Data: amount of data that will\r\nbe sent when a computer obtains the chan" +
        "nel");
            // 
            // tBox
            // 
            this.tBox.Location = new System.Drawing.Point(49, 57);
            this.tBox.Name = "tBox";
            this.tBox.Size = new System.Drawing.Size(100, 26);
            this.tBox.TabIndex = 3;
            this.tBox.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "T = ";
            this.toolTip1.SetToolTip(this.label3, "Time Slots: The number of times to simulate\r\nethernet activity ");
            // 
            // nBox
            // 
            this.nBox.Location = new System.Drawing.Point(49, 25);
            this.nBox.Name = "nBox";
            this.nBox.Size = new System.Drawing.Size(100, 26);
            this.nBox.TabIndex = 1;
            this.nBox.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "N = ";
            this.toolTip1.SetToolTip(this.label2, "Computers: number of devices that will attempt\r\nto use channel throught the simul" +
        "ation\r\n");
            // 
            // clearBtn
            // 
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.Location = new System.Drawing.Point(13, 526);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(200, 25);
            this.clearBtn.TabIndex = 3;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runBtn.Location = new System.Drawing.Point(12, 495);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(200, 25);
            this.runBtn.TabIndex = 4;
            this.runBtn.Text = "Begin Simulation";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "Ethernet Simulation Project";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox nBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox xBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox kBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

