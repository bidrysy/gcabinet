using GestionCabinetAvocat.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionCabinetAvocat.ViewModels
{
    public class CreateAccountViewModel
    {

        [Required]
        public Compte Compte { get; set; }

        [Required]
        public string RepeatMotDePasse { get; set; }

        public string EditMotDePasse { get; set; }
        public string EditRepeatMotDePasse { get; set; }

        public IEnumerable<AccountType> AccountTypes
        {
            get
            {
                return (AccountType[])Enum.GetValues(typeof(AccountType));
            }
        }
    }
}