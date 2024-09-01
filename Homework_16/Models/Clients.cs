using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework_16.Models
{
    public class Client : INotifyPropertyChanged
    {
        private int    _id;
        private string _lastName;
        private string _firstName;
        private string _middleName;
        private string _phoneNumber;
        //private string _email;
        public virtual ICollection<Product> Products { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ClientId));
            }
        }

        [DisplayName("Фамилия")]
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        [DisplayName("Имя")]
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        [DisplayName("Отчество")]
        public string MiddleName
        {
            get => _middleName;
            set
            {
                _middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }
        
        [DisplayName("Телефон")]
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        [Key]
        public string Email { get; set; }
        //[DisplayName("Электронная почта")]
        //[Key]
        //public string Email
        //{
        //    get => _email;
        //    set
        //    {
        //        _email = value;
        //        OnPropertyChanged(nameof(Email));
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
