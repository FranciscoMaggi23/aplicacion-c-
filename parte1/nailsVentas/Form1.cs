using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nailsVentas
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Producto");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Rinde");
            dt.Columns.Add("Total");

            DataRow dr = dt.NewRow();
            dr[0] = "Servilletas kapping";
            dr[1] = 2000;
            dr[2] = 60;
            //dr[3] = 33;
            dt.Rows.Add(dr);

            DataRow dr2 = dt.NewRow();
            dr2[0] = "Semipermanente liso";
            dr2[1] = 250;
            dr2[2] = 30;
            //dr2[3] = 60;
            dt.Rows.Add(dr2);


            DataRow dr3 = dt.NewRow();
            dr3[0] = "Lima Cebra";
            dr3[1] = 500;
            dr3[2] = 5;
            //dr3[3] = 100;
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4[0] = "Base coat";
            dr4[1] = 3500;
            dr4[2] = 25;
            //dr4[3] = 140;
            dt.Rows.Add(dr4);

            // Calcular el valor de la columna "Total" para cada fila
            foreach (DataRow row in dt.Rows)
            {
                double precio = Convert.ToDouble(row["Precio"]);
                double rinde = Convert.ToDouble(row["Rinde"]);
                double total = precio / rinde;
                row["Total"] = Math.Round(total, 2); // Redondear a 2 decimales

            }


            //rellenamos el datagrid
            dgvDataMateriales.DataSource= dt;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Servicio");
            dt2.Columns.Add("PrecioXhora");
            dt2.Columns.Add("Hora");
            dt2.Columns.Add("Total");

            DataRow fila = dt2.NewRow();
            fila[0] = "Semipermanente";
            fila[1] = 2000;
            fila[2] = 1;
            //dr[3] = 33;
            dt2.Rows.Add(fila);

            DataRow fila2 = dt2.NewRow();
            fila2[0] = "Kapping";
            fila2[1] = 2000;
            fila2[2] = 1.2;
            //dr[3] = 33;
            dt2.Rows.Add(fila2);


            DataRow fila3 = dt2.NewRow();
            fila3[0] = "Semipermanente";
            fila3[1] = 2000;
            fila3[2] = 1.5;
            //dr[3] = 33;
            dt2.Rows.Add(fila3);

            // Calcular el valor de la columna "Total" para cada fila
            foreach (DataRow row in dt2.Rows)
            {
                string servicio = Convert.ToString(row["Servicio"]); // Obtener el nombre del servicio desde la segunda DataTable
                double precioProducto = 0.0;

                // Buscar el precio del producto en el primer DataGridView
                foreach (DataGridViewRow prodRow in dgvDataMateriales.Rows)
                {
                    if (Convert.ToString(prodRow.Cells["Producto"].Value).ToUpper().Contains(servicio.ToUpper()))
                    {
                        precioProducto = Convert.ToDouble(prodRow.Cells["Precio"].Value);
                        break;
                    }
                }


                double precioXhora = Convert.ToDouble(row["PrecioXhora"]);
                double Hora = Convert.ToDouble(row["Hora"]);
                double total = precioXhora * Hora+ precioProducto;
                row["Total"] = Math.Round(total, 3); // Redondear a 3 decimales

            }
            //rellenamos el datagrid
            dgvDataTiempoServicio.DataSource = dt2;
        }

        private void dgvDataMateriales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox("Ingrese nuevo producto", "Cambio de producto");
                dgvDataMateriales.Rows[e.RowIndex].Cells[0].Value = nuevoNombre;
            }
            if(e.ColumnIndex == 1)
            {
                string nuevoprecio = Microsoft.VisualBasic.Interaction.InputBox("Ingrese nuevo precio", "Cambio de precio");
                double precio =Convert.ToDouble(nuevoprecio);
                double rinde = Convert.ToDouble(dgvDataMateriales.Rows[e.RowIndex].Cells[2].Value);
                double total = Math.Round(precio/rinde, 2); 
                dgvDataMateriales.Rows[e.RowIndex].Cells[1].Value = nuevoprecio;
                dgvDataMateriales.Rows[e.RowIndex].Cells[3].Value = total;

                RecalcularTotalDgvDataTiempoServicio();
            }
            if (e.ColumnIndex == 2)
            {
                string rendimiento = Microsoft.VisualBasic.Interaction.InputBox("Ingrese cuanto rinde", "Cambio de rendimiento");
                dgvDataMateriales.Rows[e.RowIndex].Cells[2].Value = rendimiento;
                // Recalculamos el Total después de que se haya actualizado el rendimiento
                double precio = Convert.ToDouble(dgvDataMateriales.Rows[e.RowIndex].Cells[1].Value);
                double rinde = Convert.ToDouble(rendimiento); // Usamos el nuevo valor de rendimiento ingresado
                double total = Math.Round(precio / rinde, 2);
                dgvDataMateriales.Rows[e.RowIndex].Cells[3].Value = total;
            }
        }

        private void RecalcularTotalDgvDataTiempoServicio()
        {
            // Iterar sobre las filas del segundo DataGridView
            foreach (DataGridViewRow row in dgvDataTiempoServicio.Rows)
            {
                // Obtener el nombre del servicio
                string servicio = Convert.ToString(row.Cells["Servicio"].Value);

                // Obtener el precio por hora
                double precioXhora = Convert.ToDouble(row.Cells["PrecioXhora"].Value);

                // Obtener el total de la primera DataGridView correspondiente al servicio
                double totalProducto = 0.0;
                foreach (DataGridViewRow prodRow in dgvDataMateriales.Rows)
                {
                    if (Convert.ToString(prodRow.Cells["Producto"].Value).ToUpper().Contains(servicio.ToUpper()))
                    {
                        totalProducto = Convert.ToDouble(prodRow.Cells["Precio"].Value);
                        break;
                    }
                }

                // Calcular el total sumando el precio del producto más el precio por hora
                double total = totalProducto + (precioXhora * Convert.ToDouble(row.Cells["Hora"].Value));
                row.Cells["Total"].Value = Math.Round(total, 3); // Redondear a 3 decimales
            }
        }


        private void dgvDataMateriales_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                double nuevoPrecio = Convert.ToDouble(dgvDataMateriales.Rows[e.RowIndex].Cells[1].Value);

                // Actualizar el total en el segundo DataGridView
                RecalcularTotalDgvDataTiempoServicio();
            }
        }

        private void dgvDataTiempoServicio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                string nombreservicio = Microsoft.VisualBasic.Interaction.InputBox("ingrese el nombre del servicio", "Cambio de servicio");
                dgvDataTiempoServicio.Rows[e.RowIndex].Cells[0].Value= nombreservicio;
            }
            if(e.ColumnIndex ==1) 
            {
                double precioXhora = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("ingrese el precio x hora", "Precio x hora"));
                double hora =Convert.ToDouble(dgvDataTiempoServicio.Rows[e.RowIndex].Cells[2].Value);
                dgvDataTiempoServicio.Rows[e.RowIndex].Cells[1].Value= precioXhora;
                double total = Math.Round(precioXhora * hora, 3);
                dgvDataTiempoServicio.Rows[e.RowIndex].Cells[3].Value= total;

                RecalcularTotalDgvDataTiempoServicio();
            }
            if (e.ColumnIndex == 2)
            {
                double precioXhora = Convert.ToDouble(dgvDataTiempoServicio.Rows[e.RowIndex].Cells[1].Value);
                double hora = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("ingrese la duracion del servicio en hs", "hora x servicio"));
                dgvDataTiempoServicio.Rows[e.RowIndex].Cells[2].Value = hora;
                double total = Math.Round(precioXhora * hora, 3);
                dgvDataTiempoServicio.Rows[e.RowIndex].Cells[3].Value = total;

                RecalcularTotalDgvDataTiempoServicio();
            }
        }
    }
}
