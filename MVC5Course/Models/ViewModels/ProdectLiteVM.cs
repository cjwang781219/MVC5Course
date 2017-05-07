using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    /// <summary>
    /// Prodect的精簡版
    /// </summary>
    public class ProdectLiteVM
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "請輸入商品名稱")]
        [MinLength(3), MaxLength(30)]
        [RegularExpression(".+-.+", ErrorMessage = "商品名稱格式錯誤")]
        [DisplayName("商品名稱")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "請輸入Price")]
        [Range(0, 9999999, ErrorMessage = "請輸入正確的數字")]
        [DisplayName("商品價格")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        public Nullable<decimal> Price { get; set; }

        [Required(ErrorMessage = "請輸入Stock")]
        [DisplayName("商品庫存")]
        [Range(0, 100, ErrorMessage = "請輸入0-100")]
        public Nullable<decimal> Stock { get; set; }
    }
}