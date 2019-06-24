using entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepasoDetalle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}

namespace entidades
{
    public class Ariticulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public double Existencia { get; set; }
        public double Precio { get; set; }

        public Ariticulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty;
            Existencia = 0;
            Precio = 0;
        }
    }

    public class Pedidos
    {
        [Key]
        public int PedidoId { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }

        public Pedidos()
        {
            PedidoId = 0;
            Fecha = DateTime.Now;
            Monto = 0;
        }
    }
    public class PedidosDetalle
    {
        [Key]
        public int PedidoDetalleId { get; set; }
        public int PedidoId { get; set; }
        public int ArticuloId { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }

        public PedidosDetalle(int articuloId, int cantidad, double precio)
        {
            ArticuloId = articuloId;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Pedidos> Pedidos { get; set; }
        public Contexto() : base(@"Data Source=.\SqlExpress;Initial Catalog = RepasoDb; Integrated Security = True")
        {

        }
    }
}

namespace BLL
{

}
