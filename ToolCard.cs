using System;

namespace Breakthrough
{
    class ToolCard : Card
    {
        protected string ToolType;
        protected string Kit;
        private bool multiToolCard; // task 7

        public ToolCard(string t, string k, bool multiToolCard = false) : base() // task 7
        {
            ToolType = t;
            Kit = k;
            this.multiToolCard = multiToolCard; // task 7
            SetScore();
        }

        public ToolCard(string t, string k, int cardNo, bool multiToolCard = false)
        {
            ToolType = t;
            Kit = k;
            CardNumber = cardNo;
            this.multiToolCard = multiToolCard; // task 7
            SetScore();
        }

        private void SetScore()
        {
            switch (ToolType)
            {
                case "K":
                    {
                        Score = 3;
                        break;
                    }
                case "F":
                    {
                        Score = 2;
                        break;
                    }
                case "P":
                    {
                        Score = 1;
                        break;
                    }
            }
        }

        public override string GetDescription()
        {
            return ToolType + " " + Kit;
        }

        // task 7
        public override bool updateMultiToolKit()
        {
            if (!multiToolCard) return false;
            Console.WriteLine("Please enter the card kit you would like to use:> ");
            Kit = Console.ReadLine();
            return true;
        }
    }
}