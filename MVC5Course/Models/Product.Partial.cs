namespace MVC5Course.Models
{
    using Attirbute;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product :IValidatableObject
    {
        public int 訂單數量 {
            get {
                return this.OrderLine.Count();
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Price > 1000)
            {
                yield return new ValidationResult("price 不可大於1000",new string[] { "Price"});
            }
            yield break;
        }
    }
    
    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "請輸入商品名稱")]
        //[MinLength(3), MaxLength(30)]
        //[RegularExpression(".+-.+", ErrorMessage = "商品名稱格式錯誤")]
        [DisplayName("商品名稱")]
        [ProductName(ErrorMessage ="要有b 字元")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "請輸入Price")]
        [Range(0, 9999999, ErrorMessage = "請輸入正確的數字")]
        [DisplayName("商品價格")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:0}")]
        public Nullable<decimal> Price { get; set; }
        [DisplayName("是否上架")]
        [Required(ErrorMessage = "請選擇Active")]
        public Nullable<bool> Active { get; set; }
        [Required(ErrorMessage = "請輸入Stock")]
        [DisplayName("商品庫存")]
        //[Range(0, 100, ErrorMessage = "請輸入0-100")]
        public Nullable<decimal> Stock { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime CreateDate { get; set; }

        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
