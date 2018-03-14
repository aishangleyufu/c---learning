using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.Model;
using ItcastCater.Dal;

namespace ItcastCater.Bll
{
    public class RoomInfoBll
    {
        RoomInfoDal dal = new RoomInfoDal();
        /// <summary>
        /// 增加房间
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public bool AddRoom(RoomInfo room)
        {
            return dal.AddRoom(room) > 0;
        }
        /// <summary>
        /// 获取所有的房间对象
        /// </summary>
        /// <param name="delFlag"></param>
        /// <returns></returns>
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
            return dal.GetAllRoomInfoByDelFlag(delFlag);
        }
    }
}
