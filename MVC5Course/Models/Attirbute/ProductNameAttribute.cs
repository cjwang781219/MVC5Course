using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.Attirbute
{
    public class ProductNameAttribute : DataTypeAttribute
    {
        public ProductNameAttribute() :base(DataType.Text)
        {

        }

        public override bool IsValid(object value)
        {
            string str = (string)value;
            return str.Contains("b");
        }
    }
}