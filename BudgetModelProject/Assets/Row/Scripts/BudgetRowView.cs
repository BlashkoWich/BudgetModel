using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Row.Scripts
{
    public class BudgetRowView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI amountTMPro;
        [SerializeField] private Button button;
        [SerializeField] private Image selectIndicator;

        private BudgetRowModel Model { get; set; }

        public void Initialize(BudgetRowModel model)
        {
            if (Model != null)
            {
                Model.OnDestroy -= Destroy;
                Model.Select.OnChangeValue -= ToggleSelectIndicator;
            }

            ToggleSelectIndicator(model.Select.Value);
            InitAmount();
            Subscribes();

            Model = model;

            void InitAmount()
            {
                amountTMPro.text = model.Amount.ToString(CultureInfo.InvariantCulture);
                var isMinus = model.Amount < 0;
                amountTMPro.faceColor = isMinus ? Color.red : Color.green;
            }

            void Subscribes()
            {
                model.OnDestroy += Destroy;
                model.Select.OnChangeValue += ToggleSelectIndicator;
            }
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }

        private void ToggleSelectIndicator(bool isShow)
        {
            selectIndicator.gameObject.SetActive(isShow);
        }

        private void OnEnable()
        {
            button.onClick.AddListener(Click);
        }

        private void OnDisable()
        {
            button.onClick.RemoveAllListeners();
        }

        private void Click()
        {
            Model.InvokeClick();
        }
    }
}