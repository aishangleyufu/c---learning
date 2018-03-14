using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.Model;
using System.Data;
using System.Data.SQLite;
using System.Configuration;


namespace ItcastCater.Dal
{
    public class UserInfoDal 
    {
        public UserInfo IsLoginBtLoginName(string loginName)
        {
            string sql = "select * from UserInfo where LoginUserName=@LoginUserName";
            DataTable dt=Sqlitehelper.ExecuteTable(sql,new SQLiteParameter("@LoginUserName",loginName));
            UserInfo user= null;
            if (dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    user = RowToUserInfo(dr);
                }
            }
            return user;
        }

        private UserInfo RowToUserInfo(DataRow dr)
        {
            UserInfo user = new UserInfo();
            user.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            user.LastLoginIP = dr["LastLoginIP"].ToString();
            user.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
            user.LoginUserName = dr["LoginUserName"].ToString();
            user.Pwd = dr["Pwd"].ToString();
            user.SubTime = Convert.ToDateTime(dr["SubTime"]);
            user.UserId = Convert.ToInt32(dr["UserId"]);
            user.UserName = dr["UserName"].ToString();
            return user;
        }

    }
}
