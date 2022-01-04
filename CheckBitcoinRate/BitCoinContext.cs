using System.Data.Entity;

namespace CheckBitcoinRate
{
  public partial class BitCoinContext : DbContext
  {
    public BitCoinContext()
        : base("name=BitCoinContext")
    {
    }

    public virtual DbSet<AchatVente> AchatVentes { get; set; }
    public virtual DbSet<Interruption> Interruptions { get; set; }
    public virtual DbSet<BitCoin> BitCoins { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<AchatVente>()
          .Property(e => e.TauxXbtEur)
          .HasPrecision(8, 2);

      modelBuilder.Entity<AchatVente>()
          .Property(e => e.VolumeAchatVente)
          .HasPrecision(9, 9);

      modelBuilder.Entity<AchatVente>()
          .Property(e => e.CoutBrutEuros)
          .HasPrecision(6, 3);

      modelBuilder.Entity<AchatVente>()
          .Property(e => e.FeeEuros)
          .HasPrecision(3, 2);
    }
  }
}
