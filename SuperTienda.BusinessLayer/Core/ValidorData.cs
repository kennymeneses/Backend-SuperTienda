using System;
using System.Collections.Generic;
using System.Text;
using SuperTienda.Common.Core;
using SuperTienda.Common.Facade;
using SuperTienda.DataAccess;
using SuperTienda.DataAccess.Core;
using Microsoft.Extensions.Logging;
using SuperTienda.Common.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Reflection;


namespace SuperTienda.BusinessLayer.Core
{
    public class ValidadorData
    {

        IRepository _repository;

        IUnitOfWork _unitOfWork;

        //public ValidadorData()
        //{
        //    _repository = repository;

        //    _unitOfWork = unitOfWork;
        //}

        public ValidadorData(
              IRepository repository,
              IUnitOfWork unitOfWork) : base()
        {
            _repository = repository;

            _unitOfWork = unitOfWork;
        }

        public CheckStatus Validar (string consulta, string tabla,
            string innerjoin = "", string where = "")
        {

            CheckStatus checkStatus = new CheckStatus();
            int total = 0;

            try
            {

                SqlParameter OutputParam = new SqlParameter("@total", SqlDbType.Int);
                OutputParam.Direction = ParameterDirection.InputOutput;
                OutputParam.Value = 0;

                SqlParameter[] parameters =
                {
                    new SqlParameter("@consulta", consulta),
                    new SqlParameter("@entidad",tabla),
                    new SqlParameter("@innerjoin", innerjoin),
                    new SqlParameter("@where", where),
                    OutputParam
                };

                var data = _repository.ExecuteProcedureScalar(Consultas.ConValidadorDataExistencia, parameters);
                int TT = Convert.ToInt32(OutputParam.Value);
                if (OutputParam.Value != DBNull.Value)
                {
                    total = Convert.ToInt32(OutputParam.Value);
                }

                if (data != null)
                {
                    checkStatus.apiEstado = Status.Error;
                    checkStatus.id = (int)data;
                }
                else if (data == null)
                {
                    checkStatus.apiEstado = Status.Ok;
                    checkStatus.id = 0;
                }

            }

            catch (Exception ex)
            {

                checkStatus.apiEstado = Status.Error;
                checkStatus.apiMensaje = "Error en la base de datos.";

            }

            return checkStatus;
        }
    }
}
