using First.App.Core.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace First.App.Models
{
    public abstract class CustomerViewModel
    {    
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Yaş alanı zorunludur")]
        [Display(Name = "Yaş")]
        [Range(18,99, ErrorMessage = "Yaş alanı 18 ile 99 arasında olmalıdır")]        
        public int Age { get; set; }
        [Required(ErrorMessage = "Ad alanı zorunlu alandır")]
        [StringLength(10, ErrorMessage = "Ad alanı 10 karakter büyük olamaz")]        
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyadı alanı zorunlu alandır")]
        [StringLength(20, ErrorMessage = "Soyadı alanı 10 karakter büyük olamaz")]
        public string LastName { get; set; }       
        public string Description { get; set; }
        [StringLength(100, ErrorMessage = "Soyadı alanı 10 karakter büyük olamaz")]
        [Required(ErrorMessage = "Adres alanı zorunlu alandır")]
        public string Address { get; set; }
        [DataType(DataType.Password)]
        public int Password { get ; set; }
        [MaxFileSize(2 * 1024 * 1024)]
        public IFormFile Image { get; set; } 

    }
}
