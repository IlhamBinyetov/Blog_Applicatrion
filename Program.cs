// See https://aka.ms/new-console-template for more information
using Blog_Applicatrion.Data;
using Blog_Applicatrion.Models;

Console.WriteLine("Hello, welcome to Blog Application");



BlogManagement blogManagement = new BlogManagement();

bool running = true;


while (running)
{
    Console.WriteLine("1. Create Blog Post");
    Console.WriteLine("2. List Blog Posts");
    Console.WriteLine("3. View Blog Post");
    Console.WriteLine("4. Search Blog Posts");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            Console.Write("Enter content: ");
            string content = Console.ReadLine();
            Console.Write("Enter tags (comma-separated): ");
            string tags = Console.ReadLine();
            blogManagement.CreateBlog(title, content, tags);
            break;

        case "2":
            blogManagement.ListBlogs();
            break;

        case "3":
            Console.Write("Enter blog post ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                blogManagement.ViewBlogs(id);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            break;

        case "4":
            Console.Write("Enter keyword: ");
            string keyword = Console.ReadLine();
            blogManagement.SearchBlogs(keyword);
            break;

        case "5":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}


public static class Config
{
    static Config()
    {
        Context = new ApplicationDbContext();  
    }


    public static ApplicationDbContext Context { get; private set; }
}



