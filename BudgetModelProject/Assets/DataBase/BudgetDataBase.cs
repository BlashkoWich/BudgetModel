using System.Collections.Generic;
using System.Linq;

namespace DataBase
{
    public static class BudgetDataBase
    {
        public static List<BudgetModel> Budgets { get; } = new();

        public static bool TryGetBudget(int id, out BudgetModel model)
        {
            foreach (var budget in Budgets)
            {
                if (budget.Id == id)
                {
                    model = budget;
                    return true;
                }
            }

            model = default;
            return false;
        }

        public static bool HasBudget(int id)
        {
            return Budgets.Any(budget => budget.Id == id);
        }
    }
}