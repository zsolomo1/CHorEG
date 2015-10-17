using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CHorEG_v3
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected Item ItemLeft
        { 
            get
            {
                return (Item)ViewState["ItemLeft"];
            }
            set
            {
                ViewState["ItemLeft"] = value;
            }
        }
        protected Item ItemRight
        {
            get
            {
                return (Item)ViewState["ItemRight"];
            }
            set
            {
                ViewState["ItemRight"] = value;
            }
        }

        private int GetNumItems()
        {
            var _connectionString = "Data Source=qwerty-pc;Initial Catalog=CHorEG;Integrated Security=True";
            SqlConnection _connection = new SqlConnection(_connectionString);
            _connection.Open();

            SqlDataReader dReader;

            var _cmdString = "SELECT COUNT(1) FROM tblItem";
            SqlCommand _lookupCommand = new SqlCommand(_cmdString);
            _lookupCommand.Connection = _connection;
            dReader = _lookupCommand.ExecuteReader();
            var MyResults = 0;

            if (dReader.HasRows)
            {
                while (dReader.Read())
                {
                    MyResults = dReader.GetInt32(0);
                }
            }

            _connection.Close();

            return MyResults;
        }

        private Item GetItem()
        {
            var _connectionString = "Data Source=qwerty-pc;Initial Catalog=CHorEG;Integrated Security=True";
            SqlConnection _connection = new SqlConnection(_connectionString);
            _connection.Open();

            SqlDataReader dReader;

            //Get the total number of items from the database using the GetNumItems() method
            var numItems = GetNumItems();
            //Make a new random number generator and use the total number of items as the upper bound for the random # being generated
            var aRandom = new Random();
            var myIndex = aRandom.Next(numItems);

            //Use our randomly generated number (within the bounds) to build our final SELECT string
            var _cmdString = "SELECT * FROM tblItem WHERE Item_ID = " + myIndex.ToString();
            SqlCommand _lookupCommand = new SqlCommand(_cmdString);
            _lookupCommand.Connection = _connection;
            dReader = _lookupCommand.ExecuteReader();
            Item _MyItem = new Item();
            
            if (dReader.HasRows)
            {
                while (dReader.Read())
                {
                    _MyItem.Item_ID = dReader.GetInt32(0);
                    _MyItem.Name = dReader.GetString(1);
                    _MyItem.Birthdate = dReader.GetInt32(2);
                    _MyItem.ImageURL = dReader.GetString(3);
                }
            }

            _connection.Close();
            return _MyItem;
        }

        

        protected void btLeft_Click(object sender, EventArgs e)
        {
            ItemLeft = GetItem();
            ImgL.ImageUrl = ItemLeft.ImageURL;
            ImgL.ToolTip = ItemLeft.Name;
        }


        protected void btRight_Click(object sender, EventArgs e)
        {
            ItemRight = GetItem();
            ImgR.ImageUrl = ItemRight.ImageURL;
            ImgR.ToolTip = ItemRight.Name;
        }

        protected void ImgR_Click(object sender, ImageClickEventArgs e)
        {
            var Result = false;
            if (ItemRight.Birthdate < ItemLeft.Birthdate)
            {
                Result = true;
            }
            lblResult.Text = Result.ToString();
        }

        protected void ImgL_Click(object sender, ImageClickEventArgs e)
        {
            var Result = false;
            if (ItemLeft.Birthdate < ItemRight.Birthdate)
            {
                Result = true;
            }
            lblResult.Text = Result.ToString();
        }

    }
}