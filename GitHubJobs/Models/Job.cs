using System;
namespace GitHubJobs.Models
{
    public class Job
    {
        string id;
        string type;
        string url;
        string created_at;
        string company;
        string company_url;
        string location;
        string title;
        string description;
        string how_to_apply;
        string company_logo;

        public string Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
        public string Url { get => url; set => url = value; }
        public string Created_at { get => created_at; set => created_at = value; }
        public string Company { get => company; set => company = value; }
        public string Company_url { get => company_url; set => company_url = value; }
        public string Location { get => location; set => location = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string How_to_apply { get => how_to_apply; set => how_to_apply = value; }
        public string Company_logo { get => company_logo; set => company_logo = value; }
    }
}
