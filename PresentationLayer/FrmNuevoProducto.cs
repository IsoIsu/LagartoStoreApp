﻿using BusinessLayer;
using DataAccessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;
using Utilitario;

namespace PresentationLayer
{
    public partial class FrmNuevoProducto : Form
    {
        private readonly Producto producto;

        public FrmNuevoProducto()
        {
            InitializeComponent();
            LoadCategoriaComboBox();
        }

        public FrmNuevoProducto(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;

            lblTitulo.Text = "ACTUALIZAR PRODUCTO";            

            LoadCategoriaComboBox();

            nombreTextBox.Text = producto.Nombre;
            precioTextBox.Text = producto.Precio.ToString();
            categoriaComboBox.SelectedValue = producto.Categoria.Id;
        }

        private void FrmNuevoProducto_Load(object sender, EventArgs e)
        {
            Util.Centrar(this, lblTitulo);
        }

        private void LoadCategoriaComboBox()
        {
            try
            {
                categoriaComboBox.DataSource = AppEngine.categoriaDAL.GetAll();
                categoriaComboBox.DisplayMember = "NOMBRE";
                categoriaComboBox.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        #region Eventos KeyPress
        private void NombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) BtnNuevo_Click(sender, e);
        }

        private void PrecioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) BtnNuevo_Click(sender, e);
        }

        private void StockTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) BtnNuevo_Click(sender, e);
        }
        #endregion

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (producto is null)
                {
                    AppEngine.productoDAL.Create(new Producto(1,
                        nombreTextBox.Text,
                        Convert.ToDecimal(precioTextBox.Text),
                        Convert.ToInt32(stockTextBox.Text),
                        categoriaComboBox.SelectedItem as Categoria));

                    MessageBox.Show("Se agregó al producto exitosamente.", "Registrar nuevo producto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    producto.Nombre = nombreTextBox.Text;
                    producto.Precio = Convert.ToDecimal(precioTextBox.Text);
                    producto.Categoria = categoriaComboBox.SelectedItem as Categoria;
                    producto.Stock = Convert.ToInt32(stockTextBox.Text);
                    AppEngine.productoDAL.Update(producto);

                    MessageBox.Show("Se actualizó el producto exitosamente.", "Actualizar producto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
