using DataBase;
using Services.AddRow;

namespace Systems
{
    public static class AddBudgetSystem
    {
        private const int StartIndexBudget = 1;

        public static void AddBudget(int amount)
        {
            var id = GetId();
            var budgetModel = new BudgetModel
            {
                Id = id,
                Amount = amount
            };
            
            BudgetDataBase.Budgets.Add(budgetModel);
            AddRemoveBudgetService.InvokeAdd(new AddBudgetModel(id));

            int GetId()
            {
                var foundId = StartIndexBudget;
                while (true)
                {
                    var hasBudget = BudgetDataBase.HasBudget(foundId);
                    if (!hasBudget)
                        return foundId;

                    foundId++;
                }
            }
        }
    }
}