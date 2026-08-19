using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChamaJussaBack.Models;

[Table("Notificacao")]
public partial class Notificacao
{
    [Key]
    [Column("idNotificacao")]
    public Guid IdNotificacao { get; set; }

    [StringLength(255)]
    public string Titulo { get; set; } = null!;

    [StringLength(255)]
    public string Mensagem { get; set; } = null!;

    public bool? Verificada { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataNotificacao { get; set; }

    public Guid IdChamado { get; set; }

    public Guid IdUsuario { get; set; }

    [ForeignKey("IdChamado")]
    [InverseProperty("Notificacaos")]
    public virtual Chamado IdChamadoNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Notificacaos")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
