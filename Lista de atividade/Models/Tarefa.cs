using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Lista_de_atividade.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }
       [Required(ErrorMessage = "Preencha a descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Preencha a data de vencimento")]
        public DateTime? DataDeVencimento { get; set; }
        [Required(ErrorMessage = "Selecione uma categoria")]
        public string CategoriaId { get; set; }
        [ValidateNever]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Selecione um Status")]
        public string StatusId { get; set; }
        [ValidateNever]
        public string Status { get; set; }

        public bool Atrasado => StatusId ==  "aberto" && DataDeVencimento < DateTime.Today;
    }
}
