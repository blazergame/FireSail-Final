using System;

using Xamarin.Forms;

namespace DandD.iOS
{
    public class FileUtility : IFileUtility
    {
        public string SaveFile(string fileName, byte[] fileStream)
        {
            string path = null;
            string imageFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ProductImages");

            //Check if the folder exist or not
            if (!System.IO.Directory.Exists(imageFolderPath))
            {
                System.IO.Directory.CreateDirectory(imageFolderPath);
            }
            string imagefilePath = System.IO.Path.Combine(imageFolderPath, fileName);

            //Try to write the file bytes to the specified location.
            try
            {
                System.IO.File.WriteAllBytes(imagefilePath, fileStream);
                path = imagefilePath;
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return path;
        }

        public void DeleteDirectory()
        {
            string imageFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ProductImages");
            if (System.IO.Directory.Exists(imageFolderPath))
            {
                System.IO.Directory.Delete(imageFolderPath, true);
            }
        }
    }
}

