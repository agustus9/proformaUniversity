using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proformaUniversity
{
    class Course
    {
        public string Number { get; set; }
        public string Course_Level { get; set; }
        public int Id { get; }
        public string Course_Name { get; set; }
        public string Course_Room { get; set; }
        public string Start_Time { get; set; }
        public string Subject { get; set; }
        public int SubjectId { get; set; }

        public Course()
        {

        }
        public Course(SqlDataReader reader)
        {
            Number = reader["Courses.Name"].ToString();
            Course_Level = reader["Title"].ToString();
            Id = (int)reader["ID"];
            Course_Name = reader["Course_Name"].ToString();
            Course_Room = reader["Course_Room"].ToString();
            Start_Time = reader["Start_Time"].ToString();
            Subject = reader["Subject"].ToString();
            if (reader["SubjectId"] != null)
            {
                SubjectId = (int)reader["SubjectId"];
            }


        }

    }
}
