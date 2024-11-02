using Quanlykho.Entity;

namespace Quanlykho.Common
{
    public static class Instance
    {
        private static QuanLyKhoKteamEntities _quanLyKhoKteamEntities;
        public static QuanLyKhoKteamEntities QuanLyKhoKteamEntities()
        {
            if(_quanLyKhoKteamEntities == null)
            {
                _quanLyKhoKteamEntities = new QuanLyKhoKteamEntities(); 
            }
            return _quanLyKhoKteamEntities;
        }
    }
}