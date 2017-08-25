using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;   //CommandType için
using MySql.Data.MySqlClient;  //MySqlConnection için gerekli

namespace StokUrunYonetim
{
    public class Komutlar
    {
        MySqlConnection conn = new MySqlConnection("server=localhost; userid=root; password=; database=urunstokyonetim;");

        public DataTable urunStokCikisTumu()
        {
            //int parcaStokID = 0;
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("urun_Stok_Cikis_Tumu", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);

            return dataTable;
        }

        public void urunStokCikis(int urun_id, int urun_miktar, DateTime urun_islem_tarih)
        {
            MySqlCommand cmd = new MySqlCommand("urun_Stok_Cikis", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new MySqlParameter("_urun_id", urun_id));
            cmd.Parameters.Add(new MySqlParameter("_urun_miktar", urun_miktar));
            cmd.Parameters.Add(new MySqlParameter("_urun_islem_tarih", urun_islem_tarih));


            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                //MessageBox.Show("Yeni parca stok'a eklendi.");
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.ToString(), "Parcayı Stok'a Ekleme Hatası");
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public void urunStokSil(int urun_id)
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("urun_Stok_Sil", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_urun_id", urun_id));

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public DataTable urunStokGosterId(int urun_id)
        {
            //int parcaStokID = 0;
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("urun_Stok_Goster_Id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_urun_id", urun_id));

            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);

            return dataTable;
        }

        public void urunStokGuncelle(int urun_id, int urun_miktar, DateTime urun_islem_tarih)
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("urun_Stok_Guncelle", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_urun_id", urun_id));
            cmd.Parameters.Add(new MySqlParameter("_urun_miktar", urun_miktar));
            cmd.Parameters.Add(new MySqlParameter("_urun_islem_tarih", urun_islem_tarih));

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                //MessageBox.Show("'" + urun_id + " ID'li  urun stok'u başarıyla güncellendi.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public DataTable urunStokTumu()
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("urun_Stok_Tumu", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);

           return dataTable;
        }

        public double parcaFiyat(int parca_id)
        {
            double parcaFiyat = 0;
            DataTable dataTable = new DataTable();
            MySqlCommand cmd = new MySqlCommand("parca_Fiyat", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_parca_id",parca_id));
            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);

            parcaFiyat = (double)dataTable.Rows[0][0];

            return parcaFiyat;
        }

