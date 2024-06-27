using Blog_Applicatrion.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Applicatrion.Models
{
    public  class Blog
    {
        [Key]
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();


        public Blog()
        {

        }

        public Blog(string title, string content, string tags)
        {
            Title = title;
            Content = content;
            Tags = new List<Tag>(tags.Split(',').Select(t => new Tag { Value = t }));
        }

        public override string ToString()
        {
            return $"ID: {Id}\nTitle: {Title}\nContent: {Content}\nTags: {string.Join(", ", Tags)}";
        }

    }
}
