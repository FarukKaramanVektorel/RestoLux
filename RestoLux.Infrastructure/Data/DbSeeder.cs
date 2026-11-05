using Microsoft.EntityFrameworkCore;
using RestoLux.Domain.Entities;
using RestoLux.Domain.Enums;

namespace RestoLux.Infrastructure.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (await db.Restaurants.AnyAsync())
            return;

        // --- Core ---
        var restaurant = new Restaurant
        {
            Name = "RestoLux Demo",
            Slug = "restolux-demo",
            Description = "Premium restoran deneyimi",
            CurrencyCode = "TRY",
            DefaultCulture = "tr",
            IsActive = true
        };
        db.Restaurants.Add(restaurant);
        await db.SaveChangesAsync();

        var branches = new List<Branch>();
        var cities = new[] { "İstanbul", "Ankara", "İzmir" };
        for (int i = 1; i <= 3; i++)
        {
            branches.Add(new Branch
            {
                RestaurantId = restaurant.Id,
                Name = $"Şube {i}",
                City = cities[i - 1],
                Address = $"{cities[i - 1]} Merkez",
                Capacity = 40 + i * 10,
                Phone = $"021{i}000000",
                IsActive = true,
                IsMainBranch = i == 1
            });
        }
        db.Branches.AddRange(branches);
        await db.SaveChangesAsync();

        var allergens = new[] { "Gluten", "Süt", "Yumurta", "Fındık", "Soya" }
            .Select((n, idx) => new Allergen { Name = n, SortOrder = idx }).ToList();
        db.Allergens.AddRange(allergens);

        var tags = new[] { "Vegan", "Vejetaryen", "Glutensiz" }
            .Select((n, idx) => new DietaryTag { Name = n, SortOrder = idx }).ToList();
        db.DietaryTags.AddRange(tags);

        var tax = new TaxRule { Name = "KDV %10", TaxPercentage = 10, IsDefault = true, IsActive = true };
        db.TaxRules.Add(tax);
        await db.SaveChangesAsync();

        var foods = new (string Name, string Desc, decimal Price, int Group)[]
        {
            ("Adana Kebap", "Acılı kıyma kebabı", 280m, 1),
            ("İskender", "Döner ve yoğurt", 320m, 1),
            ("Lahmacun", "İnce hamur", 120m, 1),
            ("Pide Karışık", "Kaşarlı pide", 180m, 1),
            ("Mercimek Çorbası", "Sıcak çorba", 60m, 1),
            ("Caesar Salata", "Tavuklu salata", 150m, 2),
            ("Mantı", "Yoğurtlu mantı", 160m, 2),
            ("Baklava", "Fıstıklı baklava", 140m, 3),
            ("Künefe", "Peynirli künefe", 130m, 3),
            ("Ayran", "Soğuk ayran", 30m, 4)
        };

        var allProducts = new List<Product>();
        var allTables = new List<DiningTable>();

        foreach (var branch in branches)
        {
            var menu = new Menu { BranchId = branch.Id, Name = "Ana Menü", IsActive = true, IsFeatured = true };
            db.Menus.Add(menu);
            await db.SaveChangesAsync();

            var catFood = new MenuCategory { MenuId = menu.Id, Name = "Yemekler", SortOrder = 1, IsActive = true };
            var catDrink = new MenuCategory { MenuId = menu.Id, Name = "İçecekler", SortOrder = 2, IsActive = true };
            var catDessert = new MenuCategory { MenuId = menu.Id, Name = "Tatlılar", SortOrder = 3, IsActive = true };
            db.MenuCategories.AddRange(catFood, catDrink, catDessert);
            await db.SaveChangesAsync();

            int count = 0;
            foreach (var (name, desc, price, group) in foods)
            {
                var cat = group == 3 ? catDessert : group == 4 ? catDrink : catFood;
                var product = new Product
                {
                    CategoryId = cat.Id,
                    TaxRuleId = tax.Id,
                    Name = name,
                    Description = desc,
                    Price = price,
                    IsActive = true,
                    IsFeatured = count < 3,
                    SortOrder = count
                };
                db.Products.Add(product);
                allProducts.Add(product);
                count++;
                if (count >= 10) break;
            }
            await db.SaveChangesAsync();

            var area = new DiningArea
            {
                BranchId = branch.Id,
                Name = "Ana Salon",
                AreaType = DiningAreaType.Indoor,
                Capacity = branch.Capacity,
                IsActive = true,
                IsReservable = true,
                SortOrder = 1
            };
            db.DiningAreas.Add(area);
            await db.SaveChangesAsync();

            for (int t = 1; t <= 5; t++)
            {
                var table = new DiningTable
                {
                    DiningAreaId = area.Id,
                    TableNumber = $"T{t}",
                    MinCapacity = 2,
                    MaxCapacity = 4,
                    Status = TableStatus.Available,
                    IsActive = true,
                    IsReservable = true
                };
                db.DiningTables.Add(table);
                allTables.Add(table);
            }
            await db.SaveChangesAsync();

            for (int d = 0; d < 7; d++)
            {
                db.OpeningHours.Add(new OpeningHour
                {
                    BranchId = branch.Id,
                    DayOfWeek = (DayOfWeek)d,
                    OpenTime = new TimeOnly(10, 0),
                    CloseTime = new TimeOnly(23, 0),
                    IsClosed = false
                });
            }
            await db.SaveChangesAsync();
        }

        // --- Demo extras (3 each) ---

        // Customers
        var customers = new List<Customer>();
        for (int i = 1; i <= 3; i++)
        {
            customers.Add(new Customer
            {
                FirstName = $"Müşteri{i}",
                LastName = "Demo",
                Email = $"musteri{i}@test.com",
                Phone = $"555000{i}",
                IsGuest = i > 1,
                IsVip = i == 1
            });
        }
        db.Customers.AddRange(customers);
        await db.SaveChangesAsync();

        // Reviews
        for (int i = 1; i <= 3; i++)
        {
            db.Reviews.Add(new Review
            {
                BranchId = branches[0].Id,
                CustomerId = customers[i - 1].Id,
                AuthorName = customers[i - 1].FirstName,
                Rating = 4 + (i % 2),
                Comment = "Harika bir deneyim!",
                IsApproved = true,
                IsFeatured = i == 1
            });
        }
        await db.SaveChangesAsync();

        // ContentPages
        for (int i = 1; i <= 3; i++)
        {
            db.ContentPages.Add(new ContentPage
            {
                RestaurantId = restaurant.Id,
                Title = $"Sayfa {i}",
                Slug = $"sayfa-{i}",
                Content = $"İçerik {i}",
                Status = ContentPageStatus.Published,
                SortOrder = i
            });
        }
        await db.SaveChangesAsync();

        // SiteSettings
        for (int i = 1; i <= 3; i++)
        {
            db.SiteSettings.Add(new SiteSetting
            {
                RestaurantId = restaurant.Id,
                Key = $"setting.key{i}",
                Value = $"value{i}",
                Group = "general"
            });
        }
        await db.SaveChangesAsync();

        // SpecialClosures
        for (int i = 1; i <= 3; i++)
        {
            db.SpecialClosures.Add(new SpecialClosure
            {
                BranchId = branches[0].Id,
                Date = DateOnly.FromDateTime(DateTime.Today.AddDays(i * 5)),
                Reason = $"Özel gün {i}",
                IsFullDay = true
            });
        }
        await db.SaveChangesAsync();

        // NotificationTemplates
        for (int i = 1; i <= 3; i++)
        {
            db.NotificationTemplates.Add(new NotificationTemplate
            {
                TemplateName = $"template{i}",
                Subject = $"Konu {i}",
                Body = $"Gövde {i}",
                Type = NotificationType.Email,
                Culture = "tr",
                IsActive = true
            });
        }
        await db.SaveChangesAsync();

        // ModifierGroups + Options
        var modifierGroups = new List<ModifierGroup>();
        for (int i = 0; i < 3 && i < allProducts.Count; i++)
        {
            var mg = new ModifierGroup
            {
                ProductId = allProducts[i].Id,
                Name = $"Seçenek Grubu {i + 1}",
                IsRequired = false,
                MinSelections = 0,
                MaxSelections = 2,
                SortOrder = i
            };
            db.ModifierGroups.Add(mg);
            modifierGroups.Add(mg);
        }
        await db.SaveChangesAsync();

        foreach (var mg in modifierGroups)
        {
            for (int j = 1; j <= 3; j++)
            {
                db.ModifierOptions.Add(new ModifierOption
                {
                    ModifierGroupId = mg.Id,
                    Name = $"Seçenek {j}",
                    PriceDifference = j * 5m,
                    SortOrder = j,
                    IsDefault = j == 1,
                    IsActive = true
                });
            }
        }
        await db.SaveChangesAsync();

        // ProductVariants
        if (allProducts.Count > 0)
        {
            for (int i = 1; i <= 3; i++)
            {
                db.ProductVariants.Add(new ProductVariant
                {
                    ProductId = allProducts[0].Id,
                    Name = $"Varyant {i}",
                    PriceDifference = i * 10m,
                    IsDefault = i == 1,
                    SortOrder = i,
                    IsActive = true
                });
            }
            await db.SaveChangesAsync();
        }

        // BranchProductAvailabilities
        for (int i = 0; i < 3 && i < allProducts.Count; i++)
        {
            db.BranchProductAvailabilities.Add(new BranchProductAvailability
            {
                BranchId = branches[0].Id,
                ProductId = allProducts[i].Id,
                IsAvailable = true
            });
        }
        await db.SaveChangesAsync();

        // ReservationPolicies (3 branches)
        foreach (var b in branches)
        {
            db.ReservationPolicies.Add(new ReservationPolicy
            {
                BranchId = b.Id,
                MinGuests = 1,
                MaxGuests = 20,
                SlotDurationMinutes = 30,
                DefaultDurationMinutes = 90,
                MinAdvanceHours = 2,
                MaxAdvanceDays = 30,
                CancellationDeadlineHours = 24,
                AllowWaitlist = true,
                RequireConfirmation = true
            });
        }
        await db.SaveChangesAsync();

        // WaitlistEntries
        for (int i = 1; i <= 3; i++)
        {
            db.WaitlistEntries.Add(new WaitlistEntry
            {
                BranchId = branches[0].Id,
                CustomerId = customers[i - 1].Id,
                DesiredDate = DateOnly.FromDateTime(DateTime.Today.AddDays(i)),
                GuestCount = 2 + i,
                IsNotified = false,
                IsConverted = false
            });
        }
        await db.SaveChangesAsync();

        // TableCombinations
        if (allTables.Count >= 4)
        {
            for (int i = 0; i < 3; i++)
            {
                var combo = new TableCombination
                {
                    Name = $"Kombinasyon {i + 1}",
                    CombinedCapacity = 8,
                    IsActive = true
                };
                combo.Tables.Add(allTables[i * 2]);
                combo.Tables.Add(allTables[i * 2 + 1]);
                db.TableCombinations.Add(combo);
            }
            await db.SaveChangesAsync();
        }

        // Reservations (3)
        var reservations = new List<Reservation>();
        for (int i = 1; i <= 3; i++)
        {
            var res = new Reservation
            {
                BranchId = branches[0].Id,
                CustomerId = customers[i - 1].Id,
                Date = DateOnly.FromDateTime(DateTime.Today.AddDays(i)),
                StartTime = new TimeOnly(19, 0),
                EndTime = new TimeOnly(21, 0),
                GuestCount = 2 + i,
                Status = ReservationStatus.Pending,
                SpecialRequests = $"Özel istek {i}",
                ConfirmationCode = $"CONF{i:D4}"
            };
            db.Reservations.Add(res);
            reservations.Add(res);
        }
        await db.SaveChangesAsync();

        // ReservationTables + StatusHistory
        if (allTables.Count > 0 && reservations.Count > 0)
        {
            for (int i = 0; i < 3; i++)
            {
                db.ReservationTables.Add(new ReservationTable
                {
                    ReservationId = reservations[i].Id,
                    DiningTableId = allTables[i % allTables.Count].Id
                });
                db.ReservationStatusHistories.Add(new ReservationStatusHistory
                {
                    ReservationId = reservations[i].Id,
                    OldStatus = ReservationStatus.Pending,
                    NewStatus = ReservationStatus.Confirmed,
                    Notes = "Onaylandı"
                });
            }
            await db.SaveChangesAsync();
        }

        // CustomerNotes + Consents
        for (int i = 1; i <= 3; i++)
        {
            db.CustomerNotes.Add(new CustomerNote
            {
                CustomerId = customers[i - 1].Id,
                Note = $"Not {i}",
                CreatedByUserId = "admin"
            });
            db.CustomerConsents.Add(new CustomerConsent
            {
                CustomerId = customers[i - 1].Id,
                ConsentType = ConsentType.Marketing,
                IsGranted = i % 2 == 0,
                GrantedAt = i % 2 == 0 ? DateTime.UtcNow : null
            });
        }
        await db.SaveChangesAsync();

        // MediaAssets
        for (int i = 1; i <= 3; i++)
        {
            db.MediaAssets.Add(new MediaAsset
            {
                RestaurantId = restaurant.Id,
                FileName = $"file{i}.jpg",
                OriginalFileName = $"original{i}.jpg",
                FilePath = $"/uploads/file{i}.jpg",
                ContentType = "image/jpeg",
                FileSize = 1024 * i,
                AltText = $"Görsel {i}"
            });
        }
        await db.SaveChangesAsync();

        // Notifications
        for (int i = 1; i <= 3; i++)
        {
            db.Notifications.Add(new Notification
            {
                BranchId = branches[0].Id,
                Title = $"Bildirim {i}",
                Message = $"Mesaj {i}",
                Type = NotificationType.Email,
                IsRead = i == 1
            });
        }
        await db.SaveChangesAsync();

        // ProductAllergens + ProductDietaryTags
        if (allProducts.Count > 0)
        {
            for (int i = 0; i < 3 && i < allergens.Count; i++)
            {
                db.ProductAllergens.Add(new ProductAllergen
                {
                    ProductId = allProducts[0].Id,
                    AllergenId = allergens[i].Id
                });
            }
            for (int i = 0; i < 3 && i < tags.Count; i++)
            {
                db.ProductDietaryTags.Add(new ProductDietaryTag
                {
                    ProductId = allProducts[0].Id,
                    DietaryTagId = tags[i].Id
                });
            }
            await db.SaveChangesAsync();
        }

        // UserBranches
        for (int i = 0; i < 3; i++)
        {
            db.UserBranches.Add(new UserBranch
            {
                UserId = $"user{i + 1}",
                BranchId = branches[i % branches.Count].Id,
                IsPrimary = i == 0
            });
        }
        await db.SaveChangesAsync();

        // LocalizedTexts
        if (allProducts.Count > 0)
        {
            for (int i = 1; i <= 3; i++)
            {
                db.LocalizedTexts.Add(new LocalizedText
                {
                    EntityName = "Product",
                    EntityId = allProducts[0].Id,
                    Culture = i == 1 ? "tr" : "en",
                    FieldName = "Name",
                    Value = i == 1 ? allProducts[0].Name : $"Product {i}"
                });
            }
            await db.SaveChangesAsync();
        }

        // AuditLogs
        for (int i = 1; i <= 3; i++)
        {
            db.AuditLogs.Add(new AuditLog
            {
                Action = AuditAction.Create,
                EntityName = "Product",
                EntityId = i.ToString(),
                UserName = "admin"
            });
        }
        await db.SaveChangesAsync();

        // NotificationOutboxes
        for (int i = 1; i <= 3; i++)
        {
            db.NotificationOutboxes.Add(new NotificationOutbox
            {
                Recipient = $"test{i}@mail.com",
                Subject = $"Konu {i}",
                Body = $"Gövde {i}",
                Type = NotificationType.Email,
                Status = NotificationStatus.Pending,
                MaxRetries = 3
            });
        }
        await db.SaveChangesAsync();
    }
}