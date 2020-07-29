using System.IO;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;



namespace dotnetcore.Services
{
    public interface IFileService
    {

        /// <summary>
        /// should create file 
        /// </summary>
        void FileCreator();

        void AddPriceToFile(int productId, float price);


    }

    public class FileService : IFileService
    {
        public int sec { get; private set; }
        public int min { get; private set; }

        
        public string file
        {
            get { return string.Format("{0}_{1}.txt", sec, min); }
            
        }
        


        /// <summary>
        /// create file every sec
        /// </summary>
        public void FileCreator(){

            sec = DateTime.Now.Second;
            min = DateTime.Now.Minute;
            var fs = File.Create(file);

        }

        public void AddPriceToFile(int productId, float price){
            File.WriteAllTextAsync(file, string.Format("{0}  {1}  {2}", productId.ToString(), price.ToString(), DateTime.Now ));

        }

    }
}