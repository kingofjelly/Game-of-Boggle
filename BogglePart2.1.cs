
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//THIS VERSION OF BOGGLE, 2.1 HAS NO IF STATEMENTS AT THE BOTTOM, HAS METHODISED CURSOR SET AND RANDOM
//next iteration has single array of all die. substring pulls letter from each element. then xferred to holding array, before being
//put into position in 2d array.
//version 2.1.4 update: Takes most of code from if userChoioe ==1 and adds it into a method.
//version 2.1.5 update: improves code further and removes 1x set cursor method
namespace Assignment
{
    class Boggle
    {
        const int MaxWordCount = 80000;
        static string[] wordList = new string[MaxWordCount];
        static int wordListCount = 0;
        static Random numGen1 = new Random();//this num gen is used for the array, 1, 7
        static Random numGen2 = new Random();//this num gen is used for the grid posit, 1, 17
        static string dieFace; //string which holds the letter from the die array.
        //the array below used to be 16 arrays. now it's 1.
        static string[] dies = new string[16] { "LRYTTE", "VTHRWE", "EGHWNE", "SEOTIS", "ANAEEG", "IDSYTT", "OATTOW", "MTOICU",
                                            "AFPKFS", "XLDERI", "HCPOAS", "ENSIEU", "YLDEVR","ZNRNHL","NMIQHU","OBBAOJ"};
        static string[] dieSides = new string[16];//holding array for all letters once taken from die.theyre then moved to boggleBoard[]
        static string[] boggleBoard = new string[16];//this array is cut out. the number is out 
        //finally create 2 x arrays to hold integers which will be the co-ordinates for the setCursor method. a nested
        //loop will pass through the boggleBoard array, setting cursor positions
        static int[] leftValue = new int[16] { 35, 38, 41, 44, 35, 38, 41, 44, 35, 38, 41, 44, 35, 38, 41, 44 };
        static int[] topValue = new int[16] { 13, 13, 13, 13, 15, 15, 15, 15, 17, 17, 17, 17, 19, 19, 19, 19 };
        static int leftP = 0;//left value array reference
        static int topP = 0;//top value array reference
        static int dieArrayLetter; //this is the updated number used, to load it to the correct position in the array
        static int dieBoardPosition;

        static void printBoggle()
        {
            Array.Clear(boggleBoard, 0, boggleBoard.Length);//clears any existing letters.
            //the Array.Clear at the bottom of the while loop would remove any letters, making a good app have issues.

            for (int i = 0; i < dies.Length; i++)
            {
                dieArrayLetter = gen1stNo(7);//calls numGen1. All the work is done inside the method. dieArrayLetter = return value
                dieFace = dies[i].Substring(dieArrayLetter, 1);//this code gets the letter from the array element dies[i]
                dieSides[i] = dieFace;
                //Console.WriteLine(dieSides[i]);

                dieBoardPosition = gen1stNo(17);
                while (boggleBoard[dieBoardPosition] != null)
                {
                    dieBoardPosition = gen1stNo(17);
                }
                boggleBoard[dieBoardPosition] = dieSides[i];

            }
            //this loop recurse 16 times. the value of boggleBoard.Length, which is 16, which is also
            //the number of numbers which need to be positioned. this loop increments 3x arrays simultaneously.
            for (int i = 0; i < boggleBoard.Length; i++)//this does the same amount of work as 81 lines in my previous version
            {
                leftP = leftValue[i];
                topP = topValue[i];
                setCursor(leftP, topP);
                Console.Write(boggleBoard[i]);
            }
            

        }//this method is all the code which was if userChoice ==1
        static void setCursor(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }//method to set the cursor position.
        static int gen1stNo(int maxValue)//running number gen for 1,7 for the letter from the die, then 1,17 for position on grid.
        {
            int roll;//contains the initial roll of the number gen
            int dieRollUpdate;//contains the updated value
            roll = numGen1.Next(1,(maxValue));//uses the global Random generator of numGen1, to gen a no. between 1 & 7, then 1,17
            dieRollUpdate = roll - 1;
            return dieRollUpdate;//returns this value. this is the value that is evaluated, then re-rolled if needed.
        }
       
