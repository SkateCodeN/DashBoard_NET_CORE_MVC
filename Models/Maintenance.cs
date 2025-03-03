using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization.Infrastructure;
namespace MyDashboardApp.Models
{
    [Table("log")]
    public class Item
    {   
        [Column("id")]
        public int Id { get; set; }
        [Column("date")]
        public string Date { get; set; }
        [Column("maintenance")]
        public string Maintenance { get; set; }
        [Column("miles")]
        public int Miles { get; set; }
    }
}
