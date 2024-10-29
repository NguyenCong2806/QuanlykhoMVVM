using Quanlykho.Utilities;
using System;
using System.Linq.Expressions;
using System.Windows.Input;

namespace Quanlykho.Model
{
    public class PagedList<T,Tkey> : ViewModelBase
    {
        /// <summary>
        /// Số trang
        /// </summary>
        private int _pageNumber;
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = value;
                OnPropertyChanged(nameof(PageNumber));
            }
        }
        /// <summary>
        /// Bản ghi trên mỗi trang
        /// </summary>
        private int _recordsPerPage;
        public int RecordsPerPage
        {
            get
            {
                return _recordsPerPage;
            }
            set
            {
                _recordsPerPage = value;
                OnPropertyChanged(nameof(RecordsPerPage));
            }
        }
        private string _keyword;

        public string KeyWord
        {
            get { return _keyword; }
            set
            {
                _keyword = value;
                OnPropertyChanged(nameof(KeyWord));
            }
        }
        public Expression<Func<T, Tkey>> KeySelector;
    }
}