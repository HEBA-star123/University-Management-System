using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace UniversityManagementSystem.Forms
{
    public partial class CourseForm : Form
    {
        List<Course> courses = new List<Course>();

        public CourseForm()
        {
            InitializeComponent();
        }

   
        


        


        private void UpdateGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new BindingList<Course>(courses);
        }

        private void ClearInputs()
        {
            txtCourseID.Clear();
            txtCourseName.Clear();
            txtCredits.Clear();
            txtSearchID.Clear();
            txtCourseID.Focus();
        }

        public class Course
        {
            public string CourseID { get; set; }
            public string CourseName { get; set; }
            public int CreditHours { get; set; }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                Course existing = courses.Find(cr => cr.CourseID == txtCourseID.Text);
                if (existing != null)
                {
                    MessageBox.Show("Course ID already exists!");
                    return;
                }

                Course courseObj = new Course();
                courseObj.CourseID = txtCourseID.Text;
                courseObj.CourseName = txtCourseName.Text;
                courseObj.CreditHours = int.Parse(txtCredits.Text);

                courses.Add(courseObj);
                UpdateGrid();
                ClearInputs();
                MessageBox.Show("Course Added Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            Course found = courses.Find(cr => cr.CourseID == txtCourseID.Text);
            if (found != null)
            {
                found.CourseName = txtCourseName.Text;
                found.CreditHours = int.Parse(txtCredits.Text);
                UpdateGrid();
                MessageBox.Show("Course Updated Successfully");
            }
            else
            {
                MessageBox.Show("Course Not Found to Update");
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            Course found = courses.Find(cr => cr.CourseID == txtCourseID.Text);
            if (found != null)
            {
                courses.Remove(found);
                UpdateGrid();
                ClearInputs();
                MessageBox.Show("Course Deleted");
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            Course found = courses.Find(cr => cr.CourseID == txtSearchID.Text);
            if (found != null)
            {
                txtCourseID.Text = found.CourseID;
                txtCourseName.Text = found.CourseName;
                txtCredits.Text = found.CreditHours.ToString();
            }
            else
            {
                MessageBox.Show("Course Not Found");
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("courses.txt");
            foreach (Course courseObj in courses)
            {
                writer.WriteLine(courseObj.CourseID + "," + courseObj.CourseName + "," + courseObj.CreditHours);
            }
            writer.Close();
            MessageBox.Show("Courses Saved Successfully to courses.txt");
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            courses.Clear();
            if (!File.Exists("courses.txt"))
            {
                MessageBox.Show("No saved courses found");
                return;
            }

            StreamReader reader = new StreamReader("courses.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');
                if (data.Length == 3)
                {
                    Course courseObj = new Course();
                    courseObj.CourseID = data[0];
                    courseObj.CourseName = data[1];
                    courseObj.CreditHours = int.Parse(data[2]);
                    courses.Add(courseObj);
                }
            }
            reader.Close();
            UpdateGrid();
            MessageBox.Show("Courses Loaded Successfully");
        }
    }
}
