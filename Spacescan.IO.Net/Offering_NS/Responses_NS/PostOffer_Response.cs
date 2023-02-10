
using System.Text.Json;

namespace Spacescan.IO.Net.Offering_NS.Responses_NS
{
    public class PostOffer_Response
    {
        public string success { get; set; }
        public string? error { get;  set; }
        public dynamic offer { get; set; }
        /// <summary>
        /// Saves the Offer object to disk as a JSON file.
        /// </summary>
        /// <param name="path">The file path to save the Offer object to.</param>
        public void Save(string path)
        {
            if (!path.EndsWith(".spacescanoffer"))
            {
                path += ".spacescanoffer";
            }
            File.WriteAllText(path, JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }

        /// <summary>
        /// Loads an Offer object from disk.
        /// </summary>
        /// <param name="path">The file path to load the Offer object from.</param>
        /// <returns>The Offer object loaded from disk.</returns>
        public static PostOffer_Response Load(string path)
        {
            if (!path.EndsWith(".spacescanoffer"))
            {
                path += ".spacescanoffer";
            }
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<PostOffer_Response>(json);
        }
    }
}
