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
    /// Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerWindow()
        {
            InitializeComponent();
            MainWindow window = new MainWindow();
            lvOperatorList.ItemsSource = window.db.Operators.ToList();
        }

        private void addComplaintButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            if (CheckComplaint(tbxComplaint.Text) && CorrectFill(tbxComplaint.Text))
            {
                window.db.Complaints.Add(new Complaint(tbxComplaint.Text));
                window.db.SaveChanges();
                lbForErrors.Foreground = Brushes.LimeGreen;
                lbForErrors.Content = "Your complaint is under consideration";
            }
        }
        public bool CheckComplaint(string ComplaintDescription)
        {
            MainWindow window = new MainWindow();
            foreach (Complaint complaint in window.db.Complaints)
            {
                if (ComplaintDescription == complaint.Description)
                {
                    lbForErrors.Content = "Such Complaint already exists";
                    return false;
                }
            }
            return true;
        }
        public bool CorrectFill(string ComplaintDescription)
        {
            if (String.IsNullOrWhiteSpace(ComplaintDescription))
            {
                lbForErrors.Content = "The Complaint wasn't entered";
                return false;
            }
            return true;
        }
    }
}
