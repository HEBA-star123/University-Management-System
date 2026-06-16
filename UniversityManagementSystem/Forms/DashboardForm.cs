using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityManagementSystem.Forms;

namespace UniversityManagementSystem.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentForm form = new StudentForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        
            CourseForm courseForm = new CourseForm();
            courseForm.Show();
        
    }

        private void button3_Click(object sender, EventArgs e)
        {
            EnrollmentForm enrollmentForm = new EnrollmentForm();
            enrollmentForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.Show();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
