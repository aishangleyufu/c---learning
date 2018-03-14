using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.Dal;
using ItcastCater.Model;

namespace ItcastCater.Bll
{
    public class CategoryInfoBll
    {

        CategoryInfoDal dal = new CategoryInfoDal();
       /// <summary>
        /// 软删除商品种类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SoftDeleteCategoryInfoByCatId(int id)
        {
            return dal.SoftDeleteCategoryInfoByCatId(id) > 0;
        }
        /// <summary>
        /// 新增或修改商品信息
        /// </summary>
        /// <param name="mem">商品对象</param>
        /// <param name="temp">1--新增 2--修改</param>
        /// <returns>成功还是失败</returns>
        public bool SaveCategoryInfo(CategoryInfo cat, int temp)
        {
            int r = -1;
            if (temp == 1)
            {
                r = dal.AddCategoryInfo(cat);
            }
            else if (temp == 2)
            {
                r = dal.UpdateCategoryInfo(cat);
            }
            return r > 0;
        }
        /// <summary>
        /// 根据类别的id查询类别对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CategoryInfo GetCategoryInfoById(int id)
        {
            return dal.GetCategoryInfoById(id);
        }

        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
            return dal.GetAllCategoryInfoByDelFlag(delFlag);
        }
    }
}
