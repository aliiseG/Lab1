using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Lab1Library;

namespace Lab1WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Studentu saraksts.
        /// </summary>
        private StudentsData students = new StudentsData();

        private void InvalidateList()
        {
            //saraksta aktualizēšana
            lstStudents.ItemsSource = students.Students.ToList();
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtSurname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                students.Add(new Student(txtName.Text, txtSurname.Text, txtId.Text, txtGroup.Text, txtEmail.Text));
                txtName.Clear();
                txtSurname.Clear();
                txtId.Clear();
                txtGroup.Clear();
                txtEmail.Clear();
                InvalidateList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                students.Save(StudentsData.DefaultFilename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                students.Students.Clear();
                students.Load(StudentsData.DefaultFilename);
                InvalidateList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}