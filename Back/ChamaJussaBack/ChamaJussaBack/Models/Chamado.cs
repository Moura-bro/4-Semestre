using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChamaJussaBack.Models;

[Table("Chamado")]
public partial class Chamado
{
    [Key]
    [Column("idChamado")]
    public Guid IdChamado { get; set; }

    [StringLength(255)]
    public string Titulo { get; set; } = null!;

    [StringLength(255)]
    public string Equipamento { get; set; } = null!;

    [StringLength(255)]
    public string Setor { get; set; } = null!;

    [StringLength(255)]
    public string Descricao { get; set; } = null!;

    [StringLength(255)]
    public string? FotoDoProblema { get; set; }

    [Column("Status_OS")]
    [StringLength(255)]
    public string StatusOs { get; set; } = null!;

    [Column("Data_Criacao", TypeName = "datetime")]
    public DateTime DataCriacao { get; set; }

    [Column("Data_Atualizacao", TypeName = "datetime")]
    public DateTime DataAtualizacao { get; set; }

    public Guid IdUsuario { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Chamados")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    [InverseProperty("IdChamadoNavigation")]
    public virtual ICollection<Notificacao> Notificacaos { get; set; } = new List<Notificacao>();
}
