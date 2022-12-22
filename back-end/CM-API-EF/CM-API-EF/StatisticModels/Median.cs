using System.ComponentModel.DataAnnotations;

namespace CM_API_EF.StatisticModels
{
    public class Median
    {
        [Key]
        public int MedianId { get; set; }

        [Required]
        public double MedianValue { get; set; }
    }
}