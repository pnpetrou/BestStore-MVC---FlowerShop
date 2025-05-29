using BestStoreMVC.Models;
using BestStoreMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BestStoreMVC.Controllers
{
    public class FlowersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;
        public FlowersController(ApplicationDbContext context, IWebHostEnvironment environment) 
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var flowers = this.context.Flowers.OrderByDescending(p => p.Id).ToList();
            return View(flowers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FlowerDto flowerDto)
        {
            if (flowerDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "the image file is required");
            }

            if (!ModelState.IsValid)
            {
                return View(flowerDto);
            }

            // save the image file
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(flowerDto.ImageFile!.FileName);

            string imageFullPath = environment.WebRootPath + "/FlowersImages/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                flowerDto.ImageFile.CopyTo(stream);
            }

            // save the new flower in the database
            Flower flower = new Flower()
            {
                Name = flowerDto.Name,
                Category = flowerDto.Category,
                Price = flowerDto.Price,
                Description = flowerDto.Description,
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now,
            };

            context.Flowers.Add(flower);
            context.SaveChanges();


            return RedirectToAction("Index", "Flowers");
        }

        // finding the flower ID to modify
        public IActionResult Edit(int id)
        {
            var flower = context.Flowers.Find(id);

            if (flower == null)
            {
                return RedirectToAction("Index", "Flowers");
            }

            // create FlowerDto from flower
            var FlowerDto = new FlowerDto()
            {
                Name = flower.Name,
                Category = flower.Category,
                Price = flower.Price,
                Description = flower.Description,
            };


            ViewData["FlowerId"] = flower.Id;
            ViewData["ImageFileName"] = flower.ImageFileName;
            ViewData["CreatedAt"] = flower.CreatedAt.ToString("MM/dd/yyyy");

            return View(FlowerDto);

        }

        [HttpPost]
        public IActionResult Edit(int id, FlowerDto flowerDto)
        {
            var flower = context.Flowers.Find(id);
            if (flower == null)
            {
                return RedirectToAction("Index", "Flowers");
            }

            if (!ModelState.IsValid)
            {
                ViewData["FlowerId"] = flower.Id;
                ViewData["ImageFileName"] = flower.ImageFileName;
                ViewData["CreatedAt"] = flower.CreatedAt.ToString("MM/dd/yyyy");

                return View(flowerDto);
            }

            // update the image file if we have a new image file
            string newFileName = flower.ImageFileName;
            if (flowerDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(flowerDto.ImageFile.FileName);

                string imageFullPath = environment.WebRootPath + "/FlowersImages/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    flowerDto.ImageFile.CopyTo(stream);
                }

                // delete the old image
                string oldImageFullPath = environment.WebRootPath + "/FlowersImages/" + flower.ImageFileName;
                System.IO.File.Delete(oldImageFullPath);
            }

            // update the flower in the database
            flower.Name = flowerDto.Name;
            flower.Category = flowerDto.Category;
            flower.Price = flowerDto.Price;
            flower.Description = flowerDto.Description;
            flower.ImageFileName = newFileName;

            context.SaveChanges();

            return RedirectToAction("Index", "Flowers");


        }

        public IActionResult Delete(int id)
        {
            var flower = context.Flowers.Find(id);
            if (flower == null)
            {
                return RedirectToAction("Index", "Flowers");
            }

            string imageFullPath = environment.WebRootPath + "/FlowersImages/" + flower.ImageFileName;
            System.IO.File.Delete(imageFullPath);

            context.Flowers.Remove(flower);
            context.SaveChanges(true);

            return RedirectToAction("Index", "Flowers");

        }
    }
}
