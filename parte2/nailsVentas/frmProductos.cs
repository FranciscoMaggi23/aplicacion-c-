using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using Entidades;
using static ClosedXML.Excel.XLPredefinedFormat;
using ClosedXML.Excel;

namespace nailsVentas
{
    public partial class frmProductos : Form
    {
        private List<Productos> listaProducto;
        public frmProductos()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //
            cargar();
            //
            cboEstado.Items.Add("Activo");
            cboEstado.Items.Add("No Activo");
        }

        private void cargar()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            listaProducto = productoNegocio.listarProductos();
            dgvDataProductos.DataSource = listaProducto;
            dgvDataProductos.Columns["Id"].Visible = true;
        }

        public void btnGuardar_Click(object sender, EventArgs e)
        {
            ProductoNegocio lista = new ProductoNegocio();
            Productos objProductos = new Productos();
            try
            {
                // Validamos
                if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(txtStock.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecioCompra.Text) ||
                    cboEstado.SelectedItem == null)
                {
                    MessageBox.Show("Todos los campos deben ser completados.");
                    return;
                }
                else
                {
                    objProductos.Id = Convert.ToInt32(txtId.Text);
                    objProductos.Codigo = txtCodigo.Text;
                    objProductos.Nombre = txtNombre.Text;
                    objProductos.Descripcion = txtDescripcion.Text;
                    objProductos.Stock = int.Parse(txtStock.Text);
                    objProductos.PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                    objProductos.Estado = cboEstado.SelectedItem.ToString() == "Activo" ? 1 : 0;
                }
                if (objProductos.Id == 0)
                    lista.agregar(objProductos);
                else
                {
                    lista.modificar(objProductos);
                }
                cargar();
                Limpiar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dgvDataProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            txtIndice.Text = indice.ToString();
            if (indice >= 0)
            {
                txtId.Text = dgvDataProductos.Rows[indice].Cells["Id"].Value.ToString();
                txtCodigo.Text = dgvDataProductos.Rows[indice].Cells["Codigo"].Value.ToString();
                txtNombre.Text = dgvDataProductos.Rows[indice].Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dgvDataProductos.Rows[indice].Cells["Descripcion"].Value.ToString();
                txtStock.Text = dgvDataProductos.Rows[indice].Cells["Stock"].Value.ToString();
                txtPrecioCompra.Text = dgvDataProductos.Rows[indice].Cells["PrecioCompra"].Value.ToString();
                cboEstado.SelectedItem = dgvDataProductos.Rows[indice].Cells["estado"].Value.ToString() == "1" ? "Activo" : "No Activo";
            }
        }
        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtStock.Text = "";
            txtPrecioCompra.Text = "";
            cboEstado.SelectedIndex = 0;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ProductoNegocio lista = new ProductoNegocio();
            Productos objProductos;
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                //preguntamos si quiere eliminar el producto
                if (MessageBox.Show("¿desea eliminar el producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objProductos = (Productos)dgvDataProductos.CurrentRow.DataBoundItem;
                    lista.EliminarLogico(objProductos);
                    cargar();
                    Limpiar();
                }
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtfiltro_TextChanged(object sender, EventArgs e)
        {
            List<Productos> listaFiltrada;
            string filtro = txtfiltro.Text;

            if (filtro != "")
            {
                listaFiltrada = listaProducto.FindAll(x => x.Nombre.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            }
            else
            {
                listaFiltrada = listaProducto;
            }


            dgvDataProductos.DataSource = null;
            dgvDataProductos.DataSource = listaFiltrada;
        }

        private void btnExel_Click(object sender, EventArgs e)
        {
            //si no hay registros en el data grid view no nos genera el excel
            if (dgvDataProductos.Rows.Count < 1)
            {
                MessageBox.Show("no hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //si hay filas para exportar, insertamos todos los datos en el datatable
                DataTable dt = new DataTable();

                //primero insertamos las columnas. Para eso recorremos la grilla
                foreach (DataGridViewColumn columna in dgvDataProductos.Columns)
                {
                    //solo las columnas con encabezados y visibles
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        //le agregamos al data table todas las columnas que tengan encabezados
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }
                //insertamos filas
                foreach (DataGridViewRow row in dgvDataProductos.Rows)
                {
                    //si la fila es visible
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells["Id"].Value.ToString(),
                            row.Cells["Codigo"].Value.ToString(),
                            row.Cells["Nombre"].Value.ToString(),
                            row.Cells["Descripcion"].Value.ToString(),
                            row.Cells["Stock"].Value.ToString(),
                            row.Cells["PrecioCompra"].Value.ToString(),
                            row.Cells["Estado"].Value.ToString(),

                        });
                    }
                }
                SaveFileDialog savefile = new SaveFileDialog();
                //nombre con el que se va a guardar nuestro archivo excel     
                savefile.FileName = string.Format("ReporteProducto_{0}.xlsx", System.DateTime.Now.ToString("ddMMyyyyHHmmss"));
                //filtro para que se muestren solo archivos del mismo tipo(extension xlsx)
                savefile.Filter = "Excel Files | *.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //creamos el archivo excel
                        XLWorkbook wb = new XLWorkbook();
                        //agregamos una hoja           nombre de la hoja
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        //ajustamos el ancho de las columnas segun el valor que tengan
                        hoja.ColumnsUsed().AdjustToContents();
                        //guardamos con la ruta que seleccionamos
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar el Reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            
            }
        }
    }
}

