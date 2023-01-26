using Microsoft.EntityFrameworkCore.Storage;
using Mobile_Network_System.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mobile_Network_System
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            MainWindow window = new MainWindow();
            lvOperatorList.ItemsSource = window.db.Operators.ToList();
            lvComplaintsList.ItemsSource = window.db.Complaints.ToList();
        }

        public bool CorrectFill(string operatorName, string Phone, string Logo, string OperatorPercent)
        {
            if (String.IsNullOrWhiteSpace(operatorName))
            {
                lbForErrors.Content = "The Operator Name wasn't entered";
                return false;
            }
            if (String.IsNullOrWhiteSpace(Phone))
            {
                lbForErrors.Content = "The Phone wasn't entered";
                return false;
            }
            if (String.IsNullOrWhiteSpace(Logo))
            {
                lbForErrors.Content = "The Logo wasn't entered:(";
                return false;
            }
            if (String.IsNullOrWhiteSpace(OperatorPercent))
            {
                lbForErrors.Content = "The Operator Percent wasn't entered:(";
                return false;
            }
            return true;
        }

        private void addOperatorButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            if (CheckOperator(tbxOperatorName.Text, tbxPhoneNumber.Text) && CorrectFill(tbxOperatorName.Text, tbxPhoneNumber.Text,
               tbxLogo.Text, tbxPercent.Text)) 
            {
                window.db.Operators.Add(new Operator(tbxOperatorName.Text, tbxPhoneNumber.Text,
                tbxLogo.Text, Int32.Parse(tbxPercent.Text)));
                window.db.SaveChanges();
                lbForErrors.Content = "Operator was successfully added";
                lvOperatorList.ItemsSource = window.db.Operators.ToList();
            }
        }
        public bool CheckOperator(string Name, string PhoneNumber)
        {
            MainWindow window = new MainWindow();
            foreach (Operator op in window.db.Operators)
            {
                if (Name == op.Name)
                {
                    lbForErrors.Content = "Operator with such Name has already registered";
                    return false;
                }
            }
            foreach (Operator op in window.db.Operators)
            {
                if (PhoneNumber == op.Phone)
                {
                    lbForErrors.Content = "Operator with such Phone Number has already registered";
                    return false;
                }
            }
            return true;
        }

        private void lvComplaintsList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                var index = lvComplaintsList.SelectedIndex;
                //MessageBox.Show($"\nIndex: {index}\nItems Count: {school.SubjectsList.ToList().Count()}");
                //return SubjectsList.ToList()[index];
                MainWindow window = new MainWindow();
                window.db.Complaints.ToList()[index].Status = "solved";
                window.db.SaveChanges();
                lvComplaintsList.ItemsSource = window.db.Complaints.ToList();
                //MessageBox.Show($"Items Count: {school.SubjectsList.ToList().Count()}");
                MessageBox.Show($"The status was changed on solved");
            }
        }
    }
}
