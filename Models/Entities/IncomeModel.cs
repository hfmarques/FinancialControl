using Models.Enums;

namespace Models.Entities;

public class IncomeModel
{
    public Guid Id { get; set; }
    public decimal Value { get; set; }
    public string Description { get; set; }
    public IncomeType Type { get; set; }
}