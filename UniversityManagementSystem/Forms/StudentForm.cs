using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UniversityManagementSystem.Models;
using System.IO;

namespace UniversityManagementSystem.Forms
{
    public partial class StudentForm : Form
    {
        List<Student> students = new List<Student>();
        public StudentForm()
        {
            InitializeComponent();

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Student existing = students.Find(student =>
         student.ID == int.Parse(textBox1.Text));

            if (existing != null)
            {
                MessageBox.Show("Student ID already exists");
                return;
            }

            Student s = new Student();

            s.ID = int.Parse(textBox1.Text);
            s.Name = textBox2.Text;
            s.Email = textBox3.Text;
            s.Major = textBox4.Text;
            s.GPA = double.Parse(textBox5.Text);

            students.Add(s);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new System.ComponentModel.BindingList<Student>(students);
            MessageBox.Show("Student Added");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox6.Text);

            Student found = students.Find(s => s.ID == id);

            if (found != null)
            {
                textBox1.Text = found.ID.ToString();
                textBox2.Text = found.Name;
                textBox3.Text = found.Email;
                textBox4.Text = found.Major;
                textBox5.Text = found.GPA.ToString();
            }
            else
            {
                MessageBox.Show("Student Not Found");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            if (!int.TryParse(textBox1.Text, out int id))
            {
               
                MessageBox.Show("Please enter a valid numeric ID!");
                return;
            }

            Student found = students.Find(s => s.ID == id);

            if (found != null)
            {
                students.Remove(found);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = students;

                MessageBox.Show("Student Deleted");
            }
            else
            {
                MessageBox.Show("Student not found!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);

            Student found = students.Find(s => s.ID == id);

            if (found != null)
            {
                found.Name = textBox2.Text;
                found.Email = textBox3.Text;
                found.Major = textBox4.Text;
                found.GPA = double.Parse(textBox5.Text);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = students;

                MessageBox.Show("Student Updated");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("students.txt");

            foreach (Student s in students)
            {
                writer.WriteLine(
                    s.ID + "," +
                    s.Name + "," +
                    s.Email + "," +
                    s.Major + "," +
                    s.GPA);
            }

            writer.Close();

            MessageBox.Show("Data Saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Focus();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["ID"].Value.ToString();
                textBox2.Text = row.Cells["Name"].Value.ToString();
                textBox3.Text = row.Cells["Email"].Value.ToString();
                textBox4.Text = row.Cells["Major"].Value.ToString();
                textBox5.Text = row.Cells["GPA"].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("students.txt");

            foreach (Student s in students)
            {
                writer.WriteLine(
                    s.ID + "," +
                    s.Name + "," +
                    s.Email + "," +
                    s.Major + "," +
                    s.GPA);
            }

            writer.Close();

            MessageBox.Show("Data Saved Successfully");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            students.Clear();

            if (!File.Exists("students.txt"))
            {
                MessageBox.Show("No saved data found");
                return;
            }

            StreamReader reader = new StreamReader("students.txt");

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                string[] data = line.Split(',');

                Student s = new Student();

                s.ID = int.Parse(data[0]);
                s.Name = data[1];
                s.Email = data[2];
                s.Major = data[3];
                s.GPA = double.Parse(data[4]);

                students.Add(s);
            }

            reader.Close();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new System.ComponentModel.BindingList<Student>(students);
            
            MessageBox.Show("Data Loaded Successfully");
        }
        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Major { get; set; }
            public double GPA { get; set; }
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }
    }
    

   
    }
