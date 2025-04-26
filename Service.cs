using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MYSQL_EF2.Models;

namespace WPF_MYSQL_EF2
{
    class Service
    {
        private readonly ApplicationContext _context = new();

        public async void testc()
        {
            try
            {
                var canConnect = await _context.Database.CanConnectAsync();

                if (canConnect)
                    MessageBox.Show("✅ Connection successful!");
                else
                    MessageBox.Show("❌ Could not connect to the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"⚠️ Exception: {ex.Message}");
            }
        }

        public void InsertOrder(int storeid, int productid, int amountOrdered, DateOnly orderDate, int? amountDelivered, DateOnly? deliveryDate)
        {
            Order order = new Order
            {
                StoreId = storeid,
                ProductId = productid,
                AmountOrdered = amountOrdered,
                OrderDate = orderDate,
                AmountDelivered = amountDelivered,
                DeliveryDate = deliveryDate
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public void InsertProduct(string productName, decimal productFat, int priceOne, DateOnly expirationDate)
        {
            Product product = new Product
            {
                ProductName = productName,
                ProductFat = productFat,
                PriceOne = priceOne,
                ExpirationDate = expirationDate,
            };
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void InsertStore(string storeName, string storeAdress, string storeRegion, string storeCEO, string phone)
        {
            Store store = new Store
            {
                StoreName = storeName,
                StoreAdress = storeAdress,
                StoreRegion = storeRegion,
                StoreCeo = storeCEO,
                Phone = phone
            };
            _context.Stores.Add(store);
            _context.SaveChanges();
        }

        public List<Object> Select<T>() where T : class
        {
            return _context.Set<T>().Cast<object>().ToList();
        }
        public List<Object> firstQ()
        {
            var result = _context.Stores
            .Where(s => _context.Orders.Any(o => o.StoreId == s.StoreId))
            .Cast<object>()
            .ToList();

            return result;
        }
        public List<Object> secondQ()
        {
            var result = _context.Stores
            .Select(s => new
            {
                s.StoreName,
                OrderCount = s.Orders.Count
            }).Cast<Object>().ToList();

            return result;
        }
        public List<Object> thirdQ()
        {
            var result = _context.Orders
            .OrderByDescending(o => o.AmountDelivered)
            .Select(o => new
            {
                o.Store.StoreName,
                o.Product.ProductName,
                o.AmountOrdered,
                o.OrderDate,
                o.AmountDelivered,
                o.DeliveryDate
            }).Take(1).Cast<Object>().ToList();

            return result;
        }
        public List<Object> fourthQ()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var result = _context.Products
                .GroupBy(p => p.ProductName)
                .Select(x => new
                {
                    Product = x.Key,
                    ProductFat = Math.Round(x.Average(p => p.ProductFat),2),
                    ExpirationDate = x.Max(p => p.ExpirationDate)
                })
                .Cast<Object>()
                .ToList();

            return result;
        }
        public List<Object> fifthQ()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var result = _context.Products
                .Where(p => p.ExpirationDate <= today.AddDays(30))
                .Cast<Object>()
                .ToList();

            return result;
        }
        public List<Object> sixthQ()
        {
            var result = _context.Orders
            .GroupBy(o => o.Store.StoreName)
            .Select(g => new
            {
                Store = g.Key,
                TotalDelivered = g.Sum(o => o.AmountDelivered ?? 0)
            })
            .Where(x => x.TotalDelivered > 200)
            .Cast<Object>()
            .ToList();

            return result;
        }
        public List<Object> seventhQ()
        {
            var result = _context.Products
            .Where(p => _context.Orders.Any(o => o.ProductId == p.ProductId))
            .Cast<Object>()
            .ToList();

            return result;
        }
        public List<Object> eighthQ()
        {
            var result = _context.Stores
            .Where(s => new[] { "Подільський", "Оболонський" }.Contains(s.StoreRegion))
            .Select(s => new { s.StoreName, s.StoreRegion })
            .Cast<Object>()
            .ToList();

            return result;
        }
        public List<Object> ninthQ()
        {
            var result = _context.Orders
            .GroupBy(o => o.Product.ProductName)
            .Select(g => new
            {
                Product = g.Key,
                OrderCount = g.Count()
            })
            .OrderByDescending(x => x.OrderCount)
            .Cast<Object>()
            .ToList();

            return result;
        }
        public List<Object> tenthQ()
        {
            var result = _context.Orders
            .GroupBy(o => o.Store.StoreName)
            .Select(g => new
            {
                Store = g.Key,
                TotalOrdered = g.Sum(o => o.AmountOrdered)
            })
            .OrderByDescending(x => x.TotalOrdered)
            .Cast<Object>()
            .ToList();

            return result;
        }

    }
}
