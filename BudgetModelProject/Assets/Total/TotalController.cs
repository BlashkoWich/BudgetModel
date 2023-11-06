using System.Linq;
using DataBase;
using Services.AddRow;
using UnityEngine;

namespace Total
{
    public class TotalController : MonoBehaviour
    {
        [SerializeField] private TotalView totalView;

        private TotalModel _model;

        private void Awake()
        {
            var totalModel = new TotalModel(GetTotalValue());
            totalView.Initialize(totalModel);

            _model = totalModel;
        }
        
        private void OnEnable()
        {
            AddRemoveBudgetService.OnAddBudget += OnAddRow;
            AddRemoveBudgetService.OnRemoveBudget += OnRemoveRow;
        }
        private void OnDisable()
        {
            AddRemoveBudgetService.OnAddBudget -= OnAddRow;
            AddRemoveBudgetService.OnRemoveBudget -= OnRemoveRow;
        }

        private void OnAddRow(AddBudgetModel model)
        {
            UpdateTotal();
        }
        private void OnRemoveRow(RemoveBudgetModel model)
        {
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            var totalValue = GetTotalValue();
            _model.Total.Value = totalValue;
        }


        private static int GetTotalValue()
        {
            return BudgetDataBase.Budgets.Sum(budgetModel => budgetModel.Amount);
        }
    }
}