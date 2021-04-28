
namespace WindowsFormsApp11
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.FileNameTF = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.PasswordTF = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.EncryptButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.DecryptButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.CancelButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.EncryptName = new MaterialSkin.Controls.MaterialCheckBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FileNameTF
            // 
            this.FileNameTF.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FileNameTF.Depth = 0;
            this.FileNameTF.Hint = "";
            this.FileNameTF.Location = new System.Drawing.Point(101, 86);
            this.FileNameTF.MouseState = MaterialSkin.MouseState.HOVER;
            this.FileNameTF.Name = "FileNameTF";
            this.FileNameTF.PasswordChar = '\0';
            this.FileNameTF.SelectedText = "";
            this.FileNameTF.SelectionLength = 0;
            this.FileNameTF.SelectionStart = 0;
            this.FileNameTF.Size = new System.Drawing.Size(216, 23);
            this.FileNameTF.TabIndex = 0;
            this.FileNameTF.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 86);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(47, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Файл";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(12, 139);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(62, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Пароль";
            // 
            // PasswordTF
            // 
            this.PasswordTF.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PasswordTF.Depth = 0;
            this.PasswordTF.Hint = "";
            this.PasswordTF.Location = new System.Drawing.Point(101, 139);
            this.PasswordTF.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordTF.Name = "PasswordTF";
            this.PasswordTF.PasswordChar = '\0';
            this.PasswordTF.SelectedText = "";
            this.PasswordTF.SelectionLength = 0;
            this.PasswordTF.SelectionStart = 0;
            this.PasswordTF.Size = new System.Drawing.Size(299, 23);
            this.PasswordTF.TabIndex = 2;
            this.PasswordTF.UseSystemPasswordChar = false;
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Location = new System.Drawing.Point(324, 78);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(76, 36);
            this.materialFlatButton1.TabIndex = 4;
            this.materialFlatButton1.Text = "Выбрать";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // EncryptButton
            // 
            this.EncryptButton.AutoSize = true;
            this.EncryptButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EncryptButton.Depth = 0;
            this.EncryptButton.Location = new System.Drawing.Point(9, 234);
            this.EncryptButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.EncryptButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Primary = false;
            this.EncryptButton.Size = new System.Drawing.Size(116, 36);
            this.EncryptButton.TabIndex = 5;
            this.EncryptButton.Text = "Зашифровать";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // DecryptButton
            // 
            this.DecryptButton.AutoSize = true;
            this.DecryptButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DecryptButton.Depth = 0;
            this.DecryptButton.Location = new System.Drawing.Point(167, 234);
            this.DecryptButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DecryptButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Primary = false;
            this.DecryptButton.Size = new System.Drawing.Size(126, 36);
            this.DecryptButton.TabIndex = 6;
            this.DecryptButton.Text = "Расшифровать";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.AutoSize = true;
            this.CancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton.Depth = 0;
            this.CancelButton.Location = new System.Drawing.Point(334, 234);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Primary = false;
            this.CancelButton.Size = new System.Drawing.Size(68, 36);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // EncryptName
            // 
            this.EncryptName.AutoSize = true;
            this.EncryptName.Depth = 0;
            this.EncryptName.Font = new System.Drawing.Font("Roboto", 10F);
            this.EncryptName.Location = new System.Drawing.Point(9, 186);
            this.EncryptName.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptName.MouseLocation = new System.Drawing.Point(-1, -1);
            this.EncryptName.MouseState = MaterialSkin.MouseState.HOVER;
            this.EncryptName.Name = "EncryptName";
            this.EncryptName.Ripple = true;
            this.EncryptName.Size = new System.Drawing.Size(274, 30);
            this.EncryptName.TabIndex = 8;
            this.EncryptName.Text = "Обработать имя файла и расширение";
            this.EncryptName.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(429, 285);
            this.Controls.Add(this.EncryptName);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.EncryptButton);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.PasswordTF);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.FileNameTF);
            this.Name = "Form1";
            this.Text = "BeeCrytography";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private MaterialSkin.Controls.MaterialSingleLineTextField FileNameTF;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField PasswordTF;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialFlatButton EncryptButton;
        private MaterialSkin.Controls.MaterialFlatButton DecryptButton;
        private MaterialSkin.Controls.MaterialFlatButton CancelButton;
        private MaterialSkin.Controls.MaterialCheckBox EncryptName;
    }
}

