using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


public class Inventory
{
    [Key,Required]
    public int CarID { get; set; }

    [Required(ErrorMessage ="Make is requried.")]
    [StringLength(30, ErrorMessage ="Make can only be 30 characters or less.")]
    public string Make { get; set; }

    [Required, StringLength(30)]
    public string Color { get; set; }

    [StringLength(30, ErrorMessage = "PetName can only be 30 characters or less.")]
    public string PetName { get; set; }
}