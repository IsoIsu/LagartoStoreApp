﻿using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class FrmMenuPrincipal : Form
    {
        private readonly FrmLogin frmLogin;
        public FrmMenuPrincipal(FrmLogin frmLogin)
        {
            InitializeComponent();
            this.frmLogin = frmLogin;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        #region Formularios
        private void RegistroDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmUsuario(false));
        }
        private void RegistroDeColaboradoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmColaborador());
        }

        private void RegistroDeCargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmCargo());
        }

        private void RegistroDeTurnosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmTurno());
        }

        private void RegistroDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmCliente(false));
        }

        private void RegistroDeProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmProducto());
        }
        private void RegistroDeCategoríasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmCategoria());
        }

        private void RegistroDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmCompra());
        }

        private void reporteDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new FrmComprasReporte());
        }
        #endregion

        private void ShowForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            panelContenedor.Controls.Add(form);
            form.Show();
            form.BringToFront();
        }

        private void FrmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin.Show();
        }


    }
}
