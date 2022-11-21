using IceCreamCart.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using IceCreamCart.Models;
using Microsoft.EntityFrameworkCore;
using IceCreamCart.Extensions;
using Microsoft.Identity.Client;

namespace IceCreamCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly IceCreamCartContext context;
        public PagesController(IceCreamCartContext context)
        {
            this.context = context;
        }
        // get admin page 

        public async Task<ActionResult> Index()
        {
            IQueryable<Page> Pages = from p in context.Pages orderby p.Sorting select p;
            List<Page> PageList= await Pages.ToListAsync();

            return View(PageList) ;
        }
        // get admin page details specific page
        public async Task<ActionResult> Details(int id)
        {
            Page page = await context.Pages.FirstOrDefaultAsync(x => x.Id == id);
            if (page == null)
            {
                return NotFound();
            }
                
            return View(page);
            
        }
        // get admin page create
        public IActionResult Create() => View();
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Page page)
        {
            if (ModelState.IsValid)
            {
                page.Slug = page.Title.ToLower().Replace(" ", "-");
                page.Sorting = 100;
                var slug = await context.Pages.FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The title already exists");
                    return View(page);
                }
                context.Add(page);
                await context.SaveChangesAsync();
                TempData["Success"]="The page has been added";
                return RedirectToAction("Index");
            }
            return View(page); 

        }

        public async Task<ActionResult> Edit(int id)
        {

            Page page = await context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Page page)
        {
            //Page toeupdated = await context.Pages.FirstOrDefaultAsync(x=>x.Id == page.Id);
            //toeupdated = page;
           // await context.SaveChangesAsync();
            if (ModelState.IsValid)
            {
                page.Dosomething();
                page.Slug=page.Id==1? "home" : page.Title.ToLower().Replace(" ", "-");
                
                page.Sorting = 100;
                var slug = await context.Pages.Where(x =>x.Id != page.Id).FirstOrDefaultAsync(x => x.Slug == page.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The Page already exists");
                    return View(page);
                }
                //context.Add(page);
                context.Update(page);
                await context.SaveChangesAsync();
                TempData["Success"] = "The page has been edited";
                return RedirectToAction("Edit",new {id=page.Id});
            }
            return View(page);

        }
        public async Task<ActionResult> Delete(int id)
        {

            Page page = await context.Pages.FindAsync(id);
            if (page == null)
            {
                TempData["Error"] = "The Page Doesn't Exist";
            }
            else
            {
                context.Pages.Remove(page);
                await context.SaveChangesAsync();
                TempData["Success"] = "The page has been Deleted";
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Reorder(int[] id)
        {
            int count = 1;
            foreach (var pageId in id)
            {
                Page page = await context.Pages.FindAsync(pageId);
                page.Sorting = count;
                context.Update(page);
                await context.SaveChangesAsync();
                count++;

            }
            return Ok();
        }

    }
}
