using MongoDB.Driver;
using Project.DAL.Contexts;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Model
{
    public class SeedData
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        public SeedData(MongoDbContext mongoDbContext)
        {
            _categoryCollection = mongoDbContext.GetCollection<Category>("Categories");
        }

        public async Task SeedCategoriesAsync()
        {
            var existingCategories = await _categoryCollection.Find(_ => true).AnyAsync();
            if (existingCategories)
            {
                return; 
            }

            var smartphoneCategory = new Category { Name = "Smartfonlar və Aksesuarlar" };
            var smartGadgetsCategory = new Category { Name = "Smart Qadjetlər" };
            var tvAudioPhotoCategory = new Category { Name = "TV, Audio və Foto" };
            var laptopsPcTabletsCategory = new Category { Name = "Noutbuklar, PK, Plansetlər" };

            smartphoneCategory.SubCategories = new List<Category>
        {
            new Category { Name = "Smartfonlar", ParentCategoryId = smartphoneCategory.Id },
            new Category { Name = "Duyməli Telefonlar", ParentCategoryId = smartphoneCategory.Id },
            new Category { Name = "Ev Telefonları", ParentCategoryId = smartphoneCategory.Id },
            new Category { Name = "Qulaqlıqlar", ParentCategoryId = smartphoneCategory.Id }
        };

            smartGadgetsCategory.SubCategories = new List<Category>
        {
            new Category { Name = "Smart Saatlar", ParentCategoryId = smartGadgetsCategory.Id },
            new Category { Name = "Smart Qolbaqlar", ParentCategoryId = smartGadgetsCategory.Id }
        };

            tvAudioPhotoCategory.SubCategories = new List<Category>
        {
            new Category { Name = "TV Brend Üzrə", ParentCategoryId = tvAudioPhotoCategory.Id },
            new Category { Name = "TV Texnologiya Üzrə", ParentCategoryId = tvAudioPhotoCategory.Id }
        };

            laptopsPcTabletsCategory.SubCategories = new List<Category>
        {
            new Category { Name = "Noutbuklar", ParentCategoryId = laptopsPcTabletsCategory.Id },
            new Category { Name = "Komputerlər", ParentCategoryId = laptopsPcTabletsCategory.Id }
        };

            var smartphonesSubCategory = smartphoneCategory.SubCategories.First(c => c.Name == "Smartfonlar");
            smartphonesSubCategory.SubCategories = new List<Category>
        {
            new Category { Name = "Apple", ParentCategoryId = smartphonesSubCategory.Id },
            new Category { Name = "Samsung", ParentCategoryId = smartphonesSubCategory.Id },
            new Category { Name = "Oppo", ParentCategoryId = smartphonesSubCategory.Id },
            new Category { Name = "Xiaomi", ParentCategoryId = smartphonesSubCategory.Id }
        };

            var earphonesSubCategory = smartphoneCategory.SubCategories.First(c => c.Name == "Qulaqlıqlar");
            earphonesSubCategory.SubCategories = new List<Category>
        {
            new Category { Name = "Bluetooth Simsiz Qulaqlıqlar", ParentCategoryId = earphonesSubCategory.Id },
            new Category { Name = "TWS Simsiz Qulaqlıqlar", ParentCategoryId = earphonesSubCategory.Id }
        };

            var smartWatchesSubCategory = smartGadgetsCategory.SubCategories.First(c => c.Name == "Smart Saatlar");
            smartWatchesSubCategory.SubCategories = new List<Category>
        {
            new Category { Name = "Apple", ParentCategoryId = smartWatchesSubCategory.Id },
            new Category { Name = "Xiaomi", ParentCategoryId = smartWatchesSubCategory.Id },
            new Category { Name = "Huawei", ParentCategoryId = smartWatchesSubCategory.Id }
        };

            var smartBraceletsSubCategory = smartGadgetsCategory.SubCategories.First(c => c.Name == "Smart Qolbaqlar");
            smartBraceletsSubCategory.SubCategories = new List<Category>
        {
            new Category { Name = "Xiaomi", ParentCategoryId = smartBraceletsSubCategory.Id },
            new Category { Name = "Huawei", ParentCategoryId = smartBraceletsSubCategory.Id },
            new Category { Name = "Samsung", ParentCategoryId = smartBraceletsSubCategory.Id }
        };

            var laptopsSubCategory = laptopsPcTabletsCategory.SubCategories.First(c => c.Name == "Noutbuklar");
            laptopsSubCategory.SubCategories = new List<Category>
        {
            new Category { Name = "Apple", ParentCategoryId = laptopsSubCategory.Id },
            new Category { Name = "Lenovo", ParentCategoryId = laptopsSubCategory.Id },
            new Category { Name = "Acer", ParentCategoryId = laptopsSubCategory.Id }
        };

            var computersSubCategory = laptopsPcTabletsCategory.SubCategories.First(c => c.Name == "Komputerlər");
            computersSubCategory.SubCategories = new List<Category>
        {
            new Category { Name = "Sistem Blokları", ParentCategoryId = computersSubCategory.Id },
            new Category { Name = "MonoBloklar", ParentCategoryId = computersSubCategory.Id }
        };

            var tvBrandSubCategory = tvAudioPhotoCategory.SubCategories.First(c => c.Name == "TV Brend Üzrə");
            tvBrandSubCategory.SubCategories = new List<Category>
        {
            new Category { Name = "Samsung", ParentCategoryId = tvBrandSubCategory.Id },
            new Category { Name = "LG", ParentCategoryId = tvBrandSubCategory.Id },
            new Category { Name = "Sony", ParentCategoryId = tvBrandSubCategory.Id }
        };

            var tvTechSubCategory = tvAudioPhotoCategory.SubCategories.First(c => c.Name == "TV Texnologiya Üzrə");
            tvTechSubCategory.SubCategories = new List<Category>
        {
            new Category { Name = "Neo QLED", ParentCategoryId = tvTechSubCategory.Id },
            new Category { Name = "NanoCell", ParentCategoryId = tvTechSubCategory.Id },
            new Category { Name = "QNED", ParentCategoryId = tvTechSubCategory.Id }
        };

            var categories = new List<Category>
        {
            smartphoneCategory,
            smartGadgetsCategory,
            tvAudioPhotoCategory,
            laptopsPcTabletsCategory
        };

            await _categoryCollection.InsertManyAsync(categories);
        }
    }
}
