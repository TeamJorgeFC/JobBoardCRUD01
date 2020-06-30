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
            var connectionString = "data source={AppDir}\\Models\\JobBoardCRUB_DB.db;version=3";
            var fixedConnectionString = connectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);
            using (var conn = new SQLiteConnection(fixedConnectionString))
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
                var connectionString = "data source={AppDir}\\Models\\JobBoardCRUB_DB.db;version=3";
                var fixedConnectionString = connectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);

                using (var conn = new SQLiteConnection(fixedConnectionString))
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
            var connectionString = "data source={AppDir}\\Models\\JobBoardCRUB_DB.db;version=3";
            var fixedConnectionString = connectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);
            try
            {
                if (JobID > 0)
                {
                    result = 2;
                    //UPDATE                    
                    SQLiteConnection sqlite_conn = new SQLiteConnection(fixedConnectionString);
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
                    SQLiteConnection sqlite_conn = new SQLiteConnection(fixedConnectionString);
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

        public JsonResult DeletedJob(int? id)
        {
            int result = 0;
            var connectionString = "data source={AppDir}\\Models\\JobBoardCRUB_DB.db;version=3";
            var fixedConnectionString = connectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);
            try
            {
                if (id > 0)
                {
                    result = 1;
                    //DELETE                    
                    SQLiteConnection sqlite_conn = new SQLiteConnection(fixedConnectionString);
                    string stringQuery = "delete from tblJob where JobID = " + id;//Delete job
                    sqlite_conn.Open();//Open the SqliteConnection
                    var SqliteCmd = new SQLiteCommand();//Initialize the SqliteCommand
                    SqliteCmd = sqlite_conn.CreateCommand();//Create the SqliteCommand
                    SqliteCmd.CommandText = stringQuery;//Assigning the query to CommandText
                    SqliteCmd.ExecuteNonQuery();//Execute the SqliteCommand
                    sqlite_conn.Close();//Close the SqliteConnection
                }
                else
                {
                    result = 2;
                }                
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }       

    }
}