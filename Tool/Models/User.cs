using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Tool.Models
{
    public class SHA512
    {
        public static string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA512.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }
    }

    public class User
    {
        [Required]
        [DisplayName ("User name")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName ("Password")]
        public string Password { get; set; }
      
        public bool IsValid(string _username, string _password)
        {
            
            using (var cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = E:\programming\studing\softserve\Tool\Tool\Tool\App_Data\Database.mdf; Integrated Security = True"))
            {
                string _sql = @"SELECT [login] FROM [dbo].[users] WHERE [login] = @u AND [password] = @p";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = _username;
                cmd.Parameters
                    .Add(new SqlParameter("@p", SqlDbType.NVarChar))
                    .Value = SHA512.Encode(_password);
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }
        }
    }
}