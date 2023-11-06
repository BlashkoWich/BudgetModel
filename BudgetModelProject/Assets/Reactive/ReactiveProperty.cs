using System;

namespace Reactive
{
    public class ReactiveProperty<T>
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (_value.Equals(value)) 
                    return;
                
                _value = value;
                OnChangeValue?.Invoke(value);
            }
        }

        public event Action<T> OnChangeValue;

        public ReactiveProperty(T value)
        {
            _value = value;
        }
        public ReactiveProperty()
        {
        }
    }
}