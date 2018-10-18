using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class TrainingProduct
    {
        public TrainingProduct()
        {
            ProductName = "";
        }
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Product Name must be filled in")]
        [Display(Description ="Product name")]
        [StringLength(150,MinimumLength =4, ErrorMessage ="Product Name must be greater than {2} characters and less than {1} characters")]
        public string ProductName { get; set; }


        [Range(typeof(DateTime),"1/1/1900","12/21/2100", ErrorMessage ="{0} must be between {1} and {2}")]
        [Display(Description ="Introdution Date")]
        public DateTime IntrodutionDate { get; set; }

        [StringLength(2000,MinimumLength = 10, ErrorMessage ="{0} must be greater than {2} characters and less than {1} characters")]
        [Display(Description ="URL")]
        public string Url { get; set; }
        [Range(1,9999, ErrorMessage ="{0} must be between {1} and {2}")]
        public double Price { get; set; }
    }
}
