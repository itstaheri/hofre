using System;
using System.ComponentModel.DataAnnotations;

namespace SM.Domain
{
    public class SettingModel
    {
        protected SettingModel() { }
        public SettingModel(string title,string contectNumber,string contectEmail,string logo)
        {
            Title = title;
            ContectNumber = contectNumber;
            ContectEmail = contectEmail;
            Logo = logo;
        }
        public void Edit(string title, string contectNumber, string contectEmail, string logo)
        {
            Title = title;
            ContectNumber = contectNumber;
            ContectEmail = contectEmail;
            if(logo!= null) Logo = logo;

        }
        [Key]
        public long Id { get; set; }
        [MaxLength(255)]
        public string Title { get; private set; }
        public string ContectNumber { get; private set; }
        public string ContectEmail { get; private set; }
        public string Logo { get; private set; }
}
}
