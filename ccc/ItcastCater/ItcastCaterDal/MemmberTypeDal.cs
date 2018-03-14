using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;
namespace ItcastCater.Dal
{
    public class MemmberTypeDal
    {
        /// <summary>
        /// 查询所有会员等级
        /// </summary>
        /// <param name="delFlag"></param>会员等级
        /// <returns>会员等级所有集合</returns>
        public List<MemmberType> GetAllMemmberTypeByDelflag(int delFlag)
        {
            string sql = "select MemType,MemTpName from MemmberType where delFlag=" + delFlag;
            DataTable dt = Sqlitehelper.ExecuteTable(sql);
            List<MemmberType> list = new List<MemmberType>();
            MemmberType memtp = new MemmberType();
            if (dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    memtp = RowToMemmberType(dr);
                    list.Add(memtp);
                }
            }
            return list;
        }

        private MemmberType RowToMemmberType(DataRow dr)
        {
            MemmberType memtp = new MemmberType();
            memtp.MemTpName = dr["MemTpName"].ToString();
            memtp.MemType = Convert.ToInt32(dr["MemType"]);
            return memtp;
        }

    }
}
