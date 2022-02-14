using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClinicDemo.Core.QueryFilters
{
    public class DoctorQueryFilter
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
