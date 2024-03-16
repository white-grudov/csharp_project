using csharp_project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace csharp_project.Views
{
    public partial class PersonView : UserControl
    {
        private PersonViewModel _viewModel = new PersonViewModel();
        public PersonView()
        {
            InitializeComponent();
            DataContext = _viewModel;

            datePicker.SelectedDate = DateTime.Now;
        }
    }
}
