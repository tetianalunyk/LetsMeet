using LetsTogether.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsTogether.Web.Models
{
    public class ChooseCategoryModel
    {
        public List<string> SelectedCategories { get; set; }
        public List<Category> Categories { get; set; }
    }
}
