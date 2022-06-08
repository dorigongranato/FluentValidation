using System.ComponentModel.DataAnnotations;

namespace FluentValidation.Entity
{
	public class Pessoa
	{
        [Required]
        public string Nome { get; set; }

    }
}