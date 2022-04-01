using Microsoft.Data.SqlClient;                     //connect Sql
using Microsoft.Extensions.Configuration;  //設置config
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFirstTest.Models
{
    //資料庫使用相關物件工廠架構 模式
    public class DBUtility  //建立類別Db連線
    {
        private String _connectionString; //自訂建構子 空參數 注入應用系統組態物件(配置成服務環境 依賴注入DI)
        //(using Microsoft.Extensions.Configuration; )
        public DBUtility(IConfiguration config)    //物件DB
        {
            Console.WriteLine($"DB物件產生~{ config}");
            _connectionString = config.GetConnectionString("FinalProjectTes");  //取得SQL Server連線字串
        }

        //使用連接物件方法連接SQL 
        //(using Microsoft.Data.SqlClient;)
        public SqlConnection createConnection()   //創建連接
        {
            //建構連接物件 將建構子注入連接字串座使用
            return new SqlConnection(_connectionString);
        }
    }
}
