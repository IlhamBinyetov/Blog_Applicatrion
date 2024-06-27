using Blog_Applicatrion.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var blog = new Blog(title, content, tags);
            Config.Context.Blogs.Add(blog);
            Config.Context.SaveChanges();
        }

        public void ListBlogs()
        {
            var blogs = Config.Context.Blogs.ToList();
            foreach (var blog in blogs)
            {
                Console.WriteLine($"ID: {blog.Id}, Title: {blog.Title}");
            }
        }

        public void ViewBlogs(int id)
        {
            var blog = Config.Context.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog != null)
            {
                Console.WriteLine(blog.Content);
            }
            else
            {
                Console.WriteLine("Blog post not found.");
            }
        }


        public void SearchBlogs(string keyword)
        {
            var blogs = Config.Context.Blogs
                                .Where(b => b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                            b.Content.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                                .ToList();

            foreach (var blog in blogs)
            {
                Console.WriteLine(blog);
            }
        }
    }
}
