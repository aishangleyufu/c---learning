using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;
namespace ItcastCater.Dal
{
    public class R_Order_DeskDal
    {
        /// <summary>
        /// 添加一个中间表
        /// </summary>
        /// <param name="rod"></param>
        /// <returns></returns>
        public int AddOrderDesk(R_Order_Desk rod)
        {
            string sql = "insert into R_Order_Desk(OrderId,DeskId)values(@OrderId,@DeskId)";
            return Sqlitehelper.ExecuteNonQuery(sql,new SQLiteParameter("@OrderId",rod.OrderId),new SQLiteParameter("@DeskId",rod.DeskId));
        }
    }
}
