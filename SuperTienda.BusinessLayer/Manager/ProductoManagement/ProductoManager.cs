using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using SuperTienda.Common.Configuration;
using SuperTienda.Common.Entities;
using SuperTienda.Common.BussinesObjects.Dbo;
using SuperTienda.BusinessLayer.Core;
using SuperTienda.Common.Core;
using SuperTienda.DataAccess;
using SuperTienda.DataAccess.Core;

namespace SuperTienda.BusinessLayer.Manager.ProductoManagement
{
    public class ProductoManager : BusinessManager,IProductoManager
    {

        IRepository _repository;
        ILogger<ProductoManager> _logger;
        IUnitOfWork _unitOfwork;

        public ProductoManager(IRepository repository, ILogger<ProductoManager> logger, IUnitOfWork unitOfWork) : base()
        {
            _repository = repository;
            _logger = logger;
            _unitOfwork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get { return _unitOfwork; } }

        public DataQuery Search(DataQueryInput input)
        {
            DataQuery data = new DataQuery();
            ProductoQueryInput queryInput = (ProductoQueryInput)input;

            SqlParameter[] sqlParams =
            {   new SqlParameter("@idsubsubcategoria", queryInput.idSubSubCategoria),
                new SqlParameter("@tamanio", queryInput.tamanio),
                new SqlParameter("@pagina", queryInput.pagina)
            };

            data = _repository.ExecuteProcedureQuery(Consultas.DboBuscarProductoporIdSubSubCategoria, sqlParams, Mensaje.ProductoPlural);
            return data;
        }

        public SingleQuery SingleById(int id, int idUsuario)
        {
            ProductoIndOutput producto = new ProductoIndOutput();

            producto = _repository.ExecuteProcedureSingle<ProductoIndOutput>(Consultas.DboProductoInd, id);
            if (producto == null)
            {
                producto = new ProductoIndOutput
                {
                    apiMensaje = string.Format(Mensaje.NoExiste, Mensaje.Producto), apiEstado= Status.Error
                };
            }
            else
            {

            }

            return producto;
        }

        public CheckStatus Create(BaseInputEntity entity)
        {
            CheckStatus checkstatus = null;
            ProductoInput input = (ProductoInput)entity;

            Producto producto = new Producto();
            producto.CodigoProducto = input.codigoproducto;
            producto.NombreProducto = input.nombreproducto;
            producto.Fabricante = input.fabricante;
            producto.AnioFabricacion = input.aniofabricacion;
            producto.Descuento = input.descuento;
            producto.Stock = input.stock;
            producto.IdCategoria = input.idcategoria;
            producto.IdSubCategoria = input.idsubcategoria;
            producto.IdSubSubCategoria = input.idsubsubcategoria;

            try
            {
                _repository.Create<Producto>(producto);
                SaveChanges();

                checkstatus = new CheckStatus(producto.IdProducto, producto.NombreProducto, Status.Ok,
                    string.Format(Mensaje.Guardar, Mensaje.Producto));
            }
            catch(Exception ex)
            {
                checkstatus = new CheckStatus(Status.Error, ex.Message);
            }
            return checkstatus;
        }

        public CheckStatus Update(BaseInputEntity entity)
        {
            CheckStatus checkstatus = null;
            ProductoInput input = (ProductoInput)entity;

            Producto producto = _repository.Single<Producto>(p => p.IdProducto == input.idProducto);

            if(producto != null)
            {
                producto.CodigoProducto = input.codigoproducto;
                producto.NombreProducto = input.nombreproducto;
                producto.Fabricante = input.fabricante;
                producto.AnioFabricacion = input.aniofabricacion;
                producto.Descuento = input.descuento;
                producto.Stock = input.stock;
                producto.IdCategoria = input.idcategoria;
                producto.IdSubCategoria = input.idsubcategoria;
                producto.IdSubSubCategoria = input.idsubsubcategoria;
                producto.Estado = input.estado;
                producto.Eliminado = false;

                try 
                {

                    _repository.Update<Producto>(producto);
                    SaveChanges();

                    checkstatus = new CheckStatus(Status.Ok,
                        string.Format(Mensaje.Guardar, Mensaje.Producto));
                }

                catch(Exception ex)
                {
                    checkstatus = new CheckStatus(Status.Error, ex.Message);
                }
            }
            else
            {
                checkstatus = new CheckStatus(Status.Error, 
                    String.Format(Mensaje.NoExiste, Mensaje.Producto));
            }

            return checkstatus;
        }

        public CheckStatus Delete(int id, int idProducto)
        {
            CheckStatus checkstatus = null;
            Producto producto = _repository.Single<Producto>(p => p.IdProducto == id);

            if(producto != null)
            {

                producto.Eliminado = true;

                try
                {
                    _repository.Update<Producto>(producto);
                    SaveChanges();

                    checkstatus = new CheckStatus(Status.Ok,
                        string.Format(Mensaje.Eliminar, Mensaje.Usuario));
                }
                catch(Exception ex)
                {
                    checkstatus = new CheckStatus(Status.Error, ex.Message);
                }
            }
            else
            {
                checkstatus = new CheckStatus(Status.Error,
                    String.Format(Mensaje.NoExiste, Mensaje.Producto));
            }

            return checkstatus;
        }

        public void SaveChanges()
        {
            _unitOfwork.SaveChanges();
        }

    }
}
