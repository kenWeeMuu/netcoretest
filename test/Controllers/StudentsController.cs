using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext db) {
            _context = db;
        }
        [HttpGet("/aaa")]
        // GET: Students
        public    IActionResult aaa() {
            return Ok(  _context.Students.ToList());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var student = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
            if (student == null) {
                return NotFound();
            }

            return Ok(student);
        }

        // GET: Students/Create
        public IActionResult Create() {
            return Ok();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("EnrollmentDate,FirstMidName,LastName")] Student student) {
//            if (ModelState.IsValid) {
//                _context.Students.Add(student);
//                await _context.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return Ok(student);
//        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var student = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
            if (student == null) {
                return NotFound();
            }
            return Ok(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,EnrollmentDate,FirstMidName,LastName")] Student student) {
//            if (id != student.ID) {
//                return NotFound();
//            }
//
//            if (ModelState.IsValid) {
//                _context.Students.Attach(student);
//                _context.Entry(student).State = EntityState.Modified;
//                await _context.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return Ok(student);
//        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var student = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
            if (student == null) {
                return NotFound();
            }

            return Ok(student);
        }

        // POST: Students/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id) {
//            var student = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
//            _context.Students.Remove(student);
//            await _context.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

    }
}