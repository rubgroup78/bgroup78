using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class DBservices
    {
        public SqlDataAdapter da;
        public System.Data.DataTable dt;

        public DBservices()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public List<Traveller> FindActivties(string conString, Traveller T)
        {

            SqlConnection con = null;
            List<Traveller> lh = new List<Traveller>();
            try
            {
                con = connect(conString); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "select top 10 t.ActivityName,MAX(t.Latitude) as Lat,MAX(t.[Longitude]) as Long, count(*) as NumberOfTimes  from touristsTbl t INNER JOIN touristsdetailsTbl tb on tb.RecordId = t.RecordID where 1 = 1 AND t.ActivityPurpose = 'Tourism / leisure / religious services / sports activities' AND t.ActivityName <> 'חוף הים' AND t.ActivityName <> 'תצפית' AND t.ActivityName <> 'טיול' AND t.ActivityName <> 'טיילת' AND t.ActivityName <> 'טיול רגלי' AND MONTH(tb.ArrivalDate) = " + T.SelctionMonth+" AND tb.NumberOfDays <="+ T.SelctionNumberOfDays+" AND tb.CountryOfResidence = "+T.SelctionCountryOfResidence+" AND tb.Female"+T.SelctionAgegroup + " = 1 OR tb.MaleAge"+ T.SelctionAgegroup + " = 1 group by t.ActivityName order by NumberOfTimes desc ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row

                    Traveller t = new Traveller();
                    t.Lng = Convert.ToDouble(dr["Long"]);
                    t.Lat = Convert.ToDouble(dr["Lat"]);
                    t.ActivityName = dr["ActivityName"].ToString();
                    t.NumberOfTimes = Convert.ToInt32(dr["NumberOfTimes"]);
                    lh.Add(t);
                }

                return lh;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        private SqlConnection connect(string conString)
        {
            throw new NotImplementedException();
        }
    }
}