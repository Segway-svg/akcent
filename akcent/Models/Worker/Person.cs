using System.ComponentModel.DataAnnotations;

namespace akcent.Models.Worker
{
    public class Person
    {
        public int Id { get; set; }

        [Display(Name = "ФИО")]
        [Required(ErrorMessage = "ФИО обязательно")]
        public string FullName { get; set; }

        [Display(Name = "Статус")]
        [Required(ErrorMessage = "Статус обязателен")]
        public string StatusName { get; set; }

        [Display(Name = "Отдел")]
        [Required(ErrorMessage = "Отдел обязателен")]
        public string DepartmentName { get; set; }

        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Должность обязательна")]
        public string PostName { get; set; }

        [Display(Name = "Дата приема")]
        [DataType(DataType.Date)]
        public DateTime? DateEmploy { get; set; }

        [Display(Name = "Дата увольнения")]
        [DataType(DataType.Date)]
        public DateTime? DateUnemploy { get; set; }
    }

    public class PersonFilter
    {
        [Range(1, int.MaxValue, ErrorMessage = "Неверный идентификатор статуса")]
        public int? StatusId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Неверный идентификатор отдела")]
        public int? DepartmentId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Неверный идентификатор должности")]
        public int? PostId { get; set; }

        [StringLength(100, ErrorMessage = "Фамилия не должна превышать 100 символов")]
        public string LastNamePart { get; set; }

        [Required(ErrorMessage = "Поле сортировки обязательно")]
        public string SortBy { get; set; } = "FullName";

        public bool SortAscending { get; set; } = true;
    }

    public class ReferenceItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
