using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GitHubJobs.Models;

namespace GitHubJobs.Controllers
{
    public class JobController : ApiController
    {
        private List<Job> AllJobs()
        {
            List<Job> result = new List<Job>();

            for (int i = 0; i < 50; i++)
            {
                result.Add(new Job()
                {
                    Id = "id" + i,
                    Type = "type" + i,
                    Url = "url" + i + i,
                    Created_at = "created_at" + i,
                    Company = "company" + i,
                    Company_url = "company_url" + i,
                    Location = "location" + i,
                    Title = "title" + i,
                    Description = "description" + i,
                    How_to_apply = "how_to_apply" + i,
                    Company_logo = "company_logo" + i
                });
            }

            return result;

        }

        public HttpResponseMessage Get()
        {
            var jobList = AllJobs();
            return Request.CreateResponse(HttpStatusCode.OK, new { test = jobList });
        }
    }
}
