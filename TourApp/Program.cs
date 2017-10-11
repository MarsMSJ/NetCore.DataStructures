using System;
using System.Collections.Generic;
using NCDSL;
using NCDSL.TreeStructures;

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
            Console.WriteLine("Printing In-Order (Non-Recursive Method, Sorted):");
            PrintSequence( new List<int>( bst.GetInOrder_NonRecursive() ) );
            Console.WriteLine("Printing Pre-Order:");
            PrintSequence( new List<int>( bst.GetPreOrder() ) );
            Console.WriteLine("Printing Pre-Order (Non-Recursive Method):");
            PrintSequence( new List<int>( bst.GetPreOrder_NonRecursive() ) );
            Console.WriteLine("Printing Post-Order:");
            PrintSequence( new List<int>( bst.GetPostOrder() ) );
            Console.WriteLine("Printing Post-Order (Non-Recursive Method):");
            PrintSequence( new List<int>( bst.GetPostOrder_NonRecursive() ) );
            Console.WriteLine($"Done...\n");
						Signature();
             
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
        
    		static void Signature()
				{
					WriteCenter("Github.com/MarsMSJ");
					PrintHorizontalRainbow();	
					Console.WriteLine(string.Empty);
					
				}
       
			 static void WriteCenter(string str)
			 {
				 Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, Console.CursorTop);					
				 Console.WriteLine( str );
			 }
			 
			 static void SetCursorCenter( int length )
			 {
				 Console.SetCursorPosition((Console.WindowWidth - length) / 2, Console.CursorTop);
			 }
			 
			 static void PrintHorizontalRainbow( )
			 {
				  string space = "          ";														
					SetCursorCenter( space.Length * 4 );
					BgColor = ConsoleColor.Red;
					Console.Write(space);
					BgColor = ConsoleColor.Yellow;
					Console.Write(space);
					BgColor = ConsoleColor.Green;		
					Console.Write(space);
					BgColor = ConsoleColor.Blue;
					Console.Write(space);					
					ResetConsole();						
			 }
        
         static ConsoleColor FontColor { set => Console.ForegroundColor = value; }
        static ConsoleColor BgColor { set => Console.BackgroundColor = value; }
        
				static readonly string fHeading= "This is the NetCore.DataStructures Library";
        static readonly string fDiv = "*******************************";
				//static readonly string fSpace = "                              ";
        static ConsoleColor DefaultForegroundConsoleColor;
        static ConsoleColor DefaultBackgroundConsoleColor;
        
#endregion //Console Fancy Section
    }
    
   
}
