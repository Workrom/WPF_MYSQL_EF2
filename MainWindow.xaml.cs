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
using WPF_MYSQL_EF2.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Markup.Localizer;

namespace WPF_MYSQL_EF2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Service service = new Service();
    private readonly List<Func<List<object>>> _queryHandlers;

    private InsertProductPage productpage = new InsertProductPage();
    private InsertOrderPage orderpage = new InsertOrderPage();
    private InsertStorePage storepage = new InsertStorePage();
    public MainWindow()
    {
        InitializeComponent();

        service.testc();

        _queryHandlers = new List<Func<List<object>>>
    {
        service.firstQ,
        service.secondQ,
        service.thirdQ,
        service.fourthQ,
        service.fifthQ,
        service.sixthQ,
        service.seventhQ,
        service.eighthQ,
        service.ninthQ,
        service.tenthQ
    };
    }
    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        int index = Query_cb.SelectedIndex;
        if (index >= 0 && index < _queryHandlers.Count)
        {
            DGV1.ItemsSource = _queryHandlers[index]();
        }
    }

    private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        int index = insert_cb.SelectedIndex;
        switch (index)
        {
            case 0:
                mainframe.Navigate(productpage);
                break;
            case 1:
                mainframe.Navigate(orderpage);
                break;
            case 2:
                mainframe.Navigate(storepage);
                break;
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        int index = insert_cb.SelectedIndex;

        switch (index)
        {
            //-0 Product
            case 0:
                //essageBox.Show("Product is selected");
                service.InsertProduct(productpage.ProductName, productpage.ProductFat, productpage.PriceOne, productpage.ExpirationDate);
                break;
            //-1 Order
            case 1:
                //MessageBox.Show("Order is selected");
                service.InsertOrder(orderpage.Storeid, orderpage.Productid, orderpage.AmountOrdered, orderpage.OrderDate, orderpage.AmoutDelivered, orderpage.DeliveryDate);
                break;
            //-2 Store
            case 2:
                //MessageBox.Show("Store is selected");
                service.InsertStore(storepage.StoreName, storepage.StoreAdress, storepage.StoreRegion, storepage.StoreCEO, storepage.Phone);
                break;
            default: MessageBox.Show("Nothing is selected"); break;
        }
    }

    private void Show_Products_b_Click(object sender, RoutedEventArgs e)
    {
        DGV1.ItemsSource = service.Select<Product>();
    }

    private void Show_Orders_b_Click(object sender, RoutedEventArgs e)
    {
        DGV1.ItemsSource = service.Select<Order>();
    }

    private void Show_Stores_b_Click(object sender, RoutedEventArgs e)
    {
        DGV1.ItemsSource = service.Select<Store>();
    }
}