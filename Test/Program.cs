using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Methods.UpdateData();
                string testString = "";
                for (int i = 0; i < 5; i++)
                {
                    testString += ",id:"+i;
                }
                testString += ",";
                var bb=testString.Remove(0,1);
                var cc= testString.Trim(',');
                //testString.Trim(",");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());//输出错误信息  
            }
            finally
            {

            }
            Console.ReadLine();
        }
    }
}
