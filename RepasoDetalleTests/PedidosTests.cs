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
    }
}