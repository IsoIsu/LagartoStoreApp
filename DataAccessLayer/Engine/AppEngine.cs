﻿using BusinessLayer;

namespace DataAccessLayer
{
    public abstract class AppEngine
    {
        public static Cuenta Cuenta;
        public static Colaborador Colaborador;

        public static readonly UsuarioDAL usuarioDAL = new UsuarioDAL();
        public static readonly CategoriaDAL categoriaDAL = new CategoriaDAL();
        public static readonly TurnoDAL turnoDAL = new TurnoDAL();
        public static readonly CargoDAL cargoDAL = new CargoDAL();
        public static readonly ProductoDAL productoDAL = new ProductoDAL();
        public static readonly CuentaDAL cuentaDAL = new CuentaDAL();
        public static readonly ClienteDAL clienteDAL = new ClienteDAL();
        public static readonly ColaboradorDAL colaboradorDAL = new ColaboradorDAL();
        public static readonly CompraDAL compraDAL = new CompraDAL();
    }
}
