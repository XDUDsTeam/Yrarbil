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
using System.Windows.Media.Animation;




using wanju2.data;
//using liberty.library.Service;
//using liberty.library.Data_layer;


namespace wanju2
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public librarydata libdata = new librarydata();   //library页面的数据
        public serch ser = new serch();                   //图书查询页面的数据
        public user use = new user();                     //读者查询页面的数据
        public borandreturn borrowandreturn = new borandreturn();   //借还书页面数据

        //private services sv;
        //private ColorAnimation ca;
        //private ColorAnimation grd_ca;

        public Window1()
        {
            InitializeComponent();
            //ca = new ColorAnimation();
            //ca.From = Colors.White;
            //ca.To = Colors.LightGray;
            //ca.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            //ca.AutoReverse = true;

            //grd_ca = new ColorAnimation();
            //grd_ca.From = Colors.Black;
            //grd_ca.To = Colors.White;
            //grd_ca.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            //grd_ca.AutoReverse = true;

            //sv = service;
        }

        private void show(object sender, RoutedEventArgs e)
        {
            stack_library.Visibility = Visibility.Collapsed;
            stack_query.Visibility = Visibility.Collapsed;
            stack_reader.Visibility = Visibility.Collapsed;
            //stack_search_results.Visibility = Visibility.Collapsed;
            stack_log.Visibility = Visibility.Collapsed;
            stack_out.Visibility = Visibility.Collapsed;
            stack_borandreturn.Visibility = Visibility.Collapsed;

            FrameworkElement feSource = e.Source as FrameworkElement;
            switch (feSource.Name)
            {
                case "btnlibrary":
                                                                   //需要获得librarydata数据给libdata
                                                                   
                    libintroduction.Text = libdata.libintroduction;//调用方法显示
                    hotbook.Text = libdata.hotbooks;                  
                    newbook.Text = libdata.newbooks;                 
                    stack_library.Visibility = Visibility.Visible;

                    break;
                case "btnquery":
                                                                 //需要获得librarydata数据给use
                                                                  //调用方法显示即可
                    //readerinfomation.Text = use.userinfomation;  (去掉注释）
                    //borrowinfomation .Text  = use.loanrecord;    （去掉注释）                 
                    stack_query.Visibility = Visibility.Visible;
                    break;
                case "btnreader":
                    stack_reader.Visibility = Visibility.Visible;
                    break;
                //case "btnlog":
                //    //grd_borrow.ItemsSource = sv.get_availableBooks();
                //    //// Quick hack as this DataGrid is bound directly to the _borrowers datasource
                //    //// Needs to be changed so it has a listener on the modified event of the Borrowes List
                //    //grd_borrower.ItemsSource = null;
                //    //grd_borrower.ItemsSource = sv.getBorrowers();
                //    stack_log.Visibility = Visibility.Visible;
                //    break;
                //case "btnout":
                //    stack_out.Visibility = Visibility.Visible;
                //    //grd_return.ItemsSource = sv.get_BorrowedBooks();
                //    break;
                case "btnborandreturn":
                    //grd_overdue.ItemsSource = sv.overdueBooks();
                    stack_borandreturn.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void hide(object sender, RoutedEventArgs e)
        {
            stack_library.Visibility = Visibility.Collapsed;
            stack_query.Visibility = Visibility.Collapsed;
            stack_reader.Visibility = Visibility.Collapsed;
            //stack_search_results.Visibility = Visibility.Collapsed;
            stack_log.Visibility = Visibility.Collapsed;
            stack_out.Visibility = Visibility.Collapsed;
            stack_borandreturn.Visibility = Visibility.Collapsed;

        }

        //图书查询提交
        private void Button_Click(object sender, RoutedEventArgs e)
        {
             ser.booknumber = bookid.Text;
             ser.requirement1 = selection1.Text;
             ser.requirement2 = selection2.Text;
             ser.requirement3 = selection3.Text;
                                                //将图书查询的信息ser交给后端
                                                //从数据库获取图书信息给ser.serchresult和ser.details；
                                                

            bookresult.Text = ser.serchresult;
            detail.Text = ser.details;
        }

        //续借
        private void reborrow_Click(object sender, RoutedEventArgs e)
        {
                                                           //把borrowinfomation .Text传给后端续借图书
        }

        //图书查询预约
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                                                                    //把bookresult的结果返回给后端进行预约
        }

        private void btnout_Click(object sender, RoutedEventArgs e)
        {
                                                                        //用户退出，发送退出的消息给后端

            Application.Current.Shutdown();
        }

        //借还书页面btn
        private void btnborandret_Click(object sender, RoutedEventArgs e)
        {
            borrowandreturn.borrowbookid = borrowbookid.Text;
            borrowandreturn.returnbookid = returnbookid.Text;
                                                                  //将借还书的borrowandreturn数据传递给后端处理
        }

        //private void btnSaveBorrower_Click(object sender, RoutedEventArgs e)
        //{
        //    if (sv.SaveBorrower(txtFirstName.Text, txtLastName.Text))
        //    {
        //        txtFirstName.Text = "";
        //        txtLastName.Text = "";
        //    }
        //    else
        //    {
        //        txtFirstName.Background = new SolidColorBrush(Colors.White);
        //        txtFirstName.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
        //        txtLastName.Background = new SolidColorBrush(Colors.White);
        //        txtLastName.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
        //    }

        //}

        //private void btnSaveBook_Click(object sender, RoutedEventArgs e)
        //{
        //    if (sv.SaveBook(txtAuthor.Text, txtTitle.Text))
        //    {
        //        txtAuthor.Text = "";
        //        txtTitle.Text = "";
        //    }
        //    else
        //    {
        //        txtAuthor.Background = new SolidColorBrush(Colors.White);
        //        txtAuthor.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
        //        txtTitle.Background = new SolidColorBrush(Colors.White);
        //        txtTitle.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
        //    }
        //}

        //private void btnSearchTerm_Click(object sender, RoutedEventArgs e)
        //{
        //    grd_searchResults.ItemsSource = sv.SearchBook(txtSearchTerm.Text);
        //    stack_search_results.Visibility = Visibility.Visible;
        //}

        //private void btnBorrowBook_Click(object sender, RoutedEventArgs e)
        //{
        //    if (sv.borrowBook((Borrower)grd_borrower.SelectedItem, (Book)grd_borrow.SelectedItem))
        //    {
        //        grd_borrow.ItemsSource = sv.get_availableBooks();
        //        grd_borrower.ItemsSource = sv.getBorrowers();
        //    }
        //    else
        //    {
        //        grd_borrow.BorderBrush = new SolidColorBrush(Colors.Black);
        //        grd_borrow.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, grd_ca);
        //        grd_borrower.BorderBrush = new SolidColorBrush(Colors.Black);
        //        grd_borrower.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, grd_ca);
        //    }

        //}

        //private void btnReturnBook_Click(object sender, RoutedEventArgs e)
        //{
        //    if (sv.returnBook((Borrowed_Book)grd_return.SelectedItem))
        //        grd_return.ItemsSource = sv.get_BorrowedBooks();
        //    else
        //    {
        //        grd_return.BorderBrush = new SolidColorBrush(Colors.Black);
        //        grd_return.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, grd_ca);
        //    }
        //}

    }
}