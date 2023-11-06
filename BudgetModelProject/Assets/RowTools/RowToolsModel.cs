using System;
using Reactive;

namespace RowTools
{
    public class RowToolsModel
    {
        public ReactiveProperty<bool> Show { get; } = new();
        
        public event Action OnDeleteClick;

        public void InvokeDelete()
        {
            OnDeleteClick?.Invoke();
        }
    }
}