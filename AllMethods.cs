using TRAIN_MASTER_WITH_DB_1ST_APPROACH.Models;

namespace TRAIN_MASTER_WITH_DB_1ST_APPROACH
{
    public class AllMethods
    {
        private DbFirstApproachContext dbFirstApproachContext;
        public AllMethods()
        {
            dbFirstApproachContext = new DbFirstApproachContext();
        }
        public void AddRecord()
        {
            Top:
            try
            {
                Traindetail traindetail = new Traindetail();
                Console.Write("Enter train no. - ");
                traindetail.TrainNo = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter train name - ");
                traindetail.TrainName = Console.ReadLine();
                Console.Write("Enter from station - ");
                traindetail.FromStation = Console.ReadLine();
                Console.Write("Enter to station - ");
                traindetail.ToStation = Console.ReadLine();
                Console.Write("Enter time of start - ");
                traindetail.JourneyStartTime = TimeSpan.Parse(Console.ReadLine());
                Console.Write("Enter time of end - ");
                traindetail.JourneyEndTime = TimeSpan.Parse(Console.ReadLine());
                dbFirstApproachContext.Traindetails.Add(traindetail);
                dbFirstApproachContext.SaveChanges();
                Trainday trainday = new Trainday();
                trainday.TrainNo = traindetail.TrainNo;
                Console.WriteLine("Enter days on which this train runs(Just write true/false in front of each fields) - ");
                Console.Write("Sunday - ");
                trainday.Sunday = Convert.ToBoolean(Console.ReadLine());
                Console.Write("Monday - ");
                trainday.Monday = Convert.ToBoolean(Console.ReadLine());
                Console.Write("Tuesday - ");
                trainday.Tuesday = Convert.ToBoolean(Console.ReadLine());
                Console.Write("Wednesday - ");
                trainday.Wednesday = Convert.ToBoolean(Console.ReadLine());
                Console.Write("Thursday - ");
                trainday.Thursday = Convert.ToBoolean(Console.ReadLine());
                Console.Write("Friday - ");
                trainday.Friday = Convert.ToBoolean(Console.ReadLine());
                Console.Write("Saturday - ");
                trainday.Saturday = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine("Inserted");
                dbFirstApproachContext.Traindays.Add(trainday);
                dbFirstApproachContext.SaveChanges();
            }
            catch(FormatException)
            {
                Console.WriteLine("Please enter details with correct datatypes - ");
                goto Top;
            }
            catch(Microsoft.Data.SqlClient.SqlException)
            {
                Console.WriteLine("Either table is not present/u r entering duplicate train no.");
                goto Top;
            }
        }
        public void UpdateRecord()
        {
            Top:
            try
            {
                Console.Write("Enter train no. - ");
                int trainNo = Convert.ToInt32(Console.ReadLine());
                var trainDetailObj = dbFirstApproachContext.Traindetails.Where(x => x.TrainNo == trainNo).FirstOrDefault();
                if(trainDetailObj == null)
                {
                    Console.WriteLine("Can't find train with this train no, please try again - ");
                    return;
                }
                Console.Write("Enter train no. - ");
                trainDetailObj.TrainNo = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter train name - ");
                trainDetailObj.TrainName = Console.ReadLine();
                Console.Write("Enter from station - ");
                trainDetailObj.FromStation = Console.ReadLine();
                Console.Write("Enter to station - ");
                trainDetailObj.ToStation = Console.ReadLine();
                Console.Write("Enter time of start - ");
                trainDetailObj.JourneyStartTime = TimeSpan.Parse(Console.ReadLine());
                Console.Write("Enter time of end - ");
                trainDetailObj.JourneyEndTime = TimeSpan.Parse(Console.ReadLine());
                dbFirstApproachContext.Traindetails.Update(trainDetailObj);
                dbFirstApproachContext.SaveChanges();
                Console.WriteLine("Record Updated");
            }
            catch(FormatException)
            {
                Console.WriteLine("Please enter details with correct datatypes - ");
                goto Top;
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                Console.WriteLine("Either table is not present/u r entering duplicate train no.");
                goto Top;
            }
        }
        public void DeleteRecord()
        {
            Top:
            try
            {
                Console.Write("Enter train no. - ");
                int trainNo = Convert.ToInt32(Console.ReadLine());
                var trainDetailObj = dbFirstApproachContext.Traindetails.Where(x => x.TrainNo == trainNo).FirstOrDefault();
                if (trainDetailObj == null)
                {
                    Console.WriteLine("Can't find train with this train no, please try again - ");
                    return;
                }
                dbFirstApproachContext.Traindetails.Remove(trainDetailObj);
                dbFirstApproachContext.SaveChanges();
                Console.WriteLine("Record Deleted");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter details with correct datatypes - ");
                goto Top;
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                Console.WriteLine("Table is not present");
                return;
            }
        }
        public void ShowTrainDetailsByTrainNo()
        {
            Top:
            try
            {
                Console.Write("Enter train no. - ");
                int trainNo = Convert.ToInt32(Console.ReadLine());
                var trainDetailObj = dbFirstApproachContext.Traindetails.Where(x => x.TrainNo == trainNo).FirstOrDefault();
                if (trainDetailObj == null)
                {
                    Console.WriteLine("Can't find train with this train no, please try again - ");
                    return;
                }
                Console.WriteLine($"Train no. - {trainDetailObj.TrainNo}, Train name - {trainDetailObj.TrainName}, From station - {trainDetailObj.FromStation}, To station - {trainDetailObj.ToStation}, From - {trainDetailObj.JourneyStartTime}, To - {trainDetailObj.JourneyEndTime}");
            }
            catch(FormatException)
            {
                Console.WriteLine("Please enter details with correct datatypes - ");
                goto Top;
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                Console.WriteLine("Table is not present");
                return;
            }
        }
        public void SearchTrainsByStation()
        {
            try
            {
                Console.Write("From - ");
                string from = Console.ReadLine();
                Console.Write("To - ");
                string to = Console.ReadLine();
                List<Traindetail> traindetailsList = dbFirstApproachContext.Traindetails.Where(x => (x.FromStation == from) && (x.ToStation == to)).ToList();
                if (traindetailsList.Count == 0)
                {
                    Console.WriteLine("No trains run between these 2 stations, please try again with diff stations - ");
                    return;
                }
                foreach (Traindetail traindetail in traindetailsList)
                {
                    Console.WriteLine($"Train no. - {traindetail.TrainNo}, Train name - {traindetail.TrainName}, From station - {traindetail.FromStation}, To station - {traindetail.ToStation}, From - {traindetail.JourneyStartTime}, To - {traindetail.JourneyEndTime}\n");
                }Console.WriteLine();
            }
            catch(Microsoft.Data.SqlClient.SqlException)
            { 
                Console.WriteLine("Table is not present");
                return;
            }
        }
    }
}
