using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Auth;

namespace taqueria.Droid
{
    class HealthGateway 
    {
        
        public string Password
        {
            get
            {
                var account = AccountStore.Create(Application.Context).FindAccountsForService(Application.Context.ApplicationInfo.Name).FirstOrDefault();
                return (account != null) ? account.Properties["Password"] : null;
            }
        }
        public string UserName
        {
            get
            {
                var account = AccountStore.Create(Application.Context).FindAccountsForService(Application.Context.ApplicationInfo.Name).FirstOrDefault();
                return (account != null) ? account.Username : null;
            }
        }
        public void SaveCredentials(string UserName, string Password)
        {
            if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
            {
                Account account = new Account
                {
                    Username = UserName
                };
                account.Properties.Add("Password", Password);
                AccountStore.Create(Application.Context).Save(account, Application.Context.ApplicationInfo.Name);
            }
        }
        
    }
}