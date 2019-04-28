using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Methods
    {
        public static void UpdateData<T>(T t)
        {
            string conStr = "Server=192.168.10.79;Database=crm_MSCRM20171229; uid=sa;pwd=Crm)(*";//连接字符
            SqlConnection conText = new SqlConnection(conStr);//创建Connection对象  
            try
            {
                conText.Open();
                string sql = "select * from new_testitem";//创建统计语句  
                string sqltwo = "update new_rlftwo set new_name='劈里啪啦' where new_rlftwoId='D24B639A-F169-E811-80F7-005056BA5450'";
                Type oType = t.GetType();
                string tableName = "";
                if (oType.IsDefined(typeof(TableAttribute), true)){
                    TableAttribute tableAttribute = (TableAttribute)oType.GetCustomAttribute(typeof(TableAttribute), true);
                    tableName = tableAttribute.GetName();
                }
                else
                {
                    tableName = oType.Name;
                }
                string setValueString = "";
                string IdValueString = "";
                foreach (var prop in oType.GetProperties())
                {
                    if (prop.IsDefined(typeof(KeyAttribute), true))
                    {
                        if (prop.GetValue(t) == null)
                        {
                            Console.WriteLine("出现错误,主键Id不能为空！");
                            return;
                        }
                        else
                        {
                            if (prop.IsDefined(typeof(ColumnAttribute),true))
                            {
                                ColumnAttribute columnAttribute = (ColumnAttribute)prop.GetCustomAttribute(typeof(ColumnAttribute), true);
                                IdValueString = columnAttribute.GetName() + "'" + prop.GetValue(t) + "'";
                            }
                            else
                            {
                                IdValueString = prop.Name + "'" + prop.GetValue(t) + "'";
                            }
                        }
                    }
                    if (prop.GetValue(t) == null)
                    {
                        continue;
                    }
                    if (prop.IsDefined(typeof(ColumnAttribute), true))
                    {
                        ColumnAttribute columnAttribute = (ColumnAttribute)prop.GetCustomAttribute(typeof(ColumnAttribute), true);
                        
                    }
                }
                string sqls = string.Format("UPDATE {0} SET {1} WHERE {2}", tableName, setValueString,IdValueString);
                SqlCommand comText = new SqlCommand(sql, conText);//创建Command对象  
                SqlDataReader dr= comText.ExecuteReader();//执行查询  
                while (dr.Read())//判断数据表中是否含有数据  
                {
                    Console.Write(dr[0].ToString() + ",");
                    Console.WriteLine(dr[2].ToString());
                }
                dr.Close();//关闭DataReader对象  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conText.Close();
            }
        }
    }
}
