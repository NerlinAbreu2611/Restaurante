using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleApp1.Modelo;
using ConsoleApp1.Proceso;

namespace ConsoleApp1.ReporteModelo
{
    public class Reporte
    {
        private static Orden orden;

        public static Orden Orden { get => orden; set => orden = value; }
        public static MetodoDePago MetodoDePago { get => metodoDePago; set => metodoDePago = value; }
        public Pago Pago { get => pago; set => pago = value; }
        public static List<Detalle_pago> Detalle_Pagos { get => detalle_Pagos; set => detalle_Pagos = value; }
        public static Cliente ClientePago { get => clientePago; set => clientePago = value; }
        public static Pago Pago1 { get => pago; set => pago = value; }
     
        private static MetodoDePago metodoDePago;

        public static string generarFacturar()
        {
            RepositorioDeCliente repositorioDeCliente = new RepositorioDeCliente();
            Cliente cliente = repositorioDeCliente.obtenerPorId(orden.Id_cliente);
            RepositorioDeMesa repositorioDeMesa = new RepositorioDeMesa();
            Mesa mesa = repositorioDeMesa.obtenerPorId(orden.Id_mesa);
            RepositorioDeEmpleado repositorioDeEmpleado = new RepositorioDeEmpleado();    
            Empleado empleado = repositorioDeEmpleado.buscarPorId(orden.Id_empleado);
            RepositorioCondicion repositorioDeCondicion = new RepositorioCondicion();
            Condicion condicion = repositorioDeCondicion.buscarPorId(cliente.Id_condicion); ;
            List<Detalle_de_orden> detalles = PDetalle_de_Orden.getListByOrden(orden.Id_orden);
            
            // Crear PDF
            string ruta = "";
            using (FileStream fs = new FileStream("C:\\Users\\elmen\\Desktop\\Reportes\\orden_" + orden.Id_orden + ".pdf", FileMode.Create))
            {
                ruta = "C:\\Users\\elmen\\Desktop\\Reportes\\orden_" + orden.Id_orden + ".pdf";
                // Crea el escritor de PDF
                Document doc = new Document(PageSize.A4, 50, 50, 100, 50);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                // Abre el documento para escribir en él
                doc.Open();

                // Título de la factura
                Font titleFont = FontFactory.GetFont("Helvetica", 20, Font.BOLD, new BaseColor(160, 18, 52));
                doc.Add(new Paragraph("Factura", titleFont) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("Número de Factura: " + orden.Id_orden));
                doc.Add(new Paragraph("Fecha: " + orden.Fecha_hora.ToString("dd/MM/yyyy")));
                doc.Add(new Paragraph("Cliente: " + cliente.Nombre));
                doc.Add(new Paragraph("Mesa: " + mesa.Id));
                doc.Add(new Paragraph("Atendido por: " + empleado.Nombre + " " + empleado.Apellido));
                if(metodoDePago != null)
                {
                    doc.Add(new Paragraph("Metodo de pago: " + metodoDePago.Descripcion));
                }
                doc.Add(new Paragraph("Teléfono: " + cliente.Telefono));
                doc.Add(new Chunk("\n"));

                // Crear tabla para los productos
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;

                // Encabezado de la tabla (sin color de fondo y sin línea horizontal arriba)
                Font tableHeaderFont = FontFactory.GetFont("Helvetica", 12, Font.BOLD, new BaseColor(160, 18, 52));
                // Producto alineado a la izquierda, los demás alineados a la derecha
                table.AddCell(new PdfPCell(new Phrase("Producto", tableHeaderFont)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidth = 0 });
                table.AddCell(new PdfPCell(new Phrase("Cantidad", tableHeaderFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidth = 0 });
                table.AddCell(new PdfPCell(new Phrase("Precio Unitario", tableHeaderFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidth = 0 });
                table.AddCell(new PdfPCell(new Phrase("Subtotal", tableHeaderFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidth = 0 });
                RepositorioDeProductos repositorioDeProductos = new RepositorioDeProductos();
                // Agregar los productos a la tabla sin bordes laterales y alineando cantidad a la derecha
                decimal total = 0;
                foreach (var detalle in detalles)
                {
                   Producto p = repositorioDeProductos.buscarPorId(detalle.Id_producto);
                    table.AddCell(new PdfPCell(new Phrase(p.Nombre)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0, BorderWidthRight = 0 });
                    table.AddCell(new PdfPCell(new Phrase(detalle.Cantidad.ToString())) { HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidthLeft = 0, BorderWidthRight = 0 });  // Alineado a la derecha
                    table.AddCell(new PdfPCell(new Phrase("$" + p.Precio_venta.ToString("0.00"))) { HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidthLeft = 0, BorderWidthRight = 0 });
                    table.AddCell(new PdfPCell(new Phrase("$" + detalle.Sub_total.ToString("0.00"))) { HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidthLeft = 0, BorderWidthRight = 0 });
                    total += detalle.Sub_total;
                }

                // Agregar la tabla al documento
                doc.Add(table);

                // Agregar el total
                Font totalFont = FontFactory.GetFont("Helvetica", 14, Font.BOLD, new BaseColor(160, 18, 52));
                doc.Add(new Paragraph("Total: $" + total.ToString("0.00"), totalFont) { Alignment = Element.ALIGN_RIGHT });
        
                // Cerrar el documento
                doc.Close();
            }
            return ruta;
        }

        private static Pago pago;
        private static List<Detalle_pago> detalle_Pagos;
        private static Cliente clientePago;
        public static string generarPago()
        {
            RepositorioDeCliente repositorioDeCliente = new RepositorioDeCliente();
           
           
            // Crear PDF
            string ruta = "";
            using (FileStream fs = new FileStream("C:\\Users\\elmen\\Desktop\\Reportes\\pago_" + pago.Id_pago + ".pdf", FileMode.Create))
            {
                ruta = "C:\\Users\\elmen\\Desktop\\Reportes\\pago_" + pago.Id_pago + ".pdf";
                // Crea el escritor de PDF
                Document doc = new Document(PageSize.A4, 50, 50, 100, 50);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                // Abre el documento para escribir en él
                doc.Open();

                // Título de la factura
                Font titleFont = FontFactory.GetFont("Helvetica", 20, Font.BOLD, new BaseColor(160, 18, 52));
                doc.Add(new Paragraph("Pago de orden", titleFont) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("Fecha de pago: " + pago.Fecha_pago.ToString("dd/MM/yyyy")));
                doc.Add(new Paragraph("Metodo de pago: " + metodoDePago.Descripcion));
                doc.Add(new Paragraph("Cliente: " + clientePago.Nombre));
                doc.Add(new Paragraph("Teléfono: " + clientePago.Telefono));
                doc.Add(new Chunk("\n"));
                POrden porden= new POrden();
                Orden orden = porden.buscarPorId(detalle_Pagos[0].Id_orden);
                PDetalle_Pago detalle_Pago = new PDetalle_Pago();
                List<Detalle_pago> dt = detalle_Pago.detalles_Por_Pago(pago.Id_pago);
                // Crear tabla para los detalles de pago
                PdfPTable table = new PdfPTable(3);
                table.WidthPercentage = 100;

                // Encabezado de la tabla (sin color de fondo y sin línea horizontal arriba)
                Font tableHeaderFont = FontFactory.GetFont("Helvetica", 12, Font.BOLD, new BaseColor(160, 18, 52));
                // Producto alineado a la izquierda, los demás alineados a la derecha

                table.AddCell(new PdfPCell(new Phrase("Cod.Detalle", tableHeaderFont)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidth = 0 });
                table.AddCell(new PdfPCell(new Phrase("Cod.Orden", tableHeaderFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidth = 0 });
                table.AddCell(new PdfPCell(new Phrase("Monto aplicado", tableHeaderFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidth = 0 });
                RepositorioDeProductos repositorioDeProductos = new RepositorioDeProductos();
                // Agregar los productos a la tabla sin bordes laterales y alineando cantidad a la derecha
                decimal total = 0;


                foreach (Detalle_pago detalle in dt)
                { 
                    table.AddCell(new PdfPCell(new Phrase(detalle.Id_detalle.ToString())) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0, BorderWidthRight = 0 });  // Alineado a la derecha
                    table.AddCell(new PdfPCell(new Phrase(detalle.Id_orden.ToString())) { HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidthLeft = 0, BorderWidthRight = 0 });
                    table.AddCell(new PdfPCell(new Phrase("$" + detalle.Monto_aplicado.ToString("0.00"))) { HorizontalAlignment = Element.ALIGN_RIGHT, BorderWidthLeft = 0, BorderWidthRight = 0 });
                    total += detalle.Monto_aplicado;
                }

                // Agregar la tabla al documento
                doc.Add(table);

                // Agregar el total
                Font totalFont = FontFactory.GetFont("Helvetica", 14, Font.BOLD, new BaseColor(160, 18, 52));
                doc.Add(new Paragraph("Total: $" + total.ToString("0.00"), totalFont) { Alignment = Element.ALIGN_RIGHT });
                doc.Add(new Paragraph("") { Alignment = Element.ALIGN_RIGHT });
                doc.Add(new Paragraph("Nota: " + pago.Nota));
                // Cerrar el documento
                doc.Close();
            }
            return ruta;
        }
    }
}
