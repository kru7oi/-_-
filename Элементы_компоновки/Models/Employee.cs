using System;
using System.Collections.Generic;

namespace Элементы_компоновки.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public int PositionId { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int DepartmentId { get; set; }

    public DateOnly DateOfEmployment { get; set; }

    public bool IsVacation { get; set; }

    public string Gender { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;
}