        public DataTable parcaStokGoster(int urun_id)
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("parca_Stok_Goster", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new MySqlParameter("_urun_id", urun_id));

            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);

            return dataTable;
        }

        //tam emin degilim degisiklik yapabilirim TEKRAR BAK...
        public void urunStokEkle(int urun_id, int urun_miktar, DateTime urun_islem_tarih)
        {
            MySqlCommand cmd = new MySqlCommand("urun_Stok_Ekle", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_urun_id", urun_id));
            cmd.Parameters.Add(new MySqlParameter("_urun_miktar", urun_miktar));
            cmd.Parameters.Add(new MySqlParameter("_urun_islem_tarih", urun_islem_tarih));

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                //MessageBox.Show("Yeni parça ürüne eklendi.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Urun Ekleme Hatası");
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public void urunParcalarSil(int urun_id)
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("urun_Parcalar_Sil", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_urun_id", urun_id));

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public DataTable urunParcalarGoster(int urun_id)
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("urun_Parcalar_Goster", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new MySqlParameter("_urun_id", urun_id));

            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);
          
            return dataTable;
        }

        public Int32 urunSonEklenenID()
        {
            Int32 maxID = 0;
            DataTable dataTable = new DataTable();
            MySqlCommand cmd = new MySqlCommand("urun_Son_Eklenen_ID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0][0] != DBNull.Value)
                {
                    maxID = Convert.ToInt32(dataTable.Rows[0][0]);
                }
            }
            return maxID;
        }

        public void urunParcalarEkle(int urun_id, int parca_id, int parca_sayisi)
        {
            MySqlCommand cmd = new MySqlCommand("urun_Parcalar_Ekle", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_urun_id", urun_id));
            cmd.Parameters.Add(new MySqlParameter("_parca_id", parca_id));
            cmd.Parameters.Add(new MySqlParameter("_parca_sayisi", parca_sayisi));

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                //MessageBox.Show("Yeni parça ürüne eklendi.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Urune Parça Ekleme Hatası");
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public void urunGuncelle(int urun_id, string urun_isim, string urun_ozellik, string urun_aciklama, DateTime urun_kayit_tarih, bool showMessage)
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("urun_Guncelle", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_urun_id", urun_id));
            cmd.Parameters.Add(new MySqlParameter("_urun_isim", urun_isim));
            cmd.Parameters.Add(new MySqlParameter("_urun_ozellik", urun_ozellik));
            cmd.Parameters.Add(new MySqlParameter("_urun_aciklama", urun_aciklama));
            cmd.Parameters.Add(new MySqlParameter("_urun_kayit_tarih", urun_kayit_tarih));

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                if(showMessage)
                MessageBox.Show("'" + urun_isim + "' isimli ürün başarıyla güncellendi.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public void urunSil(int urun_id, bool showMessage)
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("urun_Sil", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_urun_id", urun_id));

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                if (showMessage)
                    MessageBox.Show("Ürün silme işlemi başarı ile gerçekleşti..!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public DataTable urunGosterTumu()
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("urun_Goster_Tumu", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);


            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0][0] != DBNull.Value)
                {
                    //Program.selectedCihazID = Convert.ToInt32(dataTable.Rows[0][0]);
                }

                //Program.selectedMakine_Ad = Convert.ToString(dataTable.Rows[0][1]);
                //Program.selectedBT_Adress = Convert.ToString(dataTable.Rows[0][2]);
            }

            return dataTable;
        }

        public void urunEkle(string urun_isim, string urun_ozellik, string urun_aciklama, DateTime urun_kayit_tarih, bool showMessage)
        {
            MySqlCommand cmd = new MySqlCommand("urun_Ekle", conn);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add(new MySqlParameter("_urun_isim", urun_isim));
            cmd.Parameters.Add(new MySqlParameter("_urun_ozellik", urun_ozellik));
            cmd.Parameters.Add(new MySqlParameter("_urun_aciklama", urun_aciklama));
            cmd.Parameters.Add(new MySqlParameter("_urun_kayit_tarih", urun_kayit_tarih));

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                if(showMessage)
                MessageBox.Show("Yeni urun eklendi.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Urun Ekleme Hatası");
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public DataTable parcaCikisGoster()
        {
            //int parcaStokID = 0;
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("parca_Stok_Cikis_Goster", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            

            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);

            return dataTable;
        }

        public void parcaStokCikis(int miktar, DateTime islem_tarih, int parca_id)
        {
            MySqlCommand cmd = new MySqlCommand("parca_Stok_Cikis", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new MySqlParameter("_miktar", miktar));
            cmd.Parameters.Add(new MySqlParameter("_islem_tarih", islem_tarih));
            cmd.Parameters.Add(new MySqlParameter("_parca_id", parca_id));


            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                //MessageBox.Show("Yeni parca stok'a eklendi.");
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.ToString(), "Parcayı Stok'a Ekleme Hatası");
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public void parcaStokGuncelle(int parca_id,int miktar,DateTime islem_tarih, bool showMessage)
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("parca_Stok_Guncelle", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_parca_id", parca_id));
            cmd.Parameters.Add(new MySqlParameter("_miktar", miktar));
            cmd.Parameters.Add(new MySqlParameter("_islem_tarih", islem_tarih));
            
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                if (showMessage)
                MessageBox.Show("'" + parca_id + " ID'li  parca stok'u başarıyla güncellendi.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }


        public void parcaStokSil(int parca_id)
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("parca_Stok_Sil", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_id", parca_id));

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public DataTable parcaStokTumu()
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("parca_Stok_Tumu", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);

            return dataTable;
        }

        public void parcaStokGir(int miktar,DateTime islem_tarih,int parca_id, bool showMessage)
        {
            MySqlCommand cmd = new MySqlCommand("parca_Stok_Gir", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new MySqlParameter("_miktar", miktar));
            cmd.Parameters.Add(new MySqlParameter("_islem_tarih", islem_tarih));           
            cmd.Parameters.Add(new MySqlParameter("_parca_id", parca_id));


            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                if(showMessage)
                MessageBox.Show("Yeni parca stok'a eklendi.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Parcayı Stok'a Ekleme Hatası");
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public DataTable parcaStokIsim()
        {
            DataTable dataTable = new DataTable();
            MySqlCommand cmd = new MySqlCommand("parca_Stok_Isim", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);

            return dataTable;
        }
        public DataTable parcaJoin()
        {
            DataTable dataTable = new DataTable();
            MySqlCommand cmd = new MySqlCommand("parca_Join", conn);
            cmd.CommandType = CommandType.StoredProcedure;
           
            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);

            return dataTable;
           
        }

        //ismi girilen parcalari goruntule
        public DataTable parcaIsim(string isim)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand cmd = new MySqlCommand("parca_Isim", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_isim", isim));
            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);

            return dataTable;

        }
        public void parcaEkle( string tur, string isim, string parcaKodu, string ozellik, string aciklama, double fiyat, DateTime islemTarih)
        {
            MySqlCommand cmd = new MySqlCommand("parca_Ekle", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add(new MySqlParameter("_tur", tur));
            cmd.Parameters.Add(new MySqlParameter("_isim", isim));
            cmd.Parameters.Add(new MySqlParameter("_parcaKodu", parcaKodu));
            cmd.Parameters.Add(new MySqlParameter("_ozellik", ozellik));
            cmd.Parameters.Add(new MySqlParameter("_aciklama", aciklama));            
            cmd.Parameters.Add(new MySqlParameter("_fiyat", fiyat));
            cmd.Parameters.Add(new MySqlParameter("_islemTarih", islemTarih));

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Yeni parca eklendi.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Parca Ekleme Hatası");
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public void parcaGuncelle(int id, string tur, string isim, string parcaKodu, string ozellik, string aciklama, double fiyat, DateTime islemTarih)
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("parca_Guncelle", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_id", id));
            cmd.Parameters.Add(new MySqlParameter("_tur", tur));
            cmd.Parameters.Add(new MySqlParameter("_isim", isim));
            cmd.Parameters.Add(new MySqlParameter("_parcaKodu", parcaKodu));
            cmd.Parameters.Add(new MySqlParameter("_ozellik", ozellik));
            cmd.Parameters.Add(new MySqlParameter("_aciklama", aciklama));
            cmd.Parameters.Add(new MySqlParameter("_fiyat", fiyat));
            cmd.Parameters.Add(new MySqlParameter("_islemTarih", islemTarih));

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("'" + isim + "' isimli parca başarıyla güncellendi.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public void parcaSil(int parca_id)
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("parca_Sil", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_id", parca_id));

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

        public DataTable parcaTumu()
        {
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("parca_Tumu", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);


            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0][0] != DBNull.Value)
                {
                    //Program.selectedCihazID = Convert.ToInt32(dataTable.Rows[0][0]);
                }

                //Program.selectedMakine_Ad = Convert.ToString(dataTable.Rows[0][1]);
                //Program.selectedBT_Adress = Convert.ToString(dataTable.Rows[0][2]);
            }

            return dataTable;
        }

        public DataTable parcaStokGosterId(int parca_id)
        {
            //int parcaStokID = 0;
            DataTable dataTable = new DataTable();

            MySqlCommand cmd = new MySqlCommand("parca_Stok_Goster_ID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_parca_id", parca_id));

            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);

            return dataTable;
        }

        public int parca_ID_Bul(int parca_No)
        {
            int returnedParcaNo = 0;

            MySqlCommand cmd = new MySqlCommand("parca_ID_Bul", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_parca_No", parca_No));
            try
            {
                cmd.Connection.Open();
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    returnedParcaNo = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
            return returnedParcaNo;
        }

        public DataTable parcaSecim(int parca_id)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand cmd = new MySqlCommand("parca_Secim", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("_parca_id", parca_id));
            MySqlDataAdapter adaptor = new MySqlDataAdapter(cmd);
            adaptor.Fill(dataTable);

            return dataTable;

        }
    }
}
