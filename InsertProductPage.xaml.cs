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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_MYSQL_EF2
{
    /// <summary>
    /// Interaction logic for InsertProductPage.xaml
    /// </summary>
    public partial class InsertProductPage : Page
    {
        public string ProductName => P_ProductName_txb.Text;
        public decimal ProductFat => Convert.ToDecimal(P_ProductFat_txb.Text);
        public int PriceOne => Convert.ToInt32(P_ProductPrice_txb.Text);
        public DateOnly ExpirationDate => DateOnly.FromDateTime(P_ExpirationDate_dp.SelectedDate.Value);
        public InsertProductPage()
        {
            InitializeComponent();
        }
    }
}
