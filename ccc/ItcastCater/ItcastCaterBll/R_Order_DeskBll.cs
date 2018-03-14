using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.Dal;
using ItcastCater.Model;
namespace ItcastCater.Bll
{
    public class R_Order_DeskBll
    {
        R_Order_DeskDal rdo_dal=new R_Order_DeskDal();
                /// <summary>
        /// 添加一个中间表
        /// </summary>
        /// <param name="rod"></param>
        /// <returns></returns>
        public bool AddOrderDesk(R_Order_Desk rod)
        {
            return rdo_dal.AddOrderDesk(rod) > 0;
        }
    }
}
