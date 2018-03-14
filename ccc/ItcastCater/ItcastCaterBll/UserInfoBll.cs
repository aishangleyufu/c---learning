using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItcastCater.Dal;
using ItcastCater.Model;

namespace ItcastCater.Bll
{
    public class UserInfoBll
    {
         UserInfoDal dal=new UserInfoDal();
         public bool IsLoginBtLoginName(string loginName,string pwd,out string msg)
         {
             bool flag=false;
             UserInfo user=dal.IsLoginBtLoginName(loginName);
             if (user!=null)
	         {
                    if (pwd==user.Pwd)
	                {
                      flag=true;
		              msg="登录成功";
	                }
                   else
	               {
                      msg="密码错误";
	               }
	         }
             else
	         {
                msg="账号不存在";
	         }
             return flag;

         }
    }
}
