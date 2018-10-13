namespace lssn_7
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
            this.GuessNum_button = new System.Windows.Forms.Button();
            this.NewGame_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GuessNum_button
            // 
            this.GuessNum_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GuessNum_button.Location = new System.Drawing.Point(70, 112);
            this.GuessNum_button.Name = "GuessNum_button";
            this.GuessNum_button.Size = new System.Drawing.Size(161, 46);
            this.GuessNum_button.TabIndex = 0;
            this.GuessNum_button.Text = "Угадай число";
            this.GuessNum_button.UseVisualStyleBackColor = true;
            this.GuessNum_button.Click += new System.EventHandler(this.GuessNum_button_Click);
            // 
            // NewGame_button
            // 
            this.NewGame_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewGame_button.Location = new System.Drawing.Point(70, 41);
            this.NewGame_button.Name = "NewGame_button";
            this.NewGame_button.Size = new System.Drawing.Size(161, 46);
            this.NewGame_button.TabIndex = 1;
            this.NewGame_button.Text = "Удвоитель";
            this.NewGame_button.UseVisualStyleBackColor = true;
            this.NewGame_button.Click += new System.EventHandler(this.NewGame_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 208);
            this.Controls.Add(this.NewGame_button);
            this.Controls.Add(this.GuessNum_button);
            this.Name = "Form1";
            this.Text = "ДЗ к 7-му уроку";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GuessNum_button;
        private System.Windows.Forms.Button NewGame_button;
    }
}

