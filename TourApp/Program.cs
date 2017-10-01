using System;
using System.Collections.Generic;
using NCDSL;

namespace TourApp
{
    class Program
    {
        
        //Size of our demo sequence
        const int DemoElementCount = 10;
       
        static void Main(string[] args)
        {            
           Intro();
           DemoBST();
        }
        
        //Binary Search Tree  Demo
        static void DemoBST()
        {
            Console.WriteLine("BST Demo\nGenerating Random Values...");
            var list = GetPostiveIntSequence();
            Console.Write("We will be using the following sequence:\n");
            PrintSequence( list );
            
            var bst = new BST<int>();
            foreach( int i in list )
            {
                bst.Insert( i );
            }
            
            Console.WriteLine("\nAdded Elements, here is the tree (by level):");
            FontColor = ConsoleColor.White;
            bst.PrintByLevel_Simple();
            ResetConsole();
            
            Console.WriteLine("\nPrinting In-Order (Sorted):");
            PrintSequence( new List<int>( bst.GetInOrder() ) );
            Console.WriteLine("Printing Pre-Order:");
            PrintSequence( new List<int>( bst.GetPreOrder() ) );
            Console.WriteLine("Printing In-Order:");
            PrintSequence( new List<int>( bst.GetPostOrder() ) );
            Console.WriteLine("Printing In-Level");
            PrintSequence( new List<int>( bst.GetInLevel() ) );
            Console.WriteLine($"End of BST Demo\n{fDiv}");
             
        }
/*
Region works on Visual Studio Code editors only. 
It's nice for having stuff out of the way.
*/
#region Console Fancy Section
        /*************************************************************************
            Don't mind me, I'm just here to make the console fancy. 
            
            Mars :)
        */
        
       
        
        static Program()
        {
            DefaultForegroundConsoleColor = Console.ForegroundColor;
            DefaultBackgroundConsoleColor = Console.BackgroundColor;  
        }
        
        static void ResetConsole()
        {
            Console.ForegroundColor = DefaultForegroundConsoleColor;
            Console.BackgroundColor = DefaultBackgroundConsoleColor;
        }
        
        static void Intro()
        {
            Console.WriteLine($"{fDiv}Hello C#/GitHub World\n\n");
        }
        
        //Generates a sequence with a length defined by DemoElementCount;
        static List<int> GetPostiveIntSequence( )
        {
            var intList = new List<int>();
            var rng = new Random();
            
            for( int i = 0; i < DemoElementCount; i++ )
            {
                intList.Add( rng.Next() % 10 );
            }           
            
            return intList;
        }
        
        //Printing our sequence
        static void PrintSequence<T>( List<T> list )
        {
            int len = list.Count;
            FontColor = ConsoleColor.White;
            
            for( int i = 0; i < len; i++ )
            {
                 Console.Write($"{list[i].ToString()}");
                 
                 if( i < len - 1 )
                 {
                     Console.Write($", ");
                 }
             } 
             
            Console.Write($"\n");
            ResetConsole();
                       
        }
        
    
        
        static ConsoleColor FontColor { set => Console.ForegroundColor = value; }
        static ConsoleColor BgColor { set => Console.BackgroundColor = value; }
        
        static readonly string fDiv = "\n*******************************\n";
        static ConsoleColor DefaultForegroundConsoleColor;
        static ConsoleColor DefaultBackgroundConsoleColor;
        
#endregion //Console Fancy Section
    }
    
   
}
