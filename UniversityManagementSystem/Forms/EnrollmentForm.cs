using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace UniversityManagementSystem.Forms
{
    public partial class EnrollmentForm : Form
    {
        List<Enrollment> enrollments = new List<Enrollment>();

        public EnrollmentForm()
        {
            InitializeComponent();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtStudentID.Text) || string.IsNullOrEmpty(txtCourseID.Text))
                {
                    MessageBox.Show("Please enter both Student ID and Course ID");
                    return;
                }

                bool exists = enrollments.Exists(en => en.StudentID == txtStudentID.Text && en.CourseID == txtCourseID.Text);
                if (exists)
                {
                    MessageBox.Show("This student is already enrolled in this course!");
                    return;
                }

                Enrollment enrollmentObj = new Enrollment();
                enrollmentObj.StudentID = txtStudentID.Text;
                enrollmentObj.CourseID = txtCourseID.Text;
                enrollmentObj.EnrollmentDate = DateTime.Now.ToString("yyyy-MM-dd");

                enrollments.Add(enrollmentObj);
                UpdateGrid();

                txtStudentID.Clear();
                txtCourseID.Clear();
                txtStudentID.Focus();

                MessageBox.Show("Student Enrolled in Course Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

       

        

        private void UpdateGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new BindingList<Enrollment>(enrollments);
        }

        public class Enrollment
        {
            public string StudentID { get; set; }
            public string CourseID { get; set; }
            public string EnrollmentDate { get; set; }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("enrollments.txt");
            foreach (Enrollment en in enrollments)
            {
                writer.WriteLine(en.StudentID + "," + en.CourseID + "," + en.EnrollmentDate);
            }
            writer.Close();
            MessageBox.Show("Enrollments Saved Successfully to enrollments.txt");
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            enrollments.Clear();
            if (!File.Exists("enrollments.txt"))
            {
                MessageBox.Show("No saved enrollments found");
                return;
            }

            StreamReader reader = new StreamReader("enrollments.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');
                if (data.Length == 3)
                {
                    Enrollment enrollmentObj = new Enrollment();
                    enrollmentObj.StudentID = data[0];
                    enrollmentObj.CourseID = data[1];
                    enrollmentObj.EnrollmentDate = data[2];
                    enrollments.Add(enrollmentObj);
                }
            }
            reader.Close();
            UpdateGrid();
            MessageBox.Show("Enrollments Loaded Successfully");

        }

        private void EnrollmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
