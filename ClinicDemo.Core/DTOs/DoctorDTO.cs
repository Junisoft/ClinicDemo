using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicDemo.Core.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int SpecialtyId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
