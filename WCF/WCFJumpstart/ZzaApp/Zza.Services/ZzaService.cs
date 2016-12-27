﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using Zza.Entities;

namespace Zza.Services
{
    public class ZzaService : IZzaService, IDisposable
    {
        readonly ZzaDbContext _Context = new ZzaDbContext();

        public void Dispose()
        {

        }

        public List<Customer> GetCustomers()
        {
            return _Context.Customers.ToList();
        }

        public List<Product> GetProducts()
        {
            return _Context.Products.ToList();
        }

        public void SubmitOrder(Order order)
        {
            _Context.Orders.Add(order);
            order.OrderItems.ForEach(oi => _Context.OrderItems.Add(oi));
            _Context.SaveChanges();
        }
    }
}
