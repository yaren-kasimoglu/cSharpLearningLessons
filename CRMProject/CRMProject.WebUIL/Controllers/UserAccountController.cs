using AutoMapper;
using CRMProject.BL.Abstract;
using CRMProject.BL.Concrete;
using CRMProject.DTO.Pages;
using CRMProject.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRMProject.WebUIL.Controllers
{
    // AutoMapper: NEsne dönüşümlerini kolaylaştıran bir paket
    //fluent Validation : nesnenin validation işlemini yapmak için kullanılan bir paket. 
    public class UserAccountController : Controller
    {
        IUserAccountService _userAccountService;
        IMapper _mapper;
        public UserAccountController(IUserAccountService userAccountService, IMapper mapper)
        {
            _userAccountService = userAccountService;
            _mapper = mapper;
        }

        [HttpGet("user-list")]
        public IActionResult List()
        {
            return View();
        }

        [HttpGet("user-list-data")]
        public JsonResult ListData()
        {
            var data = _userAccountService.Select();
            return Json(new { data = data });
        }
        [HttpGet("user-detail/{id?}")]
        public IActionResult Detail(int? id)
        {
            var userAccountDTO = FillUserAccount(id);
            return View(userAccountDTO);
        }
        [HttpPost("user-detail/{id?}")]
        public IActionResult Detail(int id, UserAccountDTO userAccountDTO)
        {
            //Hangi Butona basıldı
            if (Request.Form.Keys.Contains("btnNew"))
            {
                //Yeni botunundan basılmıştır.
                return Redirect("/user-detail");
            }
            else if (Request.Form.Keys.Contains("btnSave"))
            {
                var user = _mapper.Map<UserAccount>(userAccountDTO);
                if (id > 0)
                {
                    _userAccountService.Update(user);
                }
                else
                {
                    _userAccountService.Add(user);
                }
                return Redirect($"/user-detail/{user.UserId}");
            }
            else if (Request.Form.Keys.Contains("btnDelete"))
            {
                var user = _mapper.Map<UserAccount>(userAccountDTO);
                _userAccountService.Delete(user);
                return Redirect("/user-list");
            }
            else if (Request.Form.Keys.Contains("btnList"))
            {
                return Redirect("/user-list");
            }
            return View();
        }

        private UserAccountDTO FillUserAccount(int? id)
        {

            var userAccount = _userAccountService.GetById(Convert.ToInt32(id));

            //if (userAccount != null)
            //{
            //    //return new UserAccountDTO { UserName = userAccount.UserName, FullName = userAccount.Fullname, RecordDate = userAccount.RecordDate, ModifiedDate = userAccount.ModifiedDate, UserId = userAccount.UserId, Password = userAccount.Password };
            //    return _mapper.Map<UserAccountDTO>(userAccount);
            //}

            return _mapper.Map<UserAccountDTO>(_userAccountService.GetById(Convert.ToInt32(id)));


        }
        //public JsonResult ListData()
        //{
        //	var data = _userAccountService.Select();
        //	//return Json(new { data: 'data' });
        //	return Json(data);
        //}
    }
}
