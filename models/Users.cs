using System;
using System.Net.Mime;
using System.ComponentModel.DataAnnotations;

namespace DOTNETAPI.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string CodUser { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public string FunctionUser { get; set; }

        public string CdProtheus { get; set; }

        public string Email { get; set; }
    }
}