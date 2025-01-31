﻿using System;

namespace BusinessLayer
{
    public class Colaborador : Usuario
    {
        #region Propiedades
        public Cargo Cargo { get; set; }
        public Turno Turno { get; set; }
        public DateTime FechaIngreso { get; private set; }
        public DateTime FechaCese { get; private set; }
        public int Codigo { get; private set; }
        #endregion

        public Colaborador(int id, string nombre, int telefono, char sexo, string correo, int dni, string apellido,
                           Cargo cargo, Turno turno, DateTime fechaIngreso, DateTime fechaCese, int codigo) : 
            base(id, nombre, apellido, telefono, sexo, correo, dni)
        {
            Cargo = cargo ?? throw new ArgumentNullException(nameof(cargo));
            Turno = turno ?? throw new ArgumentNullException(nameof(turno));
            FechaIngreso = fechaIngreso;
            FechaCese = fechaCese;
            Codigo = codigo;
        }

        public Colaborador(Usuario usuario, Cargo cargo, Turno turno, DateTime fechaIngreso, DateTime fechaCese, int codigo) : 
            base(usuario.Id, usuario.Nombre, usuario.Apellido, usuario.Telefono, usuario.Sexo, usuario.Correo, usuario.Dni)
        {
            Cargo = cargo ?? throw new ArgumentNullException(nameof(cargo));
            Turno = turno ?? throw new ArgumentNullException(nameof(turno));
            FechaIngreso = fechaIngreso;
            FechaCese = fechaCese;
            Codigo = codigo;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} {2}", Codigo, Nombre, Apellido);
        }
    }
}
