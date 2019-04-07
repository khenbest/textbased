using System.Collections.Generic;

namespace argument.Models
{
    class Prompt : IPrompt
    {
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<Response, IPrompt> Choices { get; set; }

        public Prompt(string desc)
        {
            Description = desc;
            Choices = new Dictionary<Response, IPrompt>();
            Items = new List<Item>();

        }

    }
}