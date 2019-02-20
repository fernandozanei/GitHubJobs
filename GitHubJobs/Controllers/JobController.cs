using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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

        //public HttpResponseMessage Get()
        //{
        //    var jobList = AllJobs();
        //    return Request.CreateResponse(HttpStatusCode.OK, new { jobs = jobList });
        //}

        [HttpGet]
        public HttpResponseMessage GetJob([FromUri]PagingParameterModel pagingparametermodel)
        {

            // Return List of Customer  
            var source = AllJobs();

            // Get's No of Rows Count   
            int count = source.Count;

            // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
            int CurrentPage = pagingparametermodel.pageNumber;

            // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
            int PageSize = pagingparametermodel.pageSize;

            // Display TotalCount to Records to User  
            int TotalCount = count;

            // Calculating Totalpage by Dividing (No of Records / Pagesize)  
            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            // Returns List of Customer after applying Paging   
            var items = source.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            // if CurrentPage is greater than 1 means it has previousPage  
            var previousPage = CurrentPage > 1 ? "Yes" : "No";

            // if TotalPages is greater than CurrentPage means it has nextPage  
            var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

            // Object which we are going to send in header   
            var paginationMetadata = new
            {
                totalCount = TotalCount,
                pageSize = PageSize,
                currentPage = CurrentPage,
                totalPages = TotalPages,
                previousPage,
                nextPage
            };

            // Setting Header  
            HttpContext.Current.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(paginationMetadata));
            // Returing List of Customers Collections  
            return Request.CreateResponse(HttpStatusCode.OK, new { jobs = items });

        }
    
    }
}
