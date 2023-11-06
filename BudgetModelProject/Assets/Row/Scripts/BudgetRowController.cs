using System;
using System.Collections.Generic;
using System.Linq;
using DataBase;
using Services.AddRow;
using UnityEngine;
using UnityEngine.Events;

namespace Row.Scripts
{
    public class BudgetRowController : MonoBehaviour
    {
        [SerializeField] private BudgetRowView rowPrefab;
        [SerializeField] private RectTransform rowParent;

        private readonly List<BudgetRowModel> rows = new();

        public event Action OnSelectToggle;

        public void GetSelectedRows(List<int> buffer)
        {
            buffer.Clear();

            buffer.AddRange(from row in rows where row.Select.Value select row.Id);
        }
        
        private void OnEnable()
        {
            AddRemoveBudgetService.OnAddBudget += CreateInfoBudget;
            AddRemoveBudgetService.OnRemoveBudget += RemoveInfoBudget;
        }
        private void OnDisable()
        {
            AddRemoveBudgetService.OnAddBudget -= CreateInfoBudget;
            AddRemoveBudgetService.OnRemoveBudget -= RemoveInfoBudget;
        }

        private void CreateInfoBudget(AddBudgetModel model)
        {
            var hasBudget = BudgetDataBase.TryGetBudget(model.Id, out var budgetModel);
            if (!hasBudget)
                return;
            
            var infoRowView = Instantiate(rowPrefab, rowParent);
            var budgetRowModel = new BudgetRowModel(budgetModel.Id, budgetModel.Amount, false);
            budgetRowModel.OnClick += OnClick;
            infoRowView.Initialize(budgetRowModel);
            rows.Add(budgetRowModel);
        }

        private void OnClick(BudgetRowModel model)
        {
            model.Select.Value = !model.Select.Value;
            
            OnSelectToggle?.Invoke();
        }

        private void RemoveInfoBudget(RemoveBudgetModel removeModel)
        {
            for (var index = 0; index < rows.Count; index++)
            {
                var row = rows[index];
                if (row.Id != removeModel.BudgetModel.Id) 
                    continue;

                row.OnClick -= OnClick;
                row.InvokeDestroy();
                rows.RemoveAt(index);
                break;
            }
        }
    }
}