namespace IntelMQtest
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_getcurl = new System.Windows.Forms.Button();
            this.button_exechttpreq = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.tb_result = new System.Windows.Forms.TextBox();
            this.cb_addfield = new System.Windows.Forms.ComboBox();
            this.button_addcurrentfield = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_removecurrentfield = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_applyfieldchange = new System.Windows.Forms.Button();
            this.tb_help = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cb_currentfieldvalue = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_getcurl
            // 
            this.button_getcurl.Location = new System.Drawing.Point(24, 709);
            this.button_getcurl.Name = "button_getcurl";
            this.button_getcurl.Size = new System.Drawing.Size(218, 48);
            this.button_getcurl.TabIndex = 9;
            this.button_getcurl.Text = "get curl command";
            this.button_getcurl.UseVisualStyleBackColor = true;
            this.button_getcurl.Click += new System.EventHandler(this.button_getcurl_Click);
            // 
            // button_exechttpreq
            // 
            this.button_exechttpreq.Location = new System.Drawing.Point(248, 709);
            this.button_exechttpreq.Name = "button_exechttpreq";
            this.button_exechttpreq.Size = new System.Drawing.Size(218, 48);
            this.button_exechttpreq.TabIndex = 10;
            this.button_exechttpreq.Text = "execute http request";
            this.button_exechttpreq.UseVisualStyleBackColor = true;
            this.button_exechttpreq.Click += new System.EventHandler(this.button_exechttpreq_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "URL:";
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(84, 9);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(389, 31);
            this.tb_ip.TabIndex = 12;
            this.tb_ip.Text = "http://localhost:5000/intelmq/push";
            // 
            // tb_result
            // 
            this.tb_result.Location = new System.Drawing.Point(24, 763);
            this.tb_result.Multiline = true;
            this.tb_result.Name = "tb_result";
            this.tb_result.Size = new System.Drawing.Size(986, 160);
            this.tb_result.TabIndex = 15;
            // 
            // cb_addfield
            // 
            this.cb_addfield.FormattingEnabled = true;
            this.cb_addfield.Location = new System.Drawing.Point(24, 91);
            this.cb_addfield.Name = "cb_addfield";
            this.cb_addfield.Size = new System.Drawing.Size(449, 33);
            this.cb_addfield.TabIndex = 18;
            // 
            // button_addcurrentfield
            // 
            this.button_addcurrentfield.Location = new System.Drawing.Point(274, 138);
            this.button_addcurrentfield.Name = "button_addcurrentfield";
            this.button_addcurrentfield.Size = new System.Drawing.Size(87, 40);
            this.button_addcurrentfield.TabIndex = 19;
            this.button_addcurrentfield.Text = "add field";
            this.button_addcurrentfield.UseVisualStyleBackColor = true;
            this.button_addcurrentfield.Click += new System.EventHandler(this.button_addcurrentfield_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(24, 211);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(449, 229);
            this.listBox1.TabIndex = 20;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button_removecurrentfield
            // 
            this.button_removecurrentfield.Location = new System.Drawing.Point(368, 139);
            this.button_removecurrentfield.Name = "button_removecurrentfield";
            this.button_removecurrentfield.Size = new System.Drawing.Size(105, 39);
            this.button_removecurrentfield.TabIndex = 21;
            this.button_removecurrentfield.Text = "remove";
            this.button_removecurrentfield.UseVisualStyleBackColor = true;
            this.button_removecurrentfield.Click += new System.EventHandler(this.button_removecurrentfield_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 25);
            this.label7.TabIndex = 23;
            this.label7.Text = "current fields";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(492, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(221, 25);
            this.label8.TabIndex = 24;
            this.label8.Text = "value of selected field";
            // 
            // button_applyfieldchange
            // 
            this.button_applyfieldchange.Location = new System.Drawing.Point(870, 256);
            this.button_applyfieldchange.Name = "button_applyfieldchange";
            this.button_applyfieldchange.Size = new System.Drawing.Size(140, 44);
            this.button_applyfieldchange.TabIndex = 25;
            this.button_applyfieldchange.Text = "apply";
            this.button_applyfieldchange.UseVisualStyleBackColor = true;
            this.button_applyfieldchange.Click += new System.EventHandler(this.button_applyfieldchange_Click);
            // 
            // tb_help
            // 
            this.tb_help.Location = new System.Drawing.Point(24, 488);
            this.tb_help.Multiline = true;
            this.tb_help.Name = "tb_help";
            this.tb_help.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_help.Size = new System.Drawing.Size(986, 181);
            this.tb_help.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "description of selected field";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 25);
            this.label2.TabIndex = 28;
            this.label2.Text = "available fields";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IntelMQtest.Properties.Resources.logo_intelmq2;
            this.pictureBox1.Location = new System.Drawing.Point(514, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // cb_currentfieldvalue
            // 
            this.cb_currentfieldvalue.FormattingEnabled = true;
            this.cb_currentfieldvalue.Location = new System.Drawing.Point(487, 208);
            this.cb_currentfieldvalue.Name = "cb_currentfieldvalue";
            this.cb_currentfieldvalue.Size = new System.Drawing.Size(523, 33);
            this.cb_currentfieldvalue.TabIndex = 30;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 946);
            this.Controls.Add(this.cb_currentfieldvalue);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_help);
            this.Controls.Add(this.button_applyfieldchange);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_removecurrentfield);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_addcurrentfield);
            this.Controls.Add(this.cb_addfield);
            this.Controls.Add(this.tb_result);
            this.Controls.Add(this.tb_ip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_exechttpreq);
            this.Controls.Add(this.button_getcurl);
            this.Name = "Form1";
            this.Text = "IntelMQtest - simple IntelMQ API Collector Client";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_getcurl;
        private System.Windows.Forms.Button button_exechttpreq;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.TextBox tb_result;
        private System.Windows.Forms.ComboBox cb_addfield;
        private System.Windows.Forms.Button button_addcurrentfield;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button_removecurrentfield;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_applyfieldchange;
        private System.Windows.Forms.TextBox tb_help;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cb_currentfieldvalue;
    }
}

