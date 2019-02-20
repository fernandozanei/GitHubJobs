using System;
using System.Collections.Generic;

namespace GitHubJobs.Models
{
    public class JobCollection
    {
        private List<Job> jobs;

        public List<Job> Jobs { get => jobs; set => jobs = value; }

        public static implicit operator List<object>(JobCollection v)
        {
            throw new NotImplementedException();
        }
    }
}
