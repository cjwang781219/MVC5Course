using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.QueryModel
{
    public class ListProdectsQM :IValidatableObject
    {
        public ListProdectsQM()
        {
            Stock_s = 0;
            Stock_e = 999999;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Stock_s > this.Stock_e)
            {
                yield return new ValidationResult("起不可大於迄", new string[] { "Stock_s", "Stock_e" });
            }
            yield break;
        }
        public string q { get; set; }
        
        public int Stock_s { get; set; }

        public int Stock_e { get; set; }
    }
}