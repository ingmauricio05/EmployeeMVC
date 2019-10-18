using EmployeesModel;

namespace BusinessLogic
{
    public class ContractFactory
    {
        const string HourlySalaryContract = "HourlySalaryEmployee";
        const string MonthlySalaryEmployee = "MonthlySalaryEmployee";
        public static Contract ContractCreator(Employee employee)
        {
            switch (employee.ContractTypeName)
            {
                case HourlySalaryContract:
                    ContractHourly contract = new ContractHourly()
                    {
                        HourlySalary = employee.HourlySalary,
                    };

                    contract.AnnualSalary = contract.GetSalary();
                    return contract;
                case MonthlySalaryEmployee:
                    ContractMonthly contractM = new ContractMonthly()
                    {
                        MonthlySalary = employee.MonthlySalary,

                    };
                    contractM.AnnualSalary = contractM.GetSalary();
                    return contractM;
                default: return null;
            }
        }
    }
}
