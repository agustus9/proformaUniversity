using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proformaUniversity
{
    class Program
    {
        static public List<Professor> GetAllProfessors(SqlConnection connection)
        {
            //var professors = new List<Professor>();

        
        var _select = "SELECT dbo.Professors.ID, Professors.Name, Professors.Title, Courses.Course_Name AS Student, Courses.ID AS StudentID" +
                " FROM dbo.Professors" +
                " JOIN dbo.Jobs ON Jobs.Professorid = Professors.Id" +
                " JOIN dbo.Courses on Jobs.Courseid = Courses.ID";
        var query = new SqlCommand(_select, connection);
        var reader = query.ExecuteReader();
        var _rv = new List<Professor>();
            //using (var reader = query.ExecuteReader())
        while (reader.Read())
        {
            var _Professor = new Professor(reader);
        Console.WriteLine(_Professor.Name + " was added");
            }
        return _rv;
        }

        static public List<Course> GetAllCourses(SqlConnection connection)
        {
            //var courses = new List<Course>();


            var _select = "SELECT dbo.Courses.ID, Courses.Number, Courses.Course_Level, Courses.Course_Name, Courses.Course_Room, Course.Start_Time, Courses.Name AS Student, Courses.ID AS StudentID" +
                    " FROM dbo.Courses" +
                    " JOIN dbo.Students ON Courses.StudentId = Student.Id";
            var query = new SqlCommand(_select, connection);
            var reader = query.ExecuteReader();
            var _rv = new List<Course>();
            while (reader.Read())
            {
                var _Course = new Course(reader);
                Console.WriteLine(_Course.Number + " was added");
            }
            return _rv;
        }

        static public List<Student> GetAllStudents(SqlConnection connection)
        {
            //var students = new List<Student>();


            var _select = "SELECT dbo.Students.ID, Students.FullName, Students.Email, Students.PhoneNumber, Students.Major, Students.FullName AS Name, Students.ID AS NameID" +
                    " FROM dbo.Students" +
                    " JOIN dbo.Professors ON Courses.StudentId = Student.Id";
            var query = new SqlCommand(_select, connection);
            var reader = query.ExecuteReader();
            var _rv = new List<Student>();
            while (reader.Read())
            {
                var _Student = new Student(reader);
                Console.WriteLine(_Student.FullName + " was added");
            }
            return _rv;
        }


        static void InsertProfessor(SqlConnection conn, Professor newProfessor)
        {
            // Query the database
            var _select = "INSERT INTO dbo.Professors (Name, Title) " + "VALUES (@Name, @Title)";
            var cmd = new SqlCommand(_select, conn);
            //var reader = query.ExecuteReader();

            cmd.Parameters.AddWithValue("@Name", newProfessor.Name);
            cmd.Parameters.AddWithValue("@Title", newProfessor.Title);
            cmd.ExecuteScalar();
            //cmd.ExecuteNonQuery();
            conn.Open();
            //cmd.ExecuteNonQuery();
            conn.Close();

        }

        static void InsertCourse(SqlConnection conn, Course newCourse)
        {
            // Query the database
            var _select = "INSERT INTO dbo.Courses (Number, Course_Level, Course_Name, Course_Room, Start_Time) " + "VALUES (@Course_Number, @Course_Level, @Course_Name, @Course_Room, @Start_Time)";
            var cmd = new SqlCommand(_select, conn);
            //var reader = query.ExecuteReader();

            cmd.Parameters.AddWithValue("Course_Number", newCourse.Number);
            cmd.Parameters.AddWithValue("Course_Level", newCourse.Course_Level);
            cmd.Parameters.AddWithValue("Course_Name", newCourse.Course_Name);
            cmd.Parameters.AddWithValue("Course_Room", newCourse.Course_Room);
            cmd.Parameters.AddWithValue("Start_Time", newCourse.Start_Time);



            cmd.ExecuteScalar();
            conn.Open();
            //cmd.ExecuteNonQuery();
            conn.Close();

        }

        static void InsertStudent(SqlConnection conn, Student newStudent)
        {
            // Query the database
            var _select = "INSERT INTO dbo.Students (FullName, Email, PhoneNumber, Major) " + "VALUES (@FullName, @Email, @PhoneNumber, @Major)";
            var cmd = new SqlCommand(_select, conn);
            //var reader = query.ExecuteReader();

            cmd.Parameters.AddWithValue("FullName", newStudent.FullName);
            cmd.Parameters.AddWithValue("Email", newStudent.Email);
            cmd.Parameters.AddWithValue("PhoneNumber", newStudent.PhoneNumber);
            cmd.Parameters.AddWithValue("Major", newStudent.Major);
            cmd.ExecuteScalar();
            conn.Open();
            //cmd.ExecuteNonQuery();
            conn.Close();

        }
        static void Main(string[] args)
        {
            // WHere is the Database
            const string CONNECTION_STRING =
                @"Server=AMACK01\SQLEXPRESS;Database=Proforma University;Trusted_Connection=True;";
            // Open with using something
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {


                var newProfessor = new Professor
                {
                    Name = "Jackson",
                    Title = "Mr",
                };
                var newerProfessor = new Professor
                {
                    Name = "Popo",
                    Title = "Mr",
                };
                var newestProfessor = new Professor
                {
                    Name = "Thompson",
                    Title = "Mr",
                };
                conn.Open();
                InsertProfessor(conn, newProfessor);
                InsertProfessor(conn, newerProfessor);
                InsertProfessor(conn, newestProfessor);
                GetAllProfessors(conn);

                var newCourse = new Course
                {
                    Number = "1",
                    Course_Level = "3",
                    Course_Name = "Science",
                    Course_Room = "202",
                    Start_Time = "2018-04-24"
                };
                var newerCourse = new Course
                {
                    Number = "2",
                    Course_Level = "6",
                    Course_Name = "Math",
                    Course_Room = "201",
                    Start_Time = "2018-02-08"
                };
                var newestCourse = new Course
                {
                    Number = "3",
                    Course_Level = "3",
                    Course_Name = "Computer",
                    Course_Room = "102",
                    Start_Time = "2018-08-15"


                };
               // conn.Open();
                InsertCourse(conn, newCourse);
                InsertCourse(conn, newerCourse);
                InsertCourse(conn, newestCourse);
                GetAllCourses(conn);

                var newStudent = new Student
                {
                    FullName = "James White",
                    Email = "j@gmail.com",
                    PhoneNumber = "8136700000",
                    Major = "Computer"
                };
                var newerStudent = new Student
                {
                    FullName = "Carl Walters",
                    Email = "c@gmail.com",
                    PhoneNumber = "8136500000",
                    Major = "Math"
                };
                var newestStudent = new Student
                {
                    FullName = "John Black",
                    Email = "j@gmail.com",
                    PhoneNumber = "8138500000",
                    Major = "Science"
                };
                //conn.Open();
                InsertStudent(conn, newStudent);
                InsertStudent(conn, newerStudent);
                InsertStudent(conn, newestStudent);
                GetAllStudents(conn);

            }
        }
    }
}


