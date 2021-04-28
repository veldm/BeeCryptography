using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BeeCrypt.FileEncryptor;
using static BeeCrypt.StringEncryptor;

namespace WindowsFormsApp11
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() is DialogResult.OK)
            {
                FileNameTF.Text = openFileDialog1.FileName;
            }
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo file = new FileInfo(FileNameTF.Text);
                string codedFile = file.Encrypt(PasswordTF.Text);
                string name = EncryptName.Checked ? file.Name.Encode(PasswordTF.Text) : file.Name;
                saveFileDialog1.FileName = file.FullName.Replace(file.Name, name);
                if (saveFileDialog1.ShowDialog() is DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                    {
                        writer.Write(codedFile);
                        writer.Close();
                    }
                }
            }
            catch (ArgumentException exeption)
            {
                MessageBox.Show(exeption.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка"
                    ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo file = new FileInfo(FileNameTF.Text);
                string codedFile = file.Decrypt(PasswordTF.Text);
                string name = EncryptName.Checked ? file.Name.Decode(PasswordTF.Text) : file.Name;
                saveFileDialog1.FileName = file.FullName.Replace(file.Name, name);
                if (saveFileDialog1.ShowDialog() is DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                    {
                        writer.Write(codedFile);
                        writer.Close();
                    }
                }
            }
            catch (ArgumentException exeption)
            {
                MessageBox.Show(exeption.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
