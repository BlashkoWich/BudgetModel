using DataBase;
using Services.AddRow;

namespace Systems
{
    public static class RemoveBudgetSystem
    {
        public static void RemoveBudget(int id)
        {
            for (var i = 0; i < BudgetDataBase.Budgets.Count; i++)
            {
                var budget = BudgetDataBase.Budgets[i];
                if (budget.Id != id)
                    continue;

                BudgetDataBase.Budgets.RemoveAt(i);
                AddRemoveBudgetService.InvokeRemove(new RemoveBudgetModel
                {
                    BudgetModel = budget
                });
                break;
            }
        }
    }
}