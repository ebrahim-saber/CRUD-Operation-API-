namespace Frist_API_Project
{
    public class Logging : ILogging
    {
        public void Log(string message, string type)
        {
            // ده معمول علشانا انادي علي excption  لحاجه ملهاش excption

            if (type == "error") 
            {
                Console.WriteLine((" Error - ")+message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}
