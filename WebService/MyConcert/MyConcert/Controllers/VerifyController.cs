﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using static System.Net.WebRequestMethods;
using System.Text;
using System.IO;

namespace MyConcert.Controllers
{
    public class VerifyController : ApiController
    {
        string _dbConectionString = "Server=myconcert.database.windows.net;"   //conectionString;
            + "Database=DBMyConcert; User Id=myconcertroot; Password=!15C24D9D";


        /********************************************************        
        *                  POST Verify User 
        ********************************************************/

        [System.Web.Http.HttpPost]
        [Route("api/Verify/User")]
        public string verifyUser([FromBody] dynamic pJson)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _dbConectionString; //conectionString;
                try
                {
                    conn.Open();
                    string dbQuery = "spUserExists";

                    SqlCommand command = new SqlCommand(); // DB Call. dbQuery, conn

                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = dbQuery;//                   

                    command.Parameters.AddWithValue("@pEmail", (string)(pJson.Email));                     

                    var details = new Dictionary<string, object>();                    

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                details.Add(reader.GetName(i), reader.IsDBNull(i) ? null : reader.GetValue(i));
                            }
                        }

                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string jsonDoc = jss.Serialize(details);
                        return jsonDoc;

                    }
                }
                catch (SqlException e)
                {
                    return e.Message;
                }
            }

        }


        /********************************************************        
        *                  POST Login Verification
        ********************************************************/

        [System.Web.Http.HttpPost]
        [Route("api/Verify/Login")]        
        public string Login([FromBody] dynamic pJson)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _dbConectionString; //conectionString;
                try
                {
                    conn.Open();
                    string dbQuery = "spLogin";

                    SqlCommand command = new SqlCommand(); // DB Call. dbQuery, conn

                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = dbQuery;//                   
                        
                    command.Parameters.AddWithValue("@pEmail", (string)(pJson.Email)) ; //);
                    command.Parameters.AddWithValue("@pPass", (string)(pJson.Password));// );

                    var details = new Dictionary<string, object>();
                    //return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection).ToString();


                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                            details.Add(reader.GetName(i), reader.IsDBNull(i) ? null : reader.GetValue(i));                            
                            }
                        }
                                                                                             
                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string jsonDoc = jss.Serialize(details);
                        return jsonDoc;

                    }
                }
                catch (SqlException e)
                {
                    return e.Message;
                }
            }

        }

        /********************************************************        
         *                  POST Register User             
         ********************************************************/

        [System.Web.Http.HttpPost]
        [Route("api/Verify/RegisterUser")]        
        public string RegisterUser([FromBody] dynamic pJson)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _dbConectionString; //conectionString;
                try
                {
                    conn.Open();
                    string dbQuery = "spRegisterUser";
                    SqlCommand command = new SqlCommand(); // DB Call. dbQuery, conn

                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = dbQuery;//                            


                     command.Parameters.AddWithValue("@pName", (string)(pJson.Name));
                     command.Parameters.AddWithValue("@pLastname", (string)(pJson.Lastname));
                     command.Parameters.AddWithValue("@pCountry", (string)(pJson.Country)); //
                     command.Parameters.AddWithValue("@pResidence", (string)(pJson.Residence));
                     command.Parameters.AddWithValue("@pUni_ID", (string)(pJson.ID_Uni)); //
                     command.Parameters.AddWithValue("@pEmail", (string)(pJson.Email));
                     command.Parameters.AddWithValue("@pPhone", (string)(pJson.Phone));
                     command.Parameters.AddWithValue("@pPhoto", (string)(pJson.Photo));
                     command.Parameters.AddWithValue("@pPass", (string)(pJson.Pass));
                     command.Parameters.AddWithValue("@pDescription", (string)(pJson.Description)); 
                     command.Parameters.AddWithValue("@pBirthdate", (string)(pJson.Birthdate));

                    /*command.Parameters.AddWithValue("@pName", "David");
                    command.Parameters.AddWithValue("@pLastname", "Monestel");
                    command.Parameters.AddWithValue("@pID_Country", "1");
                    command.Parameters.AddWithValue("@pResidence", "Casa de Fabian");
                    command.Parameters.AddWithValue("@pUni_ID", "1");
                    command.Parameters.AddWithValue("@pEmail", "@papa");
                    command.Parameters.AddWithValue("@pPhone", "89731119");
                    command.Parameters.AddWithValue("@pPhoto", "abcdefgh");
                    command.Parameters.AddWithValue("@pPass", "123");
                    command.Parameters.AddWithValue("@pDescription", "hola me llamo benito benitocamelas");
                    command.Parameters.AddWithValue("@pBirthdate", "01/02/2010");*/


                    var details = new Dictionary<string, object>();

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                details.Add(reader.GetName(i), reader.IsDBNull(i) ? null : reader.GetValue(i));
                            }
                        }

                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string jsonDoc = jss.Serialize(details);
                        return jsonDoc;
                    }
                }
                catch (SqlException e)
                {
                    return e.Message;
                }
            }
        }

        /********************************************************        
        *                  POST Register Admin
        ********************************************************/

        [HttpPost]
        [Route("api/Verify/RegisterAdmin")]
        public string RegisterAdmin([FromBody] dynamic pJson)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _dbConectionString; //conectionString;
                try
                {
                    conn.Open();
                    string dbQuery = "spRegisterAdmin";
                    SqlCommand command = new SqlCommand(); // DB Call. dbQuery, conn

                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = dbQuery;//  

                    command.Parameters.AddWithValue("@pName", (string)pJson.Name);
                    command.Parameters.AddWithValue("@pLastname", (string)pJson.Lastname);
                    command.Parameters.AddWithValue("@pEmail", (string)pJson.Email);
                    command.Parameters.AddWithValue("@pPass", (string)pJson.Password);

                    var details = new Dictionary<string, object>();

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                details.Add(reader.GetName(i), reader.IsDBNull(i) ? null : reader.GetValue(i));
                            }
                        }

                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string jsonDoc = jss.Serialize(details);
                        return jsonDoc;
                    }
                }

                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

        /********************************************************        
        *                  POST Register Country
        ********************************************************/
        [HttpPost]
        [Route("api/Verify/RegisterCountry")]
        public string registerCountry([FromBody] dynamic pJson)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _dbConectionString; //conectionString;
                try
                {
                    conn.Open();
                    string dbQuery = "spRegisterCountry";
                    SqlCommand command = new SqlCommand(); // DB Call. dbQuery, conn

                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = dbQuery;//  

                    command.Parameters.AddWithValue("@pName", (string)pJson.Name);                   

                    var details = new Dictionary<string, object>();

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                details.Add(reader.GetName(i), reader.IsDBNull(i) ? null : reader.GetValue(i));
                            }
                        }

                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string jsonDoc = jss.Serialize(details);
                        return jsonDoc;
                    }
                }

                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }


        /********************************************************        
        *                  POST Register University
        ********************************************************/
        [HttpPost]
        [Route("api/Verify/RegisterUniversity")]
        public string registerUniversity([FromBody] dynamic pJson)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _dbConectionString; //conectionString;
                try
                {
                    conn.Open();
                    string dbQuery = "spRegisterUniversity";
                    SqlCommand command = new SqlCommand(); // DB Call. dbQuery, conn

                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = dbQuery;//  

                    command.Parameters.AddWithValue("@pName", (string)pJson.Name);

                    var details = new Dictionary<string, object>();

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                details.Add(reader.GetName(i), reader.IsDBNull(i) ? null : reader.GetValue(i));
                            }
                        }

                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string jsonDoc = jss.Serialize(details);
                        return jsonDoc;
                    }
                }

                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }


        /********************************************************        
        *                  POST Register User Status
        ********************************************************/
        [HttpPost]
        [Route("api/Verify/RegisterUserStatus")]
        public string registerUserStatus([FromBody] dynamic pJson)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _dbConectionString; //conectionString;
                try
                {
                    conn.Open();
                    string dbQuery = "spRegisterUserState";
                    SqlCommand command = new SqlCommand(); // DB Call. dbQuery, conn

                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = dbQuery;//  

                    command.Parameters.AddWithValue("@pName", (string)pJson.Name);

                    var details = new Dictionary<string, object>();

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                details.Add(reader.GetName(i), reader.IsDBNull(i) ? null : reader.GetValue(i));
                            }
                        }

                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string jsonDoc = jss.Serialize(details);
                        return jsonDoc;
                    }
                }

                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

        /********************************************************        
       *                  POST Register Event Status
       ********************************************************/
        [HttpPost]
        [Route("api/Verify/RegisterEventStatus")]
        public string registerEventStatus([FromBody] dynamic pJson)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _dbConectionString; //conectionString;
                try
                {
                    conn.Open();
                    string dbQuery = "spRegisterEventState";
                    SqlCommand command = new SqlCommand(); // DB Call. dbQuery, conn

                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = dbQuery;//  

                    command.Parameters.AddWithValue("@pName", (string)pJson.Name);

                    var details = new Dictionary<string, object>();

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                details.Add(reader.GetName(i), reader.IsDBNull(i) ? null : reader.GetValue(i));
                            }
                        }

                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string jsonDoc = jss.Serialize(details);
                        return jsonDoc;
                    }
                }

                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }


        /********************************************************        
       *                  POST Register Place
       ********************************************************/
        [HttpPost]
        [Route("api/Verify/RegisterPlace")]
        public string registerPlace([FromBody] dynamic pJson)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _dbConectionString; //conectionString;
                try
                {
                    conn.Open();
                    string dbQuery = "spRegisterPlace";
                    SqlCommand command = new SqlCommand(); // DB Call. dbQuery, conn

                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = dbQuery;//  

                    command.Parameters.AddWithValue("@pName", (string)pJson.Name);

                    var details = new Dictionary<string, object>();

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                details.Add(reader.GetName(i), reader.IsDBNull(i) ? null : reader.GetValue(i));
                            }
                        }

                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string jsonDoc = jss.Serialize(details);
                        return jsonDoc;
                    }
                }

                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }


        /********************************************************        
       *                  POST Register Category
       ********************************************************/
        [HttpPost]
        [Route("api/Verify/RegisterCategory")]
        public string registerCategory([FromBody] dynamic pJson)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _dbConectionString; //conectionString;
                try
                {
                    conn.Open();
                    string dbQuery = "spRegisterCategory";
                    SqlCommand command = new SqlCommand(); // DB Call. dbQuery, conn

                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = dbQuery;//  

                    command.Parameters.AddWithValue("@pName", (string)pJson.Name);

                    var details = new Dictionary<string, object>();

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                details.Add(reader.GetName(i), reader.IsDBNull(i) ? null : reader.GetValue(i));
                            }
                        }

                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string jsonDoc = jss.Serialize(details);
                        return jsonDoc;
                    }
                }

                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

        /********************************************************        
      *                  POST Register Band (SPECIAL)
      ********************************************************/
        [HttpPost]
        [Route("api/Verify/RegisterBand")]
        public string registerBand([FromBody] dynamic pJson)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _dbConectionString; //conectionString;
                try
                {
                    conn.Open();
                    string dbQuery = "spRegisterBand";
                    SqlCommand command = new SqlCommand(); // DB Call. dbQuery, conn

                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = dbQuery;//  

                    command.Parameters.AddWithValue("@pName", (string)pJson.name);                    

                    string bandID = string.Empty;                    

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            bandID = reader.GetValue(0).ToString();                                                   
                        }                        
                    }

                    try
                    {                        
                        var response="";                        
                        for (int i = 0; i < pJson.songs.Count; i++)
                        {
                            var diccA = new Dictionary<string, object>();
                            diccA.Add("ID", bandID.ToString()); 
                            diccA.Add("Song", (string)(pJson.songs[i].name));
                            dynamic JsonA = Models.UtilityMethods.diccTOstrinJson(diccA);

                            string url = "http://myconcert1.azurewebsites.net/api/Funcs/AddSongToBand";
                            response = Models.UtilityMethods.postMethod(JsonA, url);                            

                        }
                        for (int i = 0; i < pJson.members.Count; i++)
                        {
                            var diccB = new Dictionary<string, object>();
                            diccB.Add("ID", bandID.ToString()); 
                            diccB.Add("Member", (string)(pJson.members[i].name));
                            dynamic JsonB = Models.UtilityMethods.diccTOstrinJson(diccB);

                            string url = "http://myconcert1.azurewebsites.net/api/Funcs/AddMemberToBand";
                            response = Models.UtilityMethods.postMethod(JsonB, url);                     
                        }
                        for (int i = 0; i < pJson.genres.Count; i++)
                        {
                            var diccC = new Dictionary<string, object>();
                            diccC.Add("ID", bandID.ToString());
                            diccC.Add("Genre", (string)(pJson.genres[i].name));
                            dynamic JsonC = Models.UtilityMethods.diccTOstrinJson(diccC);

                            string url = "http://myconcert1.azurewebsites.net/api/Funcs/AddGenreToBand";
                            response = Models.UtilityMethods.postMethod(JsonC, url);                           
                        }                        

                        return response;

                    }
                    catch (SqlException e)
                    {
                       return e.Message;
                    }                                                                                   
                }

                catch (SqlException e)
                {
                    return e.Message;
                }
            }
        }


        /********************************************************        
        *                  POST Register Genre
        ********************************************************/
        [HttpPost]
        [Route("api/Verify/RegisterGenre")]
        public string spRegisterGenre([FromBody] dynamic pJson)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _dbConectionString; //conectionString;
                try
                {
                    conn.Open();
                    string dbQuery = "spRegisterGenre";
                    SqlCommand command = new SqlCommand(); // DB Call. dbQuery, conn

                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = dbQuery;//  

                    command.Parameters.AddWithValue("@pName", (string)pJson.Name);

                    var details = new Dictionary<string, object>();

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                details.Add(reader.GetName(i), reader.IsDBNull(i) ? null : reader.GetValue(i));
                            }
                        }

                        JavaScriptSerializer jss = new JavaScriptSerializer();
                        string jsonDoc = jss.Serialize(details);
                        return jsonDoc;
                    }
                }

                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }






















    }
}



/*
 * COMO LEER DE LA BASE.
 * var details = new Dictionary<string, object>();

            // Create new SqlDataReader object and read data from the command.
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows && reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        details.Add(reader.GetName(i), reader.IsDBNull(i) ? null : reader.GetValue(i));
                    }


                }

                JavaScriptSerializer jss = new JavaScriptSerializer();
                string jsonDoc = jss.Serialize(details);
                return jsonDoc;*/