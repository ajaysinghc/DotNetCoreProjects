namespace FoodApp
{
    public interface IGreetMessage
    {
        string getMessage();
    }

    public class GreetMessage : IGreetMessage
    {
        public string getMessage()
        {
            return "hello from Service";
        }
    }
}