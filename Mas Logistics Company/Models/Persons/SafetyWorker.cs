namespace Mas_Logistics_Company.Models.Persons
{
    public class SafetyWorker
    {
        public SafetyWorker()
        {
            
        }
        public int SafetyWorkerId { get; set; }
        public int? PersonId { get; set; }
        /// <summary>
        /// Assigns Mechanic to repair
        /// </summary>
        public void AssignMechanic()
        {
            //TODO
        }
        public virtual Person Person { get; set; }
    }
}