using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.Dal
{
    public class OrderInfoDal
    {
        /// <summary>
        /// 更新订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int UpdateOrderInfoMoney(OrderInfo order)
        {
            string sql = "update OrderInfo set OrderState=2,OrderMemId=@OrderMemId,EndTime=@EndTime,OrderMoney=@OrderMoney,DisCount=@DisCount where OrderId=@OrderId";
            SQLiteParameter[] ps = { 
             new SQLiteParameter("@OrderMemId",order.OrderMemId) ,
              new SQLiteParameter("@EndTime",order.EndTime),
               new SQLiteParameter("@OrderMoney",order.OrderMoney),
                new SQLiteParameter("@DisCount",order.DisCount),
                          new SQLiteParameter("@OrderId",order.OrderId)         
                                  
                                  };
            return Sqlitehelper.ExecuteNonQuery(sql, ps);
        }
        /// <summary>
        /// 根据订单查询该订单的消费金额
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public object GetMoney(int orderId)
        {
            string sql = "select OrderMoney from OrderInfo where OrderId=@OrderId and OrderState=1 and DelFlag=0";
            return Sqlitehelper.ExecuteScalar(sql, new SQLiteParameter("@OrderId", orderId));
        }
        /// <summary>
        /// 更新订单表中的金额信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public int UpdateMoney(int orderId, decimal money)
        {
            string sql="update OrderInfo set OrderMoney=@OrderMoney where OrderId=@OrderId and DelFlag=0";
            return Sqlitehelper.ExecuteNonQuery(sql,new SQLiteParameter("@OrderMoney",money),new SQLiteParameter("@OrderId",orderId));

        }
        /// <summary>
        /// 根据餐桌ID查找该餐桌正在使用的订单
        /// </summary>
        /// <param name="deskId"></param>
        /// <returns></returns>
        public object GetOrderIdByDeskId(int deskId)
        {
            string sql = "select OrderInfo.OrderId from R_Order_Desk inner join OrderInfo on R_Order_Desk.OrderId=OrderInfo.OrderId where OrderInfo.OrderState=1 and DeskId=@DeskId";
            return Sqlitehelper.ExecuteScalar(sql,new SQLiteParameter("@DeskId",deskId));
        }
        /// <summary>
        /// 添加一个订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public object AddOrderInfo(OrderInfo order)
        {
            string sql = "insert into OrderInfo(SubTime,Remark,Orderstate,DelFlag,SubBy,OrderMoney)values(@SubTime,@Remark,@Orderstate,@DelFlag,@SubBy,@OrderMoney);select last_insert_rowid();";
            SQLiteParameter[] ps ={
                            new SQLiteParameter("@SubTime",order.SubTime),
                            new SQLiteParameter("@Remark",order.Remark),
                            new SQLiteParameter("@Orderstate",order.OrderState),
                            new SQLiteParameter("@DelFlag",order.DelFlag),
                            new SQLiteParameter("@SubBy",order.SubBy),
                            new SQLiteParameter("@OrderMoney",order.OrderMoney)
                                 };
            return Sqlitehelper.ExecuteScalar(sql, ps);
        }

    }
}
