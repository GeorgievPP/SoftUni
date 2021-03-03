using System;
using System.Collections.Generic;
using System.Text;

namespace Stealer.Models
{
    public class Hacker
    {
        public string username = "securityGod82";
        private string password = "mySuperSecretPassw0rd";

        public string Password
        {
            get => this.password;
            set => this.password = value;
        }

        public int Id { get; set; }

        public double BankAccountBAlance { get; private set; }

        public void DownloadAllBankAccountsInTheWorld()
        {

        }
    }
}
