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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Schema;

namespace Mobile_Network_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Database db = new Database();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            lbLogin.Foreground = Brushes.DarkOrange;
            lbPassword.Foreground = Brushes.DarkOrange;
            if (CorrectFill(tbxLogin.Text, pasBox.Password, comboRoles.Text))
            {
                if (Registration())
                {
                    lbLogin.Foreground = Brushes.DarkOrange;
                    lbPassword.Foreground = Brushes.DarkOrange;
                }
            }
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            lbLogin.Foreground = Brushes.DarkOrange;
            lbPassword.Foreground = Brushes.DarkOrange;
            if (CorrectFill(tbxLogin.Text, pasBox.Password, comboRoles.Text))
            {
                if (Authorization())
                {
                    lbLogin.Foreground = Brushes.DarkOrange;
                    lbPassword.Foreground = Brushes.DarkOrange;
                }
            }
        }
        public bool CorrectFill(string login, string password, string role)
        {
            if (String.IsNullOrWhiteSpace(login))
            {
                lbLogin.Foreground = Brushes.Red;
                lbForErrors.Content = "The login wasn't entered";
                return false;
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                lbPassword.Foreground = Brushes.Red;
                lbForErrors.Content = "The password wasn't entered";
                return false;
            }
            if (String.IsNullOrWhiteSpace(role))
            {
                lbForErrors.Content = "The role wasn't selected:(";
                return false;
            }
            return true;
        }
        public bool Registration()
        {
            if (comboRoles.Text == "Customer")
            {
                Customer customer = new Customer(tbxLogin.Text, pasBox.Password);
                foreach (Customer customer2 in db.Customers.ToList())
                {
                    if (customer.Login == customer2.Login)
                    {
                        lbForErrors.Content = "User with such Login was already registrated";
                        return false;
                    }
                }
                db.Customers.Add(customer);
                db.SaveChanges();
                lbForErrors.Foreground = Brushes.LimeGreen;
                lbForErrors.Content = "The customer was succesfully registrated";
                CustomerWindow customerWindow = new CustomerWindow();
                this.Close();
                customerWindow.Show();
                return true;
            }
            else if (comboRoles.Text == "Admin")
            {
                Admin admin = new Admin(tbxLogin.Text, pasBox.Password);
                foreach (Admin admin2 in db.Admins.ToList())
                {
                    if (admin.Login == admin2.Login)
                    {
                        lbForErrors.Content = "User with such Login was already registrated:(";
                        return false;
                    }
                }
                db.Admins.Add(admin);
                db.SaveChanges();
                lbForErrors.Foreground = Brushes.LimeGreen;
                lbForErrors.Content = "The admin was succesfully registrated";
                AdminWindow adminWindow = new AdminWindow();
                this.Close();
                adminWindow.Show();
                return true;
            }
            return false;
        }
        public bool Authorization()
        {
            if (comboRoles.Text == "Customer")
            {
                if (db.Customers.Any(w => w.Login == tbxLogin.Text & w.Password == pasBox.Password))
                {
                    lbForErrors.Foreground = Brushes.LimeGreen;
                    lbForErrors.Content = "The user was successfully authohorized";
                    CustomerWindow customerWindow = new CustomerWindow();
                    this.Close();
                    customerWindow.Show();
                    return db.Customers.Any(w => w.Login == tbxLogin.Text & w.Password == pasBox.Password);
                }
                else
                {
                    lbForErrors.Content = "The authorization wasn't successful:(";
                    return false;
                }
            }
            if (comboRoles.Text == "Admin")
            {
                if (db.Admins.Any(w => w.Login == tbxLogin.Text & w.Password == pasBox.Password))
                {
                    lbForErrors.Foreground = Brushes.LimeGreen;
                    lbForErrors.Content = "The user was successfully authohorized";
                    AdminWindow adminWindow = new AdminWindow();
                    this.Close();
                    adminWindow.Show();
                    return db.Admins.Any(w => w.Login == tbxLogin.Text & w.Password == pasBox.Password);
                }
                else
                {
                    lbForErrors.Content = "The authorization wasn't successful:(";
                    return false;
                }
            }
            lbForErrors.Content = "The authorization wasn't successful:(";
            return false;
        }
    }
}
