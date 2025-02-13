using System;
using Modules.UI;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Views
{
    public class PlanetView : MonoBehaviour
    {
        public event Action OnClick
        {
            add => _button.OnClick += value;
            remove => _button.OnClick -= value;
        }
        
        public event Action OnHold
        {
            add => _button.OnHold += value;
            remove => _button.OnHold -= value;
        }

        [SerializeField] private Image _icon;
        
        [SerializeField] private GameObject _lock;
        [SerializeField] private GameObject _coin;

        [SerializeField] private GameObject _income;
        [SerializeField] private Image _incomeProgress;
        [SerializeField] private TMP_Text _incomeText;

        [SerializeField] private GameObject _price;
        [SerializeField] private TMP_Text _priceText;

        [SerializeField] private SmartButton _button;

        public void SetIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }
        
        [Button]
        public void ShowLock(bool show)
        {
            _lock.SetActive(show);
        }

        [Button]
        public void ShowCoin(bool show)
        {
            _coin.SetActive(show);
        }

        [Button]
        public void ShowIncome(bool show)
        {
            _income.SetActive(show);
        }

        [Button]
        public void SetIncomeProgress(float progress)
        {
            _incomeProgress.fillAmount = progress;
        }
        
        [Button]
        public void SetIncomeTime(string text)
        {
            _incomeText.text = text;
        }

        [Button]
        public void ShowPrice(bool show)
        {
            _price.SetActive(show);
        }

        [Button]
        public void SetPrice(string text)
        {
            _priceText.text = text;
        }
    }
}