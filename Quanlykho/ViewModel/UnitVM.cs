using Quanlykho.Entity;
using Quanlykho.Model;
using Quanlykho.Repositorys;
using Quanlykho.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace Quanlykho.ViewModel
{
    public class UnitVM
    {

        /// <summary>
        /// Notifier 
        /// </summary>
        private Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });




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

        private ICommand _findDataCommand;

        public ICommand FindDataCommand
        {
            get
            {
                if (_findDataCommand == null)
                    _findDataCommand = new AsyncRelayCommand<Unit>(param => FindDataAsync(), null);

                return _findDataCommand;
            }
        }

        private ICommand _removeDataCommand;

        public ICommand RemoveDataCommand
        {
            get
            {
                if (_removeDataCommand == null)
                    _removeDataCommand = new AsyncRelayCommand<object>(param => RemoveAsync(param), null);

                return _removeDataCommand;
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
                RecordsPerPage = 7,
                KeySelector = (d => d.Id),
                KeyFind = new List<Expression<Func<Unit, bool>>>()
            };
            _quanLyKhoKteamEntities = new QuanLyKhoKteamEntities();
            _unitrepository = new UnitRepository(_quanLyKhoKteamEntities);
            GetAll();
        }

        private async void GetAll()
        {
            PagedList.PageNumber = 1;
            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }

        private async Task SaveData()
        {
            if (Unitview.Units.Id <= 0)
            {
                await _unitrepository.AddUnit(Unitview.Units);
                notifier.ShowSuccess("Them moi thanh cong");
            }
            else
            {
                await _unitrepository.UpdateUnit(Unitview.Units);
            }

            await GetAllAsync(string.Empty, PagedList.PageNumber);
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
            Unitview.UnitModels = new ObservableCollection<Unit>();
            PagedList.PageNumber = Unitview.PageIndex = pageNumber;
            //Find keyword//
            PagedList.KeyWord = keyWord;
            if (!string.IsNullOrEmpty(keyWord))
            {
                PagedList.KeyFind = new List<Expression<Func<Unit, bool>>>();
                PagedList.KeyFind.Add(x => x.DisplayName.Contains(keyWord));
            }
            ///Get data//
            var data = await _unitrepository.GetAllUnit(PagedList);
            //Pagding//
            Unitview.PageSize = data.PageCount;
           
            Pagination(pageNumber);

            foreach (var item in data.ListData)
            {
                Unitview.UnitModels.Add(item);
            }
        }

        private async Task FindDataAsync()
        {
            if (!string.IsNullOrEmpty(Unitview.Units.DisplayName))
            {
                await GetAllAsync(Unitview.Units.DisplayName, PagedList.PageNumber);
            }
            else
            {
                PagedList.KeyFind = new List<Expression<Func<Unit, bool>>>();
                await GetAllAsync(string.Empty, PagedList.PageNumber);
            }
        }

        private void Pagination(int pageNumber)
        {
            if (pageNumber == 1)
            {
                Unitview.IsEnablePrevious = false;
                Unitview.IsEnableNext = true;
                return;
            }
            if (Unitview.PageSize == pageNumber && pageNumber==1)
            {
                Unitview.IsEnablePrevious = false;
                Unitview.IsEnableNext = false;
                return;
            }
            if (pageNumber == Unitview.PageSize && pageNumber > 1)
            {
                Unitview.IsEnableNext = false;
                Unitview.IsEnablePrevious = true;
                return;
            }
            if (pageNumber > 1 && pageNumber < Unitview.PageSize)
            {
                Unitview.IsEnableNext = true;
                Unitview.IsEnablePrevious = true;
                return;
            }
        }

        /// <summary>
        /// Remove data unit
        /// </summary>
        /// <param name="id"></param>
        private async Task RemoveAsync(object o)
        {
            var item = o as Unit;
            await _unitrepository.DeleteUnit(U => U.Id == item.Id);
            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }
    }
}