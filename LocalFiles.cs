using System;
using System.IO;
using System.Linq;

namespace xkcd_comics
{
    static class LocalFiles
    {
        public readonly static string tempDir = Directory.GetCurrentDirectory() + "\\temp\\";
        public readonly static string favDir  = Directory.GetCurrentDirectory() + "\\fav\\";

        /*
         * Copies image with ID id  to fav directory
         */
        public static bool Favorite(int id)
        {
            //If directory doesn't exist, create it
            if(!Directory.Exists(favDir)) {
                Directory.CreateDirectory(favDir);
            }

            if (Directory.Exists(tempDir))
            {
                string[] files = Directory.GetFiles(tempDir);

                string sourceFile = tempDir + id;
                string destFile = favDir + id;

                if (files.Contains(sourceFile))
                {
                    File.Copy(sourceFile, destFile, true);
                    return true;
                }
            }
            return false;
        }

        /*
         * Deletes the file from the fav folder, and returns a 
         * bool signifying wether somethign was deleted or not
         */
        public static bool Unfavorite(int id)
        {
            string workingFile = favDir + id;

            if (!Directory.Exists(favDir) || !File.Exists(workingFile))
            {
                return false;
            }
            File.Delete(workingFile);
            return true;
        }

        /*
         * Returns an array with all the ids of the favorites
         */
        public static int[] GetFavorites()
        {
            if(!Directory.Exists(favDir))
            {
                return new int[0];
            }
            string[] favs = Directory.GetFiles(favDir);

            //LINQ magic that finds the (always numeric) filename of favorites 
            //and returns them as an int array.
            char separator = Path.DirectorySeparatorChar;
            return favs.Select(x => Int32.Parse(x.Split(separator).Last())).ToArray();
        }

        /*
         * Returns an array with all the ids of the downloaded non-favorties
         */
        public static int[] GetNonFavorites()
        {
            string[] temps = Directory.GetFiles(tempDir);

            if (temps.Length > 0)
            {
                //LINQ magic that finds the (always numeric) filename of favorites 
                //and returns them as an int array.
                char separator = Path.DirectorySeparatorChar;
                return temps.Select(x => Int32.Parse(x.Split(separator).Last())).ToArray();
            }
            return new int[0];
        }
    }
}
