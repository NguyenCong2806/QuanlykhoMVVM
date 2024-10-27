using Quanlykho.Entity;
using Quanlykho.Model;
using Quanlykho.Repositorys;
using Quanlykho.Utilities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quanlykho.ViewModel
{
    public class UnitVM
    {
        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new AsyncRelayCommand<Unit>(param => SaveData(), null);

                return _saveCommand;
            }
        }

        public UnitModel Unitview { get; set; }
        private UnitRepository _unitrepository;
        private QuanLyKhoKteamEntities _quanLyKhoKteamEntities;

        public UnitVM()
        {
            Unitview = new UnitModel();
            _quanLyKhoKteamEntities = new QuanLyKhoKteamEntities();
            _unitrepository = new UnitRepository(_quanLyKhoKteamEntities);
            GetAll();
        }

        private async void GetAll()
        {
            Unitview.UnitModels = new ObservableCollection<Unit>();

            var data = await _unitrepository.GetAllUnit();
            foreach (var item in data)
            {
                Unitview.UnitModels.Add(item);
            }
        }

        private async Task SaveData()
        {
            if(Unitview.Units.Id<=0)
            {
                await _unitrepository.AddUnit(Unitview.Units);
            }
            else
            {
                await _unitrepository.UpdateUnit(Unitview.Units);
            }
            
            GetAll();
            Unitview.Units = new Unit();
        }
    }
}