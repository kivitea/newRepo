namespace lssn_7
{
    partial class Form_GuessNum
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
            this.AnswerBox = new System.Windows.Forms.TextBox();
            this.lbl_Desc = new System.Windows.Forms.Label();
            this.Answer_button = new System.Windows.Forms.Button();
            this.lbl_RoundNum = new System.Windows.Forms.Label();
            this.lbl_Hint = new System.Windows.Forms.Label();
            this.NewGame_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AnswerBox
            // 
            this.AnswerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnswerBox.Location = new System.Drawing.Point(18, 146);
            this.AnswerBox.Name = "AnswerBox";
            this.AnswerBox.Size = new System.Drawing.Size(122, 30);
            this.AnswerBox.TabIndex = 0;
            // 
            // lbl_Desc
            // 
            this.lbl_Desc.AutoSize = true;
            this.lbl_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Desc.Location = new System.Drawing.Point(12, 22);
            this.lbl_Desc.Name = "lbl_Desc";
            this.lbl_Desc.Size = new System.Drawing.Size(256, 24);
            this.lbl_Desc.TabIndex = 1;
            this.lbl_Desc.Text = "Угадайте число от 1 до 100";
            // 
            // Answer_button
            // 
            this.Answer_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Answer_button.Location = new System.Drawing.Point(143, 146);
            this.Answer_button.Name = "Answer_button";
            this.Answer_button.Size = new System.Drawing.Size(126, 30);
            this.Answer_button.TabIndex = 2;
            this.Answer_button.Text = "Ответить";
            this.Answer_button.UseVisualStyleBackColor = true;
            this.Answer_button.Click += new System.EventHandler(this.Answer_button_Click);
            // 
            // lbl_RoundNum
            // 
            this.lbl_RoundNum.AutoSize = true;
            this.lbl_RoundNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_RoundNum.Location = new System.Drawing.Point(13, 63);
            this.lbl_RoundNum.Name = "lbl_RoundNum";
            this.lbl_RoundNum.Size = new System.Drawing.Size(168, 24);
            this.lbl_RoundNum.TabIndex = 3;
            this.lbl_RoundNum.Text = "Сделано ходов: 0";
            // 
            // lbl_Hint
            // 
            this.lbl_Hint.AutoSize = true;
            this.lbl_Hint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Hint.Location = new System.Drawing.Point(14, 101);
            this.lbl_Hint.Name = "lbl_Hint";
            this.lbl_Hint.Size = new System.Drawing.Size(206, 24);
            this.lbl_Hint.TabIndex = 4;
            this.lbl_Hint.Text = "Подсказка: 0 < x < 100";
            // 
            // NewGame_button
            // 
            this.NewGame_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewGame_button.Location = new System.Drawing.Point(278, 146);
            this.NewGame_button.Name = "NewGame_button";
            this.NewGame_button.Size = new System.Drawing.Size(126, 29);
            this.NewGame_button.TabIndex = 5;
            this.NewGame_button.Text = "Новая игра";
            this.NewGame_button.UseVisualStyleBackColor = true;
            this.NewGame_button.Click += new System.EventHandler(this.NewGame_button_Click);
            // 
            // Form_GuessNum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 190);
            this.Controls.Add(this.NewGame_button);
            this.Controls.Add(this.lbl_Hint);
            this.Controls.Add(this.lbl_RoundNum);
            this.Controls.Add(this.Answer_button);
            this.Controls.Add(this.lbl_Desc);
            this.Controls.Add(this.AnswerBox);
            this.Name = "Form_GuessNum";
            this.Text = "Угадай число";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AnswerBox;
        private System.Windows.Forms.Label lbl_Desc;
        private System.Windows.Forms.Button Answer_button;
        private System.Windows.Forms.Label lbl_RoundNum;
        private System.Windows.Forms.Label lbl_Hint;
        private System.Windows.Forms.Button NewGame_button;
    }
}