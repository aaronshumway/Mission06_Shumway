using System.ComponentModel.DataAnnotations;

namespace Mission06_Shumway.Models;

public class Submission
{
    [Key]
    [Required]
    public int SubmissionId { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    [Range(1888, 2100)]
    public int Year { get; set; }

    [Required]
    public string Director { get; set; }

    [Required]
    public string Rating { get; set; }

    // Not required
    public bool? Edited { get; set; }

    // Not required
    public string? LentTo { get; set; }

    // Not required, max 25 characters
    [MaxLength(25)]
    public string? Notes { get; set; }
}