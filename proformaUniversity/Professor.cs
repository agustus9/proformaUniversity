using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proformaUniversity
{
    class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Student { get; set; }
        public int StudentId { get; set; }

        public Professor()
        {

        }
        public Professor(SqlDataReader reader)
        {
            Name = reader["Name"].ToString();
            Title = reader["Title"].ToString();
            Id = (int)reader["ID"];
            Student = reader["Student"].ToString();
            if (reader["StudentId"] != null)
            {
                StudentId = (int)reader["StudentId"];
            }

        }
    }
}
