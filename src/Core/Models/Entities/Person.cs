using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity.Metadata.Internal;

namespace MyMVC6CoreTemplate.Core.Models.Entities
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
