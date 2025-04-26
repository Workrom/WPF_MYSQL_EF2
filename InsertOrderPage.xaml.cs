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

namespace WPF_MYSQL_EF2
{
    /// <summary>
    /// Interaction logic for InsertOrderPage.xaml
    /// </summary>
    public partial class InsertOrderPage : Page
    {
        public int Productid => Convert.ToInt32(O_Productid_txb.Text);
        public int Storeid => Convert.ToInt32(O_Storeid_txb.Text);
        public int AmountOrdered => Convert.ToInt32(O_AmountOrdered_txb.Text);
        public DateOnly OrderDate => DateOnly.FromDateTime(O_OrderDate_dp.SelectedDate.Value);
        public int? AmoutDelivered => Convert.ToInt32(O_AmountDelivered_txb.Text);
        public DateOnly? DeliveryDate => DateOnly.FromDateTime(O_DeliveryDate_dp.SelectedDate.Value);
        public InsertOrderPage()
        {
            InitializeComponent();
        }
    }
}
