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
    public partial class FrmDashBoard : Form
    {
        public FrmDashBoard()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        int count = 0;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmDashBoard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString() + "₺";

            var lastBankProcessAmount = db.BankProcesses.OrderByDescending(x => x.BankProcessID).Take(1).Select(y =>
            y.Amoun).FirstOrDefault();
            lblLastBankProcessAmount.Text = lastBankProcessAmount.ToString() + "₺";

            //Chard 1 Kodları

            var bankData = db.Banks.Select(x => new
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach (var item in bankData)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }

            //Chard 2 Kodları 

            var billData = db.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if(count % 4 == 1)
            {
                var elektirikFaturasi = db.Bills.Where(x => x.BillTitle == "Elektirik Faturası").Select(y => y.BillAmount).First();
                lblBillTitle.Text = "Elektirik Faturası";
                lblBillAmount.Text = elektirikFaturasi.ToString() + "₺";
            }
            if (count % 4 == 2)
            {
                var doğalgazFaturası = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").Select(y => y.BillAmount).First();
                lblBillTitle.Text = "Doğalgaz Faturası";
                lblBillAmount.Text = doğalgazFaturası.ToString() + "₺";
            }
            if (count % 4 == 3)
            {
                var suFaturası = db.Bills.Where(x => x.BillTitle == "Su Faturası").Select(y => y.BillAmount).First();
                lblBillTitle.Text = "Su Faturası";
                lblBillAmount.Text = suFaturası.ToString() + "₺";
            }
            if (count % 4 == 0)
            {
                var internetFaturası = db.Bills.Where(x => x.BillTitle == "İnternet Faturası").Select(y => y.BillAmount).First();
                lblBillTitle.Text = "İnternet Faturası";
                lblBillAmount.Text = internetFaturası.ToString() + "₺";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmGiriş frm = new FrmGiriş();
            frm.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings();
            frm.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            frm.Show();
            this.Hide();
        }

        private void btnBankProcess_Click(object sender, EventArgs e)
        {
            FrmBankProcess frm = new FrmBankProcess();
            frm.Show();
            this.Hide();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            FrmBilling b = new FrmBilling();
            b.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.Show();
            this.Hide();
        }
    }
}
