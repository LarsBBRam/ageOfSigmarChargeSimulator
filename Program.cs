using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ageOfSigmarChargeSimulator;

class Program
{
    static void Main(string[] args)
    {
        Random dice = new();

        int roll1 = dice.Next(1, 7);
        int roll2 = dice.Next(1, 7);
        int roll3 = dice.Next(1, 7);

        bool chargeRolling = true;
        bool chargeDistancing = true;
        bool chargeBonusing = true;

        int chargeBonus = 0;
        int diceAmount = 0;

        double chargeDistance = 0;
        double chargeDistanceLimit = 0;

        bool canCharge = true;




        Console.WriteLine("So you want to charge? What are you adding anything to the roll?");
        while (chargeBonusing)
        {
            string chargeBonusText = Console.ReadLine();
            if (int.TryParse(chargeBonusText, out int convertedChargeBonus))
            {
                chargeBonus += convertedChargeBonus;
                chargeBonusing = false;
                break;
            }
            else
                Console.WriteLine("Write a whole number please. Or 0.");

        }
        Console.WriteLine($"Ok your charge bonus is {chargeBonus}. How many dice are you rolling with? (max 3)");
        while (chargeRolling)
        {
            string diceAmountText = Console.ReadLine();
            if (int.TryParse(diceAmountText, out int convertedDiceAmount))
            {
                if (convertedDiceAmount < 4)
                {
                    if (convertedDiceAmount > 0)
                    {
                        diceAmount += convertedDiceAmount;
                        chargeRolling = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You cannot have 0 dice.");
                    }
                }
                else
                {
                    Console.WriteLine("Too many dice, try again.");

                }
            }
            else
            {
                Console.WriteLine("You can only put whole numbers, and only 1, 2 or 3.");
            }
        }

        switch (diceAmount)
        {
            case 1:
                chargeDistanceLimit = 6 + chargeBonus + 0.5;
                break;
            case 2:
                chargeDistanceLimit = 6 + 6 + chargeBonus + 0.5;
                break;
            case 3:
                chargeDistanceLimit = 6 + 6 + 6 + chargeBonus + 0.5;
                break;
        }

        Console.WriteLine(chargeDistanceLimit);
        // if (diceAmount == 1)
        // {
        //     chargeDistanceLimit = 6 + chargeBonus + 0.5;
        // }
        // else if (diceAmount == 2)
        // {
        //     chargeDistanceLimit = 6 + 6 + chargeBonus + 0.5;
        // }
        // else if (chargeDistanceLimit == 3)
        // {
        //     chargeDistanceLimit = 6 + 6 + 6 + chargeBonus + 0.5;
        // }
        Console.WriteLine($"So you're rolling with {diceAmount} dice, and a bonus of {chargeBonus}. How far away is the closest enemy? Feel free to use decimals, but only numbers, please.");
        Console.WriteLine($"You cannot charge farther than {chargeDistanceLimit} inches, by the way.");
        while (chargeDistancing)
        {
            string chargeDistanceText = Console.ReadLine();
            if (double.TryParse(chargeDistanceText, out double convertedDistance))
            {
                if (chargeDistanceLimit < convertedDistance)
                {
                    Console.WriteLine("That's too far! You cannot make the charge.");
                    canCharge = false;
                    chargeDistancing = false;
                    break;

                }
                else
                {
                    chargeDistance += convertedDistance;
                    chargeDistancing = false;
                    break;
                }
            }
            else
            {
                Console.WriteLine("That's not a number silly.");
            }
        }
        if (canCharge == true)
        {
            Console.WriteLine($"So you're trying to reach an enemy within {chargeDistance} inches, rolling {diceAmount} dice, and with a bonus of {chargeBonus}. \n Press any key to continue,");
            Console.ReadKey();

            switch (diceAmount)
            {
                case 1:
                    if (roll1 + chargeBonus + 0.5 >= chargeDistance)
                    {
                        Console.WriteLine($" You can charge for {roll1 + chargeBonus} inches and will make it in!");
                    }
                    else
                    {
                        Console.WriteLine($"You only rolled {roll1 + chargeBonus}, which is not enough. You fail your charge.");

                    }
                    break;
                case 2:
                    if (roll1 + roll2 + chargeBonus + 0.5 >= chargeDistance)
                    {
                        Console.WriteLine($" You can charge for {roll1 + roll2 + chargeBonus} inches and will make it in!");
                    }
                    else
                    {
                        Console.WriteLine($"You only rolled {roll1 + roll2 + chargeBonus}, which is not enough. You fail your charge.");

                    }
                    break;

                case 3:
                    if (roll1 + roll2 + roll3 + chargeBonus + 0.5 >= chargeDistance)
                    {
                        Console.WriteLine($" You can charge for {roll1 + roll2 + roll3 + chargeBonus} inches and will make it in!");

                    }
                    else
                    {
                        Console.WriteLine($"You only rolled {roll1 + roll2 + roll3 + chargeBonus}, which is not enough. You fail your charge.");

                    }
                    break;
            }
        }
        else
        {
            Console.WriteLine("Try again with a different unit, or another turn.");
        }






        // Console.WriteLine(" ");
        // while (chargeRolling)
        // {
        //     string diceAmount = Console.ReadLine();
        //     Console.WriteLine(diceAmount);
        //     switch (diceAmount)
        //     {
        //         case "1":
        //             Console.WriteLine("Only one dice? Enter eventual additions to the charge roll, if you have any:");
        //             // string diceBonus = Console.ReadLine();
        //             return;
        //         case "2":
        //             Console.WriteLine("Please enter any additional bonuses to charge:");
        //             // string diceBonus = Console.ReadLine();
        //             return;
        //         default:
        //             Console.WriteLine("Just 1, 2, or 3.");
        //             // string diceBonus = Console.ReadLine();
        //             break;
        //     }
        // }
    }

}
