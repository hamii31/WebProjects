using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    [Comment("User books")]
    public class IdentityUserBook
    {
        public string CollectorId { get; set; } = null!;
        [ForeignKey(nameof(CollectorId))]
        public IdentityUser Collector { get; set; } = null!;
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
    }
}
//• CollectorId – a string, Primary Key, foreign key (required)
//• Collector – IdentityUser
//• BookId – an integer, Primary Key, foreign key (required)
//• Book – Book

//Primary key == Required ==> by default required, no need to type it
