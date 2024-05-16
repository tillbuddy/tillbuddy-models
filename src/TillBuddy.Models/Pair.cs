using System.Text.Json.Serialization;

namespace TillBuddy.Models
{
    public interface IPair<T1, T2>
    {
        public T1 Id { get; set; }
        public T2 Name { get; set; }
    }

    public interface IPair
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Pair<T1, T2> : IPair<T1, T2>
    {
        [JsonPropertyName("id")]
        public T1 Id { get; set; }

        [JsonPropertyName("name")]
        public T2 Name { get; set; }

        public Pair(T1 id, T2 name)
        {
            Id = id;
            Name = name;
        }
    }

    public class Pair(string id, string name) : Pair<string, string>(id, name), IPair
    {
    }

}
