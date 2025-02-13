using System;
using Game.Views;
using Modules.Money;
using Zenject;

namespace Game.Presenters
{
    public class MoneyPresenter : IInitializable, IDisposable
    {
        private readonly MoneyView _view;
        private readonly IMoneyStorage _storage;

        public MoneyPresenter(MoneyView view, IMoneyStorage storage)
        {
            _view = view;
            _storage = storage;
        }

        public void Initialize()
        {
            _storage.OnMoneyChanged += OnMoneyChanged;
            UpdateMoney();
        }

        public void Dispose()
        {
            _storage.OnMoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(int newValue, int prevValue)
        {
            UpdateMoney();
        }

        private void UpdateMoney()
        {
            _view.SetValue(_storage.Money.ToString());
        }
    }
}