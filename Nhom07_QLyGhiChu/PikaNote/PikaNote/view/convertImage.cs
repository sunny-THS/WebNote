using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PikaNote.view
{
    public class convertImage
    {
        public static String ConvertIMG(String pathFile)
        {
            try
            {
                FileInfo file = new FileInfo(pathFile);
                byte[] imageArray = System.IO.File.ReadAllBytes(file.ToString());
                String base64ImageRepresentation = Convert.ToBase64String(imageArray);
                return "data:image/png;base64," + base64ImageRepresentation;
            }
            catch (Exception e)
            {
                return "";
            }
            
        }
    }
    
}