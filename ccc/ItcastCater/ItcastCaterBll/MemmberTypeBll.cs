using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.Dal;
using ItcastCater.Model;

namespace ItcastCater.Bll
{
    public class MemmberTypeBll
    {
        MemmberTypeDal daltype = new MemmberTypeDal();
        public List<MemmberType> GetAllMemmberTypeByDelflag(int delFlag)
        {
            return daltype.GetAllMemmberTypeByDelflag(delFlag);
        }
    }
}
