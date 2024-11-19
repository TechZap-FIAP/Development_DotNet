﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APITechZap.Models;

/// <summary>
/// Classe que representa o painel solar
/// </summary>
[Table("T_TZ_SOLAR_PANEL")]
public class SolarPanel
{
    /// <summary>
    /// Identificador do painel solar
    /// </summary>
    [Key]
    [Column("ID_SOLAR_PANEL")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int IdSolarPanel { get; set; }

    /// <summary>
    /// Tamanho do painel solar
    /// </summary>
    [Column("DS_SIZE")]
    public double DsSize { get; set; }

    /// <summary>
    /// Material do painel solar
    /// </summary>
    [Column("DS_MATERIAL")]
    public string DsMaterial { get; set; }

    /// <summary>
    /// Preço do painel solar
    /// </summary>
    [Column("DS_PRICE")]
    public double DsPrice { get; set; }

    /// <summary>
    /// Tipo do painel solar
    /// </summary>
    public SolarPanelType? SolarPanelType { get; set; }
}
