using System;
using Bunifu.UI.WinForms;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

namespace Lesson_5_2
{
    public partial class Vending_Machine : Form
    {
        [Obsolete]
        public Vending_Machine() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl_ProductsSumPrice.Text = 
                (nud_CocaCola.Value * decimal.Parse(lbl_ColaPrice.Text)
                + nud_Fanta.Value * decimal.Parse(lbl_FantaPrice.Text)
                + nud_Pepsi.Value * decimal.Parse(lbl_PepsiPrice.Text)
                + nud_PepsiCap.Value * decimal.Parse(lbl_PepsiCapPrice.Text)
                + nud_Lays.Value * decimal.Parse(lbl_LaysPrice.Text)
                + nud_Oreo.Value * decimal.Parse(lbl_OreoPrice.Text)
                + nud_Haribo.Value * decimal.Parse(lbl_HariboPrice.Text)
                + nud_Crax.Value * decimal.Parse(lbl_CraxPrice.Text)
                + nud_Snikers.Value * decimal.Parse(lbl_SnikersPrice.Text)
                + nud_Bounty.Value * decimal.Parse(lbl_BountyPrice.Text)
                + nud_Monster.Value * decimal.Parse(lbl_MonsterPrice.Text)
                + nud_Redbull.Value * decimal.Parse(lbl_RedbullPrice.Text)).ToString();
            if (lbl_ProductsSumPrice.Text != "0,00" && decimal.Parse(lbl_SumMoney.Text) >= decimal.Parse(lbl_ProductsSumPrice.Text))
            {
                lbl_RemainderPrice.Text = (decimal.Parse(lbl_SumMoney.Text) - decimal.Parse(lbl_ProductsSumPrice.Text)).ToString();
                btn_Push.Enabled = true;
            }
            else { lbl_RemainderPrice.Text = "0,0"; btn_Push.Enabled = false; }
        }

        private void EnterMoney(object sender, EventArgs e)
        {
            if(sender is BunifuImageButton btn)
                lbl_SumMoney.Text = (decimal.Parse(lbl_SumMoney.Text) 
                    + decimal.Parse(btn.ToolTipText)).ToString();
            Form1_Load(this, e);
        }

        private void tbx_EnterMoney_TextChange(object sender, EventArgs e)
        {
            Regex regex = new Regex("^\\d+$");
            if (!regex.IsMatch(tbx_EnterMoney.Text)) 
                MessageBox.Show("Only numbers can be entered");
            else if (string.IsNullOrEmpty(tbx_EnterMoney.Text))
                MessageBox.Show("Forbidden Empty Text");
            else if (string.IsNullOrWhiteSpace(tbx_EnterMoney.Text))
                MessageBox.Show("Forbidden White Space");
            else if (regex.IsMatch(tbx_EnterMoney.Text) && !string.IsNullOrWhiteSpace(tbx_EnterMoney.Text))
            lbl_SumMoney.Text = $"{tbx_EnterMoney.Text},00";
            Form1_Load(this, e);
        }

        //-----------------------------------------------------------------------------------------------

