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
using System.Windows.Shapes;
using System.Windows.Media.Animation;

using wanju2.data;

namespace wanju2
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public librarydata youkelibdata = new librarydata();   //游客library页面的数据
        public serch youkeser = new serch();                   //游客图书查询页面的数据
        public Window2()
        {
            InitializeComponent();
        }

        //退出btn
        private void youkebtnout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //library的btn
        private void youkebtnlibrary_Click(object sender, RoutedEventArgs e)
        {

        }

        //图书查询的btn

        private void youkeshow(object sender, RoutedEventArgs e)
        {
            stack_youkelibrary.Visibility = Visibility.Collapsed;
            stack_youkereader.Visibility = Visibility.Collapsed;
            FrameworkElement feSource = e.Source as FrameworkElement;
            switch (feSource.Name)
            {
                case "youkebtnlibrary":
                                                                               //需要获得librarydata数据给youkelibdata
                                                                               //调用方法显示即可
                    //       libintroduction.Text = youkelibdata.libintroduction;   (去掉注释）
                    //       hotbook.Text = youkelibdata.hotbooks;                  (去掉注释）
                    //       newbook.Text = youkelibdata.newbooks;                  (去掉注释）
                    stack_youkelibrary.Visibility = Visibility.Visible;

                    break;
                
                case "youkebtnreader":
                    stack_youkereader.Visibility = Visibility.Visible;
                    break;
                ////case "btnlog":
                ////    //grd_borrow.ItemsSource = sv.get_availableBooks();
                ////    //// Quick hack as this DataGrid is bound directly to the _borrowers datasource
                ////    //// Needs to be changed so it has a listener on the modified event of the Borrowes List
                ////    //grd_borrower.ItemsSource = null;
                ////    //grd_borrower.ItemsSource = sv.getBorrowers();
                ////    stack_log.Visibility = Visibility.Visible;
                ////    break;
                ////case "btnout":
                ////    stack_out.Visibility = Visibility.Visible;
                ////    //grd_return.ItemsSource = sv.get_BorrowedBooks();
                ////    break;
                //case "btnborandreturn":
                //    //grd_overdue.ItemsSource = sv.overdueBooks();
                //    stack_borandreturn.Visibility = Visibility.Visible;
                //    break;
            }
        }
        private void hide(object sender, RoutedEventArgs e)
        {
            stack_youkelibrary.Visibility = Visibility.Collapsed;
            //stack_query.Visibility = Visibility.Collapsed;
            stack_youkereader.Visibility = Visibility.Collapsed;
            //stack_search_results.Visibility = Visibility.Collapsed;
            //stack_log.Visibility = Visibility.Collapsed;
            //stack_out.Visibility = Visibility.Collapsed;
            //stack_borandreturn.Visibility = Visibility.Collapsed;

        }


        //退出
        private void youkebtnout_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //图书查询提交btn
        private void tijiao_Click(object sender, RoutedEventArgs e)
        {
            youkeser.booknumber = bookid.Text;
            youkeser.requirement1 = selection1.Text;
            youkeser.requirement2 = selection2.Text;
            youkeser.requirement3 = selection3.Text;
                                                                     //将图书查询的信息ser交给后端
                                                                    //从数据库获取图书信息给youkeser.serchresult和youkeser.details；


            bookresult.Text = youkeser.serchresult;
            detail.Text = youkeser.details;
        }

    
    }
}
