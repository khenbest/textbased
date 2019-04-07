using System;
using argument.Models;
namespace argument
{
    class Argument
    {
        bool active = true;
        public int Points = 0;
        public IPrompt CurrentPrompt { get; set; }
        public User CurrentUser { get; set; }

        public void Init()
        {

            Prompt one = new Prompt("The Missus enters... You hear the door slam behind her. What do you do?");
            CurrentPrompt = (Prompt)one;

            Prompt two = new Prompt("You ask her what is wrong.\nThe Missus: You'll NEVER guess what Becky said to me today..");
            Prompt three = new Prompt("You tell her \"Hey, calm down.\" You have angered The Missus..\nThe Missus: Don't you tell me to CALM DOWN! What do you do?");
            Prompt four = new Prompt("Not a good choice. You created an issue. The Missus now resents you. YOU LOSE.");
            Prompt five = new Prompt("You apologize and tell her you are here to listen. The Missus: Thanks. I felt like a chicken sandwich today so I ordered one in,\nand Becky had the NERVE to tell me I should've stuck with a salad. Can you believe that?!");
            Prompt six = new Prompt("You ask her why she is so upset. The Missus: Well, I felt like a chicken sandwich today so I ordered one in, \nand Becky had the NERVE to tell me I should've stuck with a salad. Can you believe that?!");
            Prompt seven = new Prompt("You tell her she's overreacting. Not a good choice. You created an issue. The Missus now resents you. YOU LOSE.");
            Prompt eight = new Prompt("The Missus: Thanks for listening. I felt like a chicken sandwich today so I ordered one in,\nand Becky had the NERVE to tell me I should've stuck with a salad. Can you believe that?!");
            Prompt nine = new Prompt("You say \"Something snarky, I assume.\" The Missus: Oh, like THAT you mean?\n The Missus has given you an out..");
            Prompt ten = new Prompt("The Missus: I felt like a chicken sandwich today so I ordered one in,\nand Becky had the NERVE to tell me I should've stuck with a salad. Can you believe that?!");
            Prompt eleven = new Prompt("The author would like to inform you, the plot has become too complex to continue. In honor of George R.R Martin,\n the next chapter in this story will be released in 7 years, give or take. Thanks for playing!");



            Item Out = new Item("Out", "\"No Strings Attached\"");
            //2good, 3bad -- start
            //4 -- lose 7-- ovverreacting lose
            //5,6 --continue
            one.Choices.Add(Response.listen, two);
            one.Choices.Add(Response.question, two);
            one.Choices.Add(Response.statement, three);
            one.Choices.Add(Response.silence, four);
            two.Choices.Add(Response.listen, eight);
            two.Choices.Add(Response.question, six);
            two.Choices.Add(Response.statement, nine);
            two.Choices.Add(Response.silence, ten);
            three.Choices.Add(Response.listen, five);
            three.Choices.Add(Response.question, six);
            three.Choices.Add(Response.statement, seven);
            three.Choices.Add(Response.silence, four);
            five.Choices.Add(Response.listen, eleven);
            five.Choices.Add(Response.question, eleven);
            five.Choices.Add(Response.statement, eleven);
            five.Choices.Add(Response.silence, eleven);

            six.Choices.Add(Response.listen, eleven);
            six.Choices.Add(Response.question, eleven);
            six.Choices.Add(Response.statement, eleven);
            six.Choices.Add(Response.silence, eleven);

            eight.Choices.Add(Response.listen, eleven);
            eight.Choices.Add(Response.question, eleven);
            eight.Choices.Add(Response.statement, eleven);
            eight.Choices.Add(Response.silence, eleven);

            ten.Choices.Add(Response.listen, eleven);
            ten.Choices.Add(Response.question, eleven);
            ten.Choices.Add(Response.statement, eleven);
            ten.Choices.Add(Response.silence, eleven);



            nine.Items.Add(Out);
            CurrentUser = new User();
        }
        public void Run()
        {
            Init();
            Help();
            while (active)
            {

                System.Console.WriteLine($"{CurrentPrompt.Description}");
                GetUserInput();
            }


        }
        public void Respond(Response resp)
        {
            if (resp == Response.invalid)
            {
                System.Console.WriteLine("Ah ah ah, you didn't say the magic word.");
            }
            if (CurrentPrompt.Choices.ContainsKey(resp))
            {
                CurrentPrompt = CurrentPrompt.Choices[resp];
                Check();
            }

        }

