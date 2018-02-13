using System;
using System.ComponentModel.DataAnnotations;

namespace MadBug.Domain
{
    public class Bug
    {
        public int? Id { get; set; }
        public string  Title { get; set; }
        public string Body { get; set; }
        public bool IsFixed { get; set; }
        public string StepsToReproduce { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        //Created by tack
        public string CreatedById { get; set; }
        public User CreatedBy { get; set; }

        //Modified by tack
        public string ModifiedById { get; set; }
        public User ModifiedBy { get; set; }


        //Severity
        public Severity Severity { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
