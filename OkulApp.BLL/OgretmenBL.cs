using OkulApp.DAL;
using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OkulApp.BLL
{
    public class OgretmenBL
    {
        public bool OgretmenKaydet(Ogretmen ogretmen)
        {
            var helper = new Helper();
            var p = new SqlParameter[]
            {
                    new SqlParameter("@Ad",ogretmen.OgretmenAdi),
                    new SqlParameter("@Soyad",ogretmen.OgretmenSoyadi),
                    new SqlParameter("@Tc",ogretmen.OgretmenTc),
                    new SqlParameter("@Id",ogretmen.OgretmenId)
            };
            return helper.ExecuteNonQuery("Insert into tblOgretmenler Values (@Tc,@Ad,@Soyad)", p) > 0;
        }
        public Ogretmen OgretmenBul(string Tc)
        {
            try
            {
                var hlp = new Helper();
                SqlParameter[] p = { new SqlParameter("@Tc", Tc) };
                var dr = hlp.ExecuteReader("Select Ad,Soyad,Tc,Id from tblOgretmenler where OgretmenTc=@Tc", p);
                Ogretmen ogr = null;
                if (dr.Read())
                {
                    ogr = new Ogretmen();
                    ogr.OgretmenAdi = dr["Ad"].ToString();
                    ogr.OgretmenSoyadi = dr["Soyad"].ToString();
                    ogr.OgretmenId = dr["Id"].ToString();
                    ogr.OgretmenTc = dr["Tc"].ToString();

                }
                dr.Close();
                return ogr;
            }

            catch (Exception ex)
            {
                throw new Exception("Hata: " + ex);
            }


        }
        public bool OgretmenSil(String Tc)
        {
            try
            {
                var hlp = new Helper();
                var p = new SqlParameter[] {
                   new SqlParameter("@Tc", Tc)
                 };
                return hlp.ExecuteNonQuery("DELETE FROM tblOgretmenler WHERE Tc = @Tc", p) > 0;
            }

            catch (Exception ex)
            {
                throw new Exception("UYARI! Hata: " + ex.Message, ex);
            }
            finally
            {
            }
        }



        public bool OgretmenGuncelle(Ogretmen ogr)
        {
            try
            {
                SqlParameter[] p = { new SqlParameter("@Ad",ogr.OgretmenAdi),
                new SqlParameter("@Soyad", ogr.OgretmenSoyadi),
                new SqlParameter("@Id",ogr.OgretmenId),
                new SqlParameter("@Tc",ogr.OgretmenTc)};

                Helper hlp = new Helper();
                return hlp.ExecuteNonQuery("Update tblOgretmenler set OgretmenAdi=@Ad,OgretmenSoyadi=@Soyad,OgretmenId=@Id where OgretmenTc=@Tc", p) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("UYARI! Hata: " + ex.Message, ex);
            }
        }
    }
}
