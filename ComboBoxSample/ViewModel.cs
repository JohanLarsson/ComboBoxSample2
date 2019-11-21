namespace ComboBoxSample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class ViewModel : INotifyPropertyChanged
    {
        private StringComparison selected;

        public event PropertyChangedEventHandler PropertyChanged;

        public IReadOnlyList<StringComparison> StringComparisons { get; } = Enum.GetValues(typeof(StringComparison))
                                                                                .Cast<StringComparison>()
                                                                                .ToArray();

        public StringComparison Selected
        {
            get => this.selected;
            set
            {
                if (value == this.selected)
                {
                    return;
                }

                this.selected = value;
                this.OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
