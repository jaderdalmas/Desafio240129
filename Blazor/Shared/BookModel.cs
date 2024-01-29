using System.ComponentModel.DataAnnotations;

namespace Blazor.Shared;

public class BookModel
{
	[Key]
	public int Id { get; set; }

	[Required, StringLength(100)]
	public string Title { get; set; } = string.Empty;

	[Required, StringLength(50), Display(Name = "First name")]
	public string FirstName { get; set; } = string.Empty;

	[Required, StringLength(50), Display(Name = "Last name")]
	public string LastName { get; set; } = string.Empty;

	[Required, Display(Name = "Total copies")]
	public int TotalCopies { get; set; } = 0;

	[Required, Display(Name = "Copies in use")]
	public int CopiesInUse { get; set; } = 0;

	[StringLength(50)]
	public string Type { get; set; } = string.Empty;

	[StringLength(88)]
	public string ISBN { get; set; } = string.Empty;

	[StringLength(50)]
	public string Category { get; set; } = string.Empty;
}