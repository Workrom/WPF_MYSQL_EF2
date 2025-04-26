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
    /// Interaction logic for InsertStorePage.xaml
    /// </summary>
    public partial class InsertStorePage : Page
    {
        public string StoreName => S_StoreName_txb.Text;
        public string StoreAdress => S_StoreAdress_txb.Text;
        public string StoreRegion => S_StoreRegion_txb.Text;
        public string StoreCEO => S_StoreCEO_txb.Text;
        public string Phone => S_StorePhone_txb.Text;
        public InsertStorePage()
        {
            InitializeComponent();
        }
    }
}
