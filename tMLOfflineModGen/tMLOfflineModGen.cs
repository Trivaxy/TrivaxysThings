using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace tMLHelper
{
    //I wanted things to be neat

    public class ModInfo
    {
        public string name;
        public string displayName;
        public string author;
        public string version;

        public ModInfo(string name, string author, string version, string displayName)
        {
            this.name = name;
            this.author = author;
            this.version = version;
            this.displayName = displayName;
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            DisplayGreeting();
            CreateModSkeleton(AskForInfo(), GetPath());
        }

        public static void DisplayGreeting()
        {
            Console.WriteLine("Welcome to the offline Mod Skeleton Generator.");
            Console.WriteLine("By Trivaxy, V1.0");
            Console.WriteLine("\nThis tool will generate a mod skeleton in the path you input, along with the name.");
        }

        public static string GetPath()
        {
            Console.WriteLine("Input the path you want the mod skeleton to be generated in: (Pro tip: You can just drag the folder here.");
            return Console.ReadLine();
        }

        public static ModInfo AskForInfo()
        {
            Console.WriteLine("Input mod name (no spaces):");
            string name = Console.ReadLine();
            Console.WriteLine("Input mod author:");
            string author = Console.ReadLine();
            Console.WriteLine("Input version:");
            string version = Console.ReadLine();
            Console.WriteLine("Input display name (the name people will see):");
            string displayName = Console.ReadLine();

            return new ModInfo(name, author, version, displayName);
        }

        public static void CreateModSkeleton(ModInfo info, string path)
        {
            path = path.Replace("\"", "");
            string fullPath = Path.Combine(path, info.name);

            Directory.CreateDirectory(fullPath);

            using(StreamWriter writer = new StreamWriter(Path.Combine(fullPath, "build.txt")))
            {
                writer.WriteLine("author = " + info.author);
                writer.WriteLine("version = " + info.version);
                writer.WriteLine("displayName = " + info.displayName);
            }

            using (StreamWriter writer = new StreamWriter(Path.Combine(fullPath, "description.txt")))
            {
                writer.WriteLine(info.displayName + " is a pretty cool mod, it does...this. Modify this file with a description of your mod.");
            }

            using (StreamWriter writer = new StreamWriter(Path.Combine(fullPath, info.name + ".csproj")))
            {
                writer.WriteLine(@"
<?xml version=\""1.0"" encoding=""utf-8""?>
<Project ToolsVersion=""14.0"" DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">
  <Import Project=""$(MSBuildExtensionsPath)$(MSBuildToolsVersion)\Microsoft.Common.props"" Condition=""Exists('$(MSBuildExtensionsPath)$(MSBuildToolsVersion)\Microsoft.Common.props')"" />
  <PropertyGroup>
    <Configuration Condition="" '$(Configuration)' == '' "">Debug</Configuration>
    <Platform Condition="" '$(Platform)' == '' "">AnyCPU</Platform>
    <ProjectGuid>{8298EAB6-0586-4BDA-9483-83624B66B13A}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>" + info.name + @"</RootNamespace>
    <AssemblyName>" + info.name + @"</AssemblyName>
    <TargetFrameworkVersion>v4.5.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>
  </PropertyGroup>
  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' "">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' "">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <ItemGroup>
    <Compile Include=""**\*.cs"" />
  </ItemGroup>
  <ItemGroup>
    <Reference Include=""Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=x86"">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>C:\Windows\Microsoft.NET\assembly\GAC_32\Microsoft.Xna.Framework\v4.0_4.0.0.0__842cf8be1de50553\Microsoft.Xna.Framework.dll</HintPath>
    </Reference>
    <Reference Include=""Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=x86"">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>C:\Windows\Microsoft.NET\assembly\GAC_32\Microsoft.Xna.Framework.Game\v4.0_4.0.0.0__842cf8be1de50553\Microsoft.Xna.Framework.Game.dll</HintPath>
    </Reference>
    <Reference Include=""Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=x86"">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>C:\Windows\Microsoft.NET\assembly\GAC_32\Microsoft.Xna.Framework.Graphics\v4.0_4.0.0.0__842cf8be1de50553\Microsoft.Xna.Framework.Graphics.dll</HintPath>
    </Reference>
    <Reference Include=""Microsoft.Xna.Framework.Xact, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553, processorArchitecture=x86"">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>C:\Windows\Microsoft.NET\assembly\GAC_32\Microsoft.Xna.Framework.Xact\v4.0_4.0.0.0__842cf8be1de50553\Microsoft.Xna.Framework.Xact.dll</HintPath>
    </Reference>
    <Reference Include=""System"" />
    <Reference Include=""Terraria"">
      <HintPath>C:\Program Files (x86)\Steam\steamapps\common\terraria\Terraria.exe</HintPath>
    </Reference>
  </ItemGroup>
  <Import Project=""$(MSBuildToolsPath)\Microsoft.CSharp.targets"" />
  <PropertyGroup>
   <PostBuildEvent>""C:\Program Files (x86)\Steam\steamapps\common\terraria\Terraria.exe"" -build ""$(ProjectDir)\"" -eac ""$(TargetPath)""</PostBuildEvent>
  </PropertyGroup>
</Project>");

            }
            Finish();
        }

        public static void Finish()
        {
            Console.WriteLine("\nFinished! You can find the mod skeleton in the path you input.");
            Console.ReadKey();
        }
    }
}
