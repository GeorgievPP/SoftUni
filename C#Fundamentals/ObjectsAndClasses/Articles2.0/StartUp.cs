using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            

            

            int n = int.Parse(Console.ReadLine());

            List<Article> listOfArti = new List<Article>();

            

            for (int i = 0; i < n; i++)
            {

                string[] input = Console.ReadLine().Split(", ");

                Article article = new Article(input[0], input[1], input[2]);

                listOfArti.Add(article);



            }

            string criteria = Console.ReadLine();

            if (criteria == "title")
            {
                listOfArti = listOfArti
                    .OrderBy(x => x.Title)
                    .ToList();
            }
            else if( criteria == "content")
            {
                listOfArti = listOfArti
                    .OrderBy(y => y.Content)
                    .ToList();

            
            }
            else if(criteria == "author")
            {
                listOfArti = listOfArti
                    .OrderBy(v => v.Author)
                    .ToList();

            }

            
            Console.WriteLine(string.Join(Environment.NewLine, listOfArti));
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

       

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}