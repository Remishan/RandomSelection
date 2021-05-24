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
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] teamId = new string[100];
            string[] teamName = new string[100];
            int[] randomNumbers = new int[100];
            int count = 0;
            int randomCount = 0;
            SqlConnection connection = new SqlConnection(@"Server=DESKTOP-C0MLP28\SQLEXPRESS;Database=FileOpreation;Trusted_Connection=true;");
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "NameList";
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                teamId[count] = reader["Id"].ToString();
               teamName[count] = reader["Name"].ToString();
                count++;
            }

            Random random = new Random();
            int number = random.Next(1, 100);
            for (int i = 0; i < 100; i++)
            {
                if (number.ToString() == teamId[i] && randomNumbers[i] != number)
                {
                    txtName.Text = teamName[i];
                    txtId.Text = teamId[i];
                    randomNumbers[i] = number;
                    count++;
                    break;
                }
                //else
                //{
                //    MessageBox.Show("Not found" + number);
                //    randomNumbers[i] = number;

                //     break;
                //}
            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
