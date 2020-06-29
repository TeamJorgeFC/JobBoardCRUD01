using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardCRUD.CustomClass
{
    public class Job
    {
        public int JobID { get; set; }
        public String JobTittle { get; set; }
        public String JobDescription { get; set; }
        public String JobCreatedAt { get; set; }
        public String JobExpiredAt { get; set; }

    }
}