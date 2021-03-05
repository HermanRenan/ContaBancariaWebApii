using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LayerDataBase.Model
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Código do banco é obrigatório")]
        public int BankCode { get; set; }

        [Column(TypeName = "varchar(20)")]
        [MaxLength]
        [Required(ErrorMessage = "Número da Conta é obrigatório")]
        public string AccountNumber { get; set; }
        [Column(TypeName = "varchar(15)")]
        [MaxLength]
        [Required(ErrorMessage = "Número da Agência é obrigatório")]
        public string AgencyNumber { get; set; }

        [Column(TypeName = "varchar(30)")]
        [MaxLength]
        [Required(ErrorMessage = "CPF ou CNPJ é obrigatório")]
        public string Cpf_Cnpj { get; set; }

        [Column(TypeName = "varchar(600)")]
        [MaxLength]
        [Required(ErrorMessage = "Nome Cliente é obrigatório")]
        public string ClientName { get; set; }

        [Column(TypeName = "varchar(100)")]
        [MaxLength]

        public string Status { get; set; }

        [Required(ErrorMessage = "Data de abertura é obrigatório")]
        public DateTime OpeningDate { get; set; }
    }
}
