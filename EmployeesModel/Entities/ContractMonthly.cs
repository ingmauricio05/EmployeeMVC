namespace EmployeesModel
{
    public class ContractMonthly : Contract
    {
        public double MonthlySalary { get; set; }

        public override double GetSalary()
        {
            return MonthlySalary * 12;
        }
    }
}
