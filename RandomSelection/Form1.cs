using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomSelection
{
    public partial class Form1 : Form
    {
        int count;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] teamId = new string[count];
            string[] teamName = new string[count];
            int[] randomNumbers = new int[count];
            int count1 = 0;
            int randomCount = 0;
            SqlConnection connection = new SqlConnection(Connection.connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = Procedures.selectingValue;
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                teamId[count1] = reader["Id"].ToString();
               teamName[count1] = reader["Name"].ToString();
                count1++;
            }

            Random random = new Random();
            int number = random.Next(1, count);
            
            for (int i = 0; i < count; i++)
            {
                randomNumbers[randomCount] = number;
                if (number.ToString() == teamId[i] && randomNumbers[i] != number)
                {
                    txtName.Text = teamName[i];
                    txtId.Text = teamId[i];
                    break;
                }
                
            }
            randomCount++;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Connection.connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = Procedures.countingValues;
            command.CommandType = CommandType.StoredProcedure;
            count = Convert.ToInt32(command.ExecuteScalar());
        }
    }
}
