using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChamaJussaBack.Models;

[Table("Usuario")]
[Index("Email", Name = "UQ__Usuario__A9D1053429A07B5B", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("idUsuario")]
    public Guid IdUsuario { get; set; }

    [StringLength(255)]
    public string Nome { get; set; } = null!;

    [StringLength(255)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string Senha { get; set; } = null!;

    [StringLength(255)]
    public string? FotoPerfil { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Notificacao> Notificacaos { get; set; } = new List<Notificacao>();
}
