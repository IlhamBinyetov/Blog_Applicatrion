using Blog_Applicatrion.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Applicatrion.Models
{
    public  class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }

        private readonly ApplicationDbContext _dbContext;
        public Blog(int id, string title, string content, string tags, ApplicationDbContext dbContext)
        {
            Id = id;
            Title = title;
            Content = content;
            Tags = new List<string>(tags.Split(','));
            _dbContext = dbContext;
        }

        
    }
}
