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
using System.Net;
using System.Net.Mail;

namespace WpfTestMailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }
        
        ExceptionMessageWindow exceptionMessage;
        SendCompleteWindow sendComplete;
        EmailSendService emailSendService;
        string from = "MalinaRaspberry888@gmail.com";
        List<string> emailAddresses; 

        private void BtnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            string text = BodyTxtBox.Text;
            string subject = SubjectTxtBox.Text;
            string strPassword = passwordBox.Password;
            emailAddresses= new List<string>() { "molinakate888@gmail.com", "honeykate6@gmail.com" };
            try
            {
                emailSendService = new EmailSendService(emailAddresses, from, text, subject, strPassword);
                emailSendService.SendEmail();
            }
            catch(Exception ex)
            {
                exceptionMessage = new ExceptionMessageWindow();
                exceptionMessage.ExceptionTextBox.Foreground = Brushes.Red;
                exceptionMessage.ExceptionTextBox.Text = ex.Message;
                exceptionMessage.ShowDialog();
            }
            sendComplete = new SendCompleteWindow();
            sendComplete.ShowDialog();
        }
    }
}
