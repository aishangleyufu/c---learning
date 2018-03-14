using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.Dal
{
    public class ProductInfoDal
    {
        /// <summary>
        /// 根据拼音或者编号查询产品
        /// </summary>
        /// <param name="num">可以是拼音，可以是编号</param>
        /// <param name="temp">1---拼音，2---编号</param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoBySpellOrNum(string num, int temp)
        {
            string sql = "select * from ProductInfo where DelFlag=0";
            if (temp == 1)//拼音
            {
                sql += " and ProSpell like @ProSpell";
            }
            else if (temp == 2)
            {
                sql += " and ProNum like @ProSpell";
            }
            List<ProductInfo> list = new List<ProductInfo>();
            DataTable dt = Sqlitehelper.ExecuteTable(sql, new SQLiteParameter("@ProSpell", "%" + num + "%"));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 根据产品编号模糊查询
        /// </summary>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByProNum(string proNum)
        {
            List<ProductInfo> list = new List<ProductInfo>();
            string sql = "select * from ProductInfo where DelFlag=0 and ProNum like @ProNum";
            DataTable dt=Sqlitehelper.ExecuteTable(sql,new SQLiteParameter("@ProNum","%"+proNum+"%"));
            if (dt.Rows.Count>0)
	        {
                foreach (DataRow dr in dt.Rows)
	              {
                      list.Add(RowToProductInfo(dr));	 
	              }
		        
	        }
            return list;
        }
        /// <summary>
        /// 根据商品种类得到属于该商品分类下的所有产品
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByCatid(int catId)
        {
            List<ProductInfo> list=new List<ProductInfo>();
            string sql = "select * from ProductInfo where DelFlag=0 and CatId=@CatId";
            DataTable dt=Sqlitehelper.ExecuteTable(sql,new SQLiteParameter("@CatId",catId));
            if (dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ProductInfo ps = RowToProductInfo(dr);
                    list.Add(ps);
                }
            }
            return list;
        }
        /// <summary>
        /// 新增产品
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public int AddProductInfo(ProductInfo pro)
        {
            string sql = "insert into ProductInfo(CatId,ProName,ProCost,ProSpell,ProPrice,ProUnit,Remark,DelFlag,SubTime,Prostock,ProNum,SubBy)values(@CatId,@ProName,@ProCost,@ProSpell,@ProPrice,@ProUnit,@Remark,@DelFlag,@SubTime,@Prostock,@ProNum,@SubBy)";
            return AddAndUpdateProductInfo(3, sql, pro);
        }
        /// <summary>
        /// 修改产品
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public int UpdateProductInfo(ProductInfo pro)
        {
            string sql = "update ProductInfo set CatId=@CatId,ProName=@ProName,ProCost=@ProCost,ProSpell=@ProSpell,ProPrice=@ProPrice,ProUnit=@ProUnit,Remark=@Remark where ProId=@ProId";
            return AddAndUpdateProductInfo(4, sql, pro);
        }
        /// <summary>
        /// 新增和修改产品总方法
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public int AddAndUpdateProductInfo(int temp, string sql, ProductInfo pro)
        {
            SQLiteParameter[] ps ={
                    new SQLiteParameter("@CatId",pro.CatId),
                    new SQLiteParameter("@ProName",pro.ProName),
                    new SQLiteParameter("@ProNum",pro.ProNum),
                    new SQLiteParameter("@ProPrice",pro.ProPrice),
                    new SQLiteParameter("@ProSpell",pro.ProSpell),
                    new SQLiteParameter("@ProStock",pro.ProStock),
                    new SQLiteParameter("@ProUnit",pro.ProUnit),
                    new SQLiteParameter("@Remark",pro.Remark),
                    new SQLiteParameter("@ProCost",pro.ProCost)
                                 };
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            list.AddRange(ps);
            if (temp == 3)
            {
                list.Add(new SQLiteParameter("@DelFlag", pro.DelFlag));
                list.Add(new SQLiteParameter("@SubTime", pro.SubTime));
                list.Add(new SQLiteParameter("@SubBy", pro.SubBy));
            }
            else if (temp == 4)
            {
                list.Add(new SQLiteParameter("@ProId", pro.ProId));
            }
            return Sqlitehelper.ExecuteNonQuery(sql, list.ToArray());
        }
        /// <summary>
        /// 根据ID查询产品对象信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductInfo GetProductInfoById(int id)
        {
            string sql = "select * from ProductInfo where Delflag=0 and ProId=@ProId";
            DataTable dt = Sqlitehelper.ExecuteTable(sql,new SQLiteParameter("@ProId",id));
            ProductInfo pro = new ProductInfo();
            if (dt.Rows.Count>0)
            {
                pro = RowToProductInfo(dt.Rows[0]);
            }
            return pro;
        }
        /// <summary>
        /// 软删除产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SoftDeleteProductInfoByProId(int id)
        {
            string sql = "update ProductInfo set Delflag=1 Where ProId=@ProId";
            return Sqlitehelper.ExecuteNonQuery(sql,new SQLiteParameter("@ProId",id));
        }

        /// <summary>
        /// 查询所有的产品
        /// </summary>
        /// <param name="delFlag"></param>
        /// <returns></returns>
        public List<ProductInfo> GetAllProductInfoByDelFlag(int delFlag)
        {
            string sql = "select ProId,CatId,ProName,ProCost,ProSpell,ProPrice,ProUnit,Remark,ProStock,ProNum from ProductInfo where DelFlag=" + delFlag;

            List<ProductInfo> list = new List<ProductInfo>();
            DataTable dt = Sqlitehelper.ExecuteTable(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;
        }

        private ProductInfo RowToProductInfo(DataRow dr)
        {
            ProductInfo pro = new ProductInfo();
            pro.CatId = Convert.ToInt32(dr["CatId"]);
            // pro.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            pro.ProCost = Convert.ToDecimal(dr["ProCost"]);
            pro.ProId = Convert.ToInt32(dr["ProId"]);
            pro.ProName = dr["ProName"].ToString();
            pro.ProNum = dr["ProNum"].ToString();
            pro.ProPrice = Convert.ToDecimal(dr["ProPrice"]);
            pro.ProSpell = dr["ProSpell"].ToString();
            pro.ProStock = Convert.ToDecimal(dr["ProStock"]);
            pro.ProUnit = dr["ProUnit"].ToString();
            pro.Remark = dr["Remark"].ToString();
            // pro.SubBy = Convert.ToInt32(dr["SubBy"]);
            // pro.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return pro;
        }

    }
}
