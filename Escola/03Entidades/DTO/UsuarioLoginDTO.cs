﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades.DTO.Usuarios
{
    public class UsuarioLoginDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Tipo { get; set; }
    }
}
