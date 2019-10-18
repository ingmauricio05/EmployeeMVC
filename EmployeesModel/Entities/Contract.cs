namespace EmployeesModel
{
    public abstract class Contract
    {
        public double AnnualSalary { get; set; }

        public abstract double GetSalary();
    }
}
