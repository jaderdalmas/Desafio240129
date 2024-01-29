using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class BookModel
{
	[Key, Column("book_id")]
	public int Id { get; set; }

	[Required, Column("title"), StringLength(100)]
	public string Title { get; set; } = string.Empty;

	[Required, Column("first_name"), StringLength(50), Display(Name = "First name")]
	public string FirstName { get; set; } = string.Empty;

	[Required, Column("last_name"), StringLength(50), Display(Name = "Last name")]
	public string LastName { get; set; } = string.Empty;

	[Required, Column("total_copies"), Display(Name = "Total copies")]
	public int TotalCopies { get; set; } = 0;

	[Required, Column("copies_in_use"), Display(Name = "Copies in use")]
	public int CopiesInUse { get; set; } = 0;

	[Column("type"), StringLength(50)]
	public string Type { get; set; } = string.Empty;

	[Column("isbn"), StringLength(88)]
	public string ISBN { get; set; } = string.Empty;

	[Column("category"), StringLength(50)]
	public string Category { get; set; } = string.Empty;
}