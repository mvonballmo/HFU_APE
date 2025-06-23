using System.ComponentModel.DataAnnotations;
using SQLite;

namespace TigerOne.Shared.Model;

public class TigerViewAddress
{
    [Required]
    public string FirstName { get; set; } = "";

    [Required]
    public string LastName { get; set; } = "";

    public string ZipCode { get; set; } = "";

    [Required, DisplayFormat(DataFormatString = "{0:d}")]
    public DateTime Birthday { get; set; } = DateTime.Today;

    [Required, EmailAddress]
    public string Email { get; set; } = "";

    [Required, Phone]
    public string Phone { get; set; } = "";
}
