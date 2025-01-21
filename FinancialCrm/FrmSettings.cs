using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using FinancialCrm.Models;
namespace FinancialCrm
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtUserID.Text); // Güncellenecek ayarın ID'si
            string name = txtUserName.Text;
            string password = txtPassword.Text;

            var setting = db.Users.FirstOrDefault(s => s.UserID == id);
            if (setting == null) return;

            setting.UserName = name;
            setting.Password = password;

            db.SaveChanges();

            MessageBox.Show("Ayarlar Başarılı Bir şekilde Güncellendi");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmGiriş frm = new FrmGiriş();
            frm.Show();
            this.Hide();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            frm.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();

        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings();
            frm.Show();
            this.Hide();
        }

        private void btnBankProcess_Click(object sender, EventArgs e)
        {
            FrmBankProcess frm = new FrmBankProcess();
            frm.Show();
            this.Hide();
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            FrmDashBoard frm = new FrmDashBoard();
            frm.Show();
            this.Hide();

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {

        }
    }
}
