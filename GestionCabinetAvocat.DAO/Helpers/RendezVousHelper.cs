using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCabinetAvocat.DAO.Helpers
{
    public class RendezVousHelper
    {

        #region Thread-safe, lazy Singleton
        /// <summary>
        /// This is a thread-safe, lazy singleton. See
        //http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        /// 
        public static RendezVousHelper Current
        {
            get
            {
                return Nested.RendezVousHelper;
            }

        }
        class Nested
        {
            static Nested()
            {

            }
            internal static readonly RendezVousHelper RendezVousHelper = new RendezVousHelper();
        }
        #endregion
        #region Filds
        private CabinetAvocatEntities _db;
        #endregion
        #region Methods

        public RendezVous GetItem(int id)
        {
            using (_db = new CabinetAvocatEntities())
            {
                return _db.RendezVous.Find(id);
            }
        }

        public IEnumerable<RendezVous> GetIAll(String NomJuriste)
        {
            using (_db = new CabinetAvocatEntities())
            {
                IQueryable<RendezVous> rendezVous = from rendezvous in _db.RendezVous
                                             where rendezvous.NomJuriste == NomJuriste
                                             select rendezvous;
                return rendezVous;
            }
        }

       
        public IEnumerable<RendezVous> GetAll()
        {
            using (_db = new CabinetAvocatEntities())
            {
                return _db.RendezVous.ToList();
            }
        }
        public void Add(RendezVous rendezVous)
        {
            using (_db = new CabinetAvocatEntities())
            {
                _db.RendezVous.Add(rendezVous);
                _db.SaveChanges();
            }
        }
        public void Update(RendezVous rendezVous)
        {
            using (_db = new CabinetAvocatEntities())
            {
                _db.Entry(rendezVous).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }

        #endregion

    }
}
