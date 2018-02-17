using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ucss_calculator
{
    public partial class Form1 : Form
    {
        int c = 1;
        ArrayList n = new ArrayList();
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtPromFinal.ReadOnly = true;
            this.txtNumCont.Text = c+"";
            llenarArray();
            txtContinua2.Enabled = false;
            txtContinua3.Enabled = false;
            txtContinua4.Enabled = false;
            txtContinua5.Enabled = false;
            txtContinua6.Enabled = false;
            txtContinua7.Enabled = false;
            txtContinua8.Enabled = false;
        }
        private void llenarArray() {
            n.Add(txtContinua1);
            n.Add(txtContinua2);
            n.Add(txtContinua3);
            n.Add(txtContinua4);
            n.Add(txtContinua5);
            n.Add(txtContinua6);
            n.Add(txtContinua7);
            n.Add(txtContinua8);
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            vacioP();
            Double co, ep1, ep2, ep3, exF, prom;
            co = Double.Parse(txtContinuas.Text);
            ep1 = Double.Parse(txtEP1.Text);
            ep2 = Double.Parse(txtEP2.Text);
            ep3 = Double.Parse(txtEP3.Text);
            exF = Double.Parse(txtExF.Text);
            prom = co * 0.2 + ep1 * 0.1 + ep2 * 0.2 + ep3 * 0.2 + exF * 0.3;
            txtPromFinal.Text = prom.ToString();
            FormatoProm('s');
        }
        private void vacioP() {
            if (txtContinuas.Text == "") { txtContinuas.Text = "0"; }
            else {if (Double.Parse(txtContinuas.Text)>20){txtContinuas.Text = "0";}}
            if (txtEP1.Text == "") { txtEP1.Text = "0"; }
            else { if (Double.Parse(txtEP1.Text) > 20) { txtEP1.Text = "0"; } }
            if (txtEP2.Text == "") { txtEP2.Text = "0"; }
            else { if (Double.Parse(txtEP2.Text) > 20) { txtEP2.Text = "0"; } }
            if (txtEP3.Text == "") { txtEP3.Text = "0"; }
            else { if (Double.Parse(txtEP3.Text) > 20) { txtEP3.Text = "0"; } }
            if (txtExF.Text == "") { txtExF.Text = "0"; }
            else { if (Double.Parse(txtExF.Text) > 20) { txtExF.Text = "0"; } }
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            if (c == 1) { c = 1; }
            else { c = c - 1; }
            txtNumCont.Text = c + "";
            EvContinuas(c);
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            if (c == 8) { c = 8; }
            else { c = c + 1; }
            txtNumCont.Text = c + "";
            EvContinuas(c);
        }
        private void EvContinuas(int x) {
            int y = 0;
            TextBox tex;
            while (y < 8)
            {
                tex = (TextBox)n[y];
                if (y < x) { tex.Enabled = true; }
                else { tex.Enabled = false; }
                y++;
            }
        }

        private void btnPromCont_Click(object sender, EventArgs e)
        {            
            int q = 0;
            double p = 0;
            TextBox tex;
            for (int i = 0; i < n.Count; i++)
            {
                tex = (TextBox)n[i];
                if (tex.Enabled==true)
                {
                    if (tex.Text=="" ||Double.Parse(tex.Text)>20)
                    {
                        tex.Text = "0";
                        toolTip1.Show("Campo vacio",tex,500);//muestra mensaje cuando no se llena un textbox
                        toolTip1.ToolTipIcon = ToolTipIcon.Error;
                    }
                    q = q + 1;
                    p = p + Double.Parse(tex.Text);
                }
            }
            txtContinuas.Text="" + p / q;
        }

        private void txtContinua1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(txtContinua1, e);
            if ((e.KeyChar)==13)
            {
                txtContinua2.Focus();
            }
            FormNota(txtContinua1);
        }

        private void txtContinua2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(txtContinua2, e);
            if ((e.KeyChar) == 13)
            {
                txtContinua3.Focus();
            }
            FormNota(txtContinua2);
        }

        private void txtContinua3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(txtContinua3, e);
            if ((e.KeyChar) == 13)
            {
                txtContinua4.Focus();
            }
            FormNota(txtContinua3);
        }

        private void txtContinua4_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(txtContinua4, e);
            if ((e.KeyChar) == 13)
            {
                txtContinua5.Focus();
            }
            FormNota(txtContinua4);
        }

        private void txtContinua5_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(txtContinua5, e);
            if ((e.KeyChar) == 13)
            {
                txtContinua6.Focus();
            }
            FormNota(txtContinua5);
        }

        private void txtContinua6_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(txtContinua6, e);
            if ((e.KeyChar) == 13)
            {
                txtContinua7.Focus();
            }
            FormNota(txtContinua6);
        }

        private void txtContinua7_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(txtContinua7, e);
            if ((e.KeyChar) == 13)
            {
                txtContinua8.Focus();
            }
            FormNota(txtContinua7);
        }

        private void txtContinua8_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(txtContinua8, e);
            if ((e.KeyChar) == 13)
            {
                txtContinua1.Focus();
            }
            FormNota(txtContinua8);
        }
        private void validar(TextBox tex, KeyPressEventArgs e) {
            if (char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (e.KeyChar == ',' + -tex.Text.IndexOf(',')) { e.Handled = true; }
            else if (e.KeyChar == ',') { e.Handled = false; }
            else { e.Handled = true; }
        }

        private void txtContinuas_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(txtContinuas, e);
            if ((e.KeyChar) == 13)
            {
                txtEP1.Focus();
            }
            FormNota(txtContinuas);
        }

        private void txtEP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(txtEP1, e);
            if ((e.KeyChar) == 13)
            {
                txtEP2.Focus();
            }
            FormNota(txtEP1);
        }

        private void txtEP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(txtEP2, e);
            if ((e.KeyChar) == 13)
            {
                txtEP3.Focus();
            }
            FormNota(txtEP2);
        }

        private void txtEP3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(txtEP3, e);
            if ((e.KeyChar) == 13)
            {
                txtExF.Focus();
            }
            FormNota(txtEP3);
        }

        private void txtExF_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(txtExF, e);
            if ((e.KeyChar) == 13)
            {
                txtContinuas.Focus();
            }
            FormNota(txtExF);
        }

        private void btnPromedio_Click(object sender, EventArgs e)
        {
            vacioP();
            double ec, ep1, ep2, ep3, exF, prom;
            double x = 0, aux = 0;
            ec = Double.Parse(txtContinuas.Text);
            ep1 = Double.Parse(txtEP1.Text);
            ep2 = Double.Parse(txtEP2.Text);
            ep3 = Double.Parse(txtEP3.Text);
            exF = Double.Parse(txtExF.Text);
            prom = 0;
            while (prom<10.5 && aux<=20)
            {
                x = aux;
                aux += 1;
                prom = ec * 0.2 + ep1 * 0.1 + ep2 * 0.2 + ep3 * 0.2 + x * 0.3;

            }
            txtExF.Text = x+"";
            txtPromFinal.Text = prom+"";
            FormatoProm('n');
        }
        private void FormatoProm(char f) {
            double p = Double.Parse(txtPromFinal.Text);
            if (f == 's')
            {
                if (p>=10.5)
                {
                    lblMen.Text = "You Win!";
                    lblRes.Text = "";
                    lblRes.ForeColor = Color.Black;
                    lblMen.ForeColor = Color.Black;
                    txtExF.ForeColor = Color.Black;
                    txtPromFinal.ForeColor = Color.Black;
                }
                else
                {
                    lblMen.Text = "You Lose!";
                    lblRes.Text = "";
                    lblRes.ForeColor = Color.Red;
                    lblMen.ForeColor = Color.Red;
                    txtExF.ForeColor = Color.Black;
                    txtPromFinal.ForeColor = Color.Red;
                }
            }
            else if (f == 'n') {
                if (p >= 10.5)
                {
                    lblMen.Text = "You Win!!";
                    lblRes.Text = "";
                    lblRes.ForeColor = Color.Gold;
                    lblMen.ForeColor = Color.Gold;
                    txtExF.ForeColor = Color.Blue;
                    txtPromFinal.ForeColor = Color.Green;
                }
                else
                {
                    lblMen.Text = "You Lose!!";
                    lblRes.Text = "";
                    lblRes.ForeColor = Color.Red;
                    lblMen.ForeColor = Color.Red;
                    txtExF.ForeColor = Color.Blue;
                    txtPromFinal.ForeColor = Color.Green;
                }
            }
        }
        private void FormNota(TextBox t) {
            if (t.Text=="")
            {
                t.Text = 0+"";
            }
            double r = Double.Parse(t.Text);
            if (r < 10.5)
            {
                t.ForeColor = Color.Red;
            }
            else {
                t.ForeColor = Color.Black;
            }
        }
    }
}
