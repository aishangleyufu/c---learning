using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.Dal;
using ItcastCater.Model;

namespace ItcastCater.Bll
{
    public class ProductInfoBll
    {
        ProductInfoDal dal = new ProductInfoDal();
        /// <summary>
        /// 根据拼音或者编号查询产品
        /// </summary>
        /// <param name="num">可以是拼音，可以是编号</param>
        /// <param name="temp">1---拼音，2---编号</param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoBySpellOrNum(string num, int temp)
        {
            return dal.GetProductInfoBySpellOrNum(num, temp);
        }
        /// <summary>
        /// 根据产品编号模糊查询
        /// </summary>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByProNum(string proNum)
        {
           return dal.GetProductInfoByProNum(proNum);
        }
                /// <summary>
        /// 根据商品种类得到属于该商品分类下的所有产品
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByCatid(int catId)
        {
            return dal.GetProductInfoByCatid(catId);
        }
        /// <summary>
        /// 新增或修改产品信息
        /// </summary>
        /// <param name="mem">产品对象</param>
        /// <param name="temp">1--新增 2--修改</param>
        /// <returns>成功还是失败</returns>
        public bool SaveProductInfo(ProductInfo pro, int temp)
        {
            int r = -1;
            if (temp == 3)
            {
                r = dal.AddProductInfo(pro);
            }
            else if (temp == 4)
            {
                r = dal.UpdateProductInfo(pro) ;
            }
            return r > 0;
        }
        public ProductInfo GetProductInfoById(int id)
        {
            return dal.GetProductInfoById(id);
        }
        public bool SoftDeleteProductInfoByProId(int id)
        {
            return dal.SoftDeleteProductInfoByProId(id)>0;
        }
        public List<ProductInfo> GetAllProductInfoByDelFlag(int delFlag)
        {
            return dal.GetAllProductInfoByDelFlag(delFlag);
        }
    }
}
