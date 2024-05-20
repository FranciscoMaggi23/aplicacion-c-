using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using DocumentFormat.OpenXml.Math;

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
            //
            //ClienteNegocio negocio = new ClienteNegocio();  
            //dgvDataPrecioFinal.DataSource = negocio.listar();
            //dgvDataPrecioFinal.Columns["Id"].Visible = false;
            //
            

            // data table MATERIALES
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

            double sumaMateriales = 0.0;
            // Calcular el valor de la columna "Total" para cada fila
            foreach (DataRow row in dt.Rows)
            {
                double precio = Convert.ToDouble(row["Precio"]);
                double rinde = Convert.ToDouble(row["Rinde"]);
                double total = precio / rinde;
                sumaMateriales += total;
                row["Total"] = Math.Round(total, 2); // Redondear a 2 decimales
            }
            //rellenamos el datagrid
            dgvDataMateriales.DataSource= dt;

            //fin DATA TABLE MATERIALES

            //DATA TABLE MOVILIARIO
            DataTable moviliario = new DataTable();
            moviliario.Columns.Add("Producto");
            moviliario.Columns.Add("Precio");
            moviliario.Columns.Add("Rinde");
            moviliario.Columns.Add("Total");

            DataRow movFila = moviliario.NewRow();
            movFila[0] = "torno";
            movFila[1] = 19000;
            movFila[2] = 800;
            moviliario.Rows.Add(movFila);

            DataRow movFila2 = moviliario.NewRow();
            movFila2[0] = "lampara";
            movFila2[1] = 27000;
            movFila2[2] = 1000;
            moviliario.Rows.Add(movFila2);

            DataRow movFila3 = moviliario.NewRow();
            movFila3[0] = "cabina";
            movFila3[1] = 120;
            movFila3[2] = 1;
            moviliario.Rows.Add(movFila3);

            double sumaMoviliario = 0.0;

            foreach (DataRow s in moviliario.Rows)
            {
                double precio = Convert.ToDouble(s["Precio"]);
                int rinde = Convert.ToInt32(s["Rinde"]);
                double total = Convert.ToDouble(precio / rinde);
                sumaMoviliario += total;
                s["Total"] = Math.Round(total, 2);
            }
            dgvDataMoviliario.DataSource = moviliario;
            //FIN DATA TABLE MOVILIARIO

            //DATA TABLE GASTOS
            DataTable gastos = new DataTable();
            gastos.Columns.Add("Total Gasto Fijo Por Servicio");
            gastos.Columns.Add("Hora De Trabajo");
            gastos.Columns.Add("Total Gasto Variable");

            DataRow gastoFila = gastos.NewRow();
            //gastoFila[0] = 1700;
            gastoFila[1] = 2000;
            //gastoFila[2] = 3700;

            gastos.Rows.Add(gastoFila);
            double gastofijo=0.0;
            foreach (DataRow s in gastos.Rows)
            {
                gastofijo = Math.Round(sumaMateriales + sumaMoviliario,2);
                s["Total Gasto Fijo Por Servicio"] = gastofijo;
                double horaTrabajo = Convert.ToDouble(s["Hora De Trabajo"]);
                s["Total Gasto Variable"] =Math.Round(horaTrabajo+gastofijo,2);
            }
            dgvDataGastos.DataSource = gastos;

            //FIN DATA TABLE GASTOS

            //DATA TABLE TIEMPO SERVICIO
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Servicio");
            dt2.Columns.Add("PrecioXhora");
            dt2.Columns.Add("Hora");
            dt2.Columns.Add("Total");

            DataRow fila = dt2.NewRow();
            fila[0] = "Semipermanente";
            fila[1] = 2000;
            fila[2] = 1;
            dt2.Rows.Add(fila);

            DataRow fila2 = dt2.NewRow();
            fila2[0] = "Kapping en gel";
            fila2[1] = 2000;
            fila2[2] = 1.2;
            dt2.Rows.Add(fila2);


            DataRow fila3 = dt2.NewRow();
            fila3[0] = "Kapping polygel";
            fila3[1] = 2000;
            fila3[2] = 1.5;
            dt2.Rows.Add(fila3);

            DataRow fila4 = dt2.NewRow();
            fila4[0] = "soft gel";
            fila4[1] = 2000;
            fila4[2] = 2.2;
            dt2.Rows.Add(fila4);

            double precioXhora=0.0;
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
                precioXhora = Convert.ToDouble(row["PrecioXhora"]);
                double Hora = Convert.ToDouble(row["Hora"]);
                double total = precioXhora * Hora+ precioProducto;
                row["Total"] = Math.Round(total, 3); // Redondear a 3 decimales
            }
            //rellenamos el datagrid
            dgvDataTiempoServicio.DataSource = dt2;

            //FIN DATA TABLE TIEMPO SERVICIO

            // DATA TABLE MATERIALES ADICIONALES
            DataTable matAdicionales = new DataTable();
            matAdicionales.Columns.Add("Producto");
            matAdicionales.Columns.Add("Precio");
            matAdicionales.Columns.Add("Rinde");
            matAdicionales.Columns.Add("Total");

            DataRow matAdicinalesFila = matAdicionales.NewRow();
            matAdicinalesFila[0] = "base niveladora";
            matAdicinalesFila[1] = 5200;
            matAdicinalesFila[2] = 100;

            matAdicionales.Rows.Add(matAdicinalesFila);

            DataRow matAdicinalesFila2 = matAdicionales.NewRow();
            matAdicinalesFila2[0] = "base Kapping";
            matAdicinalesFila2[1] = 4000;
            matAdicinalesFila2[2] = 70;

            matAdicionales.Rows.Add(matAdicinalesFila2);

            DataRow matAdicinalesFila3 = matAdicionales.NewRow();
            matAdicinalesFila3[0] = "press gel";
            matAdicinalesFila3[1] = 4500;
            matAdicinalesFila3[2] = 50;

            matAdicionales.Rows.Add(matAdicinalesFila3);

            DataRow matAdicinalesFila4 = matAdicionales.NewRow();
            matAdicinalesFila4[0] = "solucion polygel";
            matAdicinalesFila4[1] = 2500;
            matAdicinalesFila4[2] = 100;

            matAdicionales.Rows.Add(matAdicinalesFila4);

            DataRow matAdicinalesFila5 = matAdicionales.NewRow();
            matAdicinalesFila5[0] = "polygel 30g";
            matAdicinalesFila5[1] = 5800;
            matAdicinalesFila5[2] = 50;

            matAdicionales.Rows.Add(matAdicinalesFila5);

            DataRow matAdicinalesFila6 = matAdicionales.NewRow();
            matAdicinalesFila6[0] = "tips soft gel";
            matAdicinalesFila6[1] = 8000;
            matAdicinalesFila6[2] = 60;

            matAdicionales.Rows.Add(matAdicinalesFila6);



            foreach (DataRow s in matAdicionales.Rows)
            {
                double precio = Convert.ToDouble(s["Precio"]);
                int rinde = Convert.ToInt32(s["Rinde"]);
                double total = Convert.ToDouble(precio / rinde);
                s["Total"] = Math.Round(total, 2);
            }

            dgvDataMaterialesAdicionales.DataSource = matAdicionales;

            //FIN DATA TABLE MATERIALES ADICIONALES


            //DATA TABLE PRECIO FINAL
            DataTable dt3 = new DataTable();
            dt3.Columns.Add("Servicio");
            dt3.Columns.Add("Precio");
            dt3.Columns.Add("PrecioFinal");

            DataRow f = dt3.NewRow();
            f[0] = "soft Gel Liso";
            dt3.Rows.Add(f);

            DataRow f6 = dt3.NewRow();
            f6[0] = "Semipermanente";
            dt3.Rows.Add(f6);

            DataRow f2 = dt3.NewRow();
            f2[0] = "Kapping Gel Liso";
            dt3.Rows.Add(f2);

            DataRow f3 = dt3.NewRow();
            f3[0] = "Kapping gel con diseño";
            dt3.Rows.Add(f3);

            DataRow f4 = dt3.NewRow();
            f4[0] = "Kapping polygel liso";
            dt3.Rows.Add(f4);

            DataRow f5 = dt3.NewRow();
            f5[0] = "Kapping polygel con diseño";
            dt3.Rows.Add(f5);

            DataRow f7 = dt3.NewRow();
            f7[0] = "soft Gel con diseño";
            dt3.Rows.Add(f7);

            DataRow f8 = dt3.NewRow();
            f8[0] = "Semipermanente con diseño";
            dt3.Rows.Add(f8);

            foreach (DataRow row in dt3.Rows)
            {
                string servicio = Convert.ToString(row["Servicio"]);
                string palabraclave = "diseño";
                string semi = "Semipermanente";

                if (servicio.ToUpper() == semi.ToUpper())
                {
                    row["Precio"] = gastofijo + precioXhora;
                    row["PrecioFinal"]= gastofijo + precioXhora+400;
                }

                if (servicio.ToUpper().Contains(semi.ToUpper()) && servicio.ToUpper().Contains(palabraclave.ToUpper()))
                {
                    row["Precio"] = gastofijo + precioXhora + 400;
                    row["PrecioFinal"] = gastofijo + precioXhora + 800;
                }
                else
                {
                    double BaseNiveladora = 0.0;

                    foreach (DataRow row2 in matAdicionales.Rows)
                    {
                        
                        string producto = Convert.ToString(row2["Producto"]);
                        string productoMod="";
                        if(producto != "base niveladora")
                        {
                            productoMod = DesmenuzarProducro(producto);
                            if (servicio.ToUpper().Contains(productoMod.ToUpper()))
                            {
                                if (servicio.ToLower().Contains("kapping gel"))
                                {
                                    row["Precio"] = Convert.ToDouble(row2["Total"]) + BaseNiveladora + gastofijo + precioXhora;
                                    row["PrecioFinal"] = Convert.ToDouble(row2["Total"]) + BaseNiveladora + gastofijo + precioXhora + 400;
                                }
                                double precio = Convert.ToDouble(row2["Total"]) + gastofijo + precioXhora;
                                double preciofinal = Convert.ToDouble(row2["Total"]) + gastofijo + precioXhora + 400;
                                row["Precio"] = precio;
                                row["PrecioFinal"] = preciofinal;
                                if (servicio.ToUpper().Contains(palabraclave.ToUpper()))
                                {
                                    row["Precio"] = precio+400;
                                    row["PrecioFinal"] = preciofinal+400;
                                }
                            }
                        }
                        
                        if (producto== "base niveladora")
                        {
                             BaseNiveladora =Convert.ToDouble(row2["Total"]);
                        }
                    }
                }
            }
            dgvDataPrecioFinal.DataSource = dt3;
            //FIN DATA TABLE PRECIO FINAL

            // DATA TABLE MES
            DataTable mes = new DataTable();
            mes.Columns.Add("Mes");
            mes.Columns.Add("Horas x dia");
            mes.Columns.Add("Dias por semana");
            mes.Columns.Add("Total por semana");
            mes.Columns.Add("Total por mes");
            mes.Columns.Add("Precio x hora");
            mes.Columns.Add("Sueldo x mes");

            DataRow mesFila= mes.NewRow();
            mesFila[0] = "mayo";
            mesFila[1] = 6;
            mesFila[2] = 6;
            mesFila[5] = 2000;

            mes.Rows.Add(mesFila);

            foreach (DataRow s in mes.Rows)
            {
                int horasXdias = Convert.ToInt32(s["Horas x dia"]);
                int diasXsemana = Convert.ToInt32(s["Dias por semana"]);
                int totalXsemana = horasXdias * diasXsemana;
                s["Total por semana"] =totalXsemana;
                int totalXmes = totalXsemana * 4;
                s["Total por mes"]= totalXmes;
                double precioHora = Convert.ToDouble(s["Precio x hora"]);
                s["Sueldo x mes"] = precioHora * totalXmes;

            }
            dgvDataMes.DataSource = mes;
        }
        private string DesmenuzarProducro(string producto)
        {
            int contadorEspacios = 0;

            foreach (char c in producto.Trim())
            {
                if (c == ' ')
                {
                    contadorEspacios++;
                }
            }
            if (contadorEspacios == 0)
            {
                return producto;
            }
            else
            {
                string palabra="";
                for (int i = 0; i < producto.Length; i++)
                {
                    if (producto[i] == ' ')
                        for (int j = i; j<producto.Length-1; j++)
                        {
                            palabra += producto[j + 1];
                        }

                }
                return palabra;
            }
            
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
