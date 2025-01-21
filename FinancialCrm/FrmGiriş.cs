using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGiriş_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;

            var user = db.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            if (user != null)
            {
                this.Hide();
                var mainForm = new FrmBanks();
                mainForm.Show();
            }
            else 
            {
                MessageBox.Show("Kullanıcı Girişi Veya Şifre Hatalı");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
