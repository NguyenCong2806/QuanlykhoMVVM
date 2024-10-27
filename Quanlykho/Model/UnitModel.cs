using Quanlykho.Entity;
using Quanlykho.Utilities;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Quanlykho.Model
{
    public class UnitModel : ViewModelBase
    {
        //private int _id;
        //public int Id
        //{
        //    get
        //    {
        //        return _id;
        //    }
        //    set
        //    {
        //        _id = value;
        //        OnPropertyChanged(nameof(Id));
        //    }
        //}
        //private string _displayName;

        //public string DisplayName
        //{
        //    get { return _displayName; }
        //    set
        //    {
        //        _displayName = value;
        //        OnPropertyChanged(nameof(DisplayName));
        //    }
        //}
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