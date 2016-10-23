namespace FoodTrucks.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FoodTrucksSF")]
    public partial class FoodTrucksSF
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationId { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Cnn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Approved { get; set; }

        [StringLength(50)]
        public string Block { get; set; }

        [StringLength(50)]
        public string Lot { get; set; }

        [StringLength(50)]
        public string Blocklot { get; set; }

        [StringLength(500)]
        public string Applicant { get; set; }

        [StringLength(500)]
        public string DaysHours { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExpirationDate { get; set; }

        [StringLength(50)]
        public string FacilityType { get; set; }

        [StringLength(500)]
        public string FoodItems { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        [StringLength(50)]
        public string LocationType { get; set; }

        [StringLength(500)]
        public string LocationDescription { get; set; }

        [StringLength(50)]
        public string Permit { get; set; }

        [StringLength(50)]
        public string PriorPermit { get; set; }

        [StringLength(500)]
        public string Schedule { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string x { get; set; }

        [StringLength(50)]
        public string y { get; set; }
    }
}
