using Blog_Applicatrion.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Applicatrion.Models
{
    public  class BlogManagement
    {
        

        public BlogManagement()
        {
            Config.Context.Database.EnsureCreated();
        }

     

        public void CreateBlog(string title, string content, string tags)
        {
            var blog = new Blog
            {
                Title = title,
                Content = content,
                Tags = tags.Split(',').Select(tag => new Tag { Value = tag.Trim() }).ToList()
            };
            Config.Context.Blogs.Add(blog);
            Config.Context.SaveChanges();
        }

        public void ListBlogs()
        {
            var blogs = Config.Context.Blogs.ToList();
            foreach (var blog in blogs)
            {
                Console.WriteLine($"Id: {blog.Id}, Title: {blog.Title}");
            }
        }

        public void ViewBlogs(int id)
        {
            var blog = Config.Context.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog != null)
            {
                Console.WriteLine(blog.Content, blog.Tags.Select(x=>x.Value));
            }
            else
            {
                Console.WriteLine("Blog post not found.");
            }
        }


        public void SearchBlogs(string keyword)
        {
            var blogs = Config.Context.Blogs.Include(b=>b.Tags)
                                .Where(b => EF.Functions.Like(b.Title, $"%{keyword}%") ||
                                    EF.Functions.Like(b.Content, $"%{keyword}%"))
                        .ToList();

            foreach (var blog in blogs)
            {
                Console.WriteLine($"Blog Id: {blog.Id}, Title: {blog.Title}, Content: {blog.Content}");

                foreach (var tag in blog.Tags)
                {
                    Console.WriteLine($"    Tag Id: {tag.Id}, Value: {tag.Value}");
                }
            }
        }
    }
}
