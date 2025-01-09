using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAAsync_1
{
    public partial class Form1 : Form
    {



        // await : Bir metodun görevinin tamamlanmasının baska kimseyi kitlemezken sadece o parca icin beklenmesini saglar...Eger bunu yazmazsanız o ilgili metot hep beklemez hem de hicbir şeyi kitlemez ve dolayısıyla sanki görevini salisesinde tamamlamıs gibi tepki verir...Ve bu da ciddi mantık hatalarına neden olur...


        public Form1()
        {
            InitializeComponent();
        }

        public void Deneme()
        {
            Thread.Sleep(20000);
            MessageBox.Show("Test");
        }


        //Async keyword'uyle işaretlenmiş olan bir metot yasam alanında baska awaitable metotları bekleme özelligi kazanır... 

        //Bir metoda async keyword'u yazmak onun hemen asenkron olmasını saglamaz...Bunun bir takım kurallara uyması gerekir...Birincisi async keyword'une sahip olan bir metot baskaları tarafından da cagrıldıgında awaitable hale gelir... Await edebilecegi (bekleyebilecegi ve bekledikten sonra özellikleri, durumları) döndürebilecegi bir Task tipinde olması en saglıklısı olur...Aksi durumda da kullanılabilir ama o zaman görevin ayrıntılarını cagırdıgınız yere yakalayamazsınız... Aynı zamanda  icerisindeki gerçek anlamda asenkron olan baska bir metodu da await ile beklemesi gerekir...Eger bunu yapmazsa (zaten VS uyarı verecektir) sadece ve sadece Pseude async metot yaratmıs olursunuz...Metodunuz iki kuralı uygulayıp sadece void kalırsa bekleyemeyen Asenkron metot yaratmıs olursunuz ama ilgili Task'in (yapacagınız görevin) ayrıntılarını asla barındıramazsınız...

        //Eger geriye deger döndürmeyen bir metodu Task'e cevirecekseniz direkt void Task yazarsınız...Task yazılan bir asenkron metot geriye deger döndürmeyen bir asenkron metottur...Eger geriye deger döndüren bir asenkron metot yaratacak iseniz o zaman Task tipine generic olarak döndüreceginiz degeri vermeniz gerekir...

        public async Task Selamla()
        {
            await Task.Run(() =>
              {
                  Thread.Sleep(20000);
                  MessageBox.Show("Merhaba ben kimseyi kitlemedim...");
              });
           

        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Eger bir metodun yasam alanında await keyword'u yazacak iseniz o metodun async keyword'u ileişaretlenmesi gerekir
            await Selamla();



            MessageBox.Show("Görev tamamlandı");
        }



        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aritmetik islemler");
        }
    }
}
