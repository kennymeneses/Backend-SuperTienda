using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using SuperTienda.BusinessLayer.Manager.UsuarioManagement;
using SuperTienda.BusinessLayer.Manager.CategoriaManagement;
using SuperTienda.BusinessLayer.Manager.SubCategoriaManagement;
using SuperTienda.BusinessLayer.Manager.SubSubCategoriaManagement;
using SuperTienda.BusinessLayer.Manager.ProductoManagement;


namespace SuperTienda.BusinessLayer.Core
{
    public class BusinessManagerFactory
    {
        IUsuarioManager _usuarioManager;
        ICategoriaManager _categoriaManager;
        ISubCategoriaManager _subcategoriaManager;
        ISubSubCategoriaManager _subsubcategoriaManager;
        IProductoManager _productoManager;

        public BusinessManagerFactory(IUsuarioManager usuarioManager = null, ICategoriaManager categoriaManager = null, ISubCategoriaManager subcategoriaManager= null, ISubSubCategoriaManager subsubcategoriaManager = null, IProductoManager productoManager = null)
        {
            _usuarioManager = usuarioManager;
            _categoriaManager = categoriaManager;
            _subcategoriaManager = subcategoriaManager;
            _subsubcategoriaManager = subsubcategoriaManager;
            _productoManager = productoManager;
        }

        public IUsuarioManager GetUsuarioManager()
        {
            return _usuarioManager;
        }

        public ICategoriaManager GetCategoriaManager()
        {
            return _categoriaManager;
        }

        public ISubCategoriaManager GetSubCategoriaManager()
        {
            return _subcategoriaManager;
        }

        public ISubSubCategoriaManager GetSubSubCategoriaManager()
        {
            return _subsubcategoriaManager;
        }

        public IProductoManager GetProductoManager()
        {
            return _productoManager;
        }
    }
}
