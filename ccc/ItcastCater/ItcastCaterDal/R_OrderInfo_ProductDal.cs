using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.Dal
{
    public class R_OrderInfo_ProductDal
    {
        /// <summary>
        /// 退菜
        /// </summary>
        /// <param name="rOrderId"></param>
        /// <returns></returns>
        public int SoftDeleteROrderProName(int rOrderId)
        {
            
            string sql = "update R_OrderInfo_Product set DelFlag=1 where ROrderProId=@ROrderProId";
            return Sqlitehelper.ExecuteNonQuery(sql,new SQLiteParameter("@ROrderProId",rOrderId));
        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="rop"></param>
        /// <returns></returns>
        public int AddROrderInfoProduct(R_OrderInfo_Product rop)
        {
            string sql = "insert into R_OrderInfo_Product(OrderId,ProId,DelFlag,SubTime,State,UnitCount) values (@OrderId,@ProId,@DelFlag,@SubTime,@State,@UnitCount)";
            SQLiteParameter[] ps = { 
                   new SQLiteParameter("@OrderId",rop.OrderId),
                   new SQLiteParameter("@ProId",rop.ProId),//冗余属性
                   new SQLiteParameter("@DelFlag",rop.DelFlag),
                   new SQLiteParameter("@SubTime",rop.SubTime),
                   new SQLiteParameter("@State",rop.State),
                   new SQLiteParameter("@UnitCount",rop.UnitCount)
                                  };
            return Sqlitehelper.ExecuteNonQuery(sql, ps);
        }
        /// <summary>
        /// 根据订单的id查询该订单的总金额和数量
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public R_OrderInfo_Product GetMoneyAndCount(int orderId)
        {
            string sql = "select count(*),sum(ProPrice*UnitCount) from R_OrderInfo_Product inner join ProductInfo on ProductInfo.ProId= R_OrderInfo_Product.ProId where R_OrderInfo_Product.DelFlag=0 and OrderId=" + orderId;

            R_OrderInfo_Product rop = null;
            using (SQLiteDataReader reader = Sqlitehelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rop = new R_OrderInfo_Product();
                        rop.CT = Convert.ToInt32(reader[0]);

                        if (DBNull.Value == reader[1])
                        {
                            rop.MONEY = 0;
                        }
                        else
                        {
                            rop.MONEY = Convert.ToDecimal(reader[1]);
                        }
                    }
                }
            }

            return rop;

        }
        /// <summary>
        /// 根据订单的id查询点了什么产品
        /// </summary>
        /// <param name="orderId">订单的id</param>
        /// <returns></returns>
        public List<R_OrderInfo_Product> GetROrderInfoProduct(int orderId)
        {
            //实际上少了一列
            string sql = "select ROrderProId, ProName,ProPrice,UnitCount,ProUnit,CatName,R_OrderInfo_Product.SubTime from R_OrderInfo_Product inner join ProductInfo on R_OrderInfo_Product.ProId=ProductInfo.ProId inner join CategoryInfo on ProductInfo.CatId=CategoryInfo.CatId where OrderId=@OrderId and R_OrderInfo_Product.DelFlag=0";

            DataTable dt = Sqlitehelper.ExecuteTable(sql, new SQLiteParameter("@OrderId", orderId));
            List<R_OrderInfo_Product> list = new List<R_OrderInfo_Product>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToROrderInfoProduct(dr));
                }
            }
            return list;
        }

        //关系转对象
        private R_OrderInfo_Product RowToROrderInfoProduct(DataRow dr)
        {
            R_OrderInfo_Product rop = new R_OrderInfo_Product();
            rop.CatName = dr["CatName"].ToString();
            rop.ProName = dr["ProName"].ToString();
            rop.ProPrice = Convert.ToDecimal(dr["ProPrice"]);
            rop.ProUnit = dr["ProUnit"].ToString();
            rop.ROrderProId = Convert.ToInt32(dr["ROrderProId"]);
            rop.SubTime = Convert.ToDateTime(dr["SubTime"]);
            rop.UnitCount = Convert.ToDecimal(dr["UnitCount"]);
            rop.ProMoney = rop.UnitCount * rop.ProPrice;//金额
            return rop;
        }
    }
}
