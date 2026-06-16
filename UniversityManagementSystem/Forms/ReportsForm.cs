using System;
using System.IO;
using System.Windows.Forms;

namespace UniversityManagementSystem.Forms
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. حساب عدد الطلاب ومتوسط الـ GPA من ملف students.txt
                int studentCount = 0;
                double totalGPA = 0;
                if (File.Exists("students.txt"))
                {
                    string[] studentLines = File.ReadAllLines("students.txt");
                    studentCount = studentLines.Length;

                    foreach (string line in studentLines)
                    {
                        string[] data = line.Split(',');
                        if (data.Length >= 5)
                        {
                            totalGPA += double.Parse(data[4]);
                        }
                    }
                }

                // 2. حساب عدد المواد من ملف courses.txt
                int courseCount = 0;
                if (File.Exists("courses.txt"))
                {
                    courseCount = File.ReadAllLines("courses.txt").Length;
                }

                // 3. حساب عدد التسجيلات من ملف enrollments.txt
                int enrollmentCount = 0;
                if (File.Exists("enrollments.txt"))
                {
                    enrollmentCount = File.ReadAllLines("enrollments.txt").Length;
                }

                // 4. حساب المعدل العام للجامعة
                double averageGPA = studentCount > 0 ? totalGPA / studentCount : 0.0;

                // 5. عرض النتائج على الشاشة في الـ Labels
                label1.Text = "Total Students: " + studentCount;
                label2.Text = "Total Courses: " + courseCount;
                label3.Text = "Total Enrolled Students: " + enrollmentCount;
                label4.Text = "Average University GPA: " + averageGPA.ToString("0.00");

                MessageBox.Show("Report Generated Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
            }

        }
    }
}