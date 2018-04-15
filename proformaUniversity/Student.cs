using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proformaUniversity
{
    class Student
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Id { get; }
        public string PhoneNumber { get; set; }
        public string Major { get; set; }
        public string Name { get; set; }
        public int NameId { get; set; }


        public Student()
        {

        }
        public Student(SqlDataReader reader)
        {
            FullName = reader["FullName.Name"].ToString();
            Email = reader["Email"].ToString();
            Id = (int)reader["ID"];
            PhoneNumber = reader["PhoneNumber"].ToString();
            Major = reader["Major"].ToString();

            Name = reader["Name"].ToString();
            if (reader["NameId"] != null)
            {
                NameId = (int)reader["NameId"];
            }

        }
    }
}
