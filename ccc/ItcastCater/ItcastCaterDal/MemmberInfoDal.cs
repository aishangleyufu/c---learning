using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.Dal
{
    public class MemmberInfoDal
    {
        /// <summary>
        /// 根据会员的id更新会员的卡内的钱
        /// </summary>
        /// <param name="MemmberId"></param>
        /// <param name="MemMoney"></param>
        /// <returns></returns>
        public int UpdateMoneyByMemId(int MemmberId, decimal MemMoney)
        {
            string sql = "update MemmberInfo set MemMoney=@MemMoney where DelFlag=0 and MemmberId=@MemmberId";
            return Sqlitehelper.ExecuteNonQuery(sql, new SQLiteParameter("@MemMoney", MemMoney), new SQLiteParameter("@MemmberId", MemmberId));
        }
        /// <summary>
        /// 根据会员id查询会员等级名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetMemmberTpNameByMemmberId(int id)
        {
            string sql = "select MemTpName from MemmberType inner join MemmberInfo on MemmberInfo.MemType=MemmberType.MemType where MemmberId=@MemmberId";
            return Sqlitehelper.ExecuteScalar(sql,new SQLiteParameter("@MemmberId",id)).ToString();

        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="mem"></param>
        /// <returns></returns>
        public int AddMemmberInfo(MemmberInfo mem)
       {
           string sql = "insert into MemmberInfo (MemName,MemMobilePhone,MemAddress,MemType,MemNum,MemGender,MemDiscount,MemMoney,DelFlag,SubTime,MemIntegral,MemEndServerTime,MemBirthdaty) values(@MemName,@MemMobilePhone,@MemAddress,@MemType,@MemNum,@MemGender,@MemDiscount,@MemMoney,@DelFlag,@SubTime,@MemIntegral,@MemEndServerTime,@MemBirthdaty)";
    
       
           return AddAndUpdateMemmberInfo(1,sql,mem);
       }
       /// <summary>
       /// 修改
       /// </summary>
       /// <param name="mem"></param>
       /// <returns></returns>
        public int UpdateMemmberInfo(MemmberInfo mem)
        {
            string sql = "update MemmberInfo set MemName=@MemName,MemMobilePhone=@MemMobilePhone,MemAddress=@MemAddress,MemType=@MemType,MemNum=@MemNum,MemGender=@MemGender,MemDiscount=@MemDiscount,MemMoney=@MemMoney,MemIntegral=@MemIntegral,MemEndServerTime=@MemEndServerTime,MemBirthdaty=@MemBirthdaty where MemmberId=@MemmberId";
            return AddAndUpdateMemmberInfo(2, sql, mem);
        }
        /// <summary>
        /// 新增修改方法
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="sql"></param>
        /// <param name="mem"></param>
        /// <returns></returns>
        public int AddAndUpdateMemmberInfo(int temp, string sql,MemmberInfo mem)
        {
            SQLiteParameter[] ps ={
                        new SQLiteParameter("@MemName",mem.MemName),
                        new SQLiteParameter("@MemMobilePhone",mem.MemMobilePhone),
                        new SQLiteParameter("@MemAddress",mem.MemAddress),
                        new SQLiteParameter("@MemType",mem.MemType),
                        new SQLiteParameter("@MemNum",mem.MemNum),
                        new SQLiteParameter("@MemGender",mem.MemGender),
                        new SQLiteParameter("@MemDiscount",mem.MemDiscount),
                        new SQLiteParameter("@MemMoney",mem.MemMoney),
                        new SQLiteParameter("@MemIntegral",mem.MemIntegral),
                        new SQLiteParameter("@MemEndServerTime",mem.MemEndServerTime),
                        new SQLiteParameter("@MemBirthdaty",mem.MemBirthdaty)
                                 };

            List<SQLiteParameter> list=new List<SQLiteParameter>();
            list.AddRange(ps);
            if (temp==1)
	         {
		               list.Add( new SQLiteParameter("@DelFlag",mem.DelFlag));
                       list.Add( new SQLiteParameter("@SubTime",mem.SubTime));
	        }
            else if (temp==2)
	        {
                list.Add(new SQLiteParameter("@MemmberId", mem.MemmberId));
	        }
            return Sqlitehelper.ExecuteNonQuery(sql, list.ToArray());
        }
        /// <summary>
        /// 根据用户编号查询具体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MemmberInfo GetMemmberInfoByMemmberId(int id)
        {
            string sql="select * from MemmberInfo where DelFlag=0 and MemmberId="+id;
            DataTable dt=Sqlitehelper.ExecuteTable(sql);
            MemmberInfo mem = null;
            if (dt.Rows.Count > 0)
            {
                mem = RowToMemmberInfo(dt.Rows[0]);
            }
            return mem;
        }
        /// <summary>
        /// 根据用户性别查询用户信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MemmberInfo GetMemmberInfoByMemmberName(string name)
        {
            string sql = "select * from MemmberInfo where DelFlag=0 and MemName=@MemName";
            DataTable dt = Sqlitehelper.ExecuteTable(sql,new SQLiteParameter("@MemName",name));
            MemmberInfo mem = null;
            if (dt.Rows.Count > 0)
            {
                mem = RowToMemmberInfo(dt.Rows[0]);
            }
            return mem;
        }
        /// <summary>
        /// 根据id修改会员的删除标识
        /// </summary>
        /// <param name="memmberId">会员的id</param>
        /// <returns>受影响的行数</returns>
        public int DeleteMemmberInfoByMemmberId(int memmberId)
        {
            string sql = "update MemmberInfo set DelFlag=1 where MemmberId=" + memmberId;
            return Sqlitehelper.ExecuteNonQuery(sql);
        }
        //根据delflag会员是否删除0未删除1已经删除
        /// <summary>
        /// 把表给全部导出来
        /// </summary>
        /// <param name="delFlag"></param>
        /// <returns></returns>
        public List<MemmberInfo>GetAllMemmberInfoByDelflag(int delFlag)
        {
            string sql = "select MemmberId,MemName,MemMobilePhone,MemAddress,MemType,MemNum,MemGender,MemDiscount,MemMoney,SubTime,MemIntegral,MemEndServerTime,MemBirthdaty from MemmberInfo where DelFlag=@DelFlag";
                DataTable dt=Sqlitehelper.ExecuteTable(sql,new SQLiteParameter("@DelFlag",delFlag));
                List<MemmberInfo> list = new List<MemmberInfo>();
                if (dt.Rows.Count>0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        MemmberInfo mem = RowToMemmberInfo(dr);
                        list.Add(mem);
                    }
                }

                return list;

        }

        private MemmberInfo RowToMemmberInfo(DataRow dr)
        {
            MemmberInfo mem = new MemmberInfo();
            mem.MemAddress = dr["MemAddress"].ToString();
            mem.MemBirthdaty = Convert.ToDateTime(dr["MemBirthdaty"]);
            mem.MemDiscount = Convert.ToDecimal(dr["MemDiscount"]);
            mem.MemEndServerTime = Convert.ToDateTime(dr["MemEndServerTime"]);
            mem.MemGender = dr["MemGender"].ToString();
            mem.MemIntegral = Convert.ToInt32(dr["MemIntegral"]);
            mem.MemmberId = Convert.ToInt32(dr["MemmberId"]);
            mem.MemMobilePhone = dr["MemMobilePhone"].ToString();
            mem.MemMoney = Convert.ToDecimal(dr["MemMoney"]);
            mem.MemName = dr["MemName"].ToString();
            mem.MemNum = dr["MemNum"].ToString();
            mem.MemType = Convert.ToInt32(dr["MemType"]);
            mem.SubTime = Convert.ToDateTime(dr["SubTime"]);

            return mem;
        }
        }
        
}
