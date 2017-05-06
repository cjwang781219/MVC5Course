namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }
    
    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "請輸入商品名稱")]
        [MinLength(3), MaxLength(30)]
        [RegularExpression(".+-.+", ErrorMessage = "商品名稱格式錯誤")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "請輸入Price")]
        [Range(0, 9999999, ErrorMessage = "請輸入正確的數字")]
        public Nullable<decimal> Price { get; set; }
        [Required(ErrorMessage = "請選擇Active")]
        public Nullable<bool> Active { get; set; }
        [Required(ErrorMessage = "請輸入Stock")]
        [Range(0, 100, ErrorMessage = "請輸入0-100")]
        public Nullable<decimal> Stock { get; set; }

        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}