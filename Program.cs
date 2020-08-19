using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace SQLpractice
{
    class Program
    {
        static void Main(string[] args)
        {


            sakilaContext context = new sakilaContext();

            Film m1917 = new Film("1917", "War Drama by Director Sam Mendes", "2019", 3, 5.99m, 179, 19.99m, "R");
            Film joker = new Film("Joker", "Oscar-Nominated SuperHero Drama", "2019", 3, 6.99m, 182, 23.99m, "R");
            Film rise = new Film("Star Wars:  The Rise of Skywalker", "Trash Disney Fan-fic", "2019", 3, 4.99m, 202, 21.99m, "PG-13");

           // context.Film.Add(m1917);
           // context.Film.Add(joker);
           // context.Film.Add(rise);
           // context.SaveChanges();

            Film[] films = context.Film.ToArray();
            List<Film> linqlist = (from f in films
                                   where f.release_year == ("2019")
                                   select f).ToList();

            StringBuilder builder = new StringBuilder();
            string openingHtml = "<html>\n" + 
                "<head><title>Sakila New Films</title></head>\n" + 
                "<body> \n " +
                "<h1> New Films Coming Soon! </h1> \n " +
                "<ul>";

            builder.Append(openingHtml);

            foreach (Film f in linqlist)
            {
                builder.Append("<li> " + f.title + " " + f.description);
            }

            string closingHtml = "</ul> \n" +
                "</body>\n" + 
                "</html>";
            builder.Append(closingHtml);

            string fileName = @"C:\Users\sk8er\Documents\Source\Lab11_5\newfilms.html";
            File.WriteAllText(fileName, builder.ToString());


            /* Actor[] actors = context.Actor.ToArray();

            //Linq Example

            List<Actor> linqlist = (from a in actors
                                    where a.last_name.StartsWith("B")
                                    select a).ToList();
            foreach(Actor a in linqlist)
            {
                Console.WriteLine(a.actor_id + " " + a.first_name + " " + a.last_name);
            }

            //MyData Class Linq Example
            //Create some data
            MyData data1 = new MyData("Bill", 21, "blue", false, "basketball");
            MyData data2 = new MyData("Mary", 22, "blue", true, "baseball");
            MyData data3 = new MyData("John", 23, "green", true, "baseball");
            MyData data4 = new MyData("Marcus", 45, "red", false, "football");
            MyData data5 = new MyData("Kelly", 12, "green", true, "tennois");

            //Add the data to a list
            List<MyData> mylist = new List<MyData>;
            mylist.Add(data1);
            mylist.Add(data2);
            mylist.Add(data3);
            mylist.Add(data4);
            mylist.Add(data5);

            var baseballfans = mylist.Where(b => b.favoriteSport == "baseball");
            foreach(var item in baseballfans)
            {
                Console.WriteLine(item.name + "is a baseball fan.");
            }

            var whoisunder21 = mylist.Where(x => x.age < 21);
            foreach(var item in whoisunder21)
                {
                Console.WriteLine(item.name + " is under 21.");
            }
            
            foreach(Actor a in actors)
            {
                Console.WriteLine(a.first_name + " " + a.last_name);
            }

            //Create an Actor
            
            Console.WriteLine("Creating an Actor.  Enter the FirstName:  ");
            string first_name = Console.ReadLine();

            Console.WriteLine("Creating an Actor.  Enter the LastName:  ");
            string last_name = Console.ReadLine();

            Actor newActorRecord = new Actor(first_name, last_name);
            context.Actor.Add(newActorRecord);
            context.SaveChanges();

    
            //Getting Records from SQL
            Actor myActor = context.Actor.Find(32);
            Console.WriteLine("The Actor is " + myActor.first_name + " " + myActor.last_name);

            myActor.first_name = "TIM";
            myActor.last_update = DateTime.Now;
            context.Actor.Update(myActor);
            context.SaveChanges();
            

            StringBuilder builder = new StringBuilder();
            string openingHtml = "<body> \n " +
                "<h1> List of Actors </h1> \n " +
                "<ul>";

            builder.Append(openingHtml);

            foreach(Actor a in actors)
            {
                builder.Append("<li> " + a.first_name + " " + a.last_name);
            }

            string closingHtml = "</ul> \n" +
                "</body>";
            builder.Append(closingHtml);

            string fileName = @"";
            File.WriteAllText(fileName, builder.ToString());
            */
        }
    }
}
