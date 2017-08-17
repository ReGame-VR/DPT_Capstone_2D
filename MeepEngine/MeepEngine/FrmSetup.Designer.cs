namespace MeepEngine
{
    partial class FrmSetup
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label17;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetup));
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDay = new System.Windows.Forms.NumericUpDown();
            this.txtBlock = new System.Windows.Forms.NumericUpDown();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.pathBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxHand = new System.Windows.Forms.ComboBox();
            this.cbxDifficulty = new System.Windows.Forms.ComboBox();
            this.chkScore = new System.Windows.Forms.CheckBox();
            this.chkFreePlay = new System.Windows.Forms.CheckBox();
            this.txtVelocityThreshold = new System.Windows.Forms.NumericUpDown();
            this.txtRangeNWx = new System.Windows.Forms.NumericUpDown();
            this.txtRangeNEx = new System.Windows.Forms.NumericUpDown();
            this.txtRangeSWx = new System.Windows.Forms.NumericUpDown();
            this.txtRangeSEx = new System.Windows.Forms.NumericUpDown();
            this.txtRangeNWy = new System.Windows.Forms.NumericUpDown();
            this.txtRangeNEy = new System.Windows.Forms.NumericUpDown();
            this.txtRangeSWy = new System.Windows.Forms.NumericUpDown();
            this.txtRangeSEy = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTotalAsteroids = new System.Windows.Forms.NumericUpDown();
            this.chkMute = new System.Windows.Forms.CheckBox();
            this.chkSterile = new System.Windows.Forms.CheckBox();
            this.chkEnableSequences = new System.Windows.Forms.CheckBox();
            this.rdoTrainingSequence = new System.Windows.Forms.RadioButton();
            this.rdoTestingSequence = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFixedBlock = new System.Windows.Forms.TextBox();
            this.txtRNGSeed = new System.Windows.Forms.NumericUpDown();
            this.chkMouse = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVelocityThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeNWx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeNEx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeSWx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeSEx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeNWy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeNEy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeSWy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeSEy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAsteroids)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRNGSeed)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(18, 22);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 13);
            label1.TabIndex = 1;
            label1.Text = "Directory:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(18, 76);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(46, 13);
            label2.TabIndex = 3;
            label2.Text = "Subject:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(230, 76);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(29, 13);
            label3.TabIndex = 4;
            label3.Text = "Day:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(312, 76);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(37, 13);
            label4.TabIndex = 5;
            label4.Text = "Block:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(34, 242);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(97, 13);
            label8.TabIndex = 16;
            label8.Text = "Velocity Threshold:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(174, 242);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(89, 13);
            label7.TabIndex = 17;
            label7.Text = "Range of Motion:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(203, 263);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(14, 13);
            label9.TabIndex = 18;
            label9.Text = "X";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(250, 263);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(14, 13);
            label10.TabIndex = 19;
            label10.Text = "Y";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(171, 281);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(26, 13);
            label11.TabIndex = 20;
            label11.Text = "NW";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(176, 359);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(21, 13);
            label12.TabIndex = 21;
            label12.Text = "SE";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(172, 333);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(25, 13);
            label13.TabIndex = 22;
            label13.Text = "SW";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(175, 307);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(22, 13);
            label14.TabIndex = 23;
            label14.Text = "NE";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(250, 144);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(80, 13);
            label16.TabIndex = 42;
            label16.Text = "Total Asteroids:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(10, 128);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(35, 13);
            label15.TabIndex = 53;
            label15.Text = "Seed:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(10, 158);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(35, 13);
            label17.TabIndex = 54;
            label17.Text = "Fixed:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(21, 40);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.ReadOnly = true;
            this.txtDirectory.Size = new System.Drawing.Size(375, 20);
            this.txtDirectory.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(402, 38);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(265, 73);
            this.txtDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(41, 20);
            this.txtDay.TabIndex = 6;
            this.txtDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtBlock
            // 
            this.txtBlock.Location = new System.Drawing.Point(355, 73);
            this.txtBlock.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(41, 20);
            this.txtBlock.TabIndex = 7;
            this.txtBlock.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(70, 73);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(154, 20);
            this.txtSubject.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hand:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Difficulty:";
            // 
            // cbxHand
            // 
            this.cbxHand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHand.FormattingEnabled = true;
            this.cbxHand.Items.AddRange(new object[] {
            "Right Hand",
            "Left Hand"});
            this.cbxHand.Location = new System.Drawing.Point(60, 105);
            this.cbxHand.Name = "cbxHand";
            this.cbxHand.Size = new System.Drawing.Size(107, 21);
            this.cbxHand.TabIndex = 11;
            // 
            // cbxDifficulty
            // 
            this.cbxDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDifficulty.FormattingEnabled = true;
            this.cbxDifficulty.Items.AddRange(new object[] {
            "Learner I",
            "Learner II",
            "Learner III",
            "Novice I",
            "Novice II",
            "Novice III",
            "Professional I",
            "Professional II",
            "Professional III",
            "Expert I",
            "Expert II",
            "Expert III"});
            this.cbxDifficulty.Location = new System.Drawing.Point(230, 105);
            this.cbxDifficulty.Name = "cbxDifficulty";
            this.cbxDifficulty.Size = new System.Drawing.Size(166, 21);
            this.cbxDifficulty.TabIndex = 12;
            // 
            // chkScore
            // 
            this.chkScore.AutoSize = true;
            this.chkScore.Location = new System.Drawing.Point(21, 143);
            this.chkScore.Name = "chkScore";
            this.chkScore.Size = new System.Drawing.Size(105, 17);
            this.chkScore.TabIndex = 13;
            this.chkScore.Text = "Score Feedback";
            this.chkScore.UseVisualStyleBackColor = true;
            // 
            // chkFreePlay
            // 
            this.chkFreePlay.AutoSize = true;
            this.chkFreePlay.Location = new System.Drawing.Point(21, 166);
            this.chkFreePlay.Name = "chkFreePlay";
            this.chkFreePlay.Size = new System.Drawing.Size(70, 17);
            this.chkFreePlay.TabIndex = 14;
            this.chkFreePlay.Text = "Free Play";
            this.chkFreePlay.UseVisualStyleBackColor = true;
            // 
            // txtVelocityThreshold
            // 
            this.txtVelocityThreshold.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtVelocityThreshold.Location = new System.Drawing.Point(37, 263);
            this.txtVelocityThreshold.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtVelocityThreshold.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtVelocityThreshold.Name = "txtVelocityThreshold";
            this.txtVelocityThreshold.Size = new System.Drawing.Size(57, 20);
            this.txtVelocityThreshold.TabIndex = 24;
            this.txtVelocityThreshold.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // txtRangeNWx
            // 
            this.txtRangeNWx.Location = new System.Drawing.Point(203, 279);
            this.txtRangeNWx.Maximum = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.txtRangeNWx.Name = "txtRangeNWx";
            this.txtRangeNWx.Size = new System.Drawing.Size(44, 20);
            this.txtRangeNWx.TabIndex = 25;
            // 
            // txtRangeNEx
            // 
            this.txtRangeNEx.Location = new System.Drawing.Point(203, 305);
            this.txtRangeNEx.Maximum = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.txtRangeNEx.Name = "txtRangeNEx";
            this.txtRangeNEx.Size = new System.Drawing.Size(44, 20);
            this.txtRangeNEx.TabIndex = 27;
            // 
            // txtRangeSWx
            // 
            this.txtRangeSWx.Location = new System.Drawing.Point(203, 331);
            this.txtRangeSWx.Maximum = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.txtRangeSWx.Name = "txtRangeSWx";
            this.txtRangeSWx.Size = new System.Drawing.Size(44, 20);
            this.txtRangeSWx.TabIndex = 33;
            // 
            // txtRangeSEx
            // 
            this.txtRangeSEx.Location = new System.Drawing.Point(203, 357);
            this.txtRangeSEx.Maximum = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.txtRangeSEx.Name = "txtRangeSEx";
            this.txtRangeSEx.Size = new System.Drawing.Size(44, 20);
            this.txtRangeSEx.TabIndex = 34;
            // 
            // txtRangeNWy
            // 
            this.txtRangeNWy.Location = new System.Drawing.Point(253, 279);
            this.txtRangeNWy.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.txtRangeNWy.Name = "txtRangeNWy";
            this.txtRangeNWy.Size = new System.Drawing.Size(44, 20);
            this.txtRangeNWy.TabIndex = 35;
            // 
            // txtRangeNEy
            // 
            this.txtRangeNEy.Location = new System.Drawing.Point(253, 305);
            this.txtRangeNEy.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.txtRangeNEy.Name = "txtRangeNEy";
            this.txtRangeNEy.Size = new System.Drawing.Size(44, 20);
            this.txtRangeNEy.TabIndex = 36;
            // 
            // txtRangeSWy
            // 
            this.txtRangeSWy.Location = new System.Drawing.Point(253, 331);
            this.txtRangeSWy.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.txtRangeSWy.Name = "txtRangeSWy";
            this.txtRangeSWy.Size = new System.Drawing.Size(44, 20);
            this.txtRangeSWy.TabIndex = 37;
            // 
            // txtRangeSEy
            // 
            this.txtRangeSEy.Location = new System.Drawing.Point(253, 357);
            this.txtRangeSEy.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.txtRangeSEy.Name = "txtRangeSEy";
            this.txtRangeSEy.Size = new System.Drawing.Size(44, 20);
            this.txtRangeSEy.TabIndex = 38;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(355, 143);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 40);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTotalAsteroids
            // 
            this.txtTotalAsteroids.Location = new System.Drawing.Point(253, 161);
            this.txtTotalAsteroids.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtTotalAsteroids.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTotalAsteroids.Name = "txtTotalAsteroids";
            this.txtTotalAsteroids.Size = new System.Drawing.Size(77, 20);
            this.txtTotalAsteroids.TabIndex = 43;
            this.txtTotalAsteroids.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // chkMute
            // 
            this.chkMute.AutoSize = true;
            this.chkMute.Location = new System.Drawing.Point(133, 166);
            this.chkMute.Name = "chkMute";
            this.chkMute.Size = new System.Drawing.Size(84, 17);
            this.chkMute.TabIndex = 44;
            this.chkMute.Text = "Mute Sound";
            this.chkMute.UseVisualStyleBackColor = true;
            // 
            // chkSterile
            // 
            this.chkSterile.AutoSize = true;
            this.chkSterile.Location = new System.Drawing.Point(132, 143);
            this.chkSterile.Name = "chkSterile";
            this.chkSterile.Size = new System.Drawing.Size(100, 17);
            this.chkSterile.TabIndex = 45;
            this.chkSterile.Text = "Sterile Graphics";
            this.chkSterile.UseVisualStyleBackColor = true;
            // 
            // chkEnableSequences
            // 
            this.chkEnableSequences.AutoSize = true;
            this.chkEnableSequences.Location = new System.Drawing.Point(13, 19);
            this.chkEnableSequences.Name = "chkEnableSequences";
            this.chkEnableSequences.Size = new System.Drawing.Size(59, 17);
            this.chkEnableSequences.TabIndex = 48;
            this.chkEnableSequences.Text = "Enable";
            this.chkEnableSequences.UseVisualStyleBackColor = true;
            this.chkEnableSequences.CheckedChanged += new System.EventHandler(this.chkEnableSequences_CheckedChanged);
            // 
            // rdoTrainingSequence
            // 
            this.rdoTrainingSequence.AutoSize = true;
            this.rdoTrainingSequence.Location = new System.Drawing.Point(13, 52);
            this.rdoTrainingSequence.Name = "rdoTrainingSequence";
            this.rdoTrainingSequence.Size = new System.Drawing.Size(63, 17);
            this.rdoTrainingSequence.TabIndex = 49;
            this.rdoTrainingSequence.TabStop = true;
            this.rdoTrainingSequence.Text = "Training";
            this.rdoTrainingSequence.UseVisualStyleBackColor = true;
            // 
            // rdoTestingSequence
            // 
            this.rdoTestingSequence.AutoSize = true;
            this.rdoTestingSequence.Location = new System.Drawing.Point(13, 75);
            this.rdoTestingSequence.Name = "rdoTestingSequence";
            this.rdoTestingSequence.Size = new System.Drawing.Size(60, 17);
            this.rdoTestingSequence.TabIndex = 50;
            this.rdoTestingSequence.TabStop = true;
            this.rdoTestingSequence.Text = "Testing";
            this.rdoTestingSequence.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(21, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 198);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calibration Parameters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFixedBlock);
            this.groupBox2.Controls.Add(label17);
            this.groupBox2.Controls.Add(this.txtRNGSeed);
            this.groupBox2.Controls.Add(label15);
            this.groupBox2.Controls.Add(this.rdoTestingSequence);
            this.groupBox2.Controls.Add(this.chkEnableSequences);
            this.groupBox2.Controls.Add(this.rdoTrainingSequence);
            this.groupBox2.Location = new System.Drawing.Point(328, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 198);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sequences";
            // 
            // txtFixedBlock
            // 
            this.txtFixedBlock.Location = new System.Drawing.Point(51, 155);
            this.txtFixedBlock.Name = "txtFixedBlock";
            this.txtFixedBlock.Size = new System.Drawing.Size(98, 20);
            this.txtFixedBlock.TabIndex = 53;
            // 
            // txtRNGSeed
            // 
            this.txtRNGSeed.Location = new System.Drawing.Point(51, 126);
            this.txtRNGSeed.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtRNGSeed.Name = "txtRNGSeed";
            this.txtRNGSeed.Size = new System.Drawing.Size(98, 20);
            this.txtRNGSeed.TabIndex = 53;
            // 
            // chkMouse
            // 
            this.chkMouse.AutoSize = true;
            this.chkMouse.Location = new System.Drawing.Point(407, 109);
            this.chkMouse.Name = "chkMouse";
            this.chkMouse.Size = new System.Drawing.Size(94, 17);
            this.chkMouse.TabIndex = 53;
            this.chkMouse.Text = "Mouse Control";
            this.chkMouse.UseVisualStyleBackColor = true;
            // 
            // FrmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 427);
            this.Controls.Add(this.chkMouse);
            this.Controls.Add(this.chkSterile);
            this.Controls.Add(this.chkMute);
            this.Controls.Add(this.txtTotalAsteroids);
            this.Controls.Add(label16);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRangeSEy);
            this.Controls.Add(this.txtRangeSWy);
            this.Controls.Add(this.txtRangeNEy);
            this.Controls.Add(this.txtRangeNWy);
            this.Controls.Add(this.txtRangeSEx);
            this.Controls.Add(this.txtRangeSWx);
            this.Controls.Add(this.txtRangeNEx);
            this.Controls.Add(this.txtRangeNWx);
            this.Controls.Add(this.txtVelocityThreshold);
            this.Controls.Add(label14);
            this.Controls.Add(label13);
            this.Controls.Add(label12);
            this.Controls.Add(label11);
            this.Controls.Add(label10);
            this.Controls.Add(label9);
            this.Controls.Add(label7);
            this.Controls.Add(label8);
            this.Controls.Add(this.chkFreePlay);
            this.Controls.Add(this.chkScore);
            this.Controls.Add(this.cbxDifficulty);
            this.Controls.Add(this.cbxHand);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtBlock);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSetup";
            this.Text = "Setup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSetup_FormClosing);
            this.Load += new System.EventHandler(this.FrmSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVelocityThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeNWx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeNEx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeSWx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeSEx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeNWy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeNEy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeSWy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeSEy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAsteroids)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRNGSeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.NumericUpDown txtDay;
        private System.Windows.Forms.NumericUpDown txtBlock;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.FolderBrowserDialog pathBrowser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxHand;
        private System.Windows.Forms.ComboBox cbxDifficulty;
        private System.Windows.Forms.CheckBox chkScore;
        private System.Windows.Forms.CheckBox chkFreePlay;
        private System.Windows.Forms.NumericUpDown txtVelocityThreshold;
        private System.Windows.Forms.NumericUpDown txtRangeNWx;
        private System.Windows.Forms.NumericUpDown txtRangeNEx;
        private System.Windows.Forms.NumericUpDown txtRangeSWx;
        private System.Windows.Forms.NumericUpDown txtRangeSEx;
        private System.Windows.Forms.NumericUpDown txtRangeNWy;
        private System.Windows.Forms.NumericUpDown txtRangeNEy;
        private System.Windows.Forms.NumericUpDown txtRangeSWy;
        private System.Windows.Forms.NumericUpDown txtRangeSEy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown txtTotalAsteroids;
        private System.Windows.Forms.CheckBox chkMute;
        private System.Windows.Forms.CheckBox chkSterile;
        private System.Windows.Forms.CheckBox chkEnableSequences;
        private System.Windows.Forms.RadioButton rdoTrainingSequence;
        private System.Windows.Forms.RadioButton rdoTestingSequence;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown txtRNGSeed;
        private System.Windows.Forms.TextBox txtFixedBlock;
        private System.Windows.Forms.CheckBox chkMouse;
    }
}