using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Data.Models
{
    public class Order
    {
        [BsonId]
        [BindNever]
        public int Id { get; set; }

        [Display(Name="Имя")]
        [StringLength(10)]
        [Required(ErrorMessage ="Длина имени не более 10 символов")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина фамилии не менее 15 символов")]
        public string Surname { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(40)]
        [Required(ErrorMessage = "Длина адреса не более 40 символов")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина телефонаса не более 15 символов")]
        public string Phone { get; set; }


        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина E-mail не менее 25 символов")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

    }
}
