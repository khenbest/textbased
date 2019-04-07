using argument.Models;

namespace argument
{
    interface IArgument
    {

        IPrompt CurrentPrompt { get; set; }
        User CurrentUser { get; set; }

        void GetUserInput(string input);



        void Help();


        void Inventory();


        void Look();


        void Quit();


        void Reset();


        void Setup();


        void StartGame();


        void TakeItem(string itemName);


        void UseItem(string itemName);

    }

}
