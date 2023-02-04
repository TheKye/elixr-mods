using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Linq;
using System.Diagnostics;

namespace PlantChanger
{
    public class PlantChanger
    {
        //Path of the plant folder
        const string srcDirPlant = "..\\Mods\\AutoGen\\Plant";
        const string editDirPlant = ".\\Plant";
        const string bkDirPlant = ".\\PlantFileBackups";

        static void Main(string[] args)
        {
            string doPlants = ConfigurationManager.AppSettings["DoPlants"];
            string plantMaturityValue = ConfigurationManager.AppSettings["PlantMaturity"];
            string doPlantMaturity = ConfigurationManager.AppSettings["DoPlantMaturity"];
            string doPlantDeathRate = ConfigurationManager.AppSettings["DoPlantDeathRate"];
            string plantdeathrate = ConfigurationManager.AppSettings["PlantDeathRate"];
            string autoReplace = ConfigurationManager.AppSettings["AutoReplace"];

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;

            Console.WriteLine($"Elixr Mods Presents: Plant Changer, Version: {version}.");
            Console.WriteLine("If you need help with this little app make sure you check out: https://forum.play.eco/filebase/file/194-em-plant-changer-exe/ We have all the details on there.");
            Console.WriteLine($"Your current settings are:\nChange Plant Maturity: {doPlantMaturity}. (true means yes, false means no)\nPlantMaturtiy: {plantMaturityValue}.\nChange Max Death Rate: {doPlantDeathRate}. (true means yes, false means no)\nPlant Max Death Rate Value: {plantdeathrate}.\nAuto Replace: {autoReplace} (true means yes, false means no).");
            Console.WriteLine("When you are ready to go press any key to continue..");
            Console.ReadKey();

            // if backup directory does not exist create it
            if (!Directory.Exists(bkDirPlant) && autoReplace == "true")
            {
                Directory.CreateDirectory(bkDirPlant);
            }

            if (!Directory.Exists(editDirPlant))
            {
                Directory.CreateDirectory(editDirPlant);
            }

            //Copy original files
            var files = Directory.EnumerateFiles(srcDirPlant, "*.cs");

            foreach (var file in files)
            {
                var fName = file.Substring(srcDirPlant.Length + 1);

                File.Copy(Path.Combine(srcDirPlant, fName), Path.Combine(editDirPlant, fName), true);
            }
            if (doPlants.ToLower() == "true")
            {
                var changeFiles = Directory.EnumerateFiles(editDirPlant, "*.cs");
                // change the text in copied files
                if (doPlantMaturity.ToLower() == "true")
                {
                    foreach (var file in changeFiles)
                    {
                        string fileText = "";

                        foreach (var line in File.ReadAllLines(file))
                        {

                            if (line.Contains("this.MaturityAgeDays"))
                            {
                                string newLine = "                this.MaturityAgeDays = " + plantMaturityValue + "f;";
                                Console.WriteLine($"{file} updated plant maturity rate to " + plantMaturityValue + " maturity");
                                fileText += newLine + "\n";
                            }
                            else
                            {
                                fileText += line + "\n";
                            }
                        }
                        File.WriteAllText(file, fileText);
                    }

                }
                if (doPlantDeathRate.ToLower() == "true")
                {
                    foreach (var file in changeFiles)
                    {
                        string newFileText = "";
                        foreach (var line in File.ReadAllLines(file))
                        {
                            if (line.Contains("this.MaxDeathRate"))
                            {
                                string nextLine = "                this.MaxDeathRate = " + plantdeathrate + "f;";
                                Console.WriteLine($"{file} updated plant death rate to " + plantdeathrate + " rate");
                                newFileText += nextLine + "\n";
                            }
                            else
                            {
                                newFileText += line + "\n";
                            }
                        }
                        File.WriteAllText(file, newFileText);
                    }
                }
                if (autoReplace.ToLower() == "true")
                {
                    //Save all orginial files first
                    DirectoryInfo origdir = new DirectoryInfo(@"..\\Mods\\AutoGen\\Plant");
                    FileInfo[] allfiles = origdir.GetFiles();
                    foreach (FileInfo file in allfiles)
                    {
                        if (file.Length > 0)
                        {
                            // then copy the file here
                            File.Copy(Path.Combine(srcDirPlant, file.Name), Path.Combine(bkDirPlant, file.Name), true);
                        }
                    }
                    Console.WriteLine("Orginal Files Saved.");

                    //now move all edited files to the new destination
                    DirectoryInfo dir = new DirectoryInfo(@".\\Plant\\");
                    FileInfo[] allnewfiles = dir.GetFiles();
                    int count = 0;
                    foreach (FileInfo file in allnewfiles)
                    {
                        if (file.Length > 0)
                        {
                            // then copy the file here
                            File.Copy(Path.Combine(editDirPlant, file.Name), Path.Combine(srcDirPlant, file.Name), true);
                            count++;
                        }
                    }

                    Console.WriteLine($"Auto File mover finished. You can find the original files here: {bkDirPlant}, Moved a total of: {count} Files");
                }

            }
            Console.WriteLine("Done. You may now close this application safely.");
            Console.ReadLine();
        }

    }
}


