using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Repository
{
   
public class CategoryRepo : ICategory<Category>
    {
        Shopping_ZoneEntities _CategoryEntities;

        //Constructor Dependancy injection
        Shopping_ZoneEntities _userdbcontext;
        public CategoryRepo(Shopping_ZoneEntities context)
        {
            _CategoryEntities = context;
        }
        //For Add new Category
        public void AddCategory(Category newCategory)
        {
            _CategoryEntities.Categories.Add(newCategory);
            _CategoryEntities.SaveChanges();
        }

        //method to delete Category
        public void DeleteCategory(int id)
        {
            Category Ut = _CategoryEntities.Categories.Find(id);
            _CategoryEntities.Categories.Remove(Ut);
            _CategoryEntities.SaveChanges();

        }

        //To Display all Categorys
        public IEnumerable<Category> GetAllCategorys()
        {

            return _CategoryEntities.Categories.ToList();

        }

        //To Display Category by ID
        public Category GetCategory(int id)
        {
            return _CategoryEntities.Categories.Find(id);

        }

        //To Update Category
        public void UpdateCategory(int id, Category per)
        {
            var category = _CategoryEntities.Categories.Find(id);
            category.CategoryID = per.CategoryID;
            category.CategoryCode = per.CategoryCode;
            category.CategoryName = per.CategoryName;
            _CategoryEntities.Entry(category).State = System.Data.Entity.EntityState.Modified;
            _CategoryEntities.SaveChanges();
        }
    }


}