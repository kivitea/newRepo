namespace lssn_7
{
    partial class Form_Dubler
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
            this.lbl_CurrentNum = new System.Windows.Forms.Label();
            this.Sum_button = new System.Windows.Forms.Button();
            this.lbl_Round = new System.Windows.Forms.Label();
            this.Mult_button = new System.Windows.Forms.Button();
            this.Cancell_button = new System.Windows.Forms.Button();
            this.lbl_Answer = new System.Windows.Forms.Label();
            this.NewGame_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_CurrentNum
            // 
            this.lbl_CurrentNum.AutoSize = true;
            this.lbl_CurrentNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_CurrentNum.Location = new System.Drawing.Point(12, 67);
            this.lbl_CurrentNum.Name = "lbl_CurrentNum";
            this.lbl_CurrentNum.Size = new System.Drawing.Size(196, 24);
            this.lbl_CurrentNum.TabIndex = 0;
            this.lbl_CurrentNum.Text = "Текущее значение: 0";
            // 
            // Sum_button
            // 
            this.Sum_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Sum_button.Location = new System.Drawing.Point(245, 13);
            this.Sum_button.Name = "Sum_button";
            this.Sum_button.Size = new System.Drawing.Size(162, 35);
            this.Sum_button.TabIndex = 1;
            this.Sum_button.Text = "+1";
            this.Sum_button.UseVisualStyleBackColor = true;
            this.Sum_button.Click += new System.EventHandler(this.Sum_button_Click);
            // 
            // lbl_Round
            // 
            this.lbl_Round.AutoSize = true;
            this.lbl_Round.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Round.Location = new System.Drawing.Point(12, 23);
            this.lbl_Round.Name = "lbl_Round";
            this.lbl_Round.Size = new System.Drawing.Size(135, 24);
            this.lbl_Round.TabIndex = 2;
            this.lbl_Round.Text = "Теущий ход: 0";
            // 
            // Mult_button
            // 
            this.Mult_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Mult_button.Location = new System.Drawing.Point(245, 56);
            this.Mult_button.Name = "Mult_button";
            this.Mult_button.Size = new System.Drawing.Size(162, 35);
            this.Mult_button.TabIndex = 3;
            this.Mult_button.Text = "*2";
            this.Mult_button.UseVisualStyleBackColor = true;
            this.Mult_button.Click += new System.EventHandler(this.Mult_button_Click);
            // 
            // Cancell_button
            // 
            this.Cancell_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancell_button.Location = new System.Drawing.Point(245, 97);
            this.Cancell_button.Name = "Cancell_button";
            this.Cancell_button.Size = new System.Drawing.Size(162, 35);
            this.Cancell_button.TabIndex = 4;
            this.Cancell_button.Text = "Отменить";
            this.Cancell_button.UseVisualStyleBackColor = true;
            this.Cancell_button.Click += new System.EventHandler(this.Cancell_button_Click);
            // 
            // lbl_Answer
            // 
            this.lbl_Answer.AutoSize = true;
            this.lbl_Answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Answer.Location = new System.Drawing.Point(12, 108);
            this.lbl_Answer.Name = "lbl_Answer";
            this.lbl_Answer.Size = new System.Drawing.Size(74, 24);
            this.lbl_Answer.TabIndex = 5;
            this.lbl_Answer.Text = "Цель: 0";
            // 
            // NewGame_button
            // 
            this.NewGame_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewGame_button.Location = new System.Drawing.Point(245, 182);
            this.NewGame_button.Name = "NewGame_button";
            this.NewGame_button.Size = new System.Drawing.Size(162, 35);
            this.NewGame_button.TabIndex = 6;
            this.NewGame_button.Text = "Новая игра";
            this.NewGame_button.UseVisualStyleBackColor = true;
            this.NewGame_button.Click += new System.EventHandler(this.NewGame_button_Click);
            // 
            // Form_Dubler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 227);
            this.Controls.Add(this.NewGame_button);
            this.Controls.Add(this.lbl_Answer);
            this.Controls.Add(this.Cancell_button);
            this.Controls.Add(this.Mult_button);
            this.Controls.Add(this.lbl_Round);
            this.Controls.Add(this.Sum_button);
            this.Controls.Add(this.lbl_CurrentNum);
            this.Name = "Form_Dubler";
            this.Text = "Удвоитель";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_CurrentNum;
        private System.Windows.Forms.Button Sum_button;
        private System.Windows.Forms.Label lbl_Round;
        private System.Windows.Forms.Button Mult_button;
        private System.Windows.Forms.Button Cancell_button;
        private System.Windows.Forms.Label lbl_Answer;
        private System.Windows.Forms.Button NewGame_button;
    }
}