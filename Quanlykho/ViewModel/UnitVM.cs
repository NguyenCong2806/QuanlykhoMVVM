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

        private ICommand _previousPageCommand;

        public ICommand PreviousPageCommand
        {
            get
            {
                if (_previousPageCommand == null)
                    _previousPageCommand = new AsyncRelayCommand<Unit>(param => PreviousPageAsync(), null);

                return _previousPageCommand;
            }
        }

        private ICommand _nextPageCommand;

        public ICommand NextPageCommand
        {
            get
            {
                if (_nextPageCommand == null)
                    _nextPageCommand = new AsyncRelayCommand<Unit>(param => NextPageAsync(), null);

                return _nextPageCommand;
            }
        }
        public UnitModel Unitview { get; set; }
        private UnitRepository _unitrepository;
        private QuanLyKhoKteamEntities _quanLyKhoKteamEntities;
        public PagedList<Unit, int> PagedList;

        public UnitVM()
        {
            Unitview = new UnitModel();
            PagedList = new PagedList<Unit, int>()
            {
                KeyWord = string.Empty,
                PageNumber = 1,
                RecordsPerPage = 5,
                KeySelector = (d => d.Id)
            };
            _quanLyKhoKteamEntities = new QuanLyKhoKteamEntities();
            _unitrepository = new UnitRepository(_quanLyKhoKteamEntities);
            GetAll();
        }

        private async void GetAll()
        {
            var data = await _unitrepository.GetAllUnit(PagedList);

            Unitview.PageSize = data.PageCount;
            Unitview.PageIndex = PagedList.PageNumber;
            Pagination(PagedList.PageNumber);
            foreach (var item in data.ListData)
            {
                Unitview.UnitModels.Add(item);
            }
        }

        private async Task SaveData()
        {
            if (Unitview.Units.Id <= 0)
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

        private async Task NextPageAsync()
        {
            await GetAllAsync(string.Empty, PagedList.PageNumber + 1);
        }
        private async Task PreviousPageAsync()
        {
            await GetAllAsync(string.Empty, PagedList.PageNumber - 1);
        }
        private async Task GetAllAsync(string keyWord, int pageNumber)
        {
            PagedList.PageNumber = pageNumber;
            PagedList.KeyWord = keyWord;
           
            Unitview.UnitModels = new ObservableCollection<Unit>();
            var data = await _unitrepository.GetAllUnit(PagedList);

            Pagination(pageNumber);
            foreach (var item in data.ListData)
            {
                Unitview.UnitModels.Add(item);
            }
        }

        private void Pagination(int pageNumber)
        {
            if (pageNumber == 1)
            {
                Unitview.IsEnablePrevious = false;
                Unitview.IsEnableNext = true;
            }
            if (pageNumber == Unitview.PageSize)
            {
                Unitview.IsEnableNext = false;
                Unitview.IsEnablePrevious = true;
            }
            if(pageNumber >1 && pageNumber < Unitview.PageSize)
            {
                Unitview.IsEnableNext = true;
                Unitview.IsEnablePrevious = true;
            }
        }
    }
}