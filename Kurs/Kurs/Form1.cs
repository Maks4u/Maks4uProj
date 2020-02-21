using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kurs
{
    public partial class Form1 : Form

    {
        string conn_string = @"Data Source=LAPTOP-IEONFFMR\SQLEXPRESS;Initial Catalog=Kursa4;Persist Security Info=True;User ID=sa;Password=e3dvdk5p";
        public Form1()
        {
            InitializeComponent();


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void catBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.catBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.kursa4DataSet);

        }

        public System.Windows.Forms.DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kursa4DataSet13.VievDeleteComing' table. You can move, or remove it, as needed.
            this.vievDeleteComingTableAdapter1.Fill(this.kursa4DataSet13.VievDeleteComing);
            // TODO: This line of code loads data into the 'kursa4DataSet12.VievDeleteComing' table. You can move, or remove it, as needed.
            this.vievDeleteComingTableAdapter.Fill(this.kursa4DataSet12.VievDeleteComing);
            // TODO: This line of code loads data into the 'kursa4DataSet11.vvv112' table. You can move, or remove it, as needed.
            this.vvv112TableAdapter.Fill(this.kursa4DataSet11.vvv112);

            // TODO: This line of code loads data into the 'here.VievPatient' table. You can move, or remove it, as needed.
            this.vievPatientTableAdapter.Fill(this.here.VievPatient);
            // TODO: This line of code loads data into the 'here.VievDoctor' table. You can move, or remove it, as needed.
            this.vievDoctorTableAdapter.Fill(this.here.VievDoctor);
            // TODO: This line of code loads data into the 'here.VievDoctor' table. You can move, or remove it, as needed.
            this.vvv112TableAdapter.Fill(this.kursa4DataSet11.vvv112);


            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView3.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView2.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void catBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private const string V = "IDdoctor";
        Form2 f2 = new Form2();

        private void button2_Click(object sender, EventArgs e)
        {

            string cmd_text;
            Form3 f2 = new Form3();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                cmd_text = "INSERT INTO Coming VALUES (" +
                "'" + f2.textBox1.Text + "' , '" +
                f2.textBox4.Text + "' , '" +
                f2.textBox3.Text + "' , '" +
                f2.textBox2.Text + "')";

                // создать соединение с базой данных
                SqlConnection sql_conn = new SqlConnection(conn_string);

                // создать команду на языке SQL
                SqlCommand sql_comm = new SqlCommand(cmd_text, sql_conn);

                sql_conn.Open(); // открыть соединение
                sql_comm.ExecuteNonQuery(); // выполнить команду на языке SQL
                sql_conn.Close(); // закрыть соединение

            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            f2.ShowDialog();
            this.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = this.here.VievDoctor;

            {
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    dataGridView2.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                        if (dataGridView2.Rows[i].Cells[j].Value != null)
                            if (dataGridView2.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox1.Text.ToLower()))
                            {
                                dataGridView2.Rows[i].Selected = true;
                                break;
                            }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = this.here.VievPatient;

            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox2.Text.ToLower()))
                            {
                                dataGridView1.Rows[i].Selected = true;
                                break;
                            }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
      
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = this.kursa4DataSet10.vv111;

            {
                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    dataGridView3.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView3.ColumnCount; j++)
                        if (dataGridView3.Rows[i].Cells[j].Value != null)
                            if (dataGridView3.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox3.Text.ToLower()))
                            {
                                dataGridView3.Rows[i].Selected = true;
                                break;
                            }
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void button7_Click_1(object sender, EventArgs e)
        {
            DeleteDru d6 = new DeleteDru();
            if (d6.ShowDialog() == DialogResult.OK)
            {
                string cmd_text = "DELETE FROM Coming";
                int index;
                string id_good;

                index = dataGridView3.CurrentRow.Index;
                id_good = Convert.ToString(dataGridView3[0, index].Value);
                cmd_text = "DELETE FROM Coming WHERE [Coming].[Id] = '" + id_good + "'";

                SqlConnection sql_conn = new SqlConnection(conn_string);
                SqlCommand sql_comm = new SqlCommand(cmd_text, sql_conn);

                sql_conn.Open();
                sql_comm.ExecuteNonQuery();
                sql_conn.Close();

            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
