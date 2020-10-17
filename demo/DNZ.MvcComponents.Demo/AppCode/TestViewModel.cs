using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DNZ.MvcComponents.Demo.AppCode
{
    public class TestViewModel
    {
        [StringLength(11, ErrorMessage = "حداکثر 11 کاراکتر مجاز است")]
        //[MaxLength(20, ErrorMessage = "حداکثر 20 کاراکتر مجاز است")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام خود را وارد کنید")]
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "نام خانوادگی خود را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "تاریخ تولد خود را وارد کنید")]
        [Display(Name = "تاریخ تولد")]
        public string BirthDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "تاریخ شروع را وارد کنید")]
        [Display(Name = "تاریخ شروع")]
        public string StartDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "استان خود را وارد کنید")]
        [Display(Name = "استان")]
        public string StateId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "شهر خود را وارد کنید")]
        [Display(Name = "شهر")]
        public string CityId { get; set; }

        [Display(Name = "کلاس های دانشجویان")]
        public IEnumerable<KeyValuePair<int, int>> StudentClasses { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "باید مقدار داشته باشد")]
        public bool Test { get; set; }

        public string ImagePath { get; set; }
        public int[] Images { get; set; }
    }
}
