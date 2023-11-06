using System;
using Reactive;

namespace Row.Scripts
{
    public class BudgetRowModel
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        
        public ReactiveProperty<bool> Select { get; }
        public event Action OnDestroy;
        public event Action<BudgetRowModel> OnClick;

        public BudgetRowModel(int id, int amount, bool select)
        {
            Id = id;
            Amount = amount;
            Select = new ReactiveProperty<bool>(select);
        }


        public void InvokeDestroy()
        {
            OnDestroy?.Invoke();
        }

        public void InvokeClick()
        {
            OnClick?.Invoke(this);
        }
    }
}