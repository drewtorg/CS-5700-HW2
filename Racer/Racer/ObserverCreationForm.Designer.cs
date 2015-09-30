namespace Racer
{
    partial class ObserverCreationForm
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
            this.typeGroupBox = new System.Windows.Forms.GroupBox();
            this.cheatingTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.bigScreenTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.supportTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.creationButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.headerTextBox = new System.Windows.Forms.TextBox();
            this.footerTextBox = new System.Windows.Forms.TextBox();
            this.quoteCheckBox = new System.Windows.Forms.CheckBox();
            this.typeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeGroupBox
            // 
            this.typeGroupBox.Controls.Add(this.cheatingTypeRadioButton);
            this.typeGroupBox.Controls.Add(this.bigScreenTypeRadioButton);
            this.typeGroupBox.Controls.Add(this.supportTypeRadioButton);
            this.typeGroupBox.Location = new System.Drawing.Point(21, 25);
            this.typeGroupBox.Name = "typeGroupBox";
            this.typeGroupBox.Size = new System.Drawing.Size(310, 46);
            this.typeGroupBox.TabIndex = 9;
            this.typeGroupBox.TabStop = false;
            this.typeGroupBox.Text = "Observer Type";
            // 
            // cheatingTypeRadioButton
            // 
            this.cheatingTypeRadioButton.AutoSize = true;
            this.cheatingTypeRadioButton.Location = new System.Drawing.Point(187, 19);
            this.cheatingTypeRadioButton.Name = "cheatingTypeRadioButton";
            this.cheatingTypeRadioButton.Size = new System.Drawing.Size(115, 17);
            this.cheatingTypeRadioButton.TabIndex = 2;
            this.cheatingTypeRadioButton.TabStop = true;
            this.cheatingTypeRadioButton.Text = "Cheating Computer";
            this.cheatingTypeRadioButton.UseVisualStyleBackColor = true;
            this.cheatingTypeRadioButton.CheckedChanged += new System.EventHandler(this.allRadioButton_CheckedChanged);
            // 
            // bigScreenTypeRadioButton
            // 
            this.bigScreenTypeRadioButton.AutoSize = true;
            this.bigScreenTypeRadioButton.Location = new System.Drawing.Point(104, 19);
            this.bigScreenTypeRadioButton.Name = "bigScreenTypeRadioButton";
            this.bigScreenTypeRadioButton.Size = new System.Drawing.Size(77, 17);
            this.bigScreenTypeRadioButton.TabIndex = 1;
            this.bigScreenTypeRadioButton.TabStop = true;
            this.bigScreenTypeRadioButton.Text = "Big Screen";
            this.bigScreenTypeRadioButton.UseVisualStyleBackColor = true;
            this.bigScreenTypeRadioButton.CheckedChanged += new System.EventHandler(this.allRadioButton_CheckedChanged);
            // 
            // supportTypeRadioButton
            // 
            this.supportTypeRadioButton.AutoSize = true;
            this.supportTypeRadioButton.Checked = true;
            this.supportTypeRadioButton.Location = new System.Drawing.Point(6, 19);
            this.supportTypeRadioButton.Name = "supportTypeRadioButton";
            this.supportTypeRadioButton.Size = new System.Drawing.Size(92, 17);
            this.supportTypeRadioButton.TabIndex = 0;
            this.supportTypeRadioButton.TabStop = true;
            this.supportTypeRadioButton.Text = "Support Team";
            this.supportTypeRadioButton.UseVisualStyleBackColor = true;
            this.supportTypeRadioButton.CheckedChanged += new System.EventHandler(this.allRadioButton_CheckedChanged);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(54, 77);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(355, 20);
            this.titleTextBox.TabIndex = 8;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(18, 80);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(30, 13);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "Title:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(21, 219);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // creationButton
            // 
            this.creationButton.Location = new System.Drawing.Point(334, 219);
            this.creationButton.Name = "creationButton";
            this.creationButton.Size = new System.Drawing.Size(75, 23);
            this.creationButton.TabIndex = 5;
            this.creationButton.Text = "Create Observer";
            this.creationButton.UseVisualStyleBackColor = true;
            this.creationButton.Click += new System.EventHandler(this.creationButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Send Emails To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Email Header:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Email Footer:";
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(103, 110);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(306, 20);
            this.toTextBox.TabIndex = 13;
            // 
            // headerTextBox
            // 
            this.headerTextBox.Location = new System.Drawing.Point(103, 136);
            this.headerTextBox.Name = "headerTextBox";
            this.headerTextBox.Size = new System.Drawing.Size(306, 20);
            this.headerTextBox.TabIndex = 14;
            // 
            // footerTextBox
            // 
            this.footerTextBox.Location = new System.Drawing.Point(103, 162);
            this.footerTextBox.Name = "footerTextBox";
            this.footerTextBox.Size = new System.Drawing.Size(306, 20);
            this.footerTextBox.TabIndex = 15;
            // 
            // quoteCheckBox
            // 
            this.quoteCheckBox.AutoSize = true;
            this.quoteCheckBox.Location = new System.Drawing.Point(21, 188);
            this.quoteCheckBox.Name = "quoteCheckBox";
            this.quoteCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.quoteCheckBox.Size = new System.Drawing.Size(139, 17);
            this.quoteCheckBox.TabIndex = 16;
            this.quoteCheckBox.Text = ":Include Random Quote";
            this.quoteCheckBox.UseVisualStyleBackColor = true;
            // 
            // ObserverCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 248);
            this.Controls.Add(this.quoteCheckBox);
            this.Controls.Add(this.footerTextBox);
            this.Controls.Add(this.headerTextBox);
            this.Controls.Add(this.toTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeGroupBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.creationButton);
            this.Name = "ObserverCreationForm";
            this.Text = "ObserverCreationForm";
            this.typeGroupBox.ResumeLayout(false);
            this.typeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox typeGroupBox;
        private System.Windows.Forms.RadioButton bigScreenTypeRadioButton;
        private System.Windows.Forms.RadioButton supportTypeRadioButton;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button creationButton;
        private System.Windows.Forms.RadioButton cheatingTypeRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.TextBox headerTextBox;
        private System.Windows.Forms.TextBox footerTextBox;
        private System.Windows.Forms.CheckBox quoteCheckBox;
    }
}