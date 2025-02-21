using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Dtos
{
    public class ResourceDto
    {
        public Guid Id { get; set; }
        public string ResourceType { get; set; }  // E.g., Room, MRI Machine, etc.
        public string Identifier { get; set; }    // E.g., Room 101, MRI-02.
        public string Status { get; set; }          // E.g., Available, In Use, Maintenance.
    }
}
