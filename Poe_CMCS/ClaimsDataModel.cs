using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace ClaimManagement
{
    public class ClaimsDataModel
    {
        private static ClaimsDataModel _instance;
        public ObservableCollection<Claim> ClaimList { get; private set; }

        private ClaimsDataModel()
        {
            ClaimList = new ObservableCollection<Claim>();
        }

        public static ClaimsDataModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClaimsDataModel();
                }
                return _instance;
            }
        }
    }
}

