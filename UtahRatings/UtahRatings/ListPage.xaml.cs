using System;
using Xamarin.Forms;

namespace UtahRatings
{
    public partial class ListPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public ListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            UpdateScreenList();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            int id;
            bool success = int.TryParse(txtId.Text, out id);
            if (success)
            {
                await firebaseHelper.AddList(
                    Convert.ToInt32(txtId.Text),
                    txtName.Text,
                    txtDescription.Text);
                await DisplayAlert("Success", "List Added Successfully", "OK");
            }
            else
            {
                await DisplayAlert("Error", "ID Must Be a Int", "OK");
            }
        }

        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            int id;
            bool success = int.TryParse(txtId.Text, out id);
            if (success)
            {
                var list = await firebaseHelper.GetList(Convert.ToInt32(txtId.Text));
                if (list != null)
                {
                    txtId.Text = list.ListId.ToString();
                    txtName.Text = list.Name;
                    txtDescription.Text = list.Description;
                    await DisplayAlert("Success", "List Retrive Successfully", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "No List With That ID Found", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "ID Must Be a Int", "OK");
            }
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            int id;
            bool success = int.TryParse(txtId.Text, out id);
            if (success)
            {
                var list = await firebaseHelper.GetList(Convert.ToInt32(txtId.Text));
                if (list != null)
                {
                    await firebaseHelper.UpdateList(
                        Convert.ToInt32(txtId.Text),
                        txtName.Text,
                        txtDescription.Text);
                    await DisplayAlert("Success", "List Updated Successfully", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "No List With That ID Found", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "ID Must Be a Int", "OK");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            int id;
            bool success = int.TryParse(txtId.Text, out id);
            if (success)
            {
                var list = await firebaseHelper.GetList(Convert.ToInt32(txtId.Text));
                if (list != null)
                {
                    await firebaseHelper.DeleteList(Convert.ToInt32(txtId.Text));
                    await DisplayAlert("Success", "List Deleted Successfully", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "No List With That ID Found", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "ID Must Be a Int", "OK");
            }
        }

        private void UpdateScreenList()
        {

        }
    }
}