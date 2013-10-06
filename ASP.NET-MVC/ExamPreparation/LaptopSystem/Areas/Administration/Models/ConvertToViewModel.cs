using LaptopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopSystem.Areas.Administration.Models
{
    public static class ConvertToViewModel
    {
        //public static Laptop ToModel(this Laptop laptop)
        //{
        //    return new Laptop
        //    {
        //        Model = laptop.Laptop.Model,
        //        Description = laptop.Laptop.Description,
        //        AdditionalParts = laptop.Laptop.AdditionalParts,
        //        Harddisk = laptop.Laptop.Harddisk,
        //        Image = laptop.Laptop.Image,
        //        Inches = laptop.Laptop.Inches,
        //        Price = laptop.Laptop.Price,
        //        Ram = laptop.Laptop.Ram,
        //        Weight = laptop.Laptop.Weight,
                
        //    };
        //}

        public static CommentsViewModel ToViewModel(this Comment comment)
        {
            CommentsViewModel vm = new CommentsViewModel
            {
                Content = comment.Content,
                Id = comment.Id
            };

            if (comment.Laptop != null)
            {
                vm.OnLaptop = comment.Laptop.Model;
            }
            if (comment.User != null)
            {
                vm.ByUser = comment.User.UserName;
            }

            return vm;
        }

        public static IEnumerable<CommentsViewModel> ToViewModel(this IEnumerable<Comment> comments)
        {
            foreach (var item in comments)
            {
                yield return item.ToViewModel();
            }
        } 
    }
}