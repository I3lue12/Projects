using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace First_Cryptology_Learning
{
    public partial class Form1 : Form
    {
        protected string hash = "superBad";
        protected string hash2 = "BadSuper";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(tbTextToEncrypt.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    tbEncryptedText.Text = Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            byte[] data = Convert.FromBase64String(tbEncryptedText.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() {Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length); //{ Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }
                    tbDecryptedText.Text = UTF8Encoding.UTF8.GetString(results);
                }
            }
        }
    }
}
