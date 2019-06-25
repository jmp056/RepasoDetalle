using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
        public void GuardarSinRepositorio()
        {
         

            Pedidos pedido = new Pedidos();
            pedido.PedidoId = 1;
            pedido.Fecha = DateTime.Now;
            pedido.Monto = 2;

            pedido.Detalle.Add(new PedidosDetalle()
            {
                ArticuloId = 1,
                Cantidad = 5,
                Precio = 1000
            }
            );

            pedido.Detalle.Add(new PedidosDetalle()
            {
                ArticuloId = 2,
                Cantidad = 1.5,
                Precio = 199.99
            }
            );

            Assert.IsTrue(PedidosBll.Guardar(pedido));
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

        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Pedidos> repositorio;
            repositorio = new RepositorioBase<Pedidos>();
            List<Pedidos> lista = new List<Pedidos>();
            lista = repositorio.GetList(p => true);
            Assert.IsNotNull(lista);
        }
    }
}