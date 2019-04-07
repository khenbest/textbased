using System.Collections.Generic;
using argument.Models;

namespace argument
{
    interface IPrompt
    {
        string Description { get; set; }
        List<Item> Items { get; set; }
        Dictionary<Response, IPrompt> Choices { get; set; }

    }
    public enum Response
    {
        invalid,
        listen,
        statement,
        silence,
        question
    }


}