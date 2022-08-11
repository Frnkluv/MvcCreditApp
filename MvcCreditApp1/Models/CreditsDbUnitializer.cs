using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcCreditApp1.Models
{
    // При инициализации в случае изменения модели старая база будет удаляться
    // и создаваться новая с начальными значениями
    public class CreditsDbUnitializer : DropCreateDatabaseIfModelChanges<CreditContext>
    {
        /* Переопределяю метод Seed() в котором создаю, например, три кредита 
         * и добавляю их в таблицу Credits с помощью метода Add() 
         * свойства Credits */
        protected override void Seed(CreditContext context)
        {
            context.Credits.Add(new Credit { Head = "Ипотечный кредит", 
                Period = 10, Sum = 1000000, Procent = 15 });
            context.Credits.Add(new Credit { Head = "Образовательный кредит", 
                Period = 7, Sum = 300000, Procent = 10 });
            context.Credits.Add(new Credit { Head = "Потребительский кредит", 
                Period = 5, Sum = 500000, Procent = 19 });

            base.Seed(context);
        }
    }
}
/* Для генерации базы данных необходимо чтобы при запуске приложения создавался 
 * экземпляр класса CreditsDbInitializer. Для этого откройте файл Global.asax и 
 * добавьте в метод Application_Start, который выполняется при старте приложения, 
 * создание объекта: Database.SetInitializer(new CreditsDbInitializer()); */