using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItcastCater.Model
{
    //select MemType,MemTpName from MemmberType
    /// <summary>
    /// 会员表格
    /// </summary>
    public class MemmberType
    {
        private int _memType;

        public int MemType
        {
            get { return _memType; }
            set { _memType = value; }
        }
        private string _memTpName;

        public string MemTpName
        {
            get { return _memTpName; }
            set { _memTpName = value; }
        }
    }
}
