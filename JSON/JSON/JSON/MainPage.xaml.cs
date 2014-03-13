using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JSON
{



    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
    
        
        
        public MainPage()
        {
            this.InitializeComponent();
        
        
        
        }

        

      /// <summary>
      /// I made a method to get json 
      /// it is a bit different from the normal void method you know why??
      /// because the type of mehtod is void but its clasification is async
      /// we load data from web 
      /// it may be dalayed so we use async got it??
      /// 
      /// There is no native api to deserialize json in windows phone so we use 
      /// newtonsoft.json  a 3rd parth .dll to deserialize the data
      /// 
      /// i am not a windows 8 developer so you should learn either there is a native 
      /// api or not
      /// 
      /// how to get newtonsoft.json do you know it??
      /// cool (y) you rock
      /// and adding the reference??
      ///
      /// </summary>

       

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        

        private void btn_tumHeHoo_Click(object sender, RoutedEventArgs e)
        {
            App.href_Json = new Uri("http://www.recipepuppy.com/api/?i=" + tbx_ingrediants.Text + "&q=" + tbx_recipie.Text + "&p=1");
            this.Frame.Navigate(typeof(Results));
        
        }
    }
}
