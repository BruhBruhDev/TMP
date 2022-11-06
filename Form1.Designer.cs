
namespace TMP
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
            this.lblCputemp = new System.Windows.Forms.Label();
            this.chBx_ToggleManager = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBx_MaxTemp = new System.Windows.Forms.MaskedTextBox();
            this.txtBx_MinTemp = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IncDec_Temp = new System.Windows.Forms.NumericUpDown();
            this.lbl_TempDirection = new System.Windows.Forms.Label();
            this.lbl_Temp = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLoadBar = new System.Windows.Forms.Label();
            this.lblLoad = new System.Windows.Forms.Label();
            this.lblClockSpeed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer_Controller = new System.Windows.Forms.Timer(this.components);
            this.lbl_IsNotElevated = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.IncDec_LimitMinP = new System.Windows.Forms.NumericUpDown();
            this.IncDec_LimitMaxP = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBx_LimitMinP = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBx_LimitMaxP = new System.Windows.Forms.MaskedTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chBx_CarryLower = new System.Windows.Forms.CheckBox();
            this.IncDec_LowerP = new System.Windows.Forms.NumericUpDown();
            this.IncDec_UpperP = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBx_LowerP = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBx_UpperP = new System.Windows.Forms.MaskedTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.lbl_ArrowUp = new System.Windows.Forms.Label();
            this.txtBx_WaitTime = new System.Windows.Forms.MaskedTextBox();
            this.lbl_CycleTime = new System.Windows.Forms.Label();
            this.lbl_ArrowDown = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.timer_ValueUpdater = new System.Windows.Forms.Timer(this.components);
            this.lblWPP = new System.Windows.Forms.Label();
            this.lblWPPUpdate = new System.Windows.Forms.Label();
            this.canvas = new TMP.canvas();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IncDec_Temp)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IncDec_LimitMinP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncDec_LimitMaxP)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IncDec_LowerP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncDec_UpperP)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCputemp
            // 
            this.lblCputemp.AutoSize = true;
            this.lblCputemp.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCputemp.Location = new System.Drawing.Point(5, 238);
            this.lblCputemp.Name = "lblCputemp";
            this.lblCputemp.Size = new System.Drawing.Size(94, 24);
            this.lblCputemp.TabIndex = 1;
            this.lblCputemp.Text = "CPU Temp";
            // 
            // chBx_ToggleManager
            // 
            this.chBx_ToggleManager.AutoSize = true;
            this.chBx_ToggleManager.Location = new System.Drawing.Point(10, 19);
            this.chBx_ToggleManager.Name = "chBx_ToggleManager";
            this.chBx_ToggleManager.Size = new System.Drawing.Size(88, 17);
            this.chBx_ToggleManager.TabIndex = 2;
            this.chBx_ToggleManager.Text = "Running/Idle";
            this.chBx_ToggleManager.UseVisualStyleBackColor = true;
            this.chBx_ToggleManager.CheckedChanged += new System.EventHandler(this.chBx_ToggleManager_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max Temp @";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Min Temp @";
            // 
            // txtBx_MaxTemp
            // 
            this.txtBx_MaxTemp.Location = new System.Drawing.Point(93, 25);
            this.txtBx_MaxTemp.Mask = "000 \\C°";
            this.txtBx_MaxTemp.Name = "txtBx_MaxTemp";
            this.txtBx_MaxTemp.PromptChar = ' ';
            this.txtBx_MaxTemp.Size = new System.Drawing.Size(38, 20);
            this.txtBx_MaxTemp.TabIndex = 7;
            this.txtBx_MaxTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBx_MaxTemp.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtBx_MaxTemp.ValidatingType = typeof(int);
            this.txtBx_MaxTemp.TextChanged += new System.EventHandler(this.txtBx_MaxTemp_TextChanged);
            // 
            // txtBx_MinTemp
            // 
            this.txtBx_MinTemp.Location = new System.Drawing.Point(93, 92);
            this.txtBx_MinTemp.Mask = "000 \\C°";
            this.txtBx_MinTemp.Name = "txtBx_MinTemp";
            this.txtBx_MinTemp.PromptChar = ' ';
            this.txtBx_MinTemp.Size = new System.Drawing.Size(38, 20);
            this.txtBx_MinTemp.TabIndex = 8;
            this.txtBx_MinTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBx_MinTemp.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtBx_MinTemp.TextChanged += new System.EventHandler(this.txtBx_MinTemp_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.IncDec_Temp);
            this.groupBox1.Controls.Add(this.lbl_TempDirection);
            this.groupBox1.Controls.Add(this.lbl_Temp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBx_MinTemp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBx_MaxTemp);
            this.groupBox1.Location = new System.Drawing.Point(140, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 118);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temp Bounds";
            // 
            // IncDec_Temp
            // 
            this.IncDec_Temp.Location = new System.Drawing.Point(113, 54);
            this.IncDec_Temp.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.IncDec_Temp.Name = "IncDec_Temp";
            this.IncDec_Temp.Size = new System.Drawing.Size(18, 20);
            this.IncDec_Temp.TabIndex = 11;
            // 
            // lbl_TempDirection
            // 
            this.lbl_TempDirection.AutoSize = true;
            this.lbl_TempDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TempDirection.Location = new System.Drawing.Point(76, 54);
            this.lbl_TempDirection.Name = "lbl_TempDirection";
            this.lbl_TempDirection.Size = new System.Drawing.Size(19, 15);
            this.lbl_TempDirection.TabIndex = 10;
            this.lbl_TempDirection.Text = "---";
            // 
            // lbl_Temp
            // 
            this.lbl_Temp.AutoSize = true;
            this.lbl_Temp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Temp.Location = new System.Drawing.Point(10, 54);
            this.lbl_Temp.Name = "lbl_Temp";
            this.lbl_Temp.Size = new System.Drawing.Size(38, 20);
            this.lbl_Temp.TabIndex = 9;
            this.lbl_Temp.Text = "0 C°";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Silver;
            this.groupBox2.Controls.Add(this.lblLoadBar);
            this.groupBox2.Controls.Add(this.lblLoad);
            this.groupBox2.Controls.Add(this.lblClockSpeed);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(140, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 92);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current CPU";
            // 
            // lblLoadBar
            // 
            this.lblLoadBar.AutoSize = true;
            this.lblLoadBar.Location = new System.Drawing.Point(58, 76);
            this.lblLoadBar.Name = "lblLoadBar";
            this.lblLoadBar.Size = new System.Drawing.Size(87, 13);
            this.lblLoadBar.TabIndex = 8;
            this.lblLoadBar.Text = "OOOOOOOOOO";
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Location = new System.Drawing.Point(90, 54);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(21, 13);
            this.lblLoad.TabIndex = 7;
            this.lblLoad.Text = "p%";
            // 
            // lblClockSpeed
            // 
            this.lblClockSpeed.AutoSize = true;
            this.lblClockSpeed.Location = new System.Drawing.Point(23, 28);
            this.lblClockSpeed.Name = "lblClockSpeed";
            this.lblClockSpeed.Size = new System.Drawing.Size(38, 13);
            this.lblClockSpeed.TabIndex = 5;
            this.lblClockSpeed.Text = "X GHz";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Load";
            // 
            // timer_Controller
            // 
            this.timer_Controller.Tick += new System.EventHandler(this.timer_Controller_Tick);
            // 
            // lbl_IsNotElevated
            // 
            this.lbl_IsNotElevated.AutoSize = true;
            this.lbl_IsNotElevated.BackColor = System.Drawing.Color.Maroon;
            this.lbl_IsNotElevated.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_IsNotElevated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lbl_IsNotElevated.Location = new System.Drawing.Point(1, 260);
            this.lbl_IsNotElevated.Name = "lbl_IsNotElevated";
            this.lbl_IsNotElevated.Size = new System.Drawing.Size(0, 13);
            this.lbl_IsNotElevated.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Silver;
            this.groupBox3.Controls.Add(this.IncDec_LimitMinP);
            this.groupBox3.Controls.Add(this.IncDec_LimitMaxP);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtBx_LimitMinP);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtBx_LimitMaxP);
            this.groupBox3.Location = new System.Drawing.Point(6, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 74);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "P% Limiter";
            // 
            // IncDec_LimitMinP
            // 
            this.IncDec_LimitMinP.Location = new System.Drawing.Point(88, 47);
            this.IncDec_LimitMinP.Name = "IncDec_LimitMinP";
            this.IncDec_LimitMinP.Size = new System.Drawing.Size(18, 20);
            this.IncDec_LimitMinP.TabIndex = 12;
            // 
            // IncDec_LimitMaxP
            // 
            this.IncDec_LimitMaxP.Location = new System.Drawing.Point(88, 21);
            this.IncDec_LimitMaxP.Name = "IncDec_LimitMaxP";
            this.IncDec_LimitMaxP.Size = new System.Drawing.Size(18, 20);
            this.IncDec_LimitMaxP.TabIndex = 11;
            this.IncDec_LimitMaxP.ValueChanged += new System.EventHandler(this.InvDec_LimitMaxP_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Max p%";
            // 
            // txtBx_LimitMinP
            // 
            this.txtBx_LimitMinP.Location = new System.Drawing.Point(48, 47);
            this.txtBx_LimitMinP.Mask = "000%";
            this.txtBx_LimitMinP.Name = "txtBx_LimitMinP";
            this.txtBx_LimitMinP.PromptChar = ' ';
            this.txtBx_LimitMinP.Size = new System.Drawing.Size(34, 20);
            this.txtBx_LimitMinP.TabIndex = 8;
            this.txtBx_LimitMinP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBx_LimitMinP.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtBx_LimitMinP.TextChanged += new System.EventHandler(this.txtBx_LimitMinP_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Min p%";
            // 
            // txtBx_LimitMaxP
            // 
            this.txtBx_LimitMaxP.Location = new System.Drawing.Point(48, 21);
            this.txtBx_LimitMaxP.Mask = "000%";
            this.txtBx_LimitMaxP.Name = "txtBx_LimitMaxP";
            this.txtBx_LimitMaxP.PromptChar = ' ';
            this.txtBx_LimitMaxP.Size = new System.Drawing.Size(34, 20);
            this.txtBx_LimitMaxP.TabIndex = 7;
            this.txtBx_LimitMaxP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBx_LimitMaxP.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtBx_LimitMaxP.ValidatingType = typeof(int);
            this.txtBx_LimitMaxP.TextChanged += new System.EventHandler(this.txtBx_LimitMaxP_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Silver;
            this.groupBox4.Controls.Add(this.chBx_CarryLower);
            this.groupBox4.Controls.Add(this.IncDec_LowerP);
            this.groupBox4.Controls.Add(this.IncDec_UpperP);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtBx_LowerP);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtBx_UpperP);
            this.groupBox4.Location = new System.Drawing.Point(6, 143);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(120, 85);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Current CPU Setting";
            // 
            // chBx_CarryLower
            // 
            this.chBx_CarryLower.AutoSize = true;
            this.chBx_CarryLower.Location = new System.Drawing.Point(7, 67);
            this.chBx_CarryLower.Name = "chBx_CarryLower";
            this.chBx_CarryLower.Size = new System.Drawing.Size(82, 17);
            this.chBx_CarryLower.TabIndex = 13;
            this.chBx_CarryLower.Text = "Carry Lower";
            this.chBx_CarryLower.UseVisualStyleBackColor = true;
            // 
            // IncDec_LowerP
            // 
            this.IncDec_LowerP.Location = new System.Drawing.Point(99, 47);
            this.IncDec_LowerP.Name = "IncDec_LowerP";
            this.IncDec_LowerP.Size = new System.Drawing.Size(18, 20);
            this.IncDec_LowerP.TabIndex = 12;
            // 
            // IncDec_UpperP
            // 
            this.IncDec_UpperP.Location = new System.Drawing.Point(99, 21);
            this.IncDec_UpperP.Name = "IncDec_UpperP";
            this.IncDec_UpperP.Size = new System.Drawing.Size(18, 20);
            this.IncDec_UpperP.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Upper p%";
            // 
            // txtBx_LowerP
            // 
            this.txtBx_LowerP.Location = new System.Drawing.Point(59, 47);
            this.txtBx_LowerP.Mask = "000%";
            this.txtBx_LowerP.Name = "txtBx_LowerP";
            this.txtBx_LowerP.PromptChar = ' ';
            this.txtBx_LowerP.Size = new System.Drawing.Size(34, 20);
            this.txtBx_LowerP.TabIndex = 8;
            this.txtBx_LowerP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBx_LowerP.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtBx_LowerP.TextChanged += new System.EventHandler(this.txtBx_LowerP_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Lower p%";
            // 
            // txtBx_UpperP
            // 
            this.txtBx_UpperP.Location = new System.Drawing.Point(59, 21);
            this.txtBx_UpperP.Mask = "000%";
            this.txtBx_UpperP.Name = "txtBx_UpperP";
            this.txtBx_UpperP.PromptChar = ' ';
            this.txtBx_UpperP.Size = new System.Drawing.Size(34, 20);
            this.txtBx_UpperP.TabIndex = 7;
            this.txtBx_UpperP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBx_UpperP.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtBx_UpperP.ValidatingType = typeof(int);
            this.txtBx_UpperP.TextChanged += new System.EventHandler(this.txtBx_UpperP_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Silver;
            this.groupBox5.Controls.Add(this.chBx_ToggleManager);
            this.groupBox5.Location = new System.Drawing.Point(6, 9);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(120, 48);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Toggle Manager";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Silver;
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.maskedTextBox1);
            this.groupBox6.Controls.Add(this.lbl_ArrowUp);
            this.groupBox6.Controls.Add(this.txtBx_WaitTime);
            this.groupBox6.Controls.Add(this.lbl_CycleTime);
            this.groupBox6.Controls.Add(this.lbl_ArrowDown);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Location = new System.Drawing.Point(297, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(96, 174);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Cycle";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Step size";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.AsciiOnly = true;
            this.maskedTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.maskedTextBox1.Location = new System.Drawing.Point(6, 80);
            this.maskedTextBox1.Mask = "000%";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PromptChar = ' ';
            this.maskedTextBox1.Size = new System.Drawing.Size(54, 20);
            this.maskedTextBox1.TabIndex = 11;
            this.maskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maskedTextBox1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // lbl_ArrowUp
            // 
            this.lbl_ArrowUp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_ArrowUp.AutoSize = true;
            this.lbl_ArrowUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ArrowUp.Location = new System.Drawing.Point(66, 139);
            this.lbl_ArrowUp.Name = "lbl_ArrowUp";
            this.lbl_ArrowUp.Size = new System.Drawing.Size(19, 15);
            this.lbl_ArrowUp.TabIndex = 10;
            this.lbl_ArrowUp.Text = "/\\";
            // 
            // txtBx_WaitTime
            // 
            this.txtBx_WaitTime.AsciiOnly = true;
            this.txtBx_WaitTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtBx_WaitTime.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.txtBx_WaitTime.Location = new System.Drawing.Point(6, 41);
            this.txtBx_WaitTime.Mask = "00000\\m\\s";
            this.txtBx_WaitTime.Name = "txtBx_WaitTime";
            this.txtBx_WaitTime.PromptChar = ' ';
            this.txtBx_WaitTime.Size = new System.Drawing.Size(54, 20);
            this.txtBx_WaitTime.TabIndex = 8;
            this.txtBx_WaitTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBx_WaitTime.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtBx_WaitTime.TextChanged += new System.EventHandler(this.txtBx_WaitTime_TextChanged);
            // 
            // lbl_CycleTime
            // 
            this.lbl_CycleTime.AutoSize = true;
            this.lbl_CycleTime.Location = new System.Drawing.Point(34, 141);
            this.lbl_CycleTime.Name = "lbl_CycleTime";
            this.lbl_CycleTime.Size = new System.Drawing.Size(31, 13);
            this.lbl_CycleTime.TabIndex = 7;
            this.lbl_CycleTime.Text = "0000";
            this.lbl_CycleTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ArrowDown
            // 
            this.lbl_ArrowDown.AutoSize = true;
            this.lbl_ArrowDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ArrowDown.Location = new System.Drawing.Point(12, 139);
            this.lbl_ArrowDown.Name = "lbl_ArrowDown";
            this.lbl_ArrowDown.Size = new System.Drawing.Size(19, 15);
            this.lbl_ArrowDown.TabIndex = 9;
            this.lbl_ArrowDown.Text = "\\/";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Length";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Current Cycle";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkGray;
            this.flowLayoutPanel1.Controls.Add(this.checkBox2);
            this.flowLayoutPanel1.Controls.Add(this.checkBox3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(399, 311);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(389, 37);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(3, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 17);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(89, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(80, 17);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // btn_Apply
            // 
            this.btn_Apply.Location = new System.Drawing.Point(297, 193);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(69, 35);
            this.btn_Apply.TabIndex = 17;
            this.btn_Apply.Text = "Apply";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(372, 192);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(21, 36);
            this.btn_Cancel.TabIndex = 18;
            this.btn_Cancel.Text = "X";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // timer_ValueUpdater
            // 
            this.timer_ValueUpdater.Tick += new System.EventHandler(this.timer_ValueUpdater_Tick);
            // 
            // lblWPP
            // 
            this.lblWPP.AutoSize = true;
            this.lblWPP.Location = new System.Drawing.Point(294, 238);
            this.lblWPP.Name = "lblWPP";
            this.lblWPP.Size = new System.Drawing.Size(84, 13);
            this.lblWPP.TabIndex = 20;
            this.lblWPP.Text = "Current WPP: ---";
            // 
            // lblWPPUpdate
            // 
            this.lblWPPUpdate.AutoSize = true;
            this.lblWPPUpdate.Location = new System.Drawing.Point(286, 252);
            this.lblWPPUpdate.Name = "lblWPPUpdate";
            this.lblWPPUpdate.Size = new System.Drawing.Size(92, 13);
            this.lblWPPUpdate.TabIndex = 21;
            this.lblWPPUpdate.Text = "Last Update --:--:--";
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(399, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(572, 296);
            this.canvas.TabIndex = 19;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(983, 388);
            this.Controls.Add(this.lblWPPUpdate);
            this.Controls.Add(this.lblWPP);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Apply);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lbl_IsNotElevated);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCputemp);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "TMP - Temperature Management Program";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IncDec_Temp)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IncDec_LimitMinP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncDec_LimitMaxP)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IncDec_LowerP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncDec_UpperP)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCputemp;
        private System.Windows.Forms.CheckBox chBx_ToggleManager;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtBx_MaxTemp;
        private System.Windows.Forms.MaskedTextBox txtBx_MinTemp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblClockSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_TempDirection;
        private System.Windows.Forms.Label lbl_Temp;
        private System.Windows.Forms.NumericUpDown IncDec_Temp;
        private System.Windows.Forms.Timer timer_Controller;
        private System.Windows.Forms.Label lbl_IsNotElevated;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown IncDec_LimitMaxP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtBx_LimitMinP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtBx_LimitMaxP;
        private System.Windows.Forms.NumericUpDown IncDec_LimitMinP;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown IncDec_LowerP;
        private System.Windows.Forms.NumericUpDown IncDec_UpperP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtBx_LowerP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox txtBx_UpperP;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lbl_CycleTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtBx_WaitTime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_ArrowUp;
        private System.Windows.Forms.Label lbl_ArrowDown;
        private System.Windows.Forms.Timer timer_ValueUpdater;
        private System.Windows.Forms.CheckBox chBx_CarryLower;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private canvas canvas;
        private System.Windows.Forms.Label lblWPP;
        private System.Windows.Forms.Label lblWPPUpdate;
        private System.Windows.Forms.Label lblLoadBar;
    }
}

