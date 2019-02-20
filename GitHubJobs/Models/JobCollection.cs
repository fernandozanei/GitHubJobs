using System;
using System.Collections.Generic;

namespace GitHubJobs.Models
{
    public class JobCollection
    {
        private List<Job> jobs;

        public List<Job> Jobs { get => jobs; set => jobs = value; }
    }
}
