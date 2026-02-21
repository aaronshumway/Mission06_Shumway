using System.ComponentModel.DataAnnotations;

namespace Mission06_Shumway.Models.Generated;

[MetadataType(typeof(MovieMetadata))]
public partial class Movie
{
}

public class MovieMetadata
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Range(1888, 2100, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; }

    [Required]
    [Range(0, 1)]
    public int Edited { get; set; }

    [Required]
    [Range(0, 1)]
    public int CopiedToPlex { get; set; }

    [MaxLength(25)]
    public string? Notes { get; set; }
}