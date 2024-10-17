using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Employees")]
    public class Employee : CommonAbstract
    {
        [Required]
        public string UserId { get; set; }
        [Key]
        [Required(ErrorMessage = "Mã nhân viên bắt buộc nhập.")]
        [StringLength(50)]
        public string EmployeeId { get; set; }
        [Required(ErrorMessage = "Tên nhân viên bắt buộc nhập.")]
        [StringLength(100)]
        public string EmployeeName { get; set; }
        public string BirthDay { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}