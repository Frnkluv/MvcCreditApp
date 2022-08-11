using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCreditApp1.Models
{
    public class Credit
    {
        public virtual int Id { get; set; }
        // Название кредита
        public virtual string Head { get; set; }
        // Период на который выдается
        public virtual int Period { get; set; }
        // Макс сумма
        public virtual int Sum { get; set; }
        // Процентная ставка
        public virtual int Procent { get; set; }
    }
}