using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace DevopsAnalyser
{
    internal class MergeRequestDataConverter
    {
        //example url :https://gitlab.com/api/v4/projects/3472737/merge_requests/1573/commits
        // the above example uses Merge Request 1573 from the inkscape project (3472737) 
        // The Merge Request is human readable at : https://gitlab.com/inkscape/inkscape/-/merge_requests/1573
        public static void DeserializeFromURL(string path, bool FromURL)
        {
            List<MRCommit> commits;
            if (FromURL)
            {
                string JSONResult = string.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    JSONResult = reader.ReadToEnd();
                    commits =  JsonConvert.DeserializeObject<List<MRCommit>>(JSONResult);
                }
            }
            else //from file
            {
                string JSONFile = File.ReadAllText(path);
                commits = JsonConvert.DeserializeObject<List<MRCommit>>(JSONFile);
            }
            Console.WriteLine($"Amount of commits for this MR : {commits.Count}");
            Console.WriteLine($"First commit date : {commits[0].authored_date}");
            Console.WriteLine($"Last commit date : {commits[commits.Count - 1].authored_date}");
            Console.WriteLine("authored_date deltas:");
            for (int i = 0; i < commits.Count - 1; i++)
            {
                Console.WriteLine($"commit {i} - {i + 1}: time: {commits[i].authored_date - commits[i + 1].authored_date}");
            }
        }
    }
}