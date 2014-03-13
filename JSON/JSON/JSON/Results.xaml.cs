using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JSON
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Results : Page
    {

        ObservableCollection<Result> abs = new ObservableCollection<Result>();
        ObservableCollection<MainJson> mainlist = new ObservableCollection<MainJson>();    
       
        public Results()
        {
            this.InitializeComponent();
            getJson();

            grd_result.SelectionChanged += grd_result_SelectionChanged;
        }

        void grd_result_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            MainJson jaz = (grd_result.SelectedItem as MainJson);

            selectedImage.Source = jaz.image1;
            tbl_title.Text = jaz.title1;
            tbl_ingrediants.Text = jaz.ingrediants1;
 
        
        }

        public async void getJson()
        {

            //ther is no web client in windows 8 so what we do is that we use httpClient
            // i have made its client


            var client = new HttpClient();

            var response = await client.GetAsync(App.href_Json);//what is missing here? yes API link

            var result = await response.Content.ReadAsStringAsync();
            // Till here there is no use of Newtonsoft
            //but  now weh have to deserialize the response that httpclient has got for us
            //so i will use newtonsoft

            var rootObject = JsonConvert.DeserializeObject<RootObject>(result);

            //here we will use the json but we are forgetting something 
            //can you tell what? ??? there?

            //so now we will use our data




            foreach (Result res in rootObject.results)
            {

                //This very this is going to reurnt the recipies

                Result r = new Result();
                r = res;
                BitmapImage img = new BitmapImage();

                if (r.thumbnail != "")
                {
                    img.UriSource = new Uri(r.thumbnail);
                }
                MainJson js = new MainJson();
                js.image1 = img;
                js.ingrediants1 = r.ingredients;
                js.title1 = r.title;

                mainlist.Add(js);

            }
           
            grd_result.ItemsSource = mainlist;



            ///<Summary>
            ///Bigar gayi wo muj sai kal 
            ///mazak hi mazak mai
            ///k mai nai q kaha chawal 
            ///mazak hi mazak mai
            ///kici ki aik wife aur kici ki aik b nahe
            ///mai le ura double double mazak he mazak mai :P
            ///</Summary>




        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }


 


    }
}
