using Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BudgetController
{
    public class BudgetController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField amountInput;
        [SerializeField] private Button increaseButton;

        private void OnEnable()
        {
            increaseButton.onClick.AddListener(OnIncrease);
        }
        private void OnDisable()
        {
            increaseButton.onClick.RemoveListener(OnIncrease);
        }

        private void OnIncrease()
        {
            var tryGetInput = TryGetInput(out var increase);
            if(tryGetInput)
                AddBudgetSystem.AddBudget(increase);
        }
        
        private bool TryGetInput(out int input)
        {
            var tryParse = int.TryParse(amountInput.text, out var result);
            if (tryParse)
            {
                input = result;
                return true;
            }

            input = default;
            return false;
        }
    }
}