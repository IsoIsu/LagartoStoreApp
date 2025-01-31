﻿using BusinessLayer;
using DataAccessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;
using Utilitario;

namespace PresentationLayer
{
    public partial class FrmNuevaCategoria : Form
    {
        private readonly Categoria categoria;

        public FrmNuevaCategoria()
        {
            InitializeComponent();
        }

        public FrmNuevaCategoria(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;

            lblTitulo.Text = "ACTUALIZAR CATEGORÍA";
            Util.Centrar(this, lblTitulo);

            nombreTextBox.Text = categoria.Nombre;
        }

        #region Eventos KeyPress
        private void NombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) BtnNuevo_Click(sender, e);
        }
        #endregion

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoria is null)
                {
                    AppEngine.categoriaDAL.Create(new Categoria(1, nombreTextBox.Text));

                    MessageBox.Show("Se agregó la categoría exitosamente.", "Registrar nueva categoría", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    categoria.Nombre = nombreTextBox.Text;
                    AppEngine.categoriaDAL.Update(categoria);

                    MessageBox.Show("Se actualizó la categoría exitosamente.", "Actualizar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                BtnCancelar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
