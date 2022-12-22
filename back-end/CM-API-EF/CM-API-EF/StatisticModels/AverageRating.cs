using System.ComponentModel.DataAnnotations;

namespace CM_API_EF.StatisticModels
{
    public class AverageRating
    {
        [Key]
        public int AverageRatingID { get; set; }
        [Required]
        public double AverageRatingPercentage;
    }
}