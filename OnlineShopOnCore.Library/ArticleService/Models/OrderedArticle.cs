using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using OnlineShopOnCore.Library.Common.Interfaces;
using OnlineShopOnCore.Library.OrdersService.Models;

namespace OnlineShopOnCore.Library.ArticleService.Models
{
    public class OrderedArticle: IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "numeric(12,4)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [NotMapped]
        public decimal Total => Price * Quantity;

        [Required]
        public string PriceListName { get; set; }

        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime ValidFrom { get; set; }

        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime ValidTo { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }

        [JsonIgnore]
        public virtual Order? Order { get; set; }
    }
}
