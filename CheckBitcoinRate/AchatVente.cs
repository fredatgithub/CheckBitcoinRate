namespace CheckBitcoinRate
{
  using System;
  using System.ComponentModel.DataAnnotations.Schema;

  [Table("AchatVente")]
  public partial class AchatVente
  {
    public int AchatVenteId { get; set; }

    public DateTime? DateAchatVente { get; set; }

    public decimal? TauxXbtEur { get; set; }

    public decimal? VolumeAchatVente { get; set; }

    public decimal? CoutBrutEuros { get; set; }

    public decimal? FeeEuros { get; set; }

    public string Remark { get; set; }
  }
}
