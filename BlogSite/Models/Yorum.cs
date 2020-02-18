namespace BlogSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yorum")]
    public partial class Yorum
    {
        public int Id { get; set; }

        [Required]
        public string YorumIcerik { get; set; }

        public int KullaniciId { get; set; }

        public int MakaleId { get; set; }

        public DateTime Tarih { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Makale Makale { get; set; }
    }
}
