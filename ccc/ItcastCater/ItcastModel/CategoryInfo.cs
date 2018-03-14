using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItcastCater.Model
{
    public class CategoryInfo
    {
        private int _catid;

        public int Catid
        {
            get { return _catid; }
            set { _catid = value; }
        }

        private string _catname;

        public string Catname
        {
            get { return _catname; }
            set { _catname = value; }
        }


        private string _catnum;

        public string Catnum
        {
            get { return _catnum; }
            set { _catnum = value; }
        }
        private string _remark;

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private int _delflag;

        public int Delflag
        {
            get { return _delflag; }
            set { _delflag = value; }
        }
        private DateTime _subtime;

        public DateTime Subtime
        {
            get { return _subtime; }
            set { _subtime = value; }
        }
        private int _subby;

        public int Subby
        {
            get { return _subby; }
            set { _subby = value; }
        }

    }
}
