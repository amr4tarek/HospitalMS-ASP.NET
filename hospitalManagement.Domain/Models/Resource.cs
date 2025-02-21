using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Domain.Models
{
    public class Resource : BaseEntity
    {
        public string ResourceType { get; set; } // e.g., Room, MRI Machine, Ultrasound.
        public string Identifier { get; set; }   // e.g., Room 101, MRI-02.
        public string Status { get; set; }         // e.g., Available, In Use, Maintenance.
    }
}
