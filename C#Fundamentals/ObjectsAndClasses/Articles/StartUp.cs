using System;

namespace Problem02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            Article article = new Article(input[0], input[1], input[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");

                string cmd = command[0];

                string argum = command[1];

                if(cmd == "Edit")
                {
                    article.Edit(argum);
                }
                else if ( cmd == "ChangeAuthor")
                {
                    article.ChangeAuthor(argum);

                }

                else if( cmd == "Rename")
                {
                    article.RenameTitle(argum);

                }


            }

            Console.WriteLine(article.ToString());
        }
    }

    public class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;

            Content = content;

            Author = author;
        }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;

        }
        public void RenameTitle(string newTitle)
        {
            Title = newTitle;

        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}