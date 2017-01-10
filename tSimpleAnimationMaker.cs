using System;
using System.IO;

namespace tSimpleAnimationMaker
{
	class MainClass
	{
		public static string[] inputStrings = new string[5];

		public static string strPath = Environment.GetFolderPath(
					 Environment.SpecialFolder.DesktopDirectory);
		public static string complete = Path.Combine(strPath, "tSimpleAnimationMaker");
		
		public static void Main(string[] args)
		{
				// Delete the file if it exists.
			Console.WriteLine("Thank you for using tSimpleAnimationMaker :)");
			Console.WriteLine("Version 1.0.0 By Trivaxy!");
			Console.WriteLine("\nPLEASE, DO NOT CHANGE THE FOLDER NAME OR THE FILE WILL NOT GET MADE!");
			Console.WriteLine("You can find the file generated in " + complete);
			Console.WriteLine("Press any key to continue.");
 			Console.ReadKey();
			Console.WriteLine("Would you like a custom place to save the file in? Or save it to \n " + complete + "?");
			Console.WriteLine("(yes/no)");
			inputStrings[3] = Convert.ToString(Console.ReadLine());
			if (inputStrings[3] == "yes")
			{
				Console.WriteLine("\nPlease input directory: (Tip: you can drag the folder here and the directory will be put!");
				inputStrings[4] = Convert.ToString(Console.ReadLine());
			}
			Console.WriteLine("\nIs this an NPC animation? (yes/no)");

			inputStrings[0] = Convert.ToString(Console.ReadLine());

			if (inputStrings[0] != "yes" && inputStrings[0] != "no")
			{
				Console.WriteLine("Oh wow, you didn't type in yes or no.. Well, restart the program.");
			}
			if (inputStrings[0] == "yes")
			{
				int frameInput;
				int speedInput;
				Console.WriteLine("\nNPC Animation, huh? Okay, I just need you to tell me 2 things.");
				Console.WriteLine("How many frames does your NPC have?");
				frameInput = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Okay, how fast do you want the animation to be?");
				Console.WriteLine("(60 = 1 frame per second, 30 = 1 frame per half a second.. etc. \nThe lower the number the faster it is)");
				speedInput = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Making file...");
				if (inputStrings[3] == "no")
				{
					using (var myFile = File.Create(Path.Combine(complete, "NPCAnimation.cs")))
					{
						//WOOT WOOT NOTHING HAPPENS HERE! :D I hope you find my simple and ugly code useful though :)
					}
					using (StreamWriter file =
						   new StreamWriter(Path.Combine(complete, "NPCAnimation.cs"), true))
					{
						file.WriteLine("//Please put: Main.npcFrameCount[npc.type] = " + frameInput + ";   In SetDefaults!");
						file.WriteLine("public override void FindFrame(int frameHeight)");
						file.WriteLine("{");
						file.WriteLine(" npc.frameCounter++;");
						file.WriteLine("   if(npc.frameCounter >= " + speedInput + ")");
						file.WriteLine("   {");
						file.WriteLine("    npc.frame.Y += frameHeight;");
						file.WriteLine();
						file.WriteLine("       if(npc.frame.Y >= Main.npcFrameCount[npc.type] * frameHeight");
						file.WriteLine("        npc.frame.Y = 0;");
						file.WriteLine("        npc.frameCounter = 0;");
						file.WriteLine("   }");
						file.WriteLine("}");
					}
					Console.WriteLine("File generated at: " + complete);
					Console.WriteLine("Finished! Thank you for using tSimpleAnimationMaker.");
					Console.ReadKey();
				}
				else if (inputStrings[3] == "yes")
				{
					using (var myFile = File.Create(Path.Combine(inputStrings[4], "NPCAnimation.cs")))
					{
						//WOOT WOOT NOTHING HAPPENS HERE! :D I hope you find my simple and ugly code useful though :)
					}

					using (StreamWriter file =
						   new StreamWriter(Path.Combine(inputStrings[4], "NPCAnimation.cs"), true))
					{
						file.WriteLine("//Please put: Main.npcFrameCount[npc.type] = " + frameInput + ";   In SetDefaults!");
						file.WriteLine("public override void FindFrame(int frameHeight)");
						file.WriteLine("{");
						file.WriteLine(" npc.frameCounter++;");
						file.WriteLine("   if(npc.frameCounter >= " + speedInput + ")");
						file.WriteLine("   {");
						file.WriteLine("    npc.frame.Y += frameHeight;");
						file.WriteLine();
						file.WriteLine("       if(npc.frame.Y >= Main.npcFrameCount[npc.type] * frameHeight");
						file.WriteLine("        npc.frame.Y = 0;");
						file.WriteLine("        npc.frameCounter = 0;");
						file.WriteLine("   }");
						file.WriteLine("}");
					}
					Console.WriteLine("File generated at: " + inputStrings[4]);
					Console.WriteLine("Finished! Thank you for using tSimpleAnimationMaker.");
					Console.ReadKey();
				}
			}
			if (inputStrings[0] == "no")
			{
				Console.WriteLine("\nIs it a projectile animation? (yes/no)");
				inputStrings[1] = Convert.ToString(Console.ReadLine());
			}

			if (inputStrings[1] == "no")
			{
				Console.WriteLine("Then what is it?... Meh, restart the program!");
				Console.ReadKey();
			}
			else if (inputStrings[1] == "yes")
			{
				int inputframes;
				int inputspeed;
				Console.WriteLine("\nHow many frames does your projectile have?");
				inputframes = Convert.ToInt32(Console.ReadLine()) - 1;
				Console.WriteLine("Okay, how fast do you want the animation to be?");
				Console.WriteLine("(60 = 1 frame per second, 30 = 1 frame per half a second.. etc. \nThe lower the number the faster it is)");
				inputspeed = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Making file...");
				if (inputStrings[3] == "no")
				{
					using (var myFile = File.Create(Path.Combine(complete, "NPCAnimation.cs")))
					{
						//..end my life please.
					}
					string outputtop =
	@"public override bool PreDraw(SpriteBatch sb, Color lightColor)
	{
	  projectile.frameCounter++;";
					string outputmiddle =
@"	  {
		projectile.frame++;
		projectile.frameCounter = 0;";

					string outputbottom =
@"	  	 projectile.frame = 0;
					}

	     return true;
	}";

					using (StreamWriter file =
							   new StreamWriter(Path.Combine(complete, "NPCAnimation.cs"), true))
					{
						file.WriteLine("//Please put: Main.projFrames[projectile.type] = " + inputframes + ";   In SetDefaults!");
						file.WriteLine(outputtop);
						file.WriteLine("\tif (projectile.frameCounter >= " + inputspeed + ")");
						file.WriteLine(outputmiddle);
						file.WriteLine("\n   if (projectile.frame > " + inputframes + ")");
						file.WriteLine(outputbottom);
					}
					Console.WriteLine("File generated at: " + complete);
					Console.WriteLine("Finished! Thank you for using tSimpleAnimationMaker.");
					Console.ReadKey();
				}
				if (inputStrings[3] == "yes")
				{
					using (var myFile = File.Create(Path.Combine(inputStrings[4], "NPCAnimation.cs")))
					{
						//..end my life please.
					}
					string outputtop =
	@"public override bool PreDraw(SpriteBatch sb, Color lightColor)
	{
	  projectile.frameCounter++;";
					string outputmiddle =
@"	  {
		projectile.frame++;
		projectile.frameCounter = 0;";

					string outputbottom =
@"	  	 projectile.frame = 0;
					}

	     return true;
	}";

					using (StreamWriter file =
					       new StreamWriter(Path.Combine(inputStrings[4], "NPCAnimation.cs"), true))
					{
						file.WriteLine("//Please put: Main.projFrames[projectile.type] = " + inputframes + ";   In SetDefaults!");
						file.WriteLine(outputtop);
						file.WriteLine("\tif (projectile.frameCounter >= " + inputspeed + ")");
						file.WriteLine(outputmiddle);
						file.WriteLine("\n   if (projectile.frame > " + inputframes + ")");
						file.WriteLine(outputbottom);
					}
					Console.WriteLine("File generated at: " + inputStrings[4]);
					Console.WriteLine("Finished! Thank you for using tSimpleAnimationMaker.");
					Console.ReadKey();
				}
           }
			if (inputStrings[1] != "yes" && inputStrings[1] != "no")
			{
				Console.WriteLine("Bro, put an actual answer in...");
			}
		}
	}
}
