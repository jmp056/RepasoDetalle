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
    public class PedidosTests
    {
        [TestMethod()]
        public void Guardar()
        {
            RepositorioBase<Pedidos> repositorio;
            repositorio = new RepositorioBase<Pedidos>();
            Pedidos pedido = new Pedidos();
            pedido.PedidoId = 1;
            pedido.Fecha = DateTime.Now;
            pedido.Monto = 2;
            Assert.IsTrue(repositorio.Guardar(pedido));
        }

        [TestMethod()]
        public void Modificar()
        {
            RepositorioBase<Pedidos> repositorio;
            repositorio = new RepositorioBase<Pedidos>();
            Pedidos pedido = new Pedidos();
            pedido.PedidoId = 1;
            pedido.Fecha = DateTime.Now;
            pedido.Monto = 1;
            Assert.IsTrue(repositorio.Guardar(pedido));
        }

        [TestMethod()]
        public void Eliminar()
        {
            RepositorioBase<Pedidos> repositorio;
            repositorio = new RepositorioBase<Pedidos>();
            Assert.IsTrue(repositorio.Eliminar(1));
        }

        [TestMethod()]
        public void Buscar()
        {
            RepositorioBase<Pedidos> repositorio;
            repositorio = new RepositorioBase<Pedidos>();
            Assert.IsNotNull(repositorio.Buscar(1));
        }

    }
}