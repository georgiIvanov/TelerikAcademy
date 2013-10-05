using LaptopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopSystem.ViewModels
{
    public static class ConvertToViewModel
    {
        public static LaptopIndexViewModel ToViewModel(this Laptop laptop)
        {
            return new LaptopIndexViewModel()
            {
                ImageUrl = laptop.Image,
                ManufacturerName = laptop.Manufacturer.Name,
                Model = laptop.Model,
                Price = laptop.Price,
                Id = laptop.Id
            };
        }

        public static IEnumerable<LaptopIndexViewModel> ToViewModel(this IEnumerable<Laptop> laptops)
        {
            foreach (var item in laptops)
            {
                yield return item.ToViewModel();
            }
        }

        public static CommentViewModel ToViewModel(this Comment comment)
        {
            return new CommentViewModel{
                Content = comment.Content,
                Username = comment.User.UserName
            };
        }

        public static IEnumerable<CommentViewModel> ToViewModel(this IEnumerable<Comment> comments)
        {
            foreach (var item in comments)
            {
                yield return item.ToViewModel();
            }
        }

        public static LaptopDetailsViewModel ToViewModel(this Laptop laptop, bool details)
        {
            return new LaptopDetailsViewModel()
            {
                ImageUrl = laptop.Image,
                ManufacturerName = laptop.Manufacturer.Name,
                Model = laptop.Model,
                Price = laptop.Price,
                Id = laptop.Id,
                AdditionalParts = laptop.AdditionalParts,
                Description = laptop.Description,
                Harddisk = laptop.Harddisk,
                Inches = laptop.Inches,
                Ram = laptop.Ram,
                Weight = laptop.Weight,
                Votes = laptop.Votes.Count
            };
        }
    }
}