using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DERS.Models
{
    public class Admin
    { 
     [Key]
    public int AdminId { get; set; }
    [Column(TypeName = "varchar(20)")]
    public string Kullanici { get; set; }
    [Column(TypeName = "varchar(10)")]
    public string Sifre { get; set; }
    public string Sehir { get; set; }

    }
}
