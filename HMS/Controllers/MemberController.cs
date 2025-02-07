using HMS.Abstractions;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _membersService;

        public MemberController(IMemberService membersService)
        {
            _membersService = membersService;
        }

        //public async Task<IActionResult> Index()
        //{
        //    List<Member> members = await _membersService.GetMembers();

        //    return View(members);
        //}

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateMember(Member member)
        {
            _membersService.AddMember(member);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Member member)
        {
            return View(member);
        }

        public IActionResult DeleteMember(int Id)
        {
            _membersService.DeleteMember(Id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetDetailsById(int Id)
        {

            Member? member = _membersService.GetMemberById(Id);

            if (member == null)
            {
                return NotFound();
            }

            return View("Details", member);
        }
    }
}
