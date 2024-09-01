using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework_16.Models
{
    public class Product : INotifyPropertyChanged
    {
        private int    _id;
        private string _email;
        private int    _productCode;
        private string _productName;

        [ForeignKey("Email")]
        public virtual Client Client { get; set; }
        public int ProductId
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }
        public string Email { get; set; }
        //[DisplayName("Электронная почта")]
        //public string Email
        //{
        //    get => _email;
        //    set
        //    {
        //        _email = value;
        //        OnPropertyChanged(nameof(Email));
        //    }
        //}

        [DisplayName("Код продукта")]
        public int ProductCode
        {
            get => _productCode;
            set
            {
                _productCode = value;
                OnPropertyChanged(nameof(ProductCode));
            }
        }

        [DisplayName("Наименование")]
        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
