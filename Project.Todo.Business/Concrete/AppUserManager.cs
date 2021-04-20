using Project.Todo.Business.Interfaces;
using Project.Todo.DataAccess.Interfaces;
using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }
        public List<AppUser> GetirAdminOlmayanlar()
        {
            return _appUserDal.GetirAdminOlmayanlar();
        }

        public List<AppUser> GetirAdminOlmayanlar(out int toplamSayfa, string aranacakKelime, int aktifSayfa)
        {
            return _appUserDal.GetirAdminOlmayanlar(out toplamSayfa,aranacakKelime, aktifSayfa);
        }

        public List<DualHelper> GetirEnCokGorevdeCalisanPersoneller()
        {
            return _appUserDal.GetirEnCokGorevdeCalisanPersoneller();
        }

        public List<DualHelper> GetirEnCokGorevTamamlamisPersoneller()
        {
            return _appUserDal.GetirEnCokGorevTamamlamisPersoneller();
        }
    }
}
