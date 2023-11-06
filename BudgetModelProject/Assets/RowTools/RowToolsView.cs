using UnityEngine;
using UnityEngine.UI;

namespace RowTools
{
    public class RowToolsView : MonoBehaviour
    {
        [SerializeField] private RectTransform toolsParent;
        [SerializeField] private Button deleteButton;

        private RowToolsModel _model;

        public void Initialize(RowToolsModel model)
        {
            ToggleShow(model.Show.Value);
            model.Show.OnChangeValue += ToggleShow;
            
            _model = model;
        }

        private void ToggleShow(bool isShow)
        {
            toolsParent.gameObject.SetActive(isShow);
        }

        private void OnEnable()
        {
            deleteButton.onClick.AddListener(OnClickDelete);
        }

        private void OnDisable()
        {
            deleteButton.onClick.RemoveAllListeners();
        }

        private void OnClickDelete()
        {
            _model.InvokeDelete();
        }
    }
}