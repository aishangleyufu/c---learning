using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.Dal
{
    public class CategoryInfoDal
    {
        /// <summary>
        /// 软删除商品种类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SoftDeleteCategoryInfoByCatId(int id)
        {
            string sql = "update CategoryInfo set Delflag=1 Where CatId=@CatId";
            return Sqlitehelper.ExecuteNonQuery(sql, new SQLiteParameter("@CatId", id));
        }
        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public int AddCategoryInfo(CategoryInfo cat)
        {
            string sql = "insert into CategoryInfo(CatName,CatNum,Remark,DelFlag,SubTime,SubBy)values(@CatName,@CatNum,@Remark,@DelFlag,@SubTime,@SubBy)";
            return AddAndUpdateCategoryInfo(1, sql, cat);
        }
        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public int UpdateCategoryInfo(CategoryInfo cat)
        {
            string sql = "update CategoryInfo set CatName=@CatName,CatNum=@CatNum,Remark=@Remark where CatId=@CatId";
            return AddAndUpdateCategoryInfo(2, sql, cat);
        }
        /// <summary>
        /// 新增和修改商品总方法
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public int AddAndUpdateCategoryInfo(int temp,string sql,CategoryInfo cat)
        {
            SQLiteParameter[] ps ={
                     new SQLiteParameter("@CatName",cat.Catname),
                     new SQLiteParameter("@CatNum",cat.Catnum),
                     new SQLiteParameter("@Remark",cat.Remark)
                                 };
            List<SQLiteParameter> list = new List<SQLiteParameter>();
            list.AddRange(ps);
            if (temp==1)
            {
                list.Add(new SQLiteParameter("@DelFlag", cat.Delflag));
                list.Add(new SQLiteParameter("@SubTime", cat.Subtime));
                list.Add(new SQLiteParameter("@SubBy", cat.Subby));
            }
            else if (temp==2)
            {
                list.Add(new SQLiteParameter("@CatId", cat.Catid));
            }
            return Sqlitehelper.ExecuteNonQuery(sql, list.ToArray());
        }

        /// <summary>
        /// 根据类别的id查询类别对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CategoryInfo GetCategoryInfoById(int id)
        {
            string sql = "select * from CategoryInfo where DelFlag=0 and CatId=" + id;
            //string sql = "select * from CategoryInfo where DelFlag=0 and CatId="+id;
            CategoryInfo ct = null;
            DataTable dt = Sqlitehelper.ExecuteTable(sql);
            if (dt.Rows.Count > 0)
            {
                ct = RowToCategoryInfo(dt.Rows[0]);
            }
            return ct;
        }

        /// <summary>
        /// 查询所有的商品类别
        /// </summary>
        /// <param name="delFlag"></param>
        /// <returns></returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
            string sql = "select CatId,CatName,CatNum,Remark from CategoryInfo where DelFlag="+delFlag;
            DataTable dt = Sqlitehelper.ExecuteTable(sql);
            List<CategoryInfo> list = new List<CategoryInfo>();
            foreach (DataRow dr in dt.Rows)
            {
                CategoryInfo cat = RowToCategoryInfo(dr);
                list.Add(cat);
            }
            return list;
        }

        private CategoryInfo RowToCategoryInfo(DataRow dr)
        {
            CategoryInfo cat = new CategoryInfo();
            cat.Catname = dr["Catname"].ToString();
            cat.Catnum = dr["Catnum"].ToString();
            cat.Catid = Convert.ToInt32(dr["Catid"]);
            cat.Remark = dr["Remark"].ToString();
            return cat;
        }
    }
}
