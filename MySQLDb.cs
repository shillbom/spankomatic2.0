using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Spankomatic
{
    public static class MySQLDb
    {
        private static List<Article> articleTable;

        private static MySqlConnection conn;

        public static MySqlConnection Connect(string connectionString) {
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
            }
            catch (MySqlException ex) {
                MessageBox.Show("Nätverksfel. Antagligen finns ingen uppkoppling till snejk, eller så behövs en SSH-tunnel.");
                return null;
            }

            return conn;
        }

        public static MySqlConnection ConnectToCafeDb() {
            
            return Connect("server=127.0.0.1;user=hemlih;database=hemlig;port=3306;password=hemlig;");           
            
            //return Connect("server=127.0.0.1;user=hemlih;database=hemlig;port=3306;password=hemlig;");           
        }

        public static MySqlConnection ConnectToDsekDb()
        {
            return Connect("server=127.0.0.1;user=hemlig;database=hemlig;port=3306;password=hemlig;");           
            
            //return Connect("server=127.0.0.1;user=hemlig;database=hemlih;port=3306;password=hemlih;");          
        }

        public static void CloseConnection() {
            conn.Close();
        }

        public static void GetArticleTable() { 
            articleTable = new List<Article>();

            string sql = "SELECT * FROM `cafe_articles` WHERE forSale = 1";
            try
            {
                ConnectToCafeDb();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader rdr = cmd.ExecuteReader();

                Article article;
                while (rdr.Read())
                {
                    article = new Article();
                    article.id = rdr.GetInt32(0);
                    article.EAN = rdr.GetString(1);
                    article.name = rdr.GetString(2);
                    article.categoryId = rdr.GetInt32(3);
                    article.comment = rdr.GetString(4);
                    article.price = rdr.GetInt32(5);
                    article.cost = rdr.GetInt32(6);
                    article.internalPrice = rdr.GetInt32(7);
                    article.forSale = rdr.GetBoolean(8);
                    article.nbrPerPack = rdr.GetInt32(9);

                    articleTable.Add(article);
                }

                rdr.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (InvalidOperationException e)
            {
                if (e.Message == "Connection must be valid and open.")
                {
                    MessageBox.Show("Nätverksfel. Antagligen finns ingen uppkoppling till snejk, eller så behövs en SSH-tunnel.");
                }
                else
                    MessageBox.Show(e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        
        public static Article EANToArticle(string EAN) { 
            IEnumerable<Article> articles = from a in articleTable
                                            where a.EAN == EAN
                                            select a;

            return articles.First();            
        }

        public static Article ArticleNameToArticle(string articleName)
        {
            IEnumerable<Article> articles = from a in articleTable
                                            where a.name == articleName
                                            select a;

            return articles.First();            
        }

        public static Sale ArticleNameToSale(string articleName) {
            Sale sale = new Sale();

            IEnumerable<Article> articles = from a in articleTable
                                            where a.name == articleName
                                            select a;

            Article article = articles.First();

            sale.articleID = article.id;
            sale.price = article.price;
            sale.cost = article.cost;
            sale.arbetsGladje = false;

            return sale;
        }

        public static void RecordSale(Sale sale) {
            string sql = "SELECT MAX(saleId) FROM `cafe_sales`";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();
            int saleId = Convert.ToInt32(result) + 1;   //Hämta högsta saleId och öka med 1

            string type = sale.arbetsGladje == true ? "work" : "default";
            sql = "INSERT INTO `cafe_sales` (saleId, articleId, timestamp, income, cost, type, discountId, invoiceId) VALUES (\'" + saleId + "\', \'" + sale.articleID + "\', NOW(), \'" + sale.price + "\', \'" + sale.cost + "\', \'" + type + "\', \'0\', \'0\')";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
        
        public static List<string> GetAllArticleNameThatContainsString(string str) {
            List<string> stringList = new List<string>();
            
            IEnumerable<Article> articles = from a in articleTable
                                            where a.name.ToUpper().Contains(str.ToUpper())
                                            select a;

            foreach (Article a in articles)
            {
                stringList.Add(a.name);
            }
            
            return stringList;
        }

        public static int GetNumMackbarsbiljetterByLogin(string login) {
            string sql = "SELECT delivered FROM `srd_baguettebiljetter` WHERE login LIKE \'" + login + "\' AND delivered = 0 AND added >= DATE_SUB( NOW( ) , INTERVAL 1 YEAR)";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            int result = 0;

            while (rdr.Read())
            {
                result++;
            }

            rdr.Close();

            return result;
        }
            
        public static void DeliverMackbarsBiljett(string login) {
            string sql = "SELECT id FROM `srd_baguettebiljetter` WHERE login LIKE \'" + login + "\' AND delivered = 0 ORDER BY added ASC";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            int id = -1;

            rdr.Read();
            id = rdr.GetInt32(0);
            rdr.Close();

            sql = "UPDATE `srd_baguettebiljetter` SET delivered = 1 WHERE id = " + id.ToString();

            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        public static User GetUserFromLogin(string login) {
            ConnectToDsekDb();
            User user = new User();

            string sql = "SELECT firstname, lastname, id FROM `members` WHERE login LIKE \'" + login + "\'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                user.login = login;
                user.realName = rdr.GetString(0) + " " + rdr.GetString(1);
                user.id = rdr.GetInt32(2);
            }
            else
            {
                user = null;
            }
            rdr.Close();

            CloseConnection();

            return user;
        }

        public static User GetUserFromId(int id) 
        {
            ConnectToDsekDb();
            User user = new User();

            string sql = "SELECT login, firstname, lastname FROM `members` WHERE id = " + id.ToString();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            user.login = rdr.GetString(0);
            user.realName = rdr.GetString(1) + " " + rdr.GetString(2);
            user.id = id;
            rdr.Close();

            CloseConnection();

            return user;
        }

        public static bool AuthenticateUser(string login, string password) 
        {
            string permit = "SELECT COUNT( * ) >0 AS permitted" +
                                " FROM staff" +
                                " JOIN members ON staff.person = members.id" +
                                " WHERE login = \'" + login + "\'" +
                                " AND (" +
                                " staff.post = 4" +
                                " OR staff.post = 47" +
                                " )" +
                                " AND staff.quit > UNIX_TIMESTAMP( NOW( ) )";

            MySqlCommand cmd = new MySqlCommand(permit, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            bool correctPost = false;

            rdr.Read();
            correctPost = rdr.GetInt32(0) > 0;
            rdr.Close();

            if (!correctPost) 
            {
                return false;
            }

            MD5 md5 = MD5.Create();

            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++) 
            {
                sb.Append(data[i].ToString("x2"));
            }

            string hash = sb.ToString();

            string sql = "SELECT password FROM `members` WHERE login LIKE \'" + login + "\'";

            cmd = new MySqlCommand(sql, conn);
            rdr = cmd.ExecuteReader();

            string str = "";

            while (rdr.Read())
            {
                str = rdr.GetString(0);
            }

            rdr.Close();

            return (str == hash);
        }

        public static List<Inkop> GetAllInkop()
        {
            List<Inkop> inkopslist = new List<Inkop>();

            ConnectToCafeDb();

            string sql = "SELECT * FROM `shoppinglist` ORDER BY id DESC";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            Inkop inkop;
            string temp;
            while (rdr.Read())                
            {
                inkop = new Inkop();
                inkop.id = rdr.GetInt32(0);
                inkop.date = rdr.GetDateTime(1);
                inkop.article = rdr.GetString(2);
                inkop.quantity = rdr.GetString(3);
                temp = rdr.GetString(4);
                inkop.purchased = temp == "yes";

                inkopslist.Add(inkop);
            }

            rdr.Close();

            CloseConnection();

            return inkopslist;
        }

        public static void SubmitInkop(Inkop inkop)
        {
            ConnectToCafeDb();
            string sql = "SELECT MAX(id) FROM `shoppinglist`";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();
            int newId = Convert.ToInt32(result) + 1;   //Hämta högsta id och öka med 1

            string purchased = inkop.purchased ? "yes" : "no";
            sql = "INSERT INTO `shoppinglist` (id, date, articleName, quantity, purchase) VALUES (\'" + newId + "\', CURDATE(), \'" + inkop.article + "\', \'" + inkop.quantity + "\', \'" + purchased + "\')";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }

        public static void UpdatePurchasedInkop(Inkop inkop)
        {
            ConnectToCafeDb();
            MySqlCommand cmd;

            string purchaseString = inkop.purchased ? "yes" : "no";
            string sql = "UPDATE `shoppinglist` SET purchase = \'" + purchaseString + "\' WHERE id = " + inkop.id;
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();    
            
            CloseConnection();
        }
    }

}
