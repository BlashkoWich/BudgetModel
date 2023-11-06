using System.Collections.Generic;
using Row.Scripts;
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
        }
        private void OnDisable()
        {
            budgetRowController.OnSelectToggle += OnSelectToggle;
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
            foreach (var deleteBudgetId in _deleteBuffer)
            {
                RemoveBudgetSystem.RemoveBudget(deleteBudgetId);
            }
        }
    }
}