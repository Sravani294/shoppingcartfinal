using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Repository;

namespace WebMVC.Controllers
{
    public class UserController : Controller
    {
        public async Task<ActionResult> Index()
        {

 
            // GET: User
            List<UserViewModel> users = new List<UserViewModel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("Users"))
                {
                    string apiResponse
                        = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject
<List<UserViewModel>>(apiResponse);
                }
            }
            return View(users);
        }
        public async Task<ActionResult> Create(UserViewModel userViewModel)
         {
             if (ModelState.IsValid)
             {
                 UserViewModel newUser = new UserViewModel();
                 var service = new ServiceRepository();
                {
                    using (var response = service.PostResponse("Users", userViewModel))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }
                return RedirectToAction("Index");
             }
             return View(userViewModel);
         }
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult loginHomepage()
        {
            return View();
        }
        public ActionResult LoginUser()
        {
            return View();
        }



        [HttpPost]
        [Route("")]
        public async Task<ActionResult> LoginUser(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoginModel newUser = new LoginModel();
                    var service = new ServiceRepository();
                    {
                        using (var response = service.VerifyLogin("api/Login", login))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            newUser = JsonConvert.DeserializeObject<LoginModel>(apiResponse);
                        }
                    }
                    if (newUser != null)
                    {
                        ViewBag.message = "Login Success";
                    }
                    else
                    {
                        ViewBag.message = "incorrect";
                    }
                }
            }
            catch
            {



            }
            return RedirectToAction("CategoryView", "CategoryDetails");



        }



        public ActionResult LoginUsers()
        {
            return View();
        }



        //This Post Method will validate the userName & Password valid or not using WebAPI
        [Route("")]
        [HttpPost]
        public ActionResult LoginUsers(UserViewModel Ur)
        {
            if (!(string.IsNullOrEmpty(Ur.EmailID) || string.IsNullOrEmpty(Ur.Password)))
            {



                if (!ModelState.IsValid)
                {
                    HttpClient hc = new HttpClient();
                    hc.BaseAddress = new Uri("https://localhost:44377/api/Login"); // URL for Login WebAPI
                    var checkLoginDetails = hc.PostAsJsonAsync<UserViewModel>("Login", Ur);//Asynchronosly passing the values in Json Format to API
                    var checkrec = checkLoginDetails.Result;//Checking the User EmailID & Password



                    //Condition for Successfull Login We need to Navigate to Flght Seach Page 
                    if ((int)checkrec.StatusCode == 200)
                    {
                        ViewBag.message = "Login Success!!";
                    }
                    //Condition for Invalid User Name & Password
                    if ((int)checkrec.StatusCode == 426)
                    {
                        ViewBag.message = "Invalid EmailID & Password";
                    }
                }
            }
            return RedirectToAction("CategoryDetails", "CategoryView");



        }
    }
}

 
    

   