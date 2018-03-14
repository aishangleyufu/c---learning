using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using ItcastCater.Model;

namespace ItcastCater.Dal
{
    public class RoomInfoDal
    {
        /// <summary>
        /// 增加房间
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public int AddRoom(RoomInfo room)
        {
            string sql = "insert into RoomInfo(RoomName,RoomType,RoomMinimunConsume,RoomMaxConsumer,IsDefault,DelFlag,SubTime,SubBy) values(@RoomName,@RoomType,@RoomMinimunConsume,@RoomMaxConsumer,@IsDefault,@DelFlag,@SubTime,@SubBy)";
            SQLiteParameter[] ps ={
                            new SQLiteParameter("@RoomName",room.RoomName),
                            new SQLiteParameter("@RoomType",room.RoomType),
                            new SQLiteParameter("@RoomMinimunConsume",room.RoomMinimunConsume),
                            new SQLiteParameter("@RoomMaxConsumer",room.RoomMaxConsumer),
                            new SQLiteParameter("@IsDefault",room.IsDefault),
                            new SQLiteParameter("@DelFlag",room.DelFlag),
                            new SQLiteParameter("@SubTime",room.SubTime),
                            new SQLiteParameter("@SubBy",room.SubBy)
                                };
            return Sqlitehelper.ExecuteNonQuery(sql, ps);
        }


        /// <summary>
        /// 获取所有的房间对象
        /// </summary>
        /// <param name="delFlag"></param>
        /// <returns></returns>
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
            List<RoomInfo> list = new List<RoomInfo>();
            string sql = "select * from RoomInfo where DelFlag="+delFlag;
            DataTable dt = Sqlitehelper.ExecuteTable(sql);
            if (dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToRoomInfo(dr));
                }
            }
                return list;
        }

        private RoomInfo RowToRoomInfo(DataRow dr)
        {
            RoomInfo rm = new RoomInfo();
            rm.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            rm.IsDefault = Convert.ToInt32(dr["IsDefault"]);
            rm.RoomId = Convert.ToInt32(dr["RoomId"]);
            rm.RoomMaxConsumer = Convert.ToDecimal(dr["RoomMaxConsumer"]);
            rm.RoomMinimunConsume = Convert.ToDecimal(dr["RoomMinimunConsume"]);
            rm.RoomName = dr["RoomName"].ToString();
            rm.RoomType = Convert.ToInt32(dr["RoomType"]);
            rm.SubBy = Convert.ToInt32(dr["SubBy"]);
            rm.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return rm;

        }

    }
}
