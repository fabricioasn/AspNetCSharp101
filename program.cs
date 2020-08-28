using System.Collections.Generic;
using System;
using System.Collections;

namespace Collections
{
    class program
    {
        static void Main(string[]args)
        {
            var listNames = new List<string>{"<name>","Ana","Felipe"};
            foreach(var name in listNames)
            {
                Console.WriteLine($"Hello, {name.ToUpper()}!");
            }
            for(int i=0;i<listNames.Count;i++){
               Console.WriteLine($"Hello, {listNames[i].ToUpper()}!"); 
            }


        }
    }



}