using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.Model;
using ItcastCater.Dal;

namespace ItcastCater.Bll
{
    public class OrderInfoBll
    {
        OrderInfoDal odal = new OrderInfoDal();
        /// <summary>
        /// 更新订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool UpdateOrderInfoMoney(OrderInfo order)
        {
            return odal.UpdateOrderInfoMoney(order) > 0;
        }
        /// <summary>
        /// 根据订单查询该订单的消费金额
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public decimal GetMoney(int orderId)
        {
            return Convert.ToDecimal(odal.GetMoney(orderId));
        }
                /// <summary>
        /// 更新订单表中的金额信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public void UpdateMoney(int orderId, decimal money)
        {
            odal.UpdateMoney(orderId, money);
        }
                /// <summary>
        /// 根据餐桌ID查找该餐桌正在使用的订单
        /// </summary>
        /// <param name="deskId"></param>
        /// <returns></returns>
        public int GetOrderIdByDeskId(int deskId)
        {
            return Convert.ToInt32(odal.GetOrderIdByDeskId(deskId));
        }
                /// <summary>
        /// 添加一个订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int AddOrderInfo(OrderInfo order)
        {
            return Convert.ToInt32(odal.AddOrderInfo(order));
        }
    }
}
