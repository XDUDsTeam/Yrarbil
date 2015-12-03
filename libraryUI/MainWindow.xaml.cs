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

using wanju2.data;

namespace wanju2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Window1 w1 = new Window1();
        Window2 w2 = new Window2();
        logindata logdata = new logindata();
        public MainWindow()
        {

            InitializeComponent();
            
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            int flag = 0;
           
            logdata.passwords = this.PassWords.Password;
            logdata.username = this.UserName.Text;
                                                             //进行用户账号的验证，若通过则将flag标记为1
            if (flag == 0){                                  //修改为1
                w1.Show();
            }
            else
            {
                MessageBox.Show("密码错误");                    // 用了if和else之后关闭后面的页面就结束不了。。。。求帮助
                                                                //我用的是强制结束
                Application.Current.Shutdown();
            }
           
        }

        //游客登陆btn
        private void trilogin_Click(object sender, RoutedEventArgs e)
        {
            w2.Show();

                                                                    //游客登陆
        }
    }
}
