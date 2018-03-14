using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.Dal
{
    public class DeskInfoDal
    {
        /// <summary>
        /// 更改餐桌状态
        /// </summary>
        /// <param name="deskId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int UpdateDeskStateByDeskId(int deskId, int state)
        {
            string sql = "update DeskInfo set DeskState=@DeskState where DelFlag=0 and DeskId=@DeskId";
            return Sqlitehelper.ExecuteNonQuery(sql, new SQLiteParameter("@DeskState", state), new SQLiteParameter("@DeskId", deskId));
        }
        /// <summary>
        /// 根据房间的ID查询该房间下所有餐桌
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public List<DeskInfo> GetAllDeskInfoByRoomId(int roomId)
        {
            List<DeskInfo> list = new List<DeskInfo>();
            string sql = "select * from DeskInfo where DelFlag=0 and RoomId=@RoomId";
            DataTable dt=Sqlitehelper.ExecuteTable(sql,new SQLiteParameter("@RoomId",roomId));
            if (dt.Rows.Count>0)
	        {
		       foreach (DataRow dr in dt.Rows)
	            {
		               list.Add(RowToDeskInfo(dr));
	            }
	        }
            return list;
        }

        private DeskInfo RowToDeskInfo(DataRow dr)
        {
            DeskInfo de = new DeskInfo();
            de.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            de.DeskId = Convert.ToInt32(dr["DeskId"]);
            de.DeskName = dr["DeskName"].ToString();
            de.DeskRegion = dr["DeskRegion"].ToString();
            de.DeskRemark = dr["DeskRemark"].ToString();
            de.DeskState = Convert.ToInt32(dr["DeskState"]);
           // de.DeskStateString = dr["DeskStateString"].ToString();
            de.RoomId = Convert.ToInt32(dr["RoomId"]);
            de.SubBy = Convert.ToInt32(dr["SubBy"]);
            de.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return de;

        }

    }
}
