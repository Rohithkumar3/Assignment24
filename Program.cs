using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

class Source
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Destination
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Age { get; set; }
}

class Program
{
    static void Main()
    {
        Source source = new Source { Id = 1, Name = "Source" };
        Destination destination = new Destination();

        MapProperties(source, destination);

        Console.WriteLine("Mapped Properties in Destination:");
        Console.WriteLine($"Id: {destination.Id}\nName: {destination.Name}\nAge: {destination.Age}");
        Console.ReadKey();
    }

    static void MapProperties(Source source, Destination destination)
    {
        PropertyInfo[] sourceProperties = typeof(Source).GetProperties();
        PropertyInfo[] destinationProperties = typeof(Destination).GetProperties();
        foreach (var sourceProperty in sourceProperties)
        {
            foreach (var destinationProperty in destinationProperties)
            {
                if (sourceProperty.Name == destinationProperty.Name && sourceProperty.PropertyType == destinationProperty.PropertyType)
                {
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                    break;
                }
            }
        }
    }
}
     


