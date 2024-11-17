using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITechZap.Models;

[Table("T_TZ_SOLAR_PANEL")]
public class SolarPanel
{
    /// <summary>
    /// Identificador do painel solar
    /// </summary>
    [Key]
    [Column("ID_SOLAR_PANEL")]
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
    [ForeignKey("ID_SOLAR_PANEL_TYPE")]
    public SolarPanelType? solarPanelType { get; set; }
}
