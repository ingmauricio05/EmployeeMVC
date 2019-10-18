namespace EmployeesModel
{
    public class ContractHourly : Contract
    {
        public double HourlySalary { get; set; }

        public override double GetSalary()
        {
            return 120 * this.HourlySalary * 12;
        }
    }
}
