using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Configuration;

namespace ItcastCater.Dal
{
    public class Sqlitehelper
    {
        private static readonly string str = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;


        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql,con))
                {
                    if (ps!= null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql,con))
                {
                    con.Open();
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] ps)
        {
            SQLiteConnection con = new SQLiteConnection(str);
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    con.Close();
                    con.Dispose();
                    throw ex;
                }
            }

        }

        public static DataTable ExecuteTable(string sql, params SQLiteParameter[] ps)
        {
            DataTable dt = new DataTable();
            using (SQLiteDataAdapter sda = new SQLiteDataAdapter(sql, str))
            {
                if (ps != null)
                {
                    sda.SelectCommand.Parameters.AddRange(ps);
                }
                sda.Fill(dt);
            }
            return dt;
        }
    }
}


