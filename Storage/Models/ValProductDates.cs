using Storage.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Storage.Models
{
    public class ValProductDates : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product)validationContext.ObjectInstance;
            var pp = new ProductProductTypeViewModel();
            pp.Product = product;
            if (pp.Product.ExpiredDate != null)
            {
                return (pp.Product.StockDate < pp.Product.ExpiredDate)
                    ? ValidationResult.Success
                    : new ValidationResult("Expire date must be after stock date!"); 
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}