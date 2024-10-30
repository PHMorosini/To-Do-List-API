﻿using System.ComponentModel.DataAnnotations;
using To_Do_List_API.Content.Task.Enum;

namespace To_Do_List_API.Content.Task.Entity
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome da tarefa")]
        [StringLength(60, ErrorMessage = "O nome deve ter no maximo {0} caracteres")]
        public string Name { get; set; }
        [Display(Name = "Descricao da tarefa")]
        [StringLength(60, ErrorMessage = "A descricao da tarefa deve ter no maximo {0} caracteres")]
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Status da tarefa")]
        public StatusEnum Status { get; set; }
        [Required]
        [Display(Name = "Tarefa criada em")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}