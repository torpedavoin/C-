using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsForm1
{
    public partial class Menu : Form
    {
        Dictionary<int, Human> Humandict = new Dictionary<int, Human>();
        Dictionary<int, Student> Studentdict = new Dictionary<int, Student>();
        Dictionary<int, Teacher> Teacherdict = new Dictionary<int, Teacher>();
        Dictionary<int, Teacher> CourseWorkdict = new Dictionary<int, Teacher>();
        private int CourseWorkn = 0;
        private ListHuman listHuman = new ListHuman();
        private ListStudent listStudent = new ListStudent();
        private ListTeacher listTeacher = new ListTeacher();
        private DataTable DataTemp = new DataTable();
        private DataTable DataTemph = new DataTable();


        public Menu()
        {

            InitializeComponent();
            Startsetings();

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            RadioButton PersonradioButton = (RadioButton)PersonRegestrationRadioButton;
            RadioButton TeacherradioButton = (RadioButton)TeacherRegestrationRadioButton;
            RadioButton StudentradioButton = (RadioButton)StudentRegestrationRadioButton;

            if (PersonradioButton.Checked) {
                int counthumans = listHuman.Counts();
                Human human = new Human(NameTextBox.Text, SurnameTextBox.Text, SelectedGender(), AgeComboBox.SelectedIndex, Convert.ToDouble(HeightTextBox.Text), Convert.ToDouble(WeightTextBox.Text), HabbitsCheckBox.Checked, EmailTextBox.Text, Nation_Convector(), new Adress(CountryTextBox.Text, CityTextBox.Text, StreetTextBox.Text, int.Parse(HouseTextBox.Text)));
                Humandict.Add(counthumans, human);
                listHuman.Add(Humandict[counthumans]);
                listHuman.TextsWriter("Humantest.txt");
            }
            if (TeacherradioButton.Checked)
            {
                int countteachet = listTeacher.Counts();
                Teacher teacher = new Teacher(NameTextBox.Text, SurnameTextBox.Text, SelectedGender(), AgeComboBox.SelectedIndex, Convert.ToDouble(HeightTextBox.Text), Convert.ToDouble(WeightTextBox.Text), HabbitsCheckBox.Checked, EmailTextBox.Text, Nation_Convector(), new Adress(CountryTextBox.Text, CityTextBox.Text, StreetTextBox.Text, int.Parse(HouseTextBox.Text)), int.Parse(GroupSalaryTextBox.Text), MoneyDepartmenttextBox.Text, int.Parse(NumofseatstextBox.Text), (KeyWords)CourseWorkSelect());
                Teacherdict.Add(countteachet, teacher);
                listTeacher.Add(Teacherdict[countteachet]);
                listTeacher.TextsWriter("Teachertest.txt");
            }
            if (StudentradioButton.Checked)
            {
                int countstudent = listStudent.Counts();
                Student students = new Student(NameTextBox.Text, SurnameTextBox.Text, SelectedGender(), AgeComboBox.SelectedIndex, Convert.ToDouble(HeightTextBox.Text), Convert.ToDouble(WeightTextBox.Text), HabbitsCheckBox.Checked, EmailTextBox.Text, Nation_Convector(), new Adress(CountryTextBox.Text, CityTextBox.Text, StreetTextBox.Text, int.Parse(HouseTextBox.Text)), int.Parse(GroupSalaryTextBox.Text), int.Parse(MoneyDepartmenttextBox.Text), (Key)CourseWorkSelect());
                Studentdict.Add(countstudent, students);
                listStudent.Add(Studentdict[countstudent]);
                listStudent.TextsWriter("Studenttest.txt");
            }
            ChooseStudent();
            CourseWork_Choose();
            Teacherselect();
            Treeviews();


            clearAll();
            PreviewButton.Visible = true;
        }
        private void clearAll()
        {
            NameTextBox.Clear();
            SurnameTextBox.Clear();
            AgeComboBox.SelectedIndex = -1;
            HeightTextBox.Clear();
            WeightTextBox.Clear();
            GenderMaleRadioButton.Checked = false;
            GenderFemaleRadioButton.Checked = false;
            HabbitsCheckBox.Checked = false;
            EmailTextBox.Clear();
            NationComboBox.SelectedIndex = -1;
            CountryTextBox.Clear();
            CityTextBox.Clear();
            StreetTextBox.Clear();
            HouseTextBox.Clear();
            GroupSalaryTextBox.Clear();
            MoneyDepartmenttextBox.Clear();
            NumofseatstextBox.Clear();
            CourseWorkcomboBox.SelectedIndex = -1;


        }
        private void Startsetings()
        {
            for (int i = 100; i > 0; i--)
            {
                AgeComboBox.Items.AddRange(new object[] {
                    i
                });
            }
            PreviewButton.Visible = false;
            gridviewcreateH();
            gridviewcreateStT();
            PersonRegestrationRadioButton.Checked = true;
        }
        private Nation Nation_Convector()
        {
            if (NationComboBox.SelectedIndex == 0) { return Nation.Ukranian; }
            if (NationComboBox.SelectedIndex == 1) { return Nation.French; }
            if (NationComboBox.SelectedIndex == 2) { return Nation.Polish; }
            return 0;
        }
        private object CourseWorkSelect()
        {
            RadioButton TeacherradioButton = (RadioButton)TeacherRegestrationRadioButton;
            RadioButton StudentradioButton = (RadioButton)StudentRegestrationRadioButton;
            if (TeacherradioButton.Checked)
            {
                if (NationComboBox.SelectedIndex == 0) { return KeyWords.csharp; }
                if (NationComboBox.SelectedIndex == 1) { return KeyWords.python; }
                if (NationComboBox.SelectedIndex == 2) { return KeyWords.java; }
                if (NationComboBox.SelectedIndex == 3) { return KeyWords.JS; }

            }
            if (StudentradioButton.Checked)
            {
                if (NationComboBox.SelectedIndex == 0) { return Key.csharp; }
                if (NationComboBox.SelectedIndex == 1) { return Key.python; }
                if (NationComboBox.SelectedIndex == 2) { return Key.java; }
                if (NationComboBox.SelectedIndex == 3) { return Key.JS; }

            }

            return 0;
        }

        private Gender SelectedGender()
        {
            RadioButton maleradioButton = (RadioButton)GenderMaleRadioButton;
            RadioButton femaleradioButton = (RadioButton)GenderFemaleRadioButton;
            if (maleradioButton.Checked)
            {
                return Gender.Male;
            }
            if (femaleradioButton.Checked)
            {
                return Gender.Female;
            }
            return 0;

        }
        


        private void PreviewButton_Click(object sender, EventArgs e)
        {
            int counthumans = listHuman.Counts();
            int countstudent = listStudent.Counts();
            int countteachet = listTeacher.Counts();
            RadioButton PersonradioButton = (RadioButton)PersonRegestrationRadioButton;
            RadioButton TeacherradioButton = (RadioButton)TeacherRegestrationRadioButton;
            RadioButton StudentradioButton = (RadioButton)StudentRegestrationRadioButton;
            HSTSelectorComboBox1.Text = "";
            HSTSelectorComboBox1.Items.Clear();
            HSTSelectorComboBox1.SelectedIndex = -1;
            InfoLabel.Text = " ";
            if (PersonradioButton.Checked)
            {
                gridviewcreateH();
                for (int i = 0; i < counthumans; i++)
                {
                    HSTSelectorComboBox1.Items.AddRange(new object[]{
                     Humandict[i].Name  + " " + Humandict[i].Surname
                });
                }
                listHuman.Show();
            }
            if (TeacherradioButton.Checked)
            {
                DataRowsGridviewT();
                for (int j = 0; j < countteachet; j++)
                {
                    HSTSelectorComboBox1.Items.AddRange(new object[]{
                        Teacherdict[j].Name +" " + Teacherdict[j].Surname
                });
                }
                listTeacher.Show();
            }
            if (StudentradioButton.Checked)
            {
                DataRowsGridviewst();
                for (int k = 0; k < countstudent; k++)
                {
                    HSTSelectorComboBox1.Items.AddRange(new object[]{
                        Studentdict[k].Name +" " + Studentdict[k].Surname
                });
                }
                listStudent.Show();
            }

        }

        private void Panel_change()
        {
            RadioButton PersonradioButton = (RadioButton)PersonRegestrationRadioButton;
            RadioButton TeacherradioButton = (RadioButton)TeacherRegestrationRadioButton;
            RadioButton StudentradioButton = (RadioButton)StudentRegestrationRadioButton;

            if (PersonradioButton.Checked)
            {

                PersonRegistrationLabel.Text = "Person Registration";
                Human_student_teacher_Lable.Text = "Selected Person";
                Previewlabel.Text = "Preview Person";
                GroupSalaryTextBox.Visible = false;
                SalaryGroupLabel.Visible = false;
                MoneyDepartmentlabel.Visible = false;
                MoneyDepartmenttextBox.Visible = false;
                Numofseatslabel.Visible = false;
                NumofseatstextBox.Visible = false;
                CourseWorkLAble.Visible = false;
                CourseWorkcomboBox.Visible = false;

                dataGridView2.Visible = true;
                dataGridView1.Visible = false;
                DataRowsGridviewh();

            }
            if (StudentradioButton.Checked)
            {

                PersonRegistrationLabel.Text = "Studen Registration";
                Human_student_teacher_Lable.Text = "Selected Studen";
                Previewlabel.Text = "Preview Studen";
                GroupSalaryTextBox.Visible = true;
                SalaryGroupLabel.Visible = true;
                SalaryGroupLabel.Text = "Group";
                MoneyDepartmentlabel.Visible = true;
                MoneyDepartmentlabel.Text = "Money";
                MoneyDepartmenttextBox.Visible = true;
                Numofseatslabel.Visible = false;
                NumofseatstextBox.Visible = false;
                CourseWorkLAble.Visible = true;
                CourseWorkcomboBox.Visible = true;
                CourseWorkcomboBox.Items.Clear();
                CourseWorkcomboBox.Items.AddRange(new object[]{
                    "csharp",
                    "python",
                    "java",
                    "JS"
                });

                dataGridView2.Visible = false;
                dataGridView1.Visible = true;
                DataRowsGridviewst();
            }
            if (TeacherradioButton.Checked)
            {
                PersonRegistrationLabel.Text = "Teacher Registration";
                Human_student_teacher_Lable.Text = "Selected Teacher";
                Previewlabel.Text = "Preview Teacher";
                GroupSalaryTextBox.Visible = true;
                SalaryGroupLabel.Visible = true;
                SalaryGroupLabel.Text = "Salary";
                MoneyDepartmentlabel.Text = "Department";
                MoneyDepartmentlabel.Visible = true;
                MoneyDepartmenttextBox.Visible = true;
                Numofseatslabel.Visible = true;
                NumofseatstextBox.Visible = true;
                CourseWorkLAble.Visible = true;
                CourseWorkcomboBox.Visible = true;
                CourseWorkcomboBox.Items.Clear();
                CourseWorkcomboBox.Items.AddRange(new object[]{
                    "csharp",
                    "python",
                    "java",
                    "JS"
                });
                dataGridView2.Visible = false;
                dataGridView1.Visible = true;

                DataRowsGridviewT();
            }
            clearAll();
            HSTSelectorComboBox1.Items.Clear();
            HSTSelectorComboBox1.SelectedIndex = -1;
            InfoLabel.Text = " ";
            HSTSelectorComboBox1.Text = "";
        }
        private void gridviewcreateH()
        {

            DataTemph.Columns.Add("Name");
            DataTemph.Columns.Add("Surname");

            this.dataGridView2.DataSource = DataTemph;
        }
        private void gridviewcreateStT()
        {

                DataTemp.Columns.Add("Name");
                DataTemp.Columns.Add("Surname");
           
                DataTemp.Columns.Add("Key Words");


            this.dataGridView1.DataSource = DataTemp;
        }
        private void DataRowsGridviewT()
        {
            DataTemp.Rows.Clear();
            for (int i = 0; i < Teacherdict.Count; i++)
            {
                DataTemp.Rows.Add(Teacherdict[i].Name, Teacherdict[i].Surname, Teacherdict[i].KeyWords);
            }
        }
        private void DataRowsGridviewst()
        {
            DataTemp.Rows.Clear();
            for (int i = 0; i < Studentdict.Count; i++)
            {
                DataTemp.Rows.Add(Studentdict[i].Name, Studentdict[i].Surname, Studentdict[i].Key);
            }
        }
        private void DataRowsGridviewh()
        {
            DataTemph.Rows.Clear();
            for (int i = 0; i < Humandict.Count; i++)
            {
                DataTemph.Rows.Add(Humandict[i].Name, Humandict[i].Surname);
            }
        }
        private void PersonRegestrationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Panel_change();
        }

        private void StudentRegestrationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Panel_change();
        }

        private void TeacherRegestrationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Panel_change();
        }

        private void HSTSelectorComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButton PersonradioButton = (RadioButton)PersonRegestrationRadioButton;
            RadioButton TeacherradioButton = (RadioButton)TeacherRegestrationRadioButton;
            RadioButton StudentradioButton = (RadioButton)StudentRegestrationRadioButton;
            if (PersonradioButton.Checked)
            {
                if (HSTSelectorComboBox1.SelectedIndex == -1)
                {
                    InfoLabel.Text = " ";
                }
                else
                {
                    InfoLabel.Text =
                    "Name " + Humandict[HSTSelectorComboBox1.SelectedIndex].Name + "\n" +
                    "Surname " + Humandict[HSTSelectorComboBox1.SelectedIndex].Surname + "\n" +
                    "Gender " + Humandict[HSTSelectorComboBox1.SelectedIndex].Gender + "\n" +
                    "Age " + Humandict[HSTSelectorComboBox1.SelectedIndex].Age + "\n" +
                    "Height " + Humandict[HSTSelectorComboBox1.SelectedIndex].Height + "\n" +
                    "Weight " + Humandict[HSTSelectorComboBox1.SelectedIndex].Weight + "\n" +
                    "Habbits " + Humandict[HSTSelectorComboBox1.SelectedIndex].Habbits + "\n" +
                    "Email " + Humandict[HSTSelectorComboBox1.SelectedIndex].Email + "\n" +
                    "Nation " + Humandict[HSTSelectorComboBox1.SelectedIndex].Nation + "\n" +
                    "Country " + Humandict[HSTSelectorComboBox1.SelectedIndex].Adress.Country + "\n" +
                    "City " + Humandict[HSTSelectorComboBox1.SelectedIndex].Adress.City + "\n" +
                    "Street " + Humandict[HSTSelectorComboBox1.SelectedIndex].Adress.Street + "\n" +
                    "House " + Humandict[HSTSelectorComboBox1.SelectedIndex].Adress.House;
                }
            }
            if (TeacherradioButton.Checked)
            {
                if (HSTSelectorComboBox1.SelectedIndex == -1)
                {
                    InfoLabel.Text = " ";
                }
                else
                {
                    InfoLabel.Text =
                "Name " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Name + "\n" +
                "Surname " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Surname + "\n" +
                "Gender " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Gender + "\n" +
                "Age " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Age + "\n" +
                "Height " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Height + "\n" +
                "Weight " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Weight + "\n" +
                "Habbits " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Habbits + "\n" +
                "Email " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Email + "\n" +
                "Nation " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Nation + "\n" +
                "Country " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Adress.Country + "\n" +
                "City " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Adress.City + "\n" +
                "Street " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Adress.Street + "\n" +
                "House " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Adress.House + "\n" +
                "Salary " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Salary + "\n" +
                "Department " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].Department + "\n" +
                "Num of seats " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].NumOfSeats + "\n" +
                "Cours Work Theme " + Teacherdict[HSTSelectorComboBox1.SelectedIndex].KeyWords + "\n";
                }
            }
            if (StudentradioButton.Checked)
            {
                if (HSTSelectorComboBox1.SelectedIndex == -1)
                {
                    InfoLabel.Text = " ";
                }
                else
                {
                    InfoLabel.Text =
                "Name " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Name + "\n" +
                "Surname " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Surname + "\n" +
                "Gender " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Gender + "\n" +
                "Age " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Age + "\n" +
                "Height " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Height + "\n" +
                "Weight " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Weight + "\n" +
                "Habbits " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Habbits + "\n" +
                "Email " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Email + "\n" +
                "Nation " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Nation + "\n" +
                "Country " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Adress.Country + "\n" +
                "City " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Adress.City + "\n" +
                "Street " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Adress.Street + "\n" +
                "House " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Adress.House +
                 "Group  " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Group + "\n" +
                "Money  " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Money + "\n" +
                "Cours Work " + Studentdict[HSTSelectorComboBox1.SelectedIndex].Key + "\n";
                }
            }
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
        private void ChooseStudent()
        {
            StudentChoose.Items.Clear();
            for (int i = 0; i < Studentdict.Count; i++)
            {
                StudentChoose.Items.AddRange(new object[]{
                     Studentdict[i].Name  + " " + Studentdict[i].Surname
                });
            }
        }
        private void Teacherselect()
        {
            TeacherSelect.Items.Clear();
            for (int i = 0; i < Teacherdict.Count; i++)
            {
                TeacherSelect.Items.AddRange(new object[]{
                     Teacherdict[i].Name  + " " + Teacherdict[i].Surname
                });
            }
        }
        private void CourseWork_Choose()
        {

            CourseWorkChoose.Items.Clear();
            for (int i = 0; i < CourseWorkdict.Count; i++)
            {
                CourseWorkChoose.Items.AddRange(new object[]{
                     CourseWorkdict[i].CourseWorks.Name  + " \n " + CourseWorkdict[i].CourseWorks.Date + " \n" + CourseWorkdict[i].CourseWorks.Description
                });
            }
        }
        private void Treeviews()
        {
            this.treeView1.Nodes.Clear();
            for (int i = 0; i < Teacherdict.Count(); i++)
            {
                treeView1.Nodes.Add(Teacherdict[i].Name + " " + Teacherdict[i].Surname);
                for (int j = 0; j < Teacherdict[i].List.Count; j++)
                {
                    treeView1.Nodes[i].Nodes.Add(Teacherdict[i].List[j].Name);
                    treeView1.Nodes[i].Nodes[j].Nodes.Add(Teacherdict[i].CourseWorks.Name);
                }
            }
        }
        private void EnrollinCourseWork_Click(object sender, EventArgs e)
        {
            CourseWorkdict[CourseWorkChoose.SelectedIndex].List.Add(Studentdict[StudentChoose.SelectedIndex]);
            ChooseStudent();
            CourseWork_Choose();
            Teacherselect();
            Treeviews();
        }

        private void CreateCourseWork_Click(object sender, EventArgs e)
        {
            
            Teacherdict[TeacherSelect.SelectedIndex].CourseWorks = new CourseWork(CourseworkDescriptionBox2.Text, CourseworkNametextBox.Text, dateTimePicker1.Value);
            CourseWorkdict.Add(CourseWorkn, Teacherdict[TeacherSelect.SelectedIndex]);
            ChooseStudent();
            CourseWork_Choose();
            Teacherselect();
            Treeviews();
            CourseWorkn++;

        }

        private void CourseWorkChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            CourseWorkInfo.Text =
               "Name " + CourseWorkdict[CourseWorkChoose.SelectedIndex].CourseWorks.Name + "\n" +
               "Data  " + CourseWorkdict[CourseWorkChoose.SelectedIndex].CourseWorks.Date + "\n" +
               "Description " + CourseWorkdict[CourseWorkChoose.SelectedIndex].CourseWorks.Description + "\n";
        }
    }
}

