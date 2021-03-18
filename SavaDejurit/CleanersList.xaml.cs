using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SavaDejurit
{
    /// <summary>
    /// Логика взаимодействия для CleanersList.xaml
    /// </summary>
    public partial class CleanersList : Page, IPage
    {
        public CleanersList()
        {
            InitializeComponent();
        }
        public void SetVM(IPageVM vm)
        {
            DataContext = vm;
        }
    }
}
