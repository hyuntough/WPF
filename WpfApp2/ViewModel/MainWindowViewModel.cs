using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Atomus.WpfApp2.ViewModel
{
    public class MainWindowViewModel : MVVM.ViewModel
    {
        private string userID;
        private string password;
        private string email;
        private List<MainWindowViewModel> list;
        private bool isEnableControl;
        private MainWindowViewModel selectedItem;

        [Required]
        [Display(Name ="아이디")]
        public string UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                if (this.userID != value)
                {
                    this.userID = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        [Required]
        [Display(Name = "패스워드")]
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        [Required]
        [Display(Name = "이메일")]
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public List<MainWindowViewModel> UserList
        {
            get
            {
                return list;
            }

            set
            {
                if(this.list != value)
                {
                    this.list = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public bool isEnablecontrol
        {
            get
            {
                return this.isEnableControl;
            }
            set
            {
                if (this.isEnableControl != value)
                {
                    this.isEnableControl = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public MainWindowViewModel SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                if (this.selectedItem != value)
                {
                    this.selectedItem = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand InitCommand { get; set; }

        public MainWindowViewModel()
        {
            this.isEnablecontrol = true;

            this.list = new List<MainWindowViewModel>();

            this.SaveCommand = new MVVM.DelegateCommand(
                () => { this.SaveProcess(); }
                , () => { return isEnablecontrol; }
                );

            this.InitCommand = new MVVM.DelegateCommand(
                () => { this.InitProcess(); }
                , () => { return isEnablecontrol; }
                );
        }

        private void InitProcess()
        {
            this.SelectedItem = new MainWindowViewModel();
        }

        private void SaveProcess()
        {
            MainWindowViewModel mainWindowViewModel;
            List<MainWindowViewModel> models;

            try
            {
                this.isEnablecontrol = false;
                (this.SaveCommand as MVVM.DelegateCommand).RaiseCanExecuteChanged();

                //System.Threading.Thread.Sleep(1000);

                mainWindowViewModel = new MainWindowViewModel();
                mainWindowViewModel.UserID = this.selectedItem.UserID;
                mainWindowViewModel.Password = this.selectedItem.Password;
                mainWindowViewModel.Email = this.selectedItem.Email;

                this.list.Add(mainWindowViewModel);

                models = this.list;
                this.UserList = null;
                this.UserList = models;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                this.isEnablecontrol = true;
                (this.SaveCommand as MVVM.DelegateCommand).RaiseCanExecuteChanged();
            }


        }
    }
}
