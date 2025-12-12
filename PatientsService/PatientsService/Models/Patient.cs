using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PatientsService.Models;

[Table("patients")]
public partial class Patient
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("birthDate")]
    public DateOnly BirthDate { get; set; }

    [Column("phone")]
    [StringLength(20)]
    public string Phone { get; set; } = null!;
}
