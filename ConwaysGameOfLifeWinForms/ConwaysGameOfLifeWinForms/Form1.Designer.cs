
namespace ConwaysGameOfLifeWinForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbShape = new System.Windows.Forms.ComboBox();
            this.cbPolicy = new System.Windows.Forms.ComboBox();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.cbSeed = new System.Windows.Forms.ComboBox();
            this.cbWalls = new System.Windows.Forms.ComboBox();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shape:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Policy:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(585, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Seed:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(590, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Walls:";
            // 
            // cbShape
            // 
            this.cbShape.FormattingEnabled = true;
            this.cbShape.Items.AddRange(new object[] {
            "Rectengular",
            "Diamond",
            "Cross",
            "Circular"});
            this.cbShape.Location = new System.Drawing.Point(85, 34);
            this.cbShape.Name = "cbShape";
            this.cbShape.Size = new System.Drawing.Size(121, 21);
            this.cbShape.TabIndex = 6;
            // 
            // cbPolicy
            // 
            this.cbPolicy.FormattingEnabled = true;
            this.cbPolicy.Items.AddRange(new object[] {
            "Conway",
            "Hyperactive",
            "High Life",
            "Spantaneous"});
            this.cbPolicy.Location = new System.Drawing.Point(85, 94);
            this.cbPolicy.Name = "cbPolicy";
            this.cbPolicy.Size = new System.Drawing.Size(121, 21);
            this.cbPolicy.TabIndex = 7;
            // 
            // cbSize
            // 
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Items.AddRange(new object[] {
            "6x6",
            "8x8",
            "10x10",
            "15x15",
            "20x20",
            "30x30",
            "50x50",
            "75x75",
            "100x100"});
            this.cbSize.Location = new System.Drawing.Point(371, 34);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(121, 21);
            this.cbSize.TabIndex = 8;
            // 
            // cbSeed
            // 
            this.cbSeed.FormattingEnabled = true;
            this.cbSeed.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "Large"});
            this.cbSeed.Location = new System.Drawing.Point(645, 34);
            this.cbSeed.Name = "cbSeed";
            this.cbSeed.Size = new System.Drawing.Size(121, 21);
            this.cbSeed.TabIndex = 10;
            // 
            // cbWalls
            // 
            this.cbWalls.FormattingEnabled = true;
            this.cbWalls.Items.AddRange(new object[] {
            "Not Active",
            "Alive"});
            this.cbWalls.Location = new System.Drawing.Point(645, 95);
            this.cbWalls.Name = "cbWalls";
            this.cbWalls.Size = new System.Drawing.Size(121, 21);
            this.cbWalls.TabIndex = 11;
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(23, 141);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(743, 32);
            this.StartGameButton.TabIndex = 12;
            this.StartGameButton.Text = "Start";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(23, 179);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1256, 407);
            this.pictureBox.TabIndex = 13;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Picture_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 598);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.StartGameButton);
            this.Controls.Add(this.cbWalls);
            this.Controls.Add(this.cbSeed);
            this.Controls.Add(this.cbSize);
            this.Controls.Add(this.cbPolicy);
            this.Controls.Add(this.cbShape);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Conway\'s Game of Life";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbShape;
        private System.Windows.Forms.ComboBox cbPolicy;
        private System.Windows.Forms.ComboBox cbSize;
        private System.Windows.Forms.ComboBox cbSeed;
        private System.Windows.Forms.ComboBox cbWalls;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

