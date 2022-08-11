using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCreditApp1.Models
{
/* Этот класс контекста представляет полный слой данных, который можно 
 * использовать в приложениях. 
 * Благодаря DbContext, можно запросить, изменить, удалить или вставить значения 
 * в базу данных */

    public class CreditContext : DbContext
    {
        public DbSet<Credit> Credits { get; set; }
        public DbSet<Bid> Bids { get; set; }
    }
}