using System.Collections.Generic;
using System;
using System.Collections;

namespace Collections
{
    class program
    {
        static void Main(string[] args)
        {
            //creat name list
            var listNames = new List<string> { "<name>", "Ana", "Felipe", "Carlos" };
            //list loop with foreach
            foreach (var name in listNames)
            {
                Console.WriteLine($"Hello, {name.ToUpper()}!");
            }
            //normal loop with for and iterative var until total itens on list
            for (int i = 0;i<listNames.Count; i++)
            {
                Console.WriteLine($"Hello, {listNames[i].ToUpper()}!");
            }

            //list names addition and removal
            listNames.Add("Maria");
            listNames.Add("Ben");
            listNames.Remove("Felipe");

            //final list foreach loop
            foreach(var name in listNames)
            {
                Console.WriteLine($"Hello, {name.ToUpper()}!");
                Console.WriteLine(name);
            }

            //new name stringType list
            var stringList = new List<String> { "strange", "David", "Kisha" };
            stringList.Add("Jason");
            stringList.Add("Mordred");
            stringList.Add("Leon");
            stringList.Remove("David");

            //foreach loop for strignList
            foreach(var stringName in stringList)
            {
                Console.WriteLine(stringName);
            }
            //show the 1st list positioned string
            Console.WriteLine(stringList[1]);
            //shows intex of list item
            var indexOf = stringList.IndexOf("Strange");
            Console.WriteLine($"Found Strange on {indexOf}");
            if (indexOf == -1)
            {
                Console.WriteLine($"When an item is not found, indexOf returns {indexOf}");
            }
            else
            {
                Console.WriteLine($"The name{stringList[indexOf]} is at index {indexOf}");
            }
            stringList.Sort();
            foreach(var sortedNames in stringList)
            {
                Console.WriteLine($"Hello, {sortedNames.ToUpper()}!");
            }
            Console.WriteLine($"My name is {stringList[0]}");
            Console.WriteLine($"I've added {stringList[2]} and {stringList[3]} to the list");
            Console.WriteLine($"The list has {stringList.Count} people added in it.");
        }
    }



}
