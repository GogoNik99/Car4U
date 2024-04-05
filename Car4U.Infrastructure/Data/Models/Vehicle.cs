using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Car4U.Infrastructure.Constants.DataConstants;
namespace Car4U.Infrastructure.Data.Models
{
    [Comment("Vehicle for lending")]
    public class Vehicle
    {
        [Key]
        [Comment("Vehicle Identifier")]

        public int Id { get; set; }

        [Required]
        [MaxLength(VehicleManufacturerMaxLenght)]
        [Comment("Vehicle Manufacturer")]
        public string Manufacturer { get; set; } = string.Empty;

        [Required]
        [MaxLength(VehicleDescriptionMaxLenght)]
        [Comment("Vehicle Description")]

        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Price of the Vehicle")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(VehicleImgNameMaxLenght)]
        [Comment("Name of the Image")]
        public string ImageFileName { get; set; } = string.Empty;

        [Required]
        [Comment("Is Vehicle Approved by Administrator")]
        public bool IsActive { get; set; }

        [Required]
        [Comment("Owner Identifier")]

        public int OwnerId { get; set; }

        [Comment("User Identifier of the Person Renting")]

        public string? RenterId { get; set; }

        [Required]
        [Comment("FuelType Identifier")]

        public int FuelTypeId { get; set; }

        [Required]
        [Comment("Model Identifier")]

        public int ModelId { get; set; }

        [ForeignKey(nameof(OwnerId))]

        public Owner Owner { get; set; } = null!;

        [ForeignKey(nameof(FuelTypeId))]

        public FuelType FuelType { get; set; } = null!;

        [ForeignKey(nameof(ModelId))]

        public Model Model { get; set; } = null!;

    }
}
