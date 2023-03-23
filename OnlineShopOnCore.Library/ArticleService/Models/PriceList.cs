using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopOnCore.Library.Common.Interfaces;
using OnlineShopOnCore.Library.Constants;

namespace OnlineShopOnCore.Library.ArticleService.Models
{
    public class PriceList: IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [ForeignKey("Article")]
        public Guid ArticleId { get; set; }

        [Column(TypeName = "numeric(12,4)")]
        public decimal Price { get; set; }

        [Required] public string Name { get; set; } = PriceListNames.DEFAULT;

        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime ValidFrom { get; set; }

        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime ValidTo { get; set; }

    }
}
