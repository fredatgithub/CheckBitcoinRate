namespace CheckBitcoinRate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
