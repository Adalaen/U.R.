﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UR_Login.ViewModel;

namespace UR_Login.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UR_LoginPage : ContentPage
    {
        LoginViewModel loginViewModel;
        public UR_LoginPage()
        {
            loginViewModel = new LoginViewModel();
            InitializeComponent();
            BindingContext = loginViewModel;
            
        }
        
        private void Loginbtn_Clicked(object sender, EventArgs e)
        {
            //null or empty field validation, check weather email and password is null or empty  
            if (string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Password.Text))
                DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                if (Email.Text == "abc@gmail.com" && Password.Text == "1234")
                {
                    DisplayAlert("Login Success", "", "Ok");
                    //Navigate to Wellcom page after successfully login  
                    Navigation.PushAsync(new WelcomePage());
                }
                else
                    DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
            }
        }
    }
}