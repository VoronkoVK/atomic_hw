using System;
using Game.Presenters.PlanetPopup;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Views
{
    public class PlanetPopupView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _population;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _income;

        [Space] [SerializeField] private GameObject _price;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private TMP_Text _upgradeText;

        [Space] [SerializeField] private Button _closeBtn;
        [SerializeField] private Button _upgradeBtn;

        [Inject] private PlanetPopupPresenter _presenter;

        private void OnEnable()
        {
            _upgradeBtn.onClick.AddListener(OnUpgradeClick);
            _closeBtn.onClick.AddListener(Hide);
            
            _presenter.OnPlanetChanged += UpdatePlanet;
            _presenter.OnUnlocked += UpdatePlanet;
            _presenter.OnUpgraded += OnUpgraded;
            _presenter.OnPopulationChanged += UpdatePopulation;
            _presenter.OnIncomeChanged += UpdateIncome;
            _presenter.OnMoneyChanged += UpdateUpgradeBtnInteractable;

            UpdatePlanet();
        }

        private void OnDisable()
        {
            _upgradeBtn.onClick.RemoveListener(OnUpgradeClick);
            _closeBtn.onClick.RemoveListener(Hide);
            
            _presenter.OnPlanetChanged -= UpdatePlanet;
            _presenter.OnUnlocked -= UpdatePlanet;
            _presenter.OnUpgraded -= OnUpgraded;
            _presenter.OnPopulationChanged -= UpdatePopulation;
            _presenter.OnIncomeChanged -= UpdateIncome;
            _presenter.OnMoneyChanged -= UpdateUpgradeBtnInteractable;
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnUpgraded()
        {
            UpdateLevel();
            UpdateUpgradeBtnText();
            UpdateUpgradeBtnInteractable();
        }
        
        private void OnUpgradeClick()
        {
            _presenter.UnlockOrUpgrade();
        }

        private void UpdatePlanet()
        {
            _icon.sprite = _presenter.Sprite;
            _title.text = _presenter.Title;
            UpdatePopulation();
            UpdateLevel();
            UpdateIncome();
            UpdateUpgradeBtnText();
            UpdateUpgradeBtnInteractable();
        }

        private void UpdatePopulation()
        {
            _population.text = _presenter.Population;
        }

        private void UpdateLevel()
        {
            _level.text = _presenter.Level;
        }

        private void UpdateIncome()
        {
            _income.text = _presenter.Income;
        }

        private void UpdateUpgradeBtnText()
        {
            _priceText.text = _presenter.Price;
            _upgradeText.text = _presenter.UpgradeText;

            if (_presenter.IsMaxLevel)
            {
                _price.gameObject.SetActive(false);
                _upgradeText.verticalAlignment = VerticalAlignmentOptions.Bottom;
                return;
            }

            _price.gameObject.SetActive(!_presenter.IsMaxLevel);
            _upgradeText.verticalAlignment = VerticalAlignmentOptions.Middle;
        }

        private void UpdateUpgradeBtnInteractable()
        {
            if (_presenter.IsMaxLevel)
            {
                _upgradeBtn.interactable = false;
                return;
            }

            _upgradeBtn.interactable = _presenter.CanUnlockOrUpgrade;
        }
    }
}