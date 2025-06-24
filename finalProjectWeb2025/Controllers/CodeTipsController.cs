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

    }
}
