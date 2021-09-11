﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Api.AspNet.Model
{
    public class UsuarioModel
    {
        public UsuarioModel()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(30)]
        public string NomeUsuario { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Senha { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Regra { get; set; }

        public UsuarioModel(string nomeUsuario, string senha, string regra)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
            Regra = regra;
        }
    }
}
