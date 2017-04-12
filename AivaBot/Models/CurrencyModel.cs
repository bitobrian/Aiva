﻿using PropertyChanged;
using System.Windows.Media;

namespace AivaBot.Models {
    [ImplementPropertyChanged]
    class CurrencyModel {
        public string BankheistText { get; set; }
        public SolidColorBrush BankheistTileColor { get; set; }
        public bool AddCurrencyOnOff { get; set; }
        public AsyncObservableCollection<Database.Currency> UserList { get; set; }
    }
}
