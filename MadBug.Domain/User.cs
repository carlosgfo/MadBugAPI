using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadBug.Domain
{
    public class User
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DisplayName { get; set; }
        public DateTime? Birthdate { get; set; }

    }
}
