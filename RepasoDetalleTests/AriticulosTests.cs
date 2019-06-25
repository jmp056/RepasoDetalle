using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace Entidades.Tests
{
    [TestClass()]
    public class AriticulosTests
    {
        [TestMethod()]
        public void Guardar()
        {
            RepositorioBase<Articulos> repositorio;
            repositorio = new RepositorioBase<Articulos>();
            Articulos articulo = new Articulos(); 
            articulo.Descripcion =$"Intel Core I5 5tg Gen {DateTime.Now.ToFileTime()}";
            articulo.Existencia = 1;
            articulo.Precio = 1;
            Assert.IsTrue(repositorio.Guardar(articulo));
        }

        [TestMethod()]
        public void Modificar()
        {
            RepositorioBase<Articulos> repositorio;
            repositorio = new RepositorioBase<Articulos>();
            Articulos articulo = new Articulos();
            articulo.ArticuloId = 1;
            articulo.Descripcion = "Intel Core I5 7tg Gen";
            articulo.Existencia = 1;
            articulo.Precio = 1;
            Assert.IsTrue(repositorio.Modificar(articulo));
        }

        [TestMethod()]
        public void Eliminar()
        {
            RepositorioBase<Articulos> repositorio;
            repositorio = new RepositorioBase<Articulos>();
            Assert.IsTrue(repositorio.Eliminar(1));
        }

        [TestMethod()]
        public void Buscar()
        {
            RepositorioBase<Articulos> repositorio;
            repositorio = new RepositorioBase<Articulos>();
            Assert.IsNotNull(repositorio.Buscar(1));
        }


        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Articulos> repositorio;
            repositorio = new RepositorioBase<Articulos>();
            List<Articulos> lista = new List<Articulos>();
            lista = repositorio.GetList(p => true);
            Assert.IsNotNull(lista);
        }
    }
}