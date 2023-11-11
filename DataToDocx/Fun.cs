using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.SQLite;
using System.Windows.Threading;

namespace DataToDocx
{
   public class Fun
    {
        
        public static void UpdateState(string connstr, string tablename, string huid)
        {
            using (var connection = new SQLiteConnection(connstr))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                //string query = $"UPDATE `{tablename}` SET `操作状况`=@state WHERE `户编号`=@huID;";
                string query = $"UPDATE `{tablename}` SET `操作状况`=@state WHERE `户主身份证号`=@huID;";
                //户主身份证号


                SQLiteCommand command = new SQLiteCommand(query, connection);

                command.Parameters.AddWithValue("@state", $"{DateTime.Now}已生成" ?? "");
                command.Parameters.AddWithValue("@huID", huid ?? "");
                command.ExecuteNonQuery();
            }
        }

        public static void Updatelogtext(string text, RichTextBox textBox)
        { // 检查标签是否从另一个线程访问
            Dispatcher.CurrentDispatcher.Invoke(new Action(() =>
            {
                textBox.AppendText(DateTime.Now + " " + text);
                textBox.AppendText("\r\n");

            }));
                
 
        }



    }
}
