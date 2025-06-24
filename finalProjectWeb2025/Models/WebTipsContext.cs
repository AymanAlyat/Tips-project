using Microsoft.EntityFrameworkCore; /* المكتبه الموجوده بيها الداتا بيس قصدي الدي بي كونتكست*/
namespace finalProjectWeb2025.Models

{
    public class WebTipsContext : DbContext /*عشان يورث من الداتا بيس ويتصل بقاعده البيانات ويتتبع التغيرات ويرسلها للداتا بيس*/
    {
        /*معلومات الاتصال بالقاعدة*//*هاذ اسمه كونستركتور*/
        public WebTipsContext(DbContextOptions<WebTipsContext> options) : base(options)
        {                                                                  /*إرسالها للكلاس الأب (DbContext)*/
        }


        /*هذول السطرين فعليا بمثلن الجدول في الداتا بيس*/
        public DbSet<Users> users { get; set; }/*هاي خاوه لكل جدول بدي انشئه*/

        public DbSet<Tips> tips { get; set; }  /* تمثيل لهذا الجدول داخل قاعده البيانات*/
        /*tips*/ /* هاذ اسم الجدول داخل الداتا بيس*/

        //Users:اسم الكلاس اللي انا بتعامل معه هون بالبرمجه
        //users:اسمه الحقيقي داخل الداتا بيس







        /*هذا الميثود بنستخدمه علشان نخصص طريقة إنشاء الجداول والعلاقات داخل قاعدة البيانات، لما يتم إنشاؤها */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(/*هون بدي ابلش اعبي داتا جوا الكلاس عشان نوديهن عالداتا بيس ويكونن زي قيمه ابتدائيه*/


                new Users { UserId = 1, Name = "Ali Talal", Email = "ali@example.com", Password = "123" },
                new Users { UserId = 2, Name = "Dalia Ahmed", Email = "dalia@example.com", Password = "456" },
                new Users { UserId = 3, Name = "Mohammad Bader", Email = "mohammad@example.com", Password = "789" },
                new Users { UserId = 4, Name = "Sami Adel", Email = "sami@example.com", Password = "abc" },
                new Users { UserId = 5, Name = "Faris Esaam", Email = "faris@example.com", Password = "xyz" }

                );
            modelBuilder.Entity<Tips>().HasData(

               new Tips { TipId = 1, Title = "HTML Basics", Content = "Use semantic tags.", Category = "HTML", UserId = 1 },
               new Tips { TipId = 2, Title = "CSS Flexbox", Content = "Use flexbox for layouts.", Category = "CSS", UserId = 2 },
               new Tips { TipId = 3, Title = "JavaScript Events", Content = "Use addEventListener.", Category = "JavaScript", UserId = 3 },
               new Tips { TipId = 4, Title = "Responsive Design", Content = "Use media queries.", Category = "CSS", UserId = 4 },
               new Tips { TipId = 5, Title = "HTML Forms", Content = "Always use labels.", Category = "HTML", UserId = 5 }

                );
        }
    }
}
