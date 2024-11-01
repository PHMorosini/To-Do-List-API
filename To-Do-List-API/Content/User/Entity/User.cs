using System.ComponentModel.DataAnnotations;

namespace To_Do_List_API.Content.User.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome do usuario")]
        [StringLength(60, ErrorMessage = "O nome deve ter no maximo {0} caracteres")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        public ICollection<Task.Entity.Task> Tasks { get; set; }
    }
}
