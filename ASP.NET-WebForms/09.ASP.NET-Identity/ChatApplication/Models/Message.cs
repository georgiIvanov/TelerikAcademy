namespace WebFormsTemplate.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }


        public ApplicationUser Author { get; set; }


    }
}