        private void Check()
        {

            if (CurrentPrompt.Description.ToLower().Contains("angered"))
            {
                Points -= 2;
                System.Console.WriteLine($"Brownie Points: {Points}");
            }
            if (CurrentPrompt.Description.ToLower().Contains("apologize"))
            {
                Points += 3;
                System.Console.WriteLine($"Brownie Points: {Points}");

            }
            if (CurrentPrompt.Description.ToLower().Contains("thanks"))
            {
                Points += 1;
                System.Console.WriteLine($"Brownie Points: {Points}");

            }
            if (CurrentPrompt.Description.ToLower().Contains("overreacting"))
            {
                Points -= 7;
                System.Console.WriteLine($"Brownie Points: {Points}");

            }
            if (CurrentPrompt.Description.ToLower().Contains("win"))
            {
                System.Console.WriteLine($"{CurrentPrompt.Description}");
                System.Console.WriteLine($"Brownie Points: {Points}");
                Quit();
            }
            if (CurrentPrompt.Description.ToLower().Contains("lose"))
            {
                Points -= 2;
                System.Console.WriteLine($"{CurrentPrompt.Description}");
                System.Console.WriteLine($"Brownie Points: {Points}");
                Quit();
            }
            if (CurrentPrompt.Description.ToLower().Contains("argument"))
            {
                Points -= 2;
                System.Console.WriteLine($"{CurrentPrompt.Description}");
                System.Console.WriteLine($"Brownie Points: {Points}");
                Quit();
            }
            if (CurrentPrompt.Description.ToLower().Contains("playing!"))
            {
                Points += 4;
                System.Console.WriteLine($"{CurrentPrompt.Description}");
                System.Console.WriteLine($"Brownie Points: {Points}");
                Quit();
            }
            if (CurrentPrompt.Description.ToLower().Contains("an out"))
            {
                System.Console.WriteLine($"Would you like to take this Out?");
            }


        }

        public void GetUserInput()
        {
            string UserInput = Console.ReadLine().ToLower();
            string[] inputs = UserInput.Split(' ');
            string command = inputs[0];
            string option = "";
            Response response = Response.invalid;
            if (inputs.Length > 1)
            {
                option = inputs[1];
                switch (option)
                {
                    case "listen":
                    case "statement":
                    case "silence":
                    case "question":
                        response = (Response)Enum.Parse(typeof(Response), option);
                        break;

                }
            }
            switch (command)
            {
                case "respond":
                    Console.Clear();
                    Respond(response);
                    break;
                case "look":
                    Console.Clear();
                    Look();
                    break;
                case "help":
                    Help();
                    break;
                case "quit":
                    Quit();
                    break;
                case "inv":
                    Inventory();
                    break;
                case "use":
                    UseItem(option);
                    break;
                case "take":
                    TakeItem(option);
                    break;
                default:
                    System.Console.WriteLine("Try again!");
                    break;
            }
        }


        public void Help()
        {
            System.Console.WriteLine($@"
Command         Options
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Respond         <silence, statement, question, listen>~
Take            <item name>                           ~  
Use             <item name>                           ~
Look            (Get description again)               ~  
Inv             (Displays contents of your inventory) ~
Quit            (Quit Game)                           ~  
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        public void Inventory()
        {

            CurrentUser.Inventory.ForEach(i =>
            {
                System.Console.WriteLine($"{i.Name}");
            });

        }

        public void Look()
        {
            System.Console.WriteLine("Now is not a good time to get distracted..\n" + CurrentPrompt.Description); ;
        }

        public void Quit()
        {
            active = false;
        }

        public void TakeItem(string itemName)
        {

            Item item = CurrentPrompt.Items.Find(i =>
           {
               return i.Name.ToLower() == itemName.ToLower();
           });
            Console.Clear();
            CurrentUser.Inventory.Add(item);
            CurrentPrompt.Items.Remove(item);
            System.Console.WriteLine($"You took the {item.Name}.");
        }

        public void UseItem(string itemName)
        {
            Item item = CurrentUser.Inventory.Find(i =>
            {
                return i.Name.ToLower() == itemName.ToLower();
            });
            if (itemName == "out" && CurrentUser.Inventory.Contains(item))
            {
                CurrentUser.Inventory.Remove(item);
                Prompt newnew = new Prompt("You use her words against her, taking your out and winning the argument. But at what cost?");
                CurrentPrompt = newnew;
                Check();
            }
            else
            {
                System.Console.WriteLine(CurrentPrompt.Description);
            }
        }

    }


}
