using Quanlykho.Entity;
using Quanlykho.Utilities;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Quanlykho.Model
{
    public class UnitModel : ViewModelBase
    {
        private int _pageIndex {  get; set; }
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                _pageIndex = value;
                OnPropertyChanged(nameof(PageIndex));
            }
        }
        private int _pageSize { get; set; }
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                OnPropertyChanged(nameof(PageSize));
            }
        }
        private Unit _units;
        public Unit Units 
        { 
            get { return _units; }
            set 
            { 
                _units = value;
                OnPropertyChanged(nameof(Units));
            }
        }
        private bool _isEnableNext;
        public bool IsEnableNext
        {
            get { return _isEnableNext; }
            set
            {
                _isEnableNext = value;
                OnPropertyChanged(nameof(IsEnableNext));
            }
        }
        private bool _isEnablePrevious;
        public bool IsEnablePrevious
        {
            get { return _isEnablePrevious; }
            set
            {
                _isEnablePrevious = value;
                OnPropertyChanged(nameof(IsEnablePrevious));
            }
        }
        private ObservableCollection<Unit> _unitModels;
        public ObservableCollection<Unit> UnitModels
        {
            get
            {
                return _unitModels;
            }
            set
            {
                _unitModels = value;
                OnPropertyChanged(nameof(UnitModels));
            }
        }
        public UnitModel()
        {
            _units = new Unit();
            _unitModels = new ObservableCollection<Unit>();
        }
        private void UnitModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(UnitModels));
        }
    }
}