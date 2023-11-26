﻿using HR.Application.Features.Departments.ViewModels;
using HR.Application.Features.Jobs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Features.People.ViewModels;
public class PersonDetailVM
{
    public Guid Id { get; set; }
    public string IdentityNumber { get; set; }
    public string Name { get; set; }
    public string? SecondName { get; set; }
    public string Surname { get; set; }
    public string? SecondSurname { get; set; }
    public string Mail { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Photo { get; set; }
    public DateTime BirthDate { get; set; }
    public string PlaceofBirth { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime? FireDate { get; set; }
    public Guid JobId { get; set; }
    public Guid DepartmentId { get; set; }
    public DepartmentVM Department { get; set; }
    public JobVM Job { get; set; }
    public string CompanyName { get; set; }
}
