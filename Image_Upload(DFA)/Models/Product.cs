using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;

namespace Image_Upload_DFA_.Models;

public partial class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public int Price { get; set; }

    [Required]
    public string ImagePath { get; set; } = null!;
}
