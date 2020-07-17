using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class MasterConsigmentService
    {
        private MasterConsigmentService()
        {
        }

        private static MasterConsigmentService _instance;

        public static MasterConsigmentService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MasterConsigmentService();
                return _instance;
            }
        }
    }
}
