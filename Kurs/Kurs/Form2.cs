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
    public partial class Form2 : Form
    {
        string conn_string = @"Data Source=LAPTOP-IEONFFMR\SQLEXPRESS;Initial Catalog=Kursa4;Persist Security Info=True;User ID=sa;Password=e3dvdk5p";
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public System.Windows.Forms.DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode { get; set; }

        private void Form2_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'here.Diagnoz' table. You can move, or remove it, as needed.
            this.diagnozTableAdapter.Fill(this.here.Diagnoz);
            // TODO: This line of code loads data into the 'kursa4DataSet6.DrugsComplete' table. You can move, or remove it, as needed.
            this.drugsCompleteTableAdapter.Fill(this.kursa4DataSet6.DrugsComplete);
            // TODO: This line of code loads data into the 'kursa4DataSet5.Number4' table. You can move, or remove it, as needed.
            this.number4TableAdapter.Fill(this.kursa4DataSet5.Number4);
            // TODO: This line of code loads data into the '_this.Drugs' table. You can move, or remove it, as needed.
            this.drugsTableAdapter2.Fill(this._this.Drugs);
            // TODO: This line of code loads data into the 'kursa4DataSet3._123' table. You can move, or remove it, as needed.
            this._123TableAdapter.Fill(this.kursa4DataSet3._123);
            // TODO: This line of code loads data into the 'kursa4DataSet1.VievDrugsCOMPLETE' table. You can move, or remove it, as needed.
            this.vievDrugsCOMPLETETableAdapter.Fill(this.kursa4DataSet1.VievDrugsCOMPLETE);
            // TODO: This line of code loads data into the 'here.VievPatientRED' table. You can move, or remove it, as needed.
            this.vievPatientREDTableAdapter.Fill(this.here.VievPatientRED);
            // TODO: This line of code loads data into the 'here.Cat' table. You can move, or remove it, as needed.
            this.catTableAdapter.Fill(this.here.Cat);
            // TODO: This line of code loads data into the 'here.Prof' table. You can move, or remove it, as needed.
            this.profTableAdapter2.Fill(this.here.Prof);
            // TODO: This line of code loads data into the 'here.VievDoctorRED' table. You can move, or remove it, as needed.
            this.vievDoctorREDTableAdapter.Fill(this.here.VievDoctorRED);
            // TODO: This line of code loads data into the 'kursa4.Coming' table. You can move, or remove it, as needed.
            this.comingTableAdapter.Fill(this.kursa4.Coming);

            dataGridView2.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView3.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView4.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView5.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView6.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // TODO: This line of code loads data into the 'kursa4.Patient' table. You can move, or remove it, as needed.
            this.patientTableAdapter.Fill(this.kursa4.Patient);
            // TODO: This line of code loads data into the 'kursa4.Doctor' table. You can move, or remove it, as needed.
            this.doctorTableAdapter.Fill(this.kursa4.Doctor);
            // TODO: This line of code loads data into the 'kursa4.Prof' table. You can move, or remove it, as needed.
            this.profTableAdapter1.Fill(this.kursa4.Prof);
            // TODO: This line of code loads data into the 'kursa4DataSet.Prof' table. You can move, or remove it, as needed.
            this.profTableAdapter.Fill(this.kursa4DataSet.Prof);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.profTableAdapter1.FillBy(this.kursa4.Prof);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmd_text;
            AddDoctor f1 = new AddDoctor();
            if (f1.ShowDialog() == DialogResult.OK)
            {
                cmd_text = "INSERT INTO Doctor VALUES (" +
                "'" + f1.textBox6.Text + "' , '" +
                f1.textBox5.Text + "' , '" +
                f1.textBox7.Text + "' , '" +
                f1.textBox4.Text + "' , '" +
                f1.textBox2.Text + "' , " +
                f1.textBox3.Text + ")";

                // создать соединение с базой данных
                SqlConnection sql_conn = new SqlConnection(conn_string);

                // создать команду на языке SQL
                SqlCommand sql_comm = new SqlCommand(cmd_text, sql_conn);

                sql_conn.Open(); // открыть соединение
                sql_comm.ExecuteNonQuery(); // выполнить команду на языке SQL
                sql_conn.Close(); // закрыть соединение

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cmd_text;
            AddCategory f3 = new AddCategory();
            if (f3.ShowDialog() == DialogResult.OK)
            {
                cmd_text = "INSERT INTO Cat VALUES (" +
                "'" + f3.textBox3.Text + "'" + ")";

                // создать соединение с базой данных
                SqlConnection sql_conn = new SqlConnection(conn_string);

                // создать команду на языке SQL
                SqlCommand sql_comm = new SqlCommand(cmd_text, sql_conn);

                sql_conn.Open(); // открыть соединение
                sql_comm.ExecuteNonQuery(); // выполнить команду на языке SQL
                sql_conn.Close(); // закрыть соединение
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DeleteDru d6 = new DeleteDru();
            if (d6.ShowDialog() == DialogResult.OK)
            {
                string cmd_text = "DELETE FROM Doctor";
                int index;
                string id_good;

                index = dataGridView6.CurrentRow.Index;
                id_good = Convert.ToString(dataGridView6[0, index].Value);
                cmd_text = "DELETE FROM Doctor WHERE [Doctor].[IDdoctor] = '" + id_good + "'";

                SqlConnection sql_conn = new SqlConnection(conn_string);
                SqlCommand sql_comm = new SqlCommand(cmd_text, sql_conn);

                sql_conn.Open();
                sql_comm.ExecuteNonQuery();
                sql_conn.Close();

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteDru d6 = new DeleteDru();
            if (d6.ShowDialog() == DialogResult.OK)
            {
                string cmd_text = "DELETE FROM Prof";
                int index;
                string id_good;

                index = dataGridView5.CurrentRow.Index;
                id_good = Convert.ToString(dataGridView5[0, index].Value);
                cmd_text = "DELETE FROM Prof WHERE [Prof].[IDprof] = '" + id_good + "'";

                SqlConnection sql_conn = new SqlConnection(conn_string);
                SqlCommand sql_comm = new SqlCommand(cmd_text, sql_conn);

                sql_conn.Open();
                sql_comm.ExecuteNonQuery();
                sql_conn.Close();

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string cmd_text;
            AddDrugs f6 = new AddDrugs();
            if (f6.ShowDialog() == DialogResult.OK)
            {
                cmd_text = "INSERT INTO Drugs VALUES (" +
                "'" + f6.textBox6.Text + "' , '" +
                f6.textBox1.Text + "')";

                // создать соединение с базой данных
                SqlConnection sql_conn = new SqlConnection(conn_string);

                // создать команду на языке SQL
                SqlCommand sql_comm = new SqlCommand(cmd_text, sql_conn);

                sql_conn.Open(); // открыть соединение
                sql_comm.ExecuteNonQuery(); // выполнить команду на языке SQL
                sql_conn.Close(); // закрыть соединение
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cmd_text;
            AddProf f2 = new AddProf();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                cmd_text = "INSERT INTO Prof VALUES (" +
                "'" + f2.textBox3.Text + "'" + ")";

                // создать соединение с базой данных
                SqlConnection sql_conn = new SqlConnection(conn_string);

                // создать команду на языке SQL
                SqlCommand sql_comm = new SqlCommand(cmd_text, sql_conn);

                sql_conn.Open(); // открыть соединение
                sql_comm.ExecuteNonQuery(); // выполнить команду на языке SQL
                sql_conn.Close(); // закрыть соединение
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string cmd_text;
            AddPatient f4 = new AddPatient();
            if (f4.ShowDialog() == DialogResult.OK)
            {
                cmd_text = "INSERT INTO Patient VALUES (" +
                "'" + f4.textBox6.Text + "' , '" +
                f4.textBox5.Text + "' , '" +
                f4.textBox1.Text + "' , '" +
                f4.textBox3.Text + "' , '" +
                f4.textBox2.Text + "')";

                // создать соединение с базой данных
                SqlConnection sql_conn = new SqlConnection(conn_string);

                // создать команду на языке SQL
                SqlCommand sql_comm = new SqlCommand(cmd_text, sql_conn);

                sql_conn.Open(); // открыть соединение
                sql_comm.ExecuteNonQuery(); // выполнить команду на языке SQL
                sql_conn.Close(); // закрыть соединение
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string cmd_text;
            AddDiagnoz f5 = new AddDiagnoz();
            if (f5.ShowDialog() == DialogResult.OK)
            {
                cmd_text = "INSERT INTO Diagnoz VALUES (" +
                "'"  + f5.textBox1.Text + "')";

                // создать соединение с базой данных
                SqlConnection sql_conn = new SqlConnection(conn_string);

                // создать команду на языке SQL
                SqlCommand sql_comm = new SqlCommand(cmd_text, sql_conn);

                sql_conn.Open(); // открыть соединение
                sql_comm.ExecuteNonQuery(); // выполнить команду на языке SQL
                sql_conn.Close(); // закрыть соединение
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            DeleteDru d6 = new DeleteDru();
            if (d6.ShowDialog() == DialogResult.OK)
            {
                string cmd_text = "DELETE FROM Drugs";
                int index;
                string id_good;

                index = dataGridView1.CurrentRow.Index;
                id_good = Convert.ToString(dataGridView1[0, index].Value);
                cmd_text = "DELETE FROM Drugs WHERE [Drugs].[Numer] = '" + id_good + "'";

                SqlConnection sql_conn = new SqlConnection(conn_string);
                SqlCommand sql_comm = new SqlCommand(cmd_text, sql_conn);

                sql_conn.Open();
                sql_comm.ExecuteNonQuery();
                sql_conn.Close();

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DeleteDru d6 = new DeleteDru();
            if (d6.ShowDialog() == DialogResult.OK)
            {
                string cmd_text = "DELETE FROM Diagnoz";
                int index;
                string id_good;

                index = dataGridView2.CurrentRow.Index;
                id_good = Convert.ToString(dataGridView2[0, index].Value);
                cmd_text = "DELETE FROM Diagnoz WHERE [Diagnoz].[IDdiagnoz] = '" + id_good + "'";

                SqlConnection sql_conn = new SqlConnection(conn_string);
                SqlCommand sql_comm = new SqlCommand(cmd_text, sql_conn);

                sql_conn.Open();
                sql_comm.ExecuteNonQuery();
                sql_conn.Close();

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DeleteDru d6 = new DeleteDru();
            if (d6.ShowDialog() == DialogResult.OK)
            {
                string cmd_text = "DELETE FROM Patient";
                int index;
                string id_good;

                index = dataGridView3.CurrentRow.Index;
                id_good = Convert.ToString(dataGridView3[0, index].Value);
                cmd_text = "DELETE FROM Patient WHERE [Patient].[IDcard] = '" + id_good + "'";

                SqlConnection sql_conn = new SqlConnection(conn_string);
                SqlCommand sql_comm = new SqlCommand(cmd_text, sql_conn);

                sql_conn.Open();
                sql_comm.ExecuteNonQuery();
                sql_conn.Close();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteDru d6 = new DeleteDru();
            if (d6.ShowDialog() == DialogResult.OK)
            {
                string cmd_text = "DELETE FROM Cat";
                int index;
                string id_good;

                index = dataGridView4.CurrentRow.Index;
                id_good = Convert.ToString(dataGridView4[0, index].Value);
                cmd_text = "DELETE FROM Cat WHERE [Cat].[IDcat] = '" + id_good + "'";

                SqlConnection sql_conn = new SqlConnection(conn_string);
                SqlCommand sql_comm = new SqlCommand(cmd_text, sql_conn);

                sql_conn.Open();
                sql_comm.ExecuteNonQuery();
                sql_conn.Close();


            }

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
