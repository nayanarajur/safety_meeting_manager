using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Meeting.Manager.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Model.Meeting> Meetings { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            this.Meetings = GetData();
        }

        public void OnPost()
        {
            string personObserved = Request.Form["personObserved"];
            string dateOfDiscussion = Request.Form["dateOfDiscussion"];
            string location = Request.Form["location"];
            string colleagues = Request.Form["colleagues"];
            string subjectOfDiscussion = Request.Form["subjectOfDiscussion"];
            string outcome = Request.Form["outcome"];

            SaveData(personObserved, dateOfDiscussion, location, colleagues, subjectOfDiscussion, outcome);

            this.Meetings = GetData();
        }

        /// <summary>
        /// Method used to insert data into db
        /// </summary>
        /// <param name="personObserved"></param>
        /// <param name="dateOfDiscussion"></param>
        /// <param name="location"></param>
        /// <param name="colleagues"></param>
        /// <param name="subjectOfDiscussion"></param>
        /// <param name="outcome"></param>
        public void SaveData(string personObserved, string dateOfDiscussion, string location, string colleagues, string subjectOfDiscussion, string outcome)
        {

            try
            {
                // Connection string to connect to database
                string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Meeting.Manager.Database;Integrated Security=True;Pooling=False;Connect Timeout=30";

                //SQL query to insert data into table dbo.Meetings
                string sqlQuery = $"INSERT INTO dbo.Meetings([personObserved],[dateOfDiscussion]" +
                                    $",[location],[colleagues],[subjectOfDiscussion],[outcome]) VALUES" +
                                    $"('{personObserved}','{dateOfDiscussion}','{location}','{colleagues}','{subjectOfDiscussion}','{outcome}')";

                //Creating an object of SqlConnection called "con"
                SqlConnection con = new SqlConnection(connectionString);

                // calling method Open
                con.Open();

                SqlCommand sc = new SqlCommand(sqlQuery, con);
                sc.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        /// <summary>
        /// Get data from database
        /// </summary>
        /// <returns></returns>
        public List<Model.Meeting> GetData()
        {
            try
            {
                // Connection string to connect to database
                string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Meeting.Manager.Database;Integrated Security=True;Pooling=False;Connect Timeout=30";

                //SQL query to get data into table dbo.Meetings
                string sqlQuery = $"SELECT * FROM dbo.Meetings";

                //Creating an object of SqlConnection called "con"
                SqlConnection con = new SqlConnection(connectionString);

                // calling method Open
                con.Open();

                SqlCommand sc = new SqlCommand(sqlQuery, con);

                SqlDataAdapter sa = new SqlDataAdapter(sc);

                var data = new DataTable();

                sa.Fill(data);

                //Converting DataTable to List<Model.Meeting>
                List<Model.Meeting> meetingsList = data.AsEnumerable().Select(dr => new Model.Meeting()
                {
                    PersonObserved = dr["personObserved"].ToString(),
                    DateOfDiscussion = dr["dateOfDiscussion"].ToString(),
                    Location = dr["location"].ToString(),
                    Colleagues = dr["colleagues"].ToString(),
                    SubjectOfDiscussion = dr["subjectOfDiscussion"].ToString(),
                    Outcome = dr["outcome"].ToString()
                }).ToList();

                con.Close();

                return meetingsList;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return null;
        }
    }
}

