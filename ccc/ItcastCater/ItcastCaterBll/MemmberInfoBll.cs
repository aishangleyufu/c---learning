using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.Model;
using ItcastCater.Dal;
using System.Data;
namespace ItcastCater.Bll
{

   public class MemmberInfoBll
    {
       MemmberInfoDal dal = new MemmberInfoDal();
       /// <summary>
       /// 根据会员的id更新会员的卡内的钱
       /// </summary>
       /// <param name="MemmberId"></param>
       /// <param name="MemMoney"></param>
       /// <returns></returns>
       public bool UpdateMoneyByMemId(int MemmberId, decimal MemMoney)
       {
           return dal.UpdateMoneyByMemId(MemmberId, MemMoney) > 0;
       }
               /// <summary>
        /// 根据会员id查询会员等级名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public string GetMemmberTpNameByMemmberId(int id)
       {
           return dal.GetMemmberTpNameByMemmberId(id);
       }
       /// <summary>
       /// 新增或修改会员信息
       /// </summary>
       /// <param name="mem">会员对象</param>
       /// <param name="temp">1--新增 2--修改</param>
       /// <returns>成功还是失败</returns>
       public bool SaveMemmberInfo(MemmberInfo mem,int temp)
       {
           int r = -1;
           if (temp==1)
           {
               r=dal.AddMemmberInfo(mem);
           }
           else if (temp==2)
           {
               r = dal.UpdateMemmberInfo(mem);
           }
           return r > 0;
       }

       public MemmberInfo GetMemmberInfoByMemmberId(int id)
       {
           return dal.GetMemmberInfoByMemmberId(id);
       }

       public MemmberInfo GetMemmberInfoByMemmberName(string name)
       {
           return dal.GetMemmberInfoByMemmberName(name);
       }
       /// <summary>
       /// 根据id修改会员的删除标识
       /// </summary>
       /// <param name="memmberId">会员的id</param>
       /// <returns>受影响的行数</returns>
       public bool DeleteMemmberInfoByMemmberId(int memmberId)
       {
           return dal.DeleteMemmberInfoByMemmberId(memmberId) > 0 ? true : false;
       }
      
       public List<MemmberInfo> GetAllMemmberInfoByDelflag(int delFlag)
       {
           return dal.GetAllMemmberInfoByDelflag(delFlag);
       }
    }
}
