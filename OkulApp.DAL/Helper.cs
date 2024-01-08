using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OkulApp.DAL
{
    public class Helper:IDisposable
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;

        string cstr = ConfigurationManager.ConnectionStrings["cstr"].ConnectionString;
        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p = null)
        {
            using (cn = new SqlConnection(cstr))
            {
                using (cmd = new SqlCommand(cmdtext, cn))
                {
                    if (p != null)
                    {
                        cmd.Parameters.AddRange(p);
                    }
                    cn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        //Dispose metodu, genellikle açılan veritabanı bağlantıları gibi kaynakları serbest bırakmak için kullanılır.Bu, bellek sızıntılarını önlemeye ve kaynak kullanımını optimize etmeye yardımcı olur.
        public SqlDataReader ExecuteReader(string cmdtext, SqlParameter[] p = null)
        {
            try
            {
                cn = new SqlConnection(cstr);
                cmd = new SqlCommand(cmdtext, cn);
                if (p != null)
                {
                    cmd.Parameters.AddRange(p);
                }
                cn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException ex)
            {

                throw new Exception("Veri Tabanı Hatası",ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Hata", ex);
            }   
        }
        public void Dispose()
        {
            cn?.Dispose();
            cmd?.Dispose();
        }
    }

}
//Bu Dispose metodu, Helper sınıfının nesnesi üzerinde çağrıldığında çalışacak. cn (SqlConnection) ve cmd(SqlCommand) nesneleri, using ifadeleri içinde tanımlanmışlardır.Bu ifadeler sayesinde, cn ve cmd nesneleri otomatik olarak Dispose metodu çağrılarak serbest bırakılır.

//İlk olarak, cn?.Dispose() ifadesiyle cn nesnesi kontrol edilir ve null olmadığı durumda Dispose metodu çağrılır. Aynı şekilde, cmd?.Dispose() ifadesiyle de cmd nesnesi kontrol edilir ve null olmadığı durumda Dispose metodu çağrılır.