        static void LoadWordList()
        {
            StreamReader wordFile;
            string wordLine;

            try
            {
                wordFile = new StreamReader("words_ospd.txt");
                if (wordFile != null)
                {
                    wordLine = wordFile.ReadLine();
                    while (wordLine != null && wordListCount < MaxWordCount)
                    {
                        wordList[wordListCount] = wordLine;
                        wordListCount++;
                        wordLine = wordFile.ReadLine();
                    }
                    wordFile.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The following error occured while attempting to read the file: " + e.Message);
                Console.WriteLine("No words have been read from the file");
                wordListCount = 0;
            }
        }//method which loads words from a .txt file into an array of 80k

        static void boggleGrid()
        {
            //method used to write the grid in # characters. start cursor at left 32, so middle of GG in boggle.
            //The boggle grid is made out of # characters. This is called when the user generates a grid.
            Console.CursorLeft = 32;
            Console.CursorTop = 12;
            Console.Write("################");
            Console.CursorLeft = 32;
            Console.CursorTop = 13;
            Console.Write("#              #");//letter spaces: 33,35,37,39
            Console.CursorLeft = 32;
            Console.CursorTop = 14;
            Console.Write("################");
            Console.CursorLeft = 32;
            Console.CursorTop = 15;
            Console.Write("#              #");//letter spaces: 33,35,37,39
            Console.CursorLeft = 32;
            Console.CursorTop = 16;
            Console.Write("################");
            Console.CursorLeft = 32;
            Console.CursorTop = 17;
            Console.Write("#              #");//letter spaces: 33,35,37,39
            Console.CursorLeft = 32;
            Console.CursorTop = 18;
            Console.Write("################");
            Console.CursorLeft = 32;
            Console.CursorTop = 19;
            Console.Write("#              #");//letter spaces: 33,35,37,39
            Console.CursorLeft = 32;
            Console.CursorTop = 20;
            Console.Write("################");
            Console.WriteLine("");


        } //method to draw the grid
        static void writeBoggle()
        {

            //####  ####  ####  ####  #     #### 1
            //#  #  #  #  #  #  #  #  #     #    2
            //###   #  #  #     #     #     ###  3
            //#  #  #  #  # ##  # ##  #     #    4
            //####  ####  ####  ####  ####  #### 5
            //this needs to be re-done. instead of doing bit by bit, i should have done it by line. reduce the code by about 40 lines.
            Console.CursorLeft = 20;
            Console.CursorTop = 2;
            Console.Write("####  ####  ####  ####  #     ####");//b1
            Console.CursorLeft = 20;
            Console.CursorTop = 3;
            Console.Write("#  #  #  #  #  #  #  #  #     #");//b2
            Console.CursorLeft = 20;
            Console.CursorTop = 4;
            Console.Write("###   #  #  #     #     #     ###");//b3
            Console.CursorLeft = 20;
            Console.CursorTop = 5;
            Console.Write("#  #  #  #  # ##  # ##  #     #");//b4
            Console.CursorLeft = 20;
            Console.CursorTop = 6;
            Console.Write("####  ####  ####  ####  ####  ####");//b5

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Press 1 to start a new game. Press 2 to add a word \n");
            Console.Write("Press 3 to view words and Press 4 to exit \n");

        }//method to display the title of boggle
     
        static void Main(string[] args)
        {
           
            LoadWordList();//initialize LoadWordList method.
           

            string wordInput;//word goes in here
            List<string> words = new List<string>();//this array will hold the contents of the user input. It will grow too.
            

            string userInput;//collects user input for choice of what to do
            int userChoice;//an integer used to TryParse and check for errors
            bool playBoggle;//variable used to confirm whether the user input is correct.
            //section below is used for RNG'ing the spacing in the boggleBoard array and each letter from the arrays.
            //this will later be translated into a method, to cut code down.           
          
            //write the title of BOGGLE
            writeBoggle();            
            //read the user input. Options are presented in the boggle title.
            userInput = Console.ReadLine();
            //userChoice = int.Parse(userInput);
            playBoggle = false;//variable used to confirm whether the user input is correct.
            //TryParse to check user input is within valid range.
            if (int.TryParse(userInput, out userChoice))
            {
                if (userChoice >= 1 && userChoice <= 4)
                {
                    playBoggle = true; //sets playBoggle to true, if user input is 1,2,3 OR 4.
                }
            }
            if (playBoggle)
            {

                while (userChoice != 4 && (playBoggle))//if userChoice != 4 && playBoggle = true
                {

                    if (userChoice == 1)
                    {
                       
                        words.Clear();//clears the words list, removing previously entered words.
                        Console.Clear();//clears the console. This removes any rubbish
                        writeBoggle(); 
                        Console.WriteLine("User Choice = " + userChoice);//carry out code 4
                        boggleGrid();                        
                        printBoggle();

                        Console.CursorLeft = 32;
                        Console.CursorTop = 30;


                    }//end of if userChoice == 1
                    else if (userChoice == 2)
                    {

                        Console.WriteLine("User Choice = " + userChoice);
                        Console.WriteLine("Please enter a word to add, which you've found in the grid");
                        wordInput = Console.ReadLine();//reads user input to string

                        for (int i = 0; i < wordList.Length; i++)//Count through array of 80k loaded from text file
                        {
                            if (wordList[i] == wordInput)//if element in array = that of wordInput (user entry)
                            {
                                Console.WriteLine("Word found and added to list");
                                words.Add(wordInput);//add (wordInput) to words. words is a list.
                            }


                        }

                        // words.Add(wordInput);//moves user input from string to list. which then moves to array.
                        // commented out because
                    }
                    else if (userChoice == 3)
                    {
                        Console.WriteLine("User Choice = " + userChoice);
                        words.ForEach(Console.WriteLine);//writes each value in the list

                    }
                    //Array.Clear(boggleBoard, 0, boggleBoard.Length); //clears the boggleboard array, preparing for next gen
                    //Console.CursorLeft = 32;
                    //Console.CursorTop = 30;
                    Console.WriteLine("To re-do the grid press 1.");
                    Console.WriteLine("To add a word press 2. To display words press 3. To exit press 4.");
                    playBoggle = false;
                    userInput = Console.ReadLine();//asks one final time. if answer != 4, repeat
                    if (int.TryParse(userInput, out userChoice))//call it again, for another parse. This could be methodised.
                    {
                        if (userChoice >= 1 && userChoice <= 4)
                        {
                            playBoggle = true; //sets playBoggle to true, if user input is 1,2,3 OR 4.
                        }
                        else
                        {
                            Console.WriteLine("User selection is invalid");
                        }
                    }
                   

                  
                }
            }
            else
            {
                Console.WriteLine("User selection is invalid");
            }
            Console.CursorLeft = 10;
            Console.CursorTop = 35;
            Console.WriteLine("Fin...");

            
        }
    }
}

