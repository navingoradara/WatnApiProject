using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseProject.Models;

public partial class PostContent
{
    public int Id { get; set; }

    
    public string? Title { get; set; }

    public int? PostTypeId { get; set; }

    public DateTime? DatePublished { get; set; }

    public int? AuthorId { get; set; }

    public bool? IsActive { get; set; }

    public string? TheContent { get; set; }

    public string? ImageSource { get; set; }

    public virtual Author? Author { get; set; }

    public virtual PostType? PostType { get; set; }
}
