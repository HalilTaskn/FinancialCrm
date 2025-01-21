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

namespace FinancialCrm
{
    public partial class FrmSpendings : Form
    {
        public FrmSpendings()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = txtSpendinqName.Text;
            decimal amount = decimal.Parse(txtSpendinqAmount.Text);
            DateTime dateTime = DateTime.Parse(txtSpendinqDate.Text);
            string category = cmbCategory.Text;

            var selectedCategory = db.Categories.FirstOrDefault(c => c.CategoryName == category);

            Spending spending = new Spending();
            spending.SpendingTitle = name;
            spending.SpendingDate = dateTime;
            spending.SpendingAmout = amount;
            spending.CategoryID = selectedCategory.CategoryID;

            db.Spendings.Add(spending);
            db.SaveChanges();

            MessageBox.Show("Gider Başarılı Birşekilde Sisteme Eklendi");


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSpendinqID.Text);
            var removeValue = db.Spendings.Find(id);
            db.Spendings.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Gider Başarılı Birşekilde Sistemden Silindi");

            
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            var values = db.Spendings.Select(x => new
            {
                x.SpendingID,
                x.SpendingTitle,
                x.SpendingDate,
                x.SpendingAmout,
                x.Category.CategoryName
            }
            ).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int spendingId = int.Parse(txtSpendinqID.Text); // Güncellenecek harcamanın ID'si
            string name = txtSpendinqName.Text;
            decimal amount = decimal.Parse(txtSpendinqAmount.Text);
            DateTime dateTime = DateTime.Parse(txtSpendinqDate.Text);
            string category = cmbCategory.Text;

            var spending = db.Spendings.FirstOrDefault(s => s.SpendingID == spendingId);
            if (spending == null) return;

            var selectedCategory = db.Categories.FirstOrDefault(c => c.CategoryName == category);

            spending.SpendingTitle = name;
            spending.SpendingDate = dateTime;
            spending.SpendingAmout = amount;
            spending.CategoryID = selectedCategory.CategoryID;

            db.SaveChanges();

            MessageBox.Show("Gider Başarılı Bir şekilde Güncellendi");



        }

        private void button1_Click(object sender, EventArgs e)
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

        }

        private void btnBankProcess_Click(object sender, EventArgs e)
        {
            FrmBankProcess frm = new FrmBankProcess();
            frm.Show();
            this.Hide();
            ;

        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            FrmDashBoard frm = new FrmDashBoard();
            frm.Show();
            this.Hide();


        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            var categoryNames = db.Categories.Select(x => x.CategoryName).ToList();
            cmbCategory.DataSource = categoryNames;

            var values = db.Spendings.Select(x => new
            {
                x.SpendingID,
                x.SpendingTitle,
                x.SpendingDate,
                x.SpendingAmout,
                x.Category.CategoryName
            }
            ).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
