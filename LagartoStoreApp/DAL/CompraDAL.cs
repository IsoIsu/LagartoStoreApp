﻿using LagartoStoreApp.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagartoStoreApp.DAL
{
    public sealed class CompraDAL : ICrud<Compra>
    {
        public void Create(Compra compra)
        {
            if (compra is null) throw new ArgumentNullException(nameof(compra));

            AppEngine.clienteDAL.GetByID(compra.Cliente.Id);

            ConexionBD.SetData("INSERT INTO COMPRAS (ID_COLABORADOR, ID_CLIENTE) " +
                               "VALUES (" + compra.Colaborador.Id + ", " + compra.Cliente.Id + ")",
                               out int rows);

            if (rows == 0) throw new Exception("No se actualizó ningún registro.");
        }

        public void Delete(int id)
        {
            if (id < 1) throw new Exception("El ID: " + id + " es incorrecto.");

            ConexionBD.SetData("DELETE FROM COMPRAS WHERE ID_COMPRA = " + id, out int rows);

            if (rows == 0) throw new Exception("No se eliminó ningún registro.");
        }

        public List<Compra> GetAll()
        {
            List<DBParametro> parametros = new List<DBParametro>();
            parametros.Add(new DBParametro("P_ID_COMPRA", 0));
            DataTable dataTable = ConexionBD.GetData("GET_COMPRAS", parametros).Tables[0];

            List<Compra> compras = new List<Compra>();
            foreach (DataRow row in dataTable.Rows)
            {
                compras.Add(new Compra(Convert.ToInt32(row["ID_COMPRA"]),
                                       Convert.ToDateTime(row["FECHA"]),
                                       new Colaborador(Convert.ToInt32(row["ID_USUARIO"]),
                                                       row["NOMBRE"].ToString(),
                                                       Convert.ToInt32(row["TELEFONO"]),
                                                       Convert.ToChar(row["SEXO"]),
                                                       row["CORREO"].ToString(),
                                                       Convert.ToInt32(row["DNI"]),
                                                       row["APELLIDO"].ToString(),
                                                       new Cargo(Convert.ToInt32(row["ID_CARGO"]),
                                                                 row["NOMBRE_CARGO"].ToString(),
                                                                 Convert.ToDecimal(row["SALARIO"])),
                                                       new Turno(Convert.ToInt32(row["ID_TURNO"]),
                                                                 row["NOMBRE_TURNO"].ToString(),
                                                                 DateTime.Today.Add(TimeSpan.Parse(row["HORA_INICIO"].ToString())),
                                                                 DateTime.Today.Add(TimeSpan.Parse(row["HORA_FIN"].ToString()))),
                                                                 Convert.ToDateTime(row["FECHA_INGRESO"]),
                                                                 !string.IsNullOrEmpty(row["FECHA_CESE"].ToString()) ?
                                                                      Convert.ToDateTime(row["FECHA_CESE"].ToString()) : new DateTime(),
                                                       Convert.ToInt32(row["CODIGO_COLABORADOR"])),
                                       new Cliente(Convert.ToInt32(row["ID_USUARIO"]),
                                                   row["NOMBRE"].ToString(),
                                                   row["APELLIDO"].ToString(),
                                                   Convert.ToInt32(row["TELEFONO"]),
                                                   Convert.ToChar(row["SEXO"]),
                                                   row["CORREO"].ToString(),
                                                   Convert.ToInt32(row["DNI"]),
                                                   Convert.ToInt32(row["CODIGO_CLIENTE"]))));
            }

            return compras;
        }

        public Compra GetByID(int id)
        {
            if (id < 1) throw new Exception("El ID: " + id + " es incorrecto.");

            List<DBParametro> parametros = new List<DBParametro>();
            parametros.Add(new DBParametro("P_ID_COMPRA", id));
            DataTable dataTable = ConexionBD.GetData("GET_COMPRAS", parametros).Tables[0];

            if (dataTable.Rows.Count == 0) throw new Exception("No se encontró la compra de ID: " + id + ".");

            return new Compra(Convert.ToInt32(dataTable.Rows[0]["ID_COMPRA"]),
                              Convert.ToDateTime(dataTable.Rows[0]["FECHA"]),
                              new Colaborador(Convert.ToInt32(dataTable.Rows[0]["ID_USUARIO"]),
                                              dataTable.Rows[0]["NOMBRE"].ToString(),
                                              Convert.ToInt32(dataTable.Rows[0]["TELEFONO"]),
                                              Convert.ToChar(dataTable.Rows[0]["SEXO"]),
                                              dataTable.Rows[0]["CORREO"].ToString(),
                                              Convert.ToInt32(dataTable.Rows[0]["DNI"]),
                                              dataTable.Rows[0]["APELLIDO"].ToString(),
                                              new Cargo(Convert.ToInt32(dataTable.Rows[0]["ID_CARGO"]),
                                                        dataTable.Rows[0]["NOMBRE_CARGO"].ToString(),
                                                        Convert.ToDecimal(dataTable.Rows[0]["SALARIO"])),
                                              new Turno(Convert.ToInt32(dataTable.Rows[0]["ID_TURNO"]),
                                                        dataTable.Rows[0]["NOMBRE_TURNO"].ToString(),
                                                        DateTime.Today.Add(TimeSpan.Parse(dataTable.Rows[0]["HORA_INICIO"].ToString())),
                                                        DateTime.Today.Add(TimeSpan.Parse(dataTable.Rows[0]["HORA_FIN"].ToString()))),
                                                        Convert.ToDateTime(dataTable.Rows[0]["FECHA_INGRESO"]),
                                                        !string.IsNullOrEmpty(dataTable.Rows[0]["FECHA_CESE"].ToString()) ?
                                                             Convert.ToDateTime(dataTable.Rows[0]["FECHA_CESE"].ToString()) : new DateTime(),
                                                        Convert.ToInt32(dataTable.Rows[0]["CODIGO_COLABORADOR"])),
                                              new Cliente(Convert.ToInt32(dataTable.Rows[0]["ID_USUARIO"]),
                                                          dataTable.Rows[0]["NOMBRE"].ToString(),
                                                          dataTable.Rows[0]["APELLIDO"].ToString(),
                                                          Convert.ToInt32(dataTable.Rows[0]["TELEFONO"]),
                                                          Convert.ToChar(dataTable.Rows[0]["SEXO"]),
                                                          dataTable.Rows[0]["CORREO"].ToString(),
                                                          Convert.ToInt32(dataTable.Rows[0]["DNI"]),
                                                          Convert.ToInt32(dataTable.Rows[0]["CODIGO_CLIENTE"])));
        }

        public void Update(Compra compra)
        {
            throw new NotImplementedException();
        }
    }
}
