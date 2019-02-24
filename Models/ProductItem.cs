using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Models
{
    public class ProductItem
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public string name { get; set; }
        [Required(ErrorMessage = "Group name is required")]
        public string groupName { get; set; }
        public DateTime addedDate { get; set; }
        public double price { get; set; }
        public double priceWithVAT { get; set; }
        public double VATRate { get; set; }
        public List<tempShop> stores { get; set; }

        public ProductItem() {
            this.addedDate = DateTime.Now;
            this.stores = new List<tempShop>();
        }

        public ProductItem(ProductItem inpProduct) {
            this.name = inpProduct.name;
            this.groupName = inpProduct.groupName;
            this.addedDate = DateTime.Now;
            this.price = inpProduct.price;
            this.priceWithVAT = inpProduct.priceWithVAT;
            this.VATRate = inpProduct.VATRate;
            this.stores = new List<tempShop>(inpProduct.stores);
        }

        public class tempShop {
            public long Id { get; set; }
            public string name { get; set; }
        }

        public bool ValidateNewItem() {
            // We need the product to have 2/3 of the following properties
            bool returnVal = true;
            // price
            int foundElements = 0;
            if (this.price!=0) {
                foundElements++;
            }
            // price + VAT
            if (this.priceWithVAT != 0) {
                foundElements++;
            }
            // VAT %
            if (this.VATRate != 0) {
                foundElements++;
            }
            if (foundElements < 2) {
                returnVal=false;
            }
            return returnVal;
        }
        
        public void CalculateMissingParameters() {
            // Calculate missing params
            if (this.price == 0) {
                this.price = this.priceWithVAT*100/(100+this.VATRate);
            }
            if (this.priceWithVAT == 0) {
                this.priceWithVAT = this.price*(100+this.VATRate)/100;
            }
            if (this.VATRate == 0) {
                this.VATRate = 100*this.priceWithVAT/this.price - 100;
            }
        }
    }
}