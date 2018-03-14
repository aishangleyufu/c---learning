using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.Dal;
using ItcastCater.Model;

namespace ItcastCater.Bll
{
    public class DeskInfoBll
    {

        DeskInfoDal dal = new DeskInfoDal();
                /// <summary>
        /// 更改餐桌状态
        /// </summary>
        /// <param name="deskId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool UpdateDeskStateByDeskId(int deskId, int state)
        {
            return dal.UpdateDeskStateByDeskId(deskId, state) > 0;
        }
        /// <summary>
        /// 根据房间的ID查询该房间下所有餐桌
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public List<DeskInfo> GetAllDeskInfoByRoomId(int roomId)
        {
            return dal.GetAllDeskInfoByRoomId(roomId);
        }
    }
}
