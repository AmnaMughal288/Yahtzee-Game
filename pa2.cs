using System;
using static System.Console;

namespace Bme121
{
    class YahtzeeDice
    {
		static Random rGen = new Random();
		static int[] dice = new int[5];
        public void Roll( ) 
        { 

			for( int i=0; i<5; i++)//initialization of dice array
			{
				if( dice[i] == 0)
				{
					dice[i] = rGen.Next(1, 7);
				}

			}
	}
		public override string ToString()//displays dice initially
		{

			return($"{dice[0]}{dice[1]}{dice[2]}{dice[3]}{dice[4]}");
		}

		public void Unroll( string faces ) 
		{ 
				if( faces == "all")
				{ for(int j = 0; j<5; j++)
					{
						dice[j] = 0;
					}
				}
			else
			{			
								
				//	looping through the dice that are rolled
				for(int j = 0; j <5; j++)
				{ 
					//looping through the faces you said to reroll
					 for(int i=0; i< faces.Length; i++)
					{
						if (dice[j] == int.Parse(faces.Substring(i,1)))
						{
						  dice[j]= 0;
						  break;//forces it to break and leave loop
						}
					}
				}
			}
			Roll();
		}
				
			
		
		
		public int Sum( ) 
		{ return dice[0]+ dice[1] + dice[2] + dice[3] + dice[4]; }
		
		public int Sum( int face )
		{
		 int counter = 0; 
		for( int i =0; i < dice.Length; i++)
			
			{
				if (dice[i] == face)
				{
					counter += face;
				}
			}
			return counter; 
		}
		
		public bool IsRunOf( int length ) // tests for a run of 4 or run of 5 consecutive faces
		{ 
			Array.Sort(dice);
			int counter = 0;
		for(int i = 1; i<5; i++)
		{
			if( dice[i] == dice[i-1] + 1 )//for the + 1 we are adding to the face value not i, we are checking to see if the one before is equal to the one after to check for consecutiveness
			{
				counter ++;
				if( counter == length - 1 )
				{
					return true;
				}
			}
		}
			
			return false; 
		}
		
		public bool IsSetOf( int size )
		 { 	Array.Sort(dice);
			 int compare = dice[0];
			 int counter = 0;
			 for(int i= 0; i< 5; i++)
			 {
				 if ( dice[i] == compare)
				 {
					 compare = dice[i];
					 counter++;
				}
				else if ( dice[i] != compare && counter < size)
				{
					compare = dice[i];
					counter = 1;
				}
				 
			 
			}
			if (counter >=size)
			{
				return true;
			}
			else
			{
				return false;
			}
		 }
		
		public bool IsFullHouse( ) 
		{ Array.Sort(dice);// order array
			
			if( dice[0] == dice[1] && dice[2] == dice[1])// check if first 3 dice =
			 {
				 if( dice[3] == dice [4] && dice[1] != dice[3])// check if next 2 are equal and if they dont equal the forst 3
				  {
					  return true;
					  
					}
					
				}
				if( dice[0] == dice [1] && dice[2] != dice[1])// repeat but reverse
				{
					if( dice[2] == dice[3] && dice [3] == dice[4])
					{
					return true;
				}
			}
			return false;
					
					
					
				
		 }
    }
}
