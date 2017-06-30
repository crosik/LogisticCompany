using System.ComponentModel.DataAnnotations;

namespace Mas_Logistics_Company.Models.Persons
{
    public class Warehouseman
    {
        public Warehouseman()
        {
            
        }

        public Warehouseman(string medicalCertificate)
        {
            MedicalCertificate = medicalCertificate;
        }
        public int WarehousemanId { get; set; }

        [Required]
        public string MedicalCertificate { get; set; }

        public string Show()
        {
            return $"{Person.Name} {Person.Surname} MedicalCertificate:{MedicalCertificate} Age:{Person.Age}";
        }
        public virtual Person Person { get; set; }
    }
}