using Homework_16.Models;
using Homework_16.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Homework_16.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly ClientService _clientService;
        private readonly ProductService _productService;
        public ClientService ClientService => _clientService;
        public ProductService ProductService => _productService;
        public ObservableCollection<Client> Clients { get; private set; }
        public ObservableCollection<Product> Products { get; private set; }

        private string _statusBarAccessContent;
        private string _statusBarSQLContent;

        public ICommand AddClientCommand { get; private set; }

        public MainWindowViewModel()
        {
            _clientService = new ClientService();
            Clients = new ObservableCollection<Client>();
            _productService = new ProductService();
            Products = new ObservableCollection<Product>();
            LoadData();
        }


        //private async void LoadDataAsync()
        private async void LoadData()
        {
            var clients = await _clientService.GetAllClientsAsync();
            foreach (var client in clients)
            {
                Clients.Add(client);
            }
            var products = await _productService.GetAllProductsAsync();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        public string StatusBarAccessContent
        {
            get => _statusBarAccessContent;
            set
            {
                if (_statusBarAccessContent != value)
                {
                    _statusBarAccessContent = value;
                    OnPropertyChanged(nameof(StatusBarAccessContent));
                }
            }
        }

        public string StatusBarSQLContent
        {
            get => _statusBarSQLContent;
            set
            {
                if (_statusBarSQLContent != value)
                {
                    _statusBarSQLContent = value;
                    OnPropertyChanged(nameof(StatusBarSQLContent));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }     
    }

    public class RelayCommand<T> : ICommand
    {
        private Action<T> _execute;
        private Func<T, bool> _canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}