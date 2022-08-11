using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCreditApp1.Models
{
    public class Bid
    {
        [DisplayName("id")]
        public virtual int BidId { get; set; }

        [DisplayName("Имя заявителя")]
        //[MinLength(2)]
        [Required(AllowEmptyStrings = false)]
        public virtual string Name { get; set; }

        [DisplayName("Название кредита")]
        [MinLength(2)]
        [Required(AllowEmptyStrings = false)]
        public virtual string CreditHead { get; set; }

        [DisplayName("Дата подачи заявки")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public virtual DateTime BidDate { get; set; }
    }
}