namespace Golden_Pot
{
    public class program
    {
        public static async Task Main(string[] args)
        {
            await new GameManager().play();
        }
    }
}