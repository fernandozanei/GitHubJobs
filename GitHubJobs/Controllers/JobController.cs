using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GitHubJobs.Models;
using Newtonsoft.Json;

namespace GitHubJobs.Controllers
{
    public class JobController : ApiController
    {
        private List<Job> AllJobs()
        {
            List<Job> result = new List<Job>();

            using (var webClient = new WebClient())
            {
                String rawJSON = webClient.DownloadString("https://jobs.github.com/positions.json?description=sql");
                result = JsonConvert.DeserializeObject<List<Job>>(rawJSON);
                Console.WriteLine(result.Count);
            }

            return result;
        }

        public HttpResponseMessage Get()
        {
            var jobList = AllJobs();
            return Request.CreateResponse(HttpStatusCode.OK, new { jobs = jobList });
        }
    }
}
