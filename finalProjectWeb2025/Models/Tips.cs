using System.ComponentModel.DataAnnotations;

namespace finalProjectWeb2025.Models
{
    public class Tips
    {
        [Key]
        public int TipId { get; set; }                // Identity Key
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }



        public int UserId { get; set; }               // Foreign Key
        public Users User { get; set; }/**هاذ زي كانه اوبجكت عكل حال ما عليك هذول السطرين عشان يصير عندي مفتاح اجنبيي*/
    }
}
