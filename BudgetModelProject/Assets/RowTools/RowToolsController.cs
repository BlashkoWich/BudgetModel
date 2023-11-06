using System.Collections.Generic;
using Row.Scripts;
using Services.AddRow;
using Systems;
using UnityEngine;

namespace RowTools
{
    public class RowToolsController : MonoBehaviour
    {
        [SerializeField] private RowToolsView view;
        [SerializeField] private BudgetRowController budgetRowController;

        private readonly List<int> _deleteBuffer = new();
        private RowToolsModel _model;
        
        private void Awake()
        {
            var model = new RowToolsModel();
            view.Initialize(model);

            model.OnDeleteClick += Delete;
            _model = model;
        }

        private void OnEnable()
        {
            budgetRowController.OnSelectToggle += OnSelectToggle;
            AddRemoveBudgetService.OnRemoveBudget += OnRemove;
        }
        private void OnDisable()
        {
            budgetRowController.OnSelectToggle += OnSelectToggle;
            AddRemoveBudgetService.OnRemoveBudget -= OnRemove;
        }

        private void OnRemove(RemoveBudgetModel model)
        {
            OnSelectToggle();
        }

        private void OnSelectToggle()
        {
            budgetRowController.GetSelectedRows(_deleteBuffer);
            var hasSelect = _deleteBuffer.Count > 0;
            _model.Show.Value = hasSelect;
        }

        private void Delete()
        {
            budgetRowController.GetSelectedRows(_deleteBuffer);
            for (var index = 0; index < _deleteBuffer.Count; index++)
            {
                var deleteBudgetId = _deleteBuffer[index];
                RemoveBudgetSystem.RemoveBudget(deleteBudgetId);
            }
        }
    }
}