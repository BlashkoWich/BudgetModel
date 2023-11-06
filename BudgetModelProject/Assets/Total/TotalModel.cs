using Reactive;

namespace Total
{
    public class TotalModel
    {
        public ReactiveProperty<int> Total;

        public TotalModel(int value)
        {
            Total = new ReactiveProperty<int>(value);
        }
    }
}