using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.Model;
using ItcastCater.Dal;

namespace ItcastCater.Bll
{
    public class R_OrderInfo_ProductBll
    {
        /// <summary>
        /// 退菜
        /// </summary>
        /// <param name="rOrderId"></param>
        /// <returns></returns>
        public bool SoftDeleteROrderProName(int rOrderId)
        {
            return rdal.SoftDeleteROrderProName(rOrderId) > 0;
        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="rop"></param>
        /// <returns></returns>
        public bool AddROrderInfoProduct(R_OrderInfo_Product rop)
        {
            return rdal.AddROrderInfoProduct(rop) > 0;
        }
        /// <summary>
        /// 根据订单的id查询该订单的总金额和数量
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public R_OrderInfo_Product GetMoneyAndCount(int orderId)
        {
            return rdal.GetMoneyAndCount(orderId);
        }
        R_OrderInfo_ProductDal rdal = new R_OrderInfo_ProductDal();
        /// <summary>
        /// 根据订单的id查询点了什么产品
        /// </summary>
        /// <param name="orderId">订单的id</param>
        /// <returns></returns>
        public List<R_OrderInfo_Product> GetROrderInfoProduct(int orderId)
        {
            return rdal.GetROrderInfoProduct(orderId);
        }
    }
}
