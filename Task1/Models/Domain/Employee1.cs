﻿using System.ComponentModel.DataAnnotations;

namespace Task1.Models.Domain
{
    public class Employee1
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
    }
}
