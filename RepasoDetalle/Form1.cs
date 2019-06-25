using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

namespace Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public double Existencia { get; set; }
        public double Precio { get; set; }

        public Articulos()
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

        public List<PedidosDetalle> Detalle { get; set; }

        public Pedidos()
        {
            PedidoId = 0;
            Fecha = DateTime.Now;
            Monto = 0;
            this.Detalle = new List<PedidosDetalle>();
        }
    }
    public class PedidosDetalle
    {
        [Key]
        public int PedidoDetalleId { get; set; }
        public int PedidoId { get; set; }
        public int ArticuloId { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulos Articulo { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }

        public PedidosDetalle()
        {

        }

        public PedidosDetalle(int articuloId, Articulos articulo, double cantidad, double precio)
        {
            ArticuloId = articuloId;
            Articulo = articulo;
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
        public DbSet<Articulos> Articulos { get; set; }
        public Contexto() : base(@"Data Source=.\SqlExpress;Initial Catalog = RepasoDetalleDb; Integrated Security = True")
        {

        }
    }
}

namespace BLL
{
    public interface IRepository<T> where T : class
    {
        List<T> GetList(Expression<Func<T, bool>> expression);
        T Buscar(int id);
        bool Guardar(T entity);
        bool Modificar(T entity);
        bool Eliminar(int id);
    }

    public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
    {
        internal Contexto _contexto;

        public RepositorioBase()
        {
            _contexto = new Contexto();
        }

        public virtual bool Guardar(T entity)
        {
            bool paso = false;
            try
            {
                if (_contexto.Set<T>().Add(entity) != null)
                    paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Dispose();
            }
            return paso;
        }

        public virtual bool Modificar(T entity)
        {
            bool paso = false;
            try
            {
                _contexto.Entry(entity).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Dispose();
            }
            return paso;
        }

        public virtual bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                T entity = _contexto.Set<T>().Find(id);
                _contexto.Set<T>().Remove(entity);
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Dispose();
            }
            return paso;
        }


        public virtual T Buscar(int id)
        {
            T entity;
            try
            {
                entity = _contexto.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Dispose();
            }
            return entity;
        }

        public virtual List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> Lista = new List<T>();
            try
            {
                Lista = _contexto.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Dispose();
            }
            return Lista;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }

    public class PedidosBll
    {
        public static bool Guardar(Pedidos pedido)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Pedidos.Add(pedido) != null)
                {
                    foreach (var item in pedido.Detalle)
                    {
                        contexto.Articulos.Find(item.ArticuloId).Existencia -= item.Cantidad;
                    }

                    contexto.SaveChanges(); //Guardar los cambios
                    paso = true;
                }
                //siempre hay que cerrar la conexion
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
    }
}
