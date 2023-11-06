using TMPro;
using UnityEngine;

namespace Total
{
    public class TotalView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI totalTMPro;
        
        public void Initialize(TotalModel model)
        {
            OnChangeValue(model.Total.Value);
            model.Total.OnChangeValue += OnChangeValue;
        }

        private void OnChangeValue(int value)
        {
            totalTMPro.text = value.ToString();
        }
    }
}