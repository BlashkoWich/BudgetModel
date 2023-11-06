using System;

namespace Services.AddRow
{
    public static class AddRemoveBudgetService
    {
        public static event Action<AddBudgetModel> OnAddBudget;
        public static event Action<RemoveBudgetModel> OnRemoveBudget;

        public static void InvokeAdd(AddBudgetModel model)
        {
            OnAddBudget?.Invoke(model);
        }
        public static void InvokeRemove(RemoveBudgetModel model)
        {
            OnRemoveBudget?.Invoke(model);
        }
    }
}