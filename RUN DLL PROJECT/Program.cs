using TRAIN_MASTER_WITH_DB_1ST_APPROACH;
namespace RunDllProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
        Top:
            AllMethods allMethods = new AllMethods();
            Console.WriteLine("WELCOME TO TRAIN MASTER, WHICH OPERATION WOULD U LIKE TO PERFORM -\n1. Add a train\n2. Update train details\n3. Remove train\n4. Search a particular train\n5. Show all trains running between 2 stations\n6. Close Application");
            switch (Console.ReadLine())
            {
                case "1":
                    allMethods.AddRecord();
                    break;
                case "2":
                    allMethods.UpdateRecord();
                    break;
                case "3":
                    allMethods.DeleteRecord();
                    break;
                case "4":
                    allMethods.ShowTrainDetailsByTrainNo();
                    break;
                case "5":
                    allMethods.SearchTrainsByStation();
                    break;
                case "6": return;
                default:
                    Console.WriteLine("Please choose correct option - ");
                    goto Top;
            }
            goto Top;
        }
    }
}