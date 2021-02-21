using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Food_Ordering
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        string constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Lenovo\\OneDrive\\Documents\\ItemsDB.mdf;Integrated Security=True;Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False;";
        public string AddItem(Item item)
        {
            string result = "";
            try
            {
                SqlConnection con = new SqlConnection(constring);
                string query = @"INSERT INTO Items(Name, Description, Price, Type, Category, Status) Values(@name,@description,@price,@type,@category,@status)";
                SqlCommand com = new SqlCommand(query, con);

                com.Parameters.AddWithValue("@name", item.Name);
                com.Parameters.AddWithValue("@description", item.Description);
                com.Parameters.AddWithValue("@price", item.Price);
                com.Parameters.AddWithValue("@type", item.Type);
                com.Parameters.AddWithValue("@category", item.Category);
                com.Parameters.AddWithValue("@status", item.Status);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                result = "Item added successfully!!";

            }
            catch (FaultException fex)
            {
                result = "Error";
            }
            return result;
        }

        public string DeleteItem(Item item)
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "DELETE FROM Items WHERE Id=@id";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@id", item.Id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            return "Item deleted!!";
        }

        public DataSet getItems()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(constring);
                string query = "SELECT * from Items";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(ds);
            }
            catch (FaultException fex)
            {
                throw new FaultException<string>("Error: " + fex);
            }
            return ds;
        }

        public DataSet SearchItem(Item item)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(constring);
                string Query = "SELECT * FROM Items WHERE Id=@id";

                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                sda.SelectCommand.Parameters.AddWithValue("@id", item.Id);
                sda.Fill(ds);
            }
            catch (FaultException fex)
            {
                throw new FaultException<string>("Error:  " + fex);
            }
            return ds;
        }

        public string UpdateItem(Item item)
        {
            string res = "";
            SqlConnection con = new SqlConnection(constring);
            string q = "UPDATE Items SET Name = @name,Description=@description,Price=@price,Type=@type,Category=@cg,Status=@st WHERE Id=@id";
            SqlCommand com = new SqlCommand(q, con);
            com.Parameters.AddWithValue("@name", item.Name);
            com.Parameters.AddWithValue("@description", item.Description);
            com.Parameters.AddWithValue("@price", item.Price);
            com.Parameters.AddWithValue("@type", item.Type);
            com.Parameters.AddWithValue("@cg", item.Category);
            com.Parameters.AddWithValue("@st", item.Status);
            com.Parameters.AddWithValue("@id", item.Id);
            con.Open();
            com.ExecuteNonQuery();
            res = "Item updated!!";
            con.Close();
            return res;
        }

        /*
        public void AddItem(Item item)
        {
            ItemContext io = new ItemContext();
            io.Items.Add(item);
            io.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            ItemContext io = new ItemContext();
            var c = (from itm in io.Items
                     where itm.Id == id
                     select itm).First();
            io.Items.Remove(c);
            io.SaveChanges();
        }

        public string DeleteItem(Item item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            List<Item> li = new List<Item>();
            ItemContext io = new ItemContext();
            li = io.Items.ToList();
            return li;
        }

        public DataSet getItems()
        {
            throw new NotImplementedException();
        }

        public DataSet SearchItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            ItemContext io = new ItemContext();
            var c = (from itm in io.Items
                     where itm.Id == item.Id
                     select itm).First();
            c.Category = item.Category;
            c.Description = item.Description;
            c.Name = item.Name;
            c.Price = item.Price;
            c.Status = item.Status;
            c.Type = item.Type;
            io.SaveChanges();
        }

        string IService1.AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        string IService1.UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
        */
    }
}
