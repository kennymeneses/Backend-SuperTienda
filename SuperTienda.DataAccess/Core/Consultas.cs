using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTienda.DataAccess.Core
{
    public class Consultas
    {




        #region dbo

        public static string ConValidadorDataExistencia = "uspValidadorDataExistencia";




        public static string ConCodigoGenerar = "uspNomenclaturaGenerar"; //OK




        public static string DboUsuarioBuscar = "uspMostrarUsuarioXPaginacion"; //-- OK
        public static string DboUsuarioInd = "uspUsuarioInd"; //-- OK

        public static string DboCategoriaBuscar = "uspMostrarCategoriaXPaginacion"; //-- OK
        public static string DboCategoriaInd = "uspCategoriaInd"; //-- OK

        public static string DboSubCategoriaBuscar = "uspMostarSubCategoriasXPaginacion"; //-- Ok
        public static string DboSubCategoriaInd = "uspSubCategoriaInd"; //-- Ok
        public static string DboSubCategoriaBuscarPorIdCategoria = "uspMostrarSubCategoriasXIdCategoria"; //-- Ok

        public static string DboSubSubCategoriaBuscar = "uspMostarSubSubCategoriasXPaginacion"; //-- Ok
        public static string DboSubSubCategoriaInd = "uspSubSubCategoriaInd"; //-- Ok
        public static string DboSubSubCategoriaBuscarPorIdSubCategoria = "uspMostrarSubSubCategoriasXIdSubCategoria"; //-- Ok

        public static string DboBuscarProductoporIdSubSubCategoria = "uspMostrarProductosXPaginacion"; //-- OK OTORGA LAS PAGINAS DE LOS PRODUCTOS POR EL ID DE LA SUBSUBCATEGORIA
        public static string DboProductoInd = "uspBuscarProductoXId"; //-- OK
        public static string DboBuscarProductoporNombreSimilar = "uspProductoBuscarInfoXNombre"; //-- OK OTORGA UNA LISTA DE UNA PAGINA QUE CONTENGA UN NOMBRE SIMILAR

        #endregion

    }
}
