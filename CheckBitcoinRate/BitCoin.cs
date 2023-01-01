namespace CheckBitcoinRate
{
  using System;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  [Table("BitCoin")]
  public partial class BitCoin
  {
    [Key]
    [Column(Order = 0)]
    public DateTime Date { get; set; }

    [Key]
    [Column(Order = 1)]
    public double RateEuros { get; set; }

    [Key]
    [Column(Order = 2)]
    public double RateDollar { get; set; }
  }
}
