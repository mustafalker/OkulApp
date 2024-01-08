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
                    new SqlParameter("@Tc",ogretmen.OgretmenTc)
            };
            return helper.ExecuteNonQuery("Insert into tblOgretmenler Values (@Ad,@Soyad,@Tc)", p) > 0;
        }
        public Ogretmen OgretmenBul(string Tc)
        {
            try
            {
                var hlp = new Helper();
                SqlParameter[] p = { new SqlParameter("@Tc", Tc) };
                var dr = hlp.ExecuteReader("Select OgretmenId,OgretmenAdi,OgretmenSoyadi,OgretmenTc from tblOgretmenler where OgretmenTc=@Tc", p);
                Ogretmen ogr = null;
                if (dr.Read())
                {
                    ogr = new Ogretmen();
                    ogr.OgretmenId = dr["OgretmenId"].ToString();
                    ogr.OgretmenAdi = dr["OgretmenAdi"].ToString();
                    ogr.OgretmenSoyadi = dr["OgretmenSoyadi"].ToString();
                    ogr.OgretmenTc = dr["OgretmenTc"].ToString();
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
                return hlp.ExecuteNonQuery("DELETE FROM tblOgretmenler WHERE OgretmenTc = @Tc", p) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Hata: " + ex.Message, ex);
            }
        }

        public bool OgretmenGuncelle(Ogretmen ogr)
        {
            try
            {
                SqlParameter[] p =
                {
                new SqlParameter("@Ad",ogr.OgretmenAdi),
                new SqlParameter("@Soyad", ogr.OgretmenSoyadi),
                new SqlParameter("@Tc",ogr.OgretmenTc)
                };

                Helper hlp = new Helper();
                return hlp.ExecuteNonQuery("Update tblOgretmenler set OgretmenAdi=@Ad,OgretmenSoyadi=@Soyad where OgretmenTc=@Tc", p) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Hata: " + ex);
            }
        }
    }
}
