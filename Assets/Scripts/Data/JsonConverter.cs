using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace Data
{
    // referenced blog : https://wergia.tistory.com/164
    // This class is for converting JSON files to any types
    // To use it, add this class reference on other classes
    public class JsonConverter
    {
        // convert string to JSON format
        public string ObjectToJson(object obj)
        {
            return JsonUtility.ToJson(obj, true);
        }

        // convert JSON format to string
        public T JsonToObject<T>(string jsonData)
        {
            return JsonUtility.FromJson<T>(jsonData);
        }


        // save JSON files written on string
        public void CreateOrSaveJsonFile(string createPath, string fileName, string jsonData)
        {
            string file = string.Format("{0}/{1}.json", createPath, fileName);
            
            if (File.Exists(file))
            {
                File.Delete(file);
            }
            
            FileStream fileStream = new FileStream(file, FileMode.Create, FileAccess.Write);
            byte[] data = Encoding.UTF8.GetBytes(jsonData);
            fileStream.Write(data, 0, data.Length);
            fileStream.Close();
        }

        // load JSON files to generic types
        public T LoadJsonFile<T>(string loadPath, string fileName)
        {
            FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fileStream.Length];
            fileStream.Read(data, 0, data.Length);
            fileStream.Close();
            string jsonData = Encoding.UTF8.GetString(data);
            return JsonUtility.FromJson<T>(jsonData);
        }

        public void CreateOrSaveEncryptedJsonFile(string createPath, string fileName, string jsonData)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
            string code = System.Convert.ToBase64String(bytes);
            File.WriteAllText(string.Format("{0}/{1}.json", createPath, fileName), String.Empty);
            File.WriteAllText(string.Format("{0}/{1}.json", createPath, fileName), code);
        }

        public T LoadEncryptedJsonFile<T>(string loadPath, string fileName)
        {
            string code = File.ReadAllText(string.Format("{0}/{1}.json", loadPath, fileName));
            byte[] bytes = System.Convert.FromBase64String(code);
            string jsonData = System.Text.Encoding.UTF8.GetString(bytes);
            
            T result = JsonUtility.FromJson<T>(jsonData);
            return (result);
        }
    }
}

