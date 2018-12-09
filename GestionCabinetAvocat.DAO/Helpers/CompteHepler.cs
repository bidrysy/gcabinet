using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCabinetAvocat.DAO.Helpers
{
   public class CompteHepler
    {
        #region Thread-safe, lazy Singleton
        /// <summary>
        /// This is a thread-safe, lazy singleton. See
        //http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        /// 
        public static CompteHepler Current
        {
            get
            {
                return Nested.CompteHepler;
            }

        }
        class Nested
        {
            static Nested()
            {

            }
            internal static readonly CompteHepler CompteHepler = new CompteHepler();
        }
        #endregion

        #region Filds
        private CabinetAvocatEntities _db;
        #endregion

        #region Methods

        public Compte GetItem(int id)
        {
            using(_db = new CabinetAvocatEntities())
            {
                return _db.Compte.Find(id);
            }
        }

        public Compte GetItem(String Email)
        {
            using (_db = new CabinetAvocatEntities())
            {
                IQueryable<Compte> comptes = from compte in _db.Compte
                                             where compte.Email == Email
                                             select compte;
                return comptes.FirstOrDefault();
            }
        }

        public Compte GetItem(String Email, String MotDePasse)
        {
            using (_db = new CabinetAvocatEntities())
            {
                IQueryable<Compte> comptes = from compte in _db.Compte
                                             where compte.Email == Email && compte.MotDePasse == MotDePasse
                                             select compte;
                return comptes.FirstOrDefault();
            }
        }
        public IEnumerable<Compte> GetComptes()
        {
            using (_db = new CabinetAvocatEntities())
            {
                return _db.Compte.ToList();
            }
        }
        public void AddCompte(Compte compte)
        {
            using (_db = new CabinetAvocatEntities())
            {
                _db.Compte.Add(compte);
                _db.SaveChanges();
            }
        }
        public void Update(Compte compte)
        {
            using(_db= new CabinetAvocatEntities())
            {
                _db.Entry(compte).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
        }
        public void UpdateEtat(int id)
        {
            using(_db= new CabinetAvocatEntities())
            {

            }
        }

        #endregion
    }
}
