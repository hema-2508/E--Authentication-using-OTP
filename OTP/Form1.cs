﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTP
{
    public partial class Form1 : Form
    {
        String randomCode;
        public static String to;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txtEmail.Text).ToString();
            from = "bujji342434@gmail.com";
            pass = "vvmh pmon jxgt vfns";
            messageBody = "Your reset code is " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Password Reseting Code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Code Sent Successfully");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVerify_Click_1(object sender, EventArgs e)
        {
            if (randomCode == txtVerify.Text.ToString())
            {
                MessageBox.Show("Verified");
            }
            else
            {
                MessageBox.Show("Wrong Code");
            }
        }
    }
}
