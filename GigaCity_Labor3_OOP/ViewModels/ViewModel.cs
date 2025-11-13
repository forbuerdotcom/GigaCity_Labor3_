using System.ComponentModel;
using System.Runtime.CompilerServices;
using GigaCity_Labor3_OOP.Models;

namespace GigaCity_Labor3_OOP.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MapModel Map { get; private set; }

        private CellViewModel _selectedCell;
        public CellViewModel SelectedCell
        {
            get => _selectedCell;
            set
            {
                _selectedCell = value;
                OnPropertyChanged();
            }
        }

        private int _population = 0;
        public int Population
        {
            get => _population;
            set
            {
                _population = value;
                OnPropertyChanged();
            }
        }

        private int _currentYear = 0;
        public int CurrentYear
        {
            get => _currentYear;
            set
            {
                _currentYear = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Map = new MapModel();
            // Выбираем первую ячейку по умолчанию
            SelectedCell = Map.Cells.FirstOrDefault();
        }

        // Команды для добавления лет
        public void AddYears(int years)
        {
            CurrentYear += years;
            // Здесь можно добавить логику, которая будет выполняться при смене года
            OnPropertyChanged(nameof(CurrentYear));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}