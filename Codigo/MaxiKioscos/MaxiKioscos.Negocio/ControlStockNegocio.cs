using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Email;
using MaxiKioscos.Email.Models;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Negocio
{
    public class ControlStockNegocio : IControlStockNegocio
    {
        private IMaxiKioscosUow Uow { get; set; }

        public ControlStockNegocio(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public bool Cerrar(int controlStockId, List<ControlStockDetalle> listado)
        {
            var motivos = Uow.MotivosCorreccion.Listado();
            var detalles = listado.Where(d => d.MotivoCorreccionId != null).ToList();
            if (detalles.Any())
            {
                foreach (var controlStockDetalle in detalles)
                {
                    var stock = Uow.Stocks.Obtener(controlStockDetalle.StockId);

                    var transaccion = new StockTransaccion()
                                          {
                                              Desincronizado = true,
                                              Eliminado = false,
                                              FechaUltimaModificacion = DateTime.Now,
                                              Identifier = Guid.NewGuid(),
                                              StockId = controlStockDetalle.StockId,
                                              StockTransaccionTipoId = 3 //Correccion
                                          };

                    var motivo = motivos.FirstOrDefault(m => m.MotivoCorreccionId == controlStockDetalle.MotivoCorreccionId);
                    transaccion.Cantidad = motivo.SumarAStock
                                               ? controlStockDetalle.Correccion.GetValueOrDefault()
                                               : -controlStockDetalle.Correccion.GetValueOrDefault();
                    Uow.StockTransacciones.Agregar(transaccion);
                    stock.StockActual += transaccion.Cantidad;

                    Uow.Stocks.Modificar(stock);
                    controlStockDetalle.Desincronizado = true;
                    Uow.ControlStockDetalles.Modificar(controlStockDetalle);
                }
            }
            var control = Uow.ControlesStock.Obtener(controlStockId);
            control.FechaCorreccion = DateTime.Now;
            control.Cerrado = true;
            control.Desincronizado = true;
            Uow.ControlesStock.Modificar(control);
            Uow.Commit();
            
            //Deshabilito todos los ControlStockDetalle con controlStock abierto para el mismo stock
            if (detalles.Any())
                Uow.ControlesStock.DeshabilitarAbiertos(controlStockId, detalles.Select(d => d.StockId).ToArray());
            
            return true;
        }

        public bool Eliminar(int id)
        {
            var controlStrock =  Uow.ControlesStock.Obtener(cs => cs.ControlStockId == id,cs => cs.ControlStockDetalles);

            if (controlStrock == null)
            {
                return false;
            }

            if (controlStrock.Cerrado)
            {
                return false;
            }

            var detalles = controlStrock.ControlStockDetalles.ToArray();

            foreach (var detalle in detalles)
            {
                Uow.ControlStockDetalles.Eliminar(detalle);
            }

            Uow.ControlesStock.Eliminar(controlStrock);

            Uow.Commit();

            return true;
        }
    }
}
