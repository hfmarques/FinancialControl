using FinancialControlApi.Features.Income;
using FinancialControlApi.Features.Income.Queries;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Enums;
using Moq;

namespace FinancialControlApi.UnitTests;

[TestFixture]
public class IncomeControllerTests
{
    private IncomeController incomeController;
    private Mock<IGetAllIncomes> getAllIncomes;

    [SetUp]
    public void SetUp()
    {
        getAllIncomes = new Mock<IGetAllIncomes>();

        incomeController = new IncomeController(getAllIncomes.Object);
    }

    [Test]
    public void GetAllIncomes_NoIncomeFound_ReturnNotFound()
    {
        getAllIncomes.Setup(x => x.Handler()).Returns(new List<IncomeModel>());

        var result = incomeController.GetAllIncomes();

        Assert.That(result, Is.InstanceOf<NotFoundResult>());
    }

    [Test]
    public void GetAllIncomes_IncomeFound_ReturnOk()
    {
        getAllIncomes.Setup(x => x.Handler()).Returns(new List<IncomeModel>
        {
            new()
            {
                Id = new Guid(),
                Description = "a",
                Value = 1,
                Type = IncomeType.Salary
            }
        });

        var result = incomeController.GetAllIncomes();

        Assert.That(result, Is.InstanceOf<OkResult>());
    }

    [Test]
    public void GetAllIncomes_WhenCalled_ThrowsException()
    {
        getAllIncomes.Setup(x => x.Handler()).Throws<Exception>();

        var result = incomeController.GetAllIncomes();

        Assert.That(result, Is.InstanceOf<BadRequestResult>());
    }
}