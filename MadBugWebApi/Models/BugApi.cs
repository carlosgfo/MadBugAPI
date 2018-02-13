using MadBug.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MadBugWebApi.Models
{
    /// <summary>
    /// this class is a model for Bug for API
    /// </summary>
    public class BugApi
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Body { get; set; }
        [Required]
        public bool IsFixed { get; set; }
        public string StepsToReproduce { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        //Created by tack
        public string CreatedById { get; set; }
        public UserApi CreatedBy { get; set; }

        //Modified by tack
        public string ModifiedById { get; set; }
        public UserApi ModifiedBy { get; set; }

        //Severity
        public Severity Severity { get; set; }
        public byte[] RowVersion { get; set; }
    }

    public class CreateBugApi
    {
        [Required]
        [MaxLength(120)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Body { get; set; }
        [Required]
        public bool IsFixed { get; set; }
        public string StepsToReproduce { get; set; }
        [Required]
        public Severity Severity { get; set; }
    }

    public class UserApi
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DisplayName { get; set; }
        public DateTime? Birthdate { get; set; }
    }

}