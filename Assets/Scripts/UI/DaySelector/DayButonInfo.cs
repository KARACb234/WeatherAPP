using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class DayButonInfo
    {
        private readonly DateTime _date;
        public DateTime GetDate => _date;
        private readonly int _butonIndex;
        public int GetButonIndex => _butonIndex;

        public DayButonInfo(DateTime date, int butonIndex)
        {
            _date = date;
            _butonIndex = butonIndex;
        }
    }
}
