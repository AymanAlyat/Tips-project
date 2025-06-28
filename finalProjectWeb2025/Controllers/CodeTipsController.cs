using finalProjectWeb2025.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace finalProjectWeb2025.Controllers
{
    public class CodeTipsController : Controller
    {

        
        /// ///////////////////////////////////////////////////////////////////////
   


           //كلاس عشان يتواصل مع الداتا بيس
        private  WebTipsContext _context;

        //Constructor               
        public CodeTipsController(WebTipsContext context)
        {
            _context = context;
        }

        //الكونستركتر اول ما اخلص تنفيذ الاوبجكت بطير عشان هيك حفظناه بمتغير وصرنا نتعامل مع المتغير

        
        /// ////////////////////////////////////////////////////////////////////////////
       





        public IActionResult ShowAllTips()
        {
            List<Tips> tips = _context.tips.Include(t => t.User).ToList();//عشان اخليه يعرض الاسم للمستخدم مش رقمه
            return View(tips);
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Users = _context.users.ToList();//عشان لما بدك تضيف نصيحه تختار رقم الطالب اختيار مش تحط رقم مش موجود عندك
            return View();
        }



        [HttpPost]
       
        public IActionResult  Create(Tips tip)
        {
            if (tip != null)
            {
                _context.tips.Add(tip);
               _context.SaveChanges();
                return RedirectToAction("ShowAllTips"); 
            }
            return View();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        public IActionResult Delete(int id) //بتسدعيها لما تكبس على الرابط اللي بوديك على هاي الاكشن ميثود
        {
            Tips tip = _context.tips.Find(id);
            if (tip != null)
            {
                _context.tips.Remove(tip);
                _context.SaveChanges();
            }
            return RedirectToAction("ShowAllTips");
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public IActionResult EditTip(int id)
        {
            ViewBag.users = _context.users.ToList();
            Tips tip = _context.tips.Find(id);
            return View(tip);
        }

        [HttpPost]
        public IActionResult EditTip(Tips tip)
        {
            _context.tips.Update(tip);
            _context.SaveChanges();
            return RedirectToAction("ShowAllTips");
        }

        ////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        public IActionResult SearchTips(string keyword)
        {
            List<Tips> tips = _context.tips.Include(t => t.User) .Where(t => t.Title.Contains(keyword) || t.Content.Contains(keyword)).ToList();

            return View("ShowAllTips", tips);
        }


        ////////////////////////////////////////////////////////////////////////////////////// 

        public IActionResult FilterByCategory(string category)
        {
            List<Tips> tips = _context.tips.Include(t => t.User).Where(t => t.Category == category).ToList();

            return View("ShowAllTips", tips);
        }


        //////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("userId", user.UserId); // تخزين اليوزر بالسيشن
                return RedirectToAction("ShowAllTips");
            }
            else
            {
                ViewBag.Error = "Invalid email or password.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
            // تنظيف كل بيانات السيشن (تسجيل الخروج)
            HttpContext.Session.Clear();

            // إعادة التوجيه لصفحة تسجيل الدخول
            return RedirectToAction("Login");
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        
        public IActionResult SuggestSimilarTips(int? id)
        {
          if(id == null)
            {
                return RedirectToAction("Login", "CodeTips");
            }
            
            var currentTip = _context.tips.FirstOrDefault(tt => tt.TipId == id.Value);
            if(currentTip==null)
            {
                return RedirectToAction("Login", "CodeTips");
            }
            
            var suggestion = _context.tips.Where(t => t.Category == currentTip.Category && t.TipId != id).Take(5).ToList();
            ViewBag.OriginalTitle = currentTip.Title;
            return View(suggestion);
        }
        [HttpGet]
        public IActionResult FindUserByDomain(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Login","CodeTips");
            }
            var currentuser = _context.users.FirstOrDefault(s => s.UserId == id.Value);
            if (currentuser == null)
            {
                return RedirectToAction("Login","CodeTips");
            }

            
  
                var domain = currentuser.Email.Split('@').Last();
            //برجع قائمه بالمستخدمين الي الجزء بعد الدومين متشابه
            var userWithDomain = _context.users.Where(st => st.Email.EndsWith("@" + domain) && st.UserId != id.Value).ToList();
            ViewBag.email = currentuser.Email;
            ViewBag.domain = domain;
            return View(userWithDomain);
            
             
        }
      public IActionResult ShowAllUsers()
        {
            List<Users> user = _context.users.ToList();
            return View(user);
        }
        [HttpGet]
        public IActionResult ConfirmDeleteUser(int ?id)//تاكيد الحذف
        {
            if (id == null)
            {
                return RedirectToAction("Login", "CodeTips");
            }
            var user = _context.users.FirstOrDefault(s => s.UserId == id.Value);
            if(user == null)
            {
                return RedirectToAction("Login", "CodeTips");

            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//بنستخدمها للحمايه من هجمات زي محاوله خداع المستخدم لتنفيذ طلب زي حذف او تعديل
        public IActionResult ConfirmDeleteUserPost(int id)//تنفيذ الحذف
        {
            var user = _context.users.FirstOrDefault(s => s.UserId == id);
            if (user != null)
            {
                _context.users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("ShowAllUsers");
        }
    }
}
