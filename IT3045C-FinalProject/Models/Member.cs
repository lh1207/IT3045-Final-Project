using System;

namespace IT3045C_FinalProject.Models
{

    public class Member
    {
        public int? ID { get; set; }

        public string FullName { get; set; }

        public string Program { get; set; }

        public string Year { get; set; }

        public DateTime DOB { get; set; }
    }

}