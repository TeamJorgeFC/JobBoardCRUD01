using JobBoardCRUD.CustomClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobBoardCRUD.Controllers
{
    public class JobController : Controller
    {
        SQLiteConnection con;
        SQLiteDataAdapter da;
        SQLiteCommand cmd;
        DataSet ds;
        public List<Job> Jobs { get; set; }

        // GET: Job
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult _JobList()
        {
            JobList();
            return PartialView("_JobList", Jobs);
        }        

        private void JobList()
        {
            var listOfJob = new List<Job>();
            var connectionString = "data source=C:/Users/Jorge/source/repos/JobBoardCRUD01/JobBoardCRUD01/JobBoardCRUD/Models/JobBoardCRUB_DB.db;version=3";

            using (var conn = new SQLiteConnection(connectionString))
            using (var cmd = new SQLiteCommand("SELECT * FROM tblJob", conn))
            {
                conn.Open();
                using (var coreReader = cmd.ExecuteReader())
                {
                    var reader = coreReader;
                    //coreReader.Read();
                    while (coreReader.Read())
                    {

                        listOfJob.Add(new Job
                        {
                            JobID = int.Parse(reader["JobID"].ToString()),
                            JobTittle = reader["JobTittle"].ToString(),
                            JobDescription = reader["JobDescription"].ToString(),
                            JobCreatedAt = reader["JobCreatedAt"].ToString(),
                            JobExpiredAt = reader["JobExpiredAt"].ToString(),

                        });
                    }
                    reader.Close();
                    Jobs = listOfJob;
                }
            }
            
            //string cs = "Data Source=" + Environment.CurrentDirectory + "\\Models\\JobBoardCRUB_DB.db";
            //using (var connection = new SQLiteConnection(cs))
            //{

            //    var listOfJob = new List<Job>();
            //    var stm = "SELECT * FROM tblJob";

            //    var command = new SQLiteCommand(stm, connection);
            //    try
            //    {

            //        var reader = command.ExecuteReader();

            //        while (reader.Read())
            //        {

            //            listOfJob.Add(new Job
            //            {
            //                JobID = int.Parse(reader["JobID"].ToString()),
            //                JobTittle = reader["JobTittle"].ToString(),
            //                JobDescription = reader["JobDescription"].ToString(),
            //                JobCreatedAt = reader["JobCreatedAt"].ToString(),
            //                JobExpiredAt = reader["JobExpiredAt"].ToString(),

            //            });
            //        }
            //        reader.Close();
            //        Jobs = listOfJob;
            //    }

            //    catch (Exception ex)
            //    {
            //        throw;
            //    }

            //}

        }

        void GetList()
        {
            con = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\Models\\JobBoardCRUB_DB.db; Version=3;");
            da = new SQLiteDataAdapter("Select *From tblJob", con);
            ds = new DataSet();
            con.Open();
            //da.Fill(ds, "Student");
            //dataGridView1.DataSource = ds.Tables["Student"];
            con.Close();

        }

        //private void button1_Click_1(object sender, EventArgs e) //Insert
        //{
        //    cmd = new SQLiteCommand();
        //    con.Open();
        //    cmd.Connection = con;
        //    cmd.CommandText = "insert into Student(FirstName,LastName) values ('" + textBox2.Text + "','" + textBox3.Text + "')";
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    GetList();
        //}

        //private void button2_Click(object sender, EventArgs e) //update
        //{
        //    cmd = new SQLiteCommand();
        //    con.Open();
        //    cmd.Connection = con;
        //    cmd.CommandText = "update Student set FirstName='" + textBox2.Text + "',LastName='" + textBox3.Text + "' where ID=" + textBox1.Text + "";
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    GetList();
        //}

        //private void button3_Click(object sender, EventArgs e) //delete
        //{
        //    cmd = new SQLiteCommand();
        //    con.Open();
        //    cmd.Connection = con;
        //    cmd.CommandText = "delete from Student where ID=" + textBox1.Text + "";
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    GetList();
        //}

    }
}