        private void cbx_CocaCola_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cbx_CocaCola.Checked) nud_CocaCola.Enabled = true;
            else { nud_CocaCola.Enabled = false; nud_CocaCola.Value = 0; }
        }

        private void cbx_Fanta_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cbx_Fanta.Checked) nud_Fanta.Enabled = true;
            else { nud_Fanta.Enabled = false; nud_Fanta.Value = 0; }
        }

        private void cbx_Pepsi_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cbx_Pepsi.Checked) nud_Pepsi.Enabled = true;
            else { nud_Pepsi.Enabled = false; nud_Pepsi.Value = 0; }
        }

        private void cbx_PepsiCap_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cbx_PepsiCap.Checked) nud_PepsiCap.Enabled = true;
            else { nud_PepsiCap.Enabled = false; nud_PepsiCap.Value = 0; }
        }

        private void cbx_Lays_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cbx_Lays.Checked) nud_Lays.Enabled = true;
            else { nud_Lays.Enabled = false; nud_Lays.Value = 0; }
        }

        private void cbx_Oreo_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cbx_Oreo.Checked) nud_Oreo.Enabled = true;
            else { nud_Oreo.Enabled = false; nud_Oreo.Value = 0; }
        }

        private void cbx_Haribo_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cbx_Haribo.Checked) nud_Haribo.Enabled = true;
            else { nud_Haribo.Enabled = false; nud_Haribo.Value = 0; }
        }

        private void cbx_Crax_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cbx_Crax.Checked) nud_Crax.Enabled = true;
            else { nud_Crax.Enabled = false; nud_Crax.Value = 0; }
        }

        private void cbx_Snikers_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cbx_Snikers.Checked) nud_Snikers.Enabled = true;
            else { nud_Snikers.Enabled = false; nud_Snikers.Value = 0; }
        }

        private void cbx_Bounty_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cbx_Bounty.Checked) nud_Bounty.Enabled = true;
            else { nud_Bounty.Enabled = false; nud_Bounty.Value = 0; }
        }

        private void cbx_Monster_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cbx_Monster.Checked) nud_Monster.Enabled = true;
            else { nud_Monster.Enabled = false; nud_Monster.Value = 0; }
        }

        private void cbx_Redbull_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (cbx_Redbull.Checked) nud_Redbull.Enabled = true;
            else { nud_Redbull.Enabled = false; nud_Redbull.Value = 0; }
        }

        //----------------------------------------------------------------------------------------------

        private void nud_CocaCola_ValueChanged(object sender, EventArgs e)
        {
            if (nud_CocaCola.Value >= decimal.Parse(btn_AmountCocaCola.Text))
                nud_CocaCola.Value = decimal.Parse(btn_AmountCocaCola.Text);
            Form1_Load(this, e);
        }

        private void nud_Fanta_ValueChanged(object sender, EventArgs e)
        {
            if (nud_Fanta.Value >= decimal.Parse(btn_AmountFanta.Text))
                nud_Fanta.Value = decimal.Parse(btn_AmountFanta.Text);
            Form1_Load(this, e);
        }

        private void nud_Pepsi_ValueChanged(object sender, EventArgs e)
        {
            if (nud_Pepsi.Value >= decimal.Parse(btn_AmountPepsi.Text))
                nud_Pepsi.Value = decimal.Parse(btn_AmountPepsi.Text);
            Form1_Load(this, e);
        }

        private void nud_PepsiCap_ValueChanged(object sender, EventArgs e)
        {
            if (nud_PepsiCap.Value >= decimal.Parse(btn_AmountPepsiCap.Text))
                nud_PepsiCap.Value = decimal.Parse(btn_AmountPepsiCap.Text);
            Form1_Load(this, e);
        }

        private void nud_Lays_ValueChanged(object sender, EventArgs e)
        {
            if (nud_Lays.Value >= decimal.Parse(btn_AmountLays.Text))
                nud_Lays.Value = decimal.Parse(btn_AmountLays.Text);
            Form1_Load(this, e);
        }

        private void nud_Oreo_ValueChanged(object sender, EventArgs e)
        {
            if (nud_Oreo.Value >= decimal.Parse(btn_AmountOreo.Text))
                nud_Oreo.Value = decimal.Parse(btn_AmountOreo.Text);
            Form1_Load(this, e);
        }

        private void nud_Haribo_ValueChanged(object sender, EventArgs e)
        {
            if (nud_Haribo.Value >= decimal.Parse(btn_AmountHaribo.Text))
                nud_Haribo.Value = decimal.Parse(btn_AmountHaribo.Text);
            Form1_Load(this, e);
        }

        private void nud_Crax_ValueChanged(object sender, EventArgs e)
        {
            if (nud_Crax.Value >= decimal.Parse(btn_AmountCrax.Text))
                nud_Crax.Value = decimal.Parse(btn_AmountCrax.Text);
            Form1_Load(this, e);
        }

        private void nud_Snikers_ValueChanged(object sender, EventArgs e)
        {
            if (nud_Snikers.Value >= decimal.Parse(btn_AmountSnikers.Text))
                nud_Snikers.Value = decimal.Parse(btn_AmountSnikers.Text);
            Form1_Load(this, e);
        }

        private void nud_Bounty_ValueChanged(object sender, EventArgs e)
        {
            if (nud_Bounty.Value >= decimal.Parse(btn_AmountBounty.Text))
                nud_Bounty.Value = decimal.Parse(btn_AmountBounty.Text);
            Form1_Load(this, e);
        }

        private void nud_Monster_ValueChanged(object sender, EventArgs e)
        {
            if (nud_Monster.Value >= decimal.Parse(btn_AmountMonster.Text))
                nud_Monster.Value = decimal.Parse(btn_AmountMonster.Text);
            Form1_Load(this, e);
        }

        private void nud_Redbull_ValueChanged(object sender, EventArgs e)
        {
            if (nud_Redbull.Value >= decimal.Parse(btn_AmountRedbull.Text))
                nud_Redbull.Value = decimal.Parse(btn_AmountRedbull.Text);
            Form1_Load(this, e);
        }

        private void btn_Push_Click(object sender, EventArgs e)
        {
            if (cbx_CocaCola.Checked) btn_AmountCocaCola.Text = (int.Parse(btn_AmountCocaCola.Text) - nud_CocaCola.Value).ToString();
            if (cbx_Fanta.Checked) btn_AmountFanta.Text = (int.Parse(btn_AmountFanta.Text) - nud_Fanta.Value).ToString();
            if (cbx_Pepsi.Checked) btn_AmountPepsi.Text = (int.Parse(btn_AmountPepsi.Text) - nud_Pepsi.Value).ToString();
            if (cbx_PepsiCap.Checked) btn_AmountPepsiCap.Text = (int.Parse(btn_AmountPepsiCap.Text) - nud_PepsiCap.Value).ToString();
            if (cbx_Lays.Checked) btn_AmountLays.Text = (int.Parse(btn_AmountLays.Text) - nud_Lays.Value).ToString();
            if (cbx_Oreo.Checked) btn_AmountOreo.Text = (int.Parse(btn_AmountOreo.Text) - nud_Oreo.Value).ToString();
            if (cbx_Haribo.Checked) btn_AmountHaribo.Text = (int.Parse(btn_AmountHaribo.Text) - nud_Haribo.Value).ToString();
            if (cbx_Crax.Checked) btn_AmountCrax.Text = (int.Parse(btn_AmountCrax.Text) - nud_Crax.Value).ToString();
            if (cbx_Snikers.Checked) btn_AmountSnikers.Text = (int.Parse(btn_AmountSnikers.Text) - nud_Snikers.Value).ToString();
            if (cbx_Bounty.Checked) btn_AmountBounty.Text = (int.Parse(btn_AmountBounty.Text) - nud_Bounty.Value).ToString();
            if (cbx_Monster.Checked) btn_AmountMonster.Text = (int.Parse(btn_AmountMonster.Text) - nud_Monster.Value).ToString();
            if (cbx_Redbull.Checked) btn_AmountRedbull.Text = (int.Parse(btn_AmountRedbull.Text) - nud_Redbull.Value).ToString();
            if (decimal.Parse(lbl_SumMoney.Text) >= decimal.Parse(lbl_ProductsSumPrice.Text))
            {
                lbl_SumMoney.Text = (decimal.Parse(lbl_SumMoney.Text) - decimal.Parse(lbl_ProductsSumPrice.Text)).ToString();
                StringBuilder sb = new StringBuilder();
                sb.Append($"                 Name                 |                 Price                 |                 Amount");
                sb.Append("\n_____________________________________________________________________________________________________\n");
                if (cbx_CocaCola.Checked) sb.Append($"                 {gbx_CocaCola.Text}     |    {lbl_ColaPrice.Text}    |    {nud_CocaCola.Value}\n");
                if (cbx_Fanta.Checked) sb.Append($"                 {gbx_Fanta.Text}    |    {lbl_FantaPrice.Text}    |    {nud_Fanta.Value}\n");
                if (cbx_Pepsi.Checked) sb.Append($"                 {gbx_Pepsi.Text}    | {lbl_PepsiPrice.Text}    |    {nud_Pepsi.Value}\n");
                if (cbx_PepsiCap.Checked) sb.Append($"                 {gbx_PepsiCap.Text}    | {lbl_PepsiCapPrice.Text}    |    {nud_PepsiCap.Value}\n");
                if (cbx_Lays.Checked) sb.Append($"                 {gbx_Lays.Text}    |    {lbl_LaysPrice.Text}    |    {nud_Lays.Value}\n");
                if (cbx_Oreo.Checked) sb.Append($"                 {gbx_Oreo.Text}    |    {lbl_OreoPrice.Text}    |    {nud_Oreo.Value}\n");
                if (cbx_Haribo.Checked) sb.Append($"                 {gbx_Haribo.Text}    |    {lbl_HariboPrice.Text}    |    {nud_Haribo.Value}\n");
                if (cbx_Crax.Checked) sb.Append($"                 {gbx_Crax.Text}    |    {lbl_CraxPrice.Text}    |    {nud_Crax.Value}\n");
                if (cbx_Snikers.Checked) sb.Append($"                 {gbx_Snikers.Text}    |    {lbl_SnikersPrice.Text}    |    {nud_Snikers.Value}\n");
                if (cbx_Bounty.Checked) sb.Append($"                 {gbx_Bounty.Text}    |    {lbl_BountyPrice.Text}    |    {nud_Bounty.Value}\n");
                if (cbx_Monster.Checked) sb.Append($"                 {gbx_Monster.Text}    |    {lbl_MonsterPrice.Text}    |    {nud_Monster.Value}\n");
                if (cbx_Redbull.Checked) sb.Append($"                 {gbx_Redbull.Text}    |    {lbl_RedbullPrice.Text}    |    {nud_Redbull.Value}\n");
                sb.Append("_____________________________________________________________________________________________________\n");
                sb.Append($"Total: {lbl_ProductsSumPrice.Text}\n");
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
                {
                    if(sfd.ShowDialog() == DialogResult.OK)
                    {
                        Document doc = new Document(PageSize.A4.Rotate());
                        try
                        {
                            PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.OpenOrCreate));
                            doc.Open();
                            doc.Add(new Paragraph(sb.ToString()));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            doc.Close();
                        }
                    }
                }
                    MessageBox.Show("The payment has been successfully paid.Thank you for your purchase.");
                nud_CocaCola.Enabled = cbx_CocaCola.Checked = false;
                nud_Fanta.Enabled = cbx_Fanta.Checked = false;
                nud_Pepsi.Enabled = cbx_Pepsi.Checked = false;
                nud_PepsiCap.Enabled = cbx_PepsiCap.Checked = false;
                nud_Lays.Enabled = cbx_Lays.Checked = false;
                nud_Oreo.Enabled = cbx_Oreo.Checked = false;
                nud_Haribo.Enabled = cbx_Haribo.Checked = false;
                nud_Crax.Enabled = cbx_Crax.Checked = false;
                nud_Snikers.Enabled = cbx_Snikers.Checked = false;
                nud_Bounty.Enabled = cbx_Bounty.Checked = false;
                nud_Monster.Enabled = cbx_Monster.Checked = false;
                nud_Redbull.Enabled = cbx_Redbull.Checked = false;
                nud_CocaCola.Value = nud_Fanta.Value = nud_Pepsi.Value = nud_PepsiCap.Value = nud_Lays.Value = nud_Oreo.Value = nud_Haribo.Value
                    = nud_Crax.Value = nud_Snikers.Value = nud_Bounty.Value = nud_Monster.Value = nud_Redbull.Value = default;
                lbl_SumMoney.Text = lbl_ProductsSumPrice.Text = lbl_RemainderPrice.Text = "0,0";
                btn_Push.Enabled = false;
            }
            if (decimal.Parse(lbl_SumMoney.Text) < decimal.Parse(lbl_ProductsSumPrice.Text)) btn_Push.Enabled = false;
        }
    }
}