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
        //SQLiteConnection con;
        //SQLiteDataAdapter da;
        //SQLiteCommand cmd;
        //DataSet ds;
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
        }

        public ActionResult _AddEditJob(int id)
        {
            Job JobResult = new Job();
            if (id == 0)
            {
                JobResult.JobID = 0;
            }
            else
            {
                var connectionString = "data source=C:/Users/Jorge/source/repos/JobBoardCRUD01/JobBoardCRUD01/JobBoardCRUD/Models/JobBoardCRUB_DB.db;version=3";

                using (var conn = new SQLiteConnection(connectionString))
                using (var cmd = new SQLiteCommand("SELECT * FROM tblJob WHERE JobID = " + id, conn))
                {
                    conn.Open();
                    using (var coreReader = cmd.ExecuteReader())
                    {
                        var reader = coreReader;
                        //coreReader.Read();
                        while (coreReader.Read())
                        {
                            JobResult.JobID = int.Parse(reader["JobID"].ToString());
                            JobResult.JobTittle = reader["JobTittle"].ToString();
                            JobResult.JobDescription = reader["JobDescription"].ToString();
                            JobResult.JobCreatedAt = reader["JobCreatedAt"].ToString();
                            JobResult.JobExpiredAt = reader["JobExpiredAt"].ToString();
                        }
                        reader.Close();
                    }
                }
            }
            return PartialView("_AddEditJob", JobResult);
        }

        public JsonResult AddEditJob(int? JobID, string JobTittle, string JobDescription, string JobCreatedAt, string JobExpiredAt)
        {
            int result = 0;
            try
            {
                if (JobID > 0)
                {
                    result = 2;
                    //UPDATE
                    string connection = @"data source=C:/Users/Jorge/source/repos/JobBoardCRUD01/JobBoardCRUD01/JobBoardCRUD/Models/JobBoardCRUB_DB.db;version=3";
                    SQLiteConnection sqlite_conn = new SQLiteConnection(connection);
                    string stringQuery = "update tblJob set JobTittle = '" + JobTittle + "',JobDescription = '"+ JobDescription + "', JobCreatedAt = '"+ JobCreatedAt + "',JobExpiredAt = '"+ JobExpiredAt + "' where JobID = "+JobID;//Update job
                    sqlite_conn.Open();//Open the SqliteConnection
                    var SqliteCmd = new SQLiteCommand();//Initialize the SqliteCommand
                    SqliteCmd = sqlite_conn.CreateCommand();//Create the SqliteCommand
                    SqliteCmd.CommandText = stringQuery;//Assigning the query to CommandText
                    SqliteCmd.ExecuteNonQuery();//Execute the SqliteCommand
                    sqlite_conn.Close();//Close the SqliteConnection
                }
                else
                {
                    result = 1;
                    //INSERT 
                    string connection = @"data source=C:/Users/Jorge/source/repos/JobBoardCRUD01/JobBoardCRUD01/JobBoardCRUD/Models/JobBoardCRUB_DB.db;version=3";
                    SQLiteConnection sqlite_conn = new SQLiteConnection(connection);
                    string stringQuery = "insert into tblJob(JobTittle,JobDescription,JobCreatedAt,JobExpiredAt) values ('" + JobTittle + "','" + JobDescription + "','" + JobCreatedAt + "','" + JobExpiredAt + "')";//insert job
                    sqlite_conn.Open();//Open the SqliteConnection
                    var SqliteCmd = new SQLiteCommand();//Initialize the SqliteCommand
                    SqliteCmd = sqlite_conn.CreateCommand();//Create the SqliteCommand
                    SqliteCmd.CommandText = stringQuery;//Assigning the query to CommandText
                    SqliteCmd.ExecuteNonQuery();//Execute the SqliteCommand
                    sqlite_conn.Close();//Close the SqliteConnection

                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
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