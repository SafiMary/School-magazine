using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace School_magazine
{
    public partial class Form1 : Form
    {
        List<Student> magazine = new List<Student>();
        List<string> printMag = new List<string>();
        public Form1()
        {
            InitializeComponent();
            refreshMagazine();
            showMagazine();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var date = maskedTextBoxBirt.Text.Split('.');
            int year = int.Parse(date[0]);
            int month = int.Parse(date[1]);
            int day = int.Parse(date[1]);
            DateTime dt = new DateTime(year,month, day);
            Text = dt.ToString();

            var student = new Student(textBoxSurname.Text, textBoxName.Text, dt); ;
            magazine.Add(student);
            magazine.Sort();
        }
        private string[] updatePrintMag()
        {
            printMag.Clear();
            for (int i = 0; i < magazine.Count; i++)
            {
                printMag.Add(magazine[i].ToString());
            }
            var arr = printMag.ToArray();
            return arr;
        }
        private void refreshMagazine(string path = "dish.xml")
        {
            Student.Deserealize_it(path, out magazine);
            listBoxStud.Items.Clear();
            listBoxStud.Items.AddRange(updatePrintMag());
        }
        private void showMagazine()
        {
            StringBuilder sb = new StringBuilder();
            var counter = 0;
            foreach (var item in magazine)
            {
                sb.Append($"{counter++}) Фамилия {item.Surname}\t Имя {item.Name}\t Дата рождения{item.Birthday}\n");
            }
            MessageBox.Show(sb.ToString());

        }

       


    }
}
