using TMPro;
using UnityEngine;

namespace Game.Views
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _valueText;

        public void SetValue(string value)
        {
            _valueText.text = value;
        }
    }
}