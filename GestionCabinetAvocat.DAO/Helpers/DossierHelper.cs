using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCabinetAvocat.DAO.Helpers
{
    public class DossierHelper
    {

        #region Thread-safe, lazy Singleton
        /// <summary>
        /// This is a thread-safe, lazy singleton. See
        //http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        /// 
        public static DossierHelper Current
        {
            get
            {
                return Nested.DossierHelper;
            }

        }
        class Nested
        {
            static Nested()
            {

            }
            internal static readonly DossierHelper DossierHelper = new DossierHelper();
        }
        #endregion
        #region Filds
        private CabinetAvocatEntities _db;
        #endregion
        #region Methods

        public Dossier GetItem(int id)
        {
            using (_db = new CabinetAvocatEntities())
            {
                return _db.Dossier.Find(id);
            }
        }

      


        public IEnumerable<Dossier> GetAll()
        {
            using (_db = new CabinetAvocatEntities())
            {
                return _db.Dossier.ToList();
            }
        }
        public void Add(Dossier dossier)
        {
            using (_db = new CabinetAvocatEntities())
            {
                _db.Dossier.Add(dossier);
                _db.SaveChanges();
            }
        }
        public void Update(Dossier dossier)
        {
            using (_db = new CabinetAvocatEntities())
            {
                _db.Entry(dossier).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

        #endregion
    }
}
