namespace HangFire.Web.Services
{
    public class MessageService : IMessageService
    {
        public async Task SendMessage()
        {
            Console.WriteLine($"{DateTime.Now} -> Hello Burak");
        }
    }
}
