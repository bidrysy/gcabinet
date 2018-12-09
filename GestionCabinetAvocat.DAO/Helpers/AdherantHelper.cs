using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCabinetAvocat.DAO.Helpers
{
    public class AdherentHelper
    {
        #region Thread-safe, lazy Singleton
        /// <summary>
        /// This is a thread-safe, lazy singleton. See
        //http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        /// 
        public static AdherentHelper Current
        {
            get
            {
                return Nested.AdherentHelper;
            }

        }
        class Nested
        {
            static Nested()
            {

            }
            internal static readonly AdherentHelper AdherentHelper = new AdherentHelper();
        }
        #endregion
        #region Filds
        private CabinetAvocatEntities _db;
        #endregion
        #region Methods

        public Adherent GetItem(int id)
        {
            using (_db = new CabinetAvocatEntities())
            {
                return _db.Adherent.Find(id);
            }
        }

        public Adherent GetItem(String Email)
        {
            using (_db = new CabinetAvocatEntities())
            {
                IQueryable<Adherent> adherents = from adherent in _db.Adherent
                                             where adherent.Email == Email
                                             select adherent;
                return adherents.FirstOrDefault();
            }
        }

       
        public IEnumerable<Adherent> GetAll()
        {
            using (_db = new CabinetAvocatEntities())
            {
                return _db.Adherent.ToList();
            }
        }
        public void Add(Adherent adherent)
        {
            using (_db = new CabinetAvocatEntities())
            {
                _db.Adherent.Add(adherent);
                _db.SaveChanges();
            }
        }
        public void Update(Adherent adherant)
        {
            using (_db = new CabinetAvocatEntities())
            {
                _db.Entry(adherant).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }
       
        #endregion
    }
}
