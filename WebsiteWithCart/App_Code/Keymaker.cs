using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;


/// <summary>
/// Keymaker is my database class manager.
/// </summary>
public class Keymaker
{
    
    
    protected string MyConstring = @"Data Source=Unkindled\SQLExpress;Initial Catalog=Voldemort;Integrated Security=True;";
    protected string privateServerString = @"Data Source=den1.mssql3.gear.host;Initial Catalog=prg412database;User ID=prg412database;Password=Sp0i_r-kt6c3;";
    protected string connstring;
    public Keymaker()
    {
        connstring = MyConstring;
        
    }
    /// <summary>
    /// This checks the user to see if in database
    /// </summary>
    /// <param name="user"></param>
    /// <returns>bool</returns>
    public bool CheckUserExists(string user)
    {
        using (SqlConnection conn = new SqlConnection(connstring))
        {
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                string query = "select * from UserInfo where Username ='" + user + "';";//refrence is a sql user needs a ' + user + '
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return true;

                    }
                }
            }
        }
        return false;
    }
    /// <summary>
    /// Checks the Password assosiated with the username
    /// </summary>
    /// <param name="user"></param>
    /// <param name="pw"></param>
    /// <returns>bool</returns>
    public bool CheckPMatches(string user, string pw)
    {
    using (SqlConnection conn = new SqlConnection(connstring))
    {
        conn.Open();
        if (conn.State == ConnectionState.Open)
        {
            string query = "select Password from UserInfo where Username='" + user + "';";
            SqlCommand cmd = new SqlCommand(query, conn);
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        //user was found
                        string pwFromDB = (string)rdr["Password"]; //read the password assosiated with the username
                                                                   //the way we wrote the username which is the primary key, if username is not 
                                                                   //a primary key we would use a while loop before the rdr.read()
                        if (pw == pwFromDB)
                        {
                            return true;
                        }
                    }

                }
            }
        }
    }
            return false;
    }
    public UserInfo GetUser(string user)    
    { 
        UserInfo ui = null;
        using(SqlConnection conn = new SqlConnection(connstring))
        {
            conn.Open();
            if(conn.State == ConnectionState.Open)
            {
                string query = "select * from UserInfo where Username ='" + user + "';";
                SqlCommand cmd = new SqlCommand(query, conn);
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        string first = (string)rdr["First"];
                        string last = (string)rdr["Last"];
                        string email = (string)rdr["Email"];
                        int age = (int)rdr["Age"];
                        bool male = (bool)rdr["IsMale"];

                       string rights = (string)rdr["AdminLevel"];//needs an enumerated type;

                        //check Enum.TryParse<>
                        AdminRights ar;
                        Enum.TryParse(rights, out ar);// captures what comes out
                        ui = new UserInfo(user, "", first, last, email, age, male, ar);
                    }

                }
    
            }
        }
        return ui;
    }
    public void CreatMember(UserInfo ui)
    {
        using (SqlConnection conn = new SqlConnection(connstring))
        {
            conn.Open();
             if(conn.State == ConnectionState.Open)
            {
                int isMale;
                if(ui.IsMale == true)
                {
                    isMale = 1;
                }
                else
                {
                    isMale = 0;
                }

                string query = "insert into UserInfo values('" + ui.UserName+ "','"
                    + ui.Password      +     "','" 
                    + ui.First         +     "','" 
                    + ui.Last          +     "','"
                    + ui.EMail          +     "',"
                    + ui.Age           +     "," 
                    + isMale           +     ",'" 
                    + ui.Rights.ToString() + "');";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();//execute the command    
            }
        }

    }
    public void CreateDBTables()
    {
        using (SqlConnection conn = new SqlConnection(connstring))
        {
            conn.Open();
            if(conn.State == ConnectionState.Open)
            {
                List<string> querys = new List<string>();

                string query = "";
                query = "create table UserInfo(Username varchar(20) primary key," +
                    "Password varchar(25) not null,First varchar(25),Last varchar(25),"
                    + "Email varchar(40),Age int, IsMale bit," +
                    "AdminLevel varchar(10));";
                querys.Add(query);
                query = "Insert into UserInfo values ('unkindled','superstrongpass','brendon','blau','brendon@yahoo.com',29,1,'Owner');";
                querys.Add(query);
                query = "create table Product(ID int primary key, Mfr varchar(20) not null,Model varchar(20) not null, Part varchar(20) not null, Description varchar(200) not null, Image varchar(50));";
                querys.Add(query);
                query = "Insert into Product values (1234,'tesla','Dragon Breath','00812','Burn your stuff with firebreath','alcohol.jpg');";
                querys.Add(query);

                SqlCommand cmd;//reuse variable.
                foreach (string q in querys)
                {
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                
            }
        }
            
    }
    public void TempDeleteAllDatabase()
    {
        string deleteEveryoneButOwner = "delete from UserInfo where AdminLevel != 'Owner';";
        using (SqlConnection conn = new SqlConnection(connstring))
        {
            conn.Open();
            if(conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand(deleteEveryoneButOwner, conn);
                cmd.ExecuteNonQuery();
            }
        }

    }
    public string CreateProducts()
    {
        string msg = "All good";
        using (SqlConnection conn = new SqlConnection(connstring))
        {
            conn.Open();
            if(conn.State== ConnectionState.Open)
            {/*
               (ID int primary key, 
               Mfr varchar(20) not null, 
               Model varchar(20) not null, 
               Part varchar(20) not null, 
               Description varchar(200) not null, 
               Image varchar(50));
             */
                List<string> bunchOfProductsQuery = new List<string>();
                string a = "";
                a = "Insert into Product values(001,'Walmart','sting','a45t2','the best thing you will ever get sting','some image.');";
                bunchOfProductsQuery.Add(a);
                a = "Insert into product values(002,'Target','bumper','g67_e2','the bump that keeps up the thump','a better image');";
                bunchOfProductsQuery.Add(a);

                foreach (string s in bunchOfProductsQuery)
                {
                    try 
                    {
                        SqlCommand cmd = new SqlCommand(s, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception e)
                    {
                        msg = e.Message;
                    }
                    
                }
            }
        }
        return msg;
    }
    public List<Product> GetAllProducts()//return list of products
    {
        #region code for getting an image.
        List<Product> allProds = new List<Product>();   //we used a list of Product because we store all information in the constructor.
        List<string> somthing = new List<string>();    //we dont use a list of string because it only can carry one single item from the sql reader. 
                        //we also dont return a string but we return a list of product.
        using (SqlConnection con = new SqlConnection(connstring))
        {
            con.Open();//attempt to open
            if (con.State == ConnectionState.Open)
            {
                string query = "select * from product;";
                SqlCommand cmd = new SqlCommand(query, con);
                using (SqlDataReader sqlReader = cmd.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        int id = (int)sqlReader["ID"];  //column in product table dictionary
                        string manufacturer = (string)sqlReader["Mfr"];
                        string model = (string)sqlReader["Model"];
                        string part = (string)sqlReader["Part"];
                        string descript = (string)sqlReader["Description"];
                        string imageFile = (string)sqlReader["Image"];
                        decimal price =  (decimal)sqlReader["Price"];
                        //string relative = Path.Combine("Images", "Products", imageFile); 
                        Product p = new Product(id, manufacturer, model, part, price, descript, imageFile);
                        allProds.Add(p);
                        //somthing.Add(model);//this only get one thing out of the sql Reader. and not everything else.
                    }
                }
            }
            return allProds;

        }
        #endregion
    }
    public Product GetProduct(int id)
    {
        Product p = null;
        using (SqlConnection conn = new SqlConnection(connstring))
        {
            conn.Open();
            if(conn.State == ConnectionState.Open)
            {
                string query = "select * from Product where ID ='"+ id + "';";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if(rdr.Read())
                    {
                        string manufacturer = (string)rdr["Mfr"];
                        string model = (string)rdr["Model"];
                        string part = (string)rdr["Part"];
                        string descript = (string)rdr["Description"];
                        string imageFile = (string)rdr["Image"];
                        decimal price = (decimal)rdr["Price"];
                        p = new Product(id, manufacturer, model, part, price, descript, imageFile);
                    }
                }
            }
        }
        return p;
    }

    //public List<string> GetProductDescription()
    //{

    //}
    //public List<Product> Search(string phraces)
    //{

    //}
     
}