using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Models;

public partial class PostContentRequest
{


    [Required]
    [StringLength(200, MinimumLength = 5)]
    public string? Title { get; set; }

    [Required]
    public string PostType { get; set; }

    [Required]
    public DateTime? DatePublished { get; set; }

    [Required]
    public string Author { get; set; }

    [Required]
    public bool? IsActive { get; set; }

    [Required]
    public string? TheContent { get; set; }

    public string? ImageSource { get; set; }

    
}
