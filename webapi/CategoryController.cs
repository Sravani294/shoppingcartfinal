using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        ICategory<Category> _CategoryRepository;



        public CategoryController()
        {
            _CategoryRepository = new CategoryRepo(new Shopping_ZoneEntities());
        }



        //To get All Categories



        [HttpGet]
        [Route("")]
        public IEnumerable<Category> GetAllCategorys()
        {
            var categories = _CategoryRepository.GetAllCategorys();
            return categories;
        }




        //Category Data inserting



        [HttpPost]
        [Route("")]
        public IHttpActionResult AddCategory(Category category)
        {
            User userobj = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Data");
                _CategoryRepository.AddCategory(category);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok("saved Successfully");
        }




        //Deleting the existing data

        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not a valid student id");



                _CategoryRepository.DeleteCategory(id);
            }
            catch
            {
                throw;
            }



            return Ok("Deleted Successfully!");
        }




        //Update category



        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, Category user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid DataList");
                _CategoryRepository.UpdateCategory(id, user);
            }
            catch
            {
                throw;
            }
            return Ok("Updated Successfully");
        }




        //Get Category details by id



        [HttpGet]
        [Route("")]
        public Category GetCategory(int id)
        {
            var categorys = _CategoryRepository.GetCategory(id);
            return categorys;
        }



    }

  

}
