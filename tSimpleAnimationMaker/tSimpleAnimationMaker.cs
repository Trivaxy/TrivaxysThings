using System;
using System.IO;

namespace tSimpleAnimationMaker
{
	class MainClass
	{
		// public static string standardPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
		//                                                 "tSimpleAnimationMaker");

		public static string standardPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
														"tSimpleAnimationMaker");
		private static string Prompt(string str)
		{
			Console.WriteLine(str);
			return Convert.ToString(Console.ReadLine());
		}

		private static int PromptInt(string str)
		{
			Console.WriteLine(str);
			return Convert.ToInt32(Console.ReadLine());
		}

		private static void PromptKey(string str)
		{
			Console.WriteLine(str);
			Console.ReadKey();
		}

		private static void DisplayIntro()
		{
			PromptKey(@"Thank you for using tSimpleAnimationMaker :)
Version 1.0.0 By Trivaxy!

(Thanks to raydeejay for revamping code)

PLEASE, DO NOT CHANGE THE FOLDER NAME OR THE FILE WILL NOT GET MADE!
You can find the file generated in " + standardPath + @"
Press any key to continue.");
		}

		private static string AskForPath(string defaultPath)
		{
			string path = defaultPath;
			while (true)
			{
				string answer = Prompt(@"Would you like a custom place to save the file in? Or save it to
" + defaultPath + @"?
(yes/no)");
				if (answer == "yes")
				{
					Console.WriteLine("\nPlease input directory: (Tip: you can drag the folder here and the directory will be put!");
					path = Convert.ToString(Console.ReadLine());
					break;
				}
				else if (answer == "no")
				{
					Console.WriteLine("You can find the file generated in " + path);
					Console.WriteLine("Make sure you have a folder name called tSimpleAnimationMaker\nin your desktop, otherwise the program will crash.");
					break;
				}
				else {
					Console.WriteLine("Bro, put an actual answer in...");
				}
			}
			path = path.Replace("/"", "");
			return path;
		}

		private static string AskForAnimationType()
		{
			string answer = "";
			while (true)
			{
				answer = Prompt("\nWhat kind of animation is this? (npc/projectile)");
				if (answer == "npc" || answer == "projectile")
				{
					break;
				}
				else {
					Console.WriteLine("Bro, put an actual answer in...");
				}
			}
			return answer;
		}

		private static void WriteNPCToFile(string filename, int frames, int ticksPerFrame)
		{
			string output = @"// Please put: Main.npcFrameCount[npc.type] = " + frames + @";   In SetDefaults!
    public override void FindFrame(int frameHeight) {
        npc.frameCounter++;
        if (npc.frameCounter >= " + ticksPerFrame + @") {
            npc.frame.Y += frameHeight;
              
            if (npc.frame.Y >= Main.npcFrameCount[npc.type] * frameHeight) {
                npc.frame.Y = 0;
            }
            
            npc.frameCounter = 0;
        }
    }";
			using (StreamWriter file = new StreamWriter(filename, false))
			{
				file.WriteLine(output);
			}
		}

		private static void WriteProjectileToFile(string filename, int frames, int ticksPerFrame)
		{
			string output = @"// Please put: Main.projFrames[projectile.type] = " + frames + @";   In SetDefaults!
    public override bool PreDraw(SpriteBatch sb, Color lightColor) {
        projectile.frameCounter++;
        if (projectile.frameCounter >= " + ticksPerFrame + @") {
            projectile.frame++;
            projectile.frameCounter = 0;

            if (projectile.frame > " + frames + @") {
                projectile.frame = 0;  
            }
        } 
        return true;
    }";
			using (StreamWriter file = new StreamWriter(filename, false))
			{
				file.WriteLine(output);
			}
		}

		public static void Main(string[] args)
		{
			DisplayIntro();

			string path = AskForPath(standardPath);
			string animationType = AskForAnimationType();

			int frames = PromptInt(@"Okay, I just need you to tell me 2 things.
How many frames does your animation have?");

			int ticksPerFrame = PromptInt(@"Okay, how fast do you want the animation to be?
(60 = 1 frame per second, 30 = 1 frame per half a second.. etc.
 The lower the number, the faster it is)");

			Console.WriteLine("Making file...");

			Directory.CreateDirectory(path);

			if (animationType == "npc")
			{
				WriteNPCToFile(Path.Combine(path, "NPCAnimation.cs"), frames, ticksPerFrame);
			}
			else if (animationType == "projectile")
			{
				WriteProjectileToFile(Path.Combine(path, "ProjectileAnimation.cs"), frames, ticksPerFrame);
			}

			PromptKey(@"File generated at: " + path + @"
Finished! Thank you for using tSimpleAnimationMaker.
Press any key to exit.");
		}
	}
}
