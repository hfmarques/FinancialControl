using Models.Entities;

namespace FinancialControlApi.Features.Income.Queries;

public interface IGetAllIncomes
{
    List<IncomeModel> Handler();
}

public class GetAllIncomes : IGetAllIncomes
{
    public List<IncomeModel> Handler()
    {
        return new List<IncomeModel>();
    }
}