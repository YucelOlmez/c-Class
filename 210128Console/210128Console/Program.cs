using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace _210128Console
{
    class Program
    {

        static void Main(string[] args)       
      
        {                               

            #region Tuple Türüyle Değer Atama

            int sayi1 = 5;
            int sayi2 = 10;

            (int yas, string ad, bool medeniHal) cc;

            cc.yas = 27;
            cc.ad = "Yücel";
            cc.medeniHal = false;

            Console.WriteLine();

            #endregion


            #region   Değişken Türüne Uygun Default Değer Atama işlemi

            //default değerler class scopeları içerisinde gönderilir.

            bool x = default(bool);            
            string y = default(string);
            int z = default(int);
            char q = default(char);

            // Default Literals

            bool xx = default; // yapabiliyoruz
            string yy = default;
            char zz = default;

            #endregion


            #region Tanımlanmış Değişkenin Değerini Okuma 

            // Bir değişkenin değerini elde edebilmek için değişkenin adından yani bizim verdiğimiz isminden faydalanmaktayız.
            //Değişkenimizin değerini çağıracaksak aşağıdaki xxx olarak isiminden faydalanacağız.
            // Bir değişkenin adı assign(=) atama operatörünün sağında ya da metotların parametrelerinde çağrılıyorsa ilgili değişkenin değeri gönderilir.
            int xxx = 12;

            Console.WriteLine(xxx); //metoda parametre olarak değişkenin adını gönderdim. Burada değeri yani 12yi gönderdi.
            //RAM'in stack bölümünde üstte tanımladığım int xxx = 12; değişkeni metotlarda xxx'in kendisi değil DEĞERİ yani 12 değeri gönderiliyor.

            int yyy = xxx; // yyy değişkeninde atama operatörü (assign) sağına değişkenin adını gönderdim. Burada değeri yani 12yi gönderdi.
                           // RAM'in stack bölümünde yyy isminde bir değişkene alan açılıyor, oluşturuluyor. yyy değişkenin kendisine xxx assign sağında olduğu için değerini ATAYACAK[bellek adresi gelmeyecek]. Gelen değer yyy'e atanacak, yyy 12 değerini alacak. Eğer xxx assign sağında olsaydı değer almak için bekliyor olacaktı.

            //örnek
            int a = 5;
            int b = 13;
            int c = b;
            int d = a;

            b = a;
            c = b;
            // örnekteki son durumda a,b,c ve d'ye gelen değişkenlerin değerlerinin açıklaması şudur; compile taradından yukarıdan aşağıya tanımlanmış değişkenin okunan değerleri a=5 b=13 c=13 d=5 sağlar. Sonrasında b değişkenine a'nın değeri gönderilerek b'nin ilk değeri olan 13 ezilip yerine yeni değeri 5 atanır. c değişkenine b'nin yeni değeri atanır c'nin son değeri 5 olur. RAM stack'inde de bu şekilde yeri ayrılır. Son atamalardan sonra değişkenlerin yeni değerleri a=5 b=5 c=5 d=5 olur.

            //örnek2

            int a1 = 5; // Stack'te bellek adresi yani alanı ayrıldı.
            a1 = a1; // değişken tanımlandı ve kendisine kendi değeri atanıyor. compiler burada şu şekilde çalışmaktadır[yukarıdan aşağıya doğru]. Stack'te bellek adresi ( alanı ayrılan ) "int a1" değişkeni assign sol tarafına stackten çağrılıyor (değeri çağırılmıyor). Assign sağ tarafına a1'in bellek adresinden değeri çağırılıp önceki 5 değeri silinip var olan 5 değeri "set" edilmiş olacak. 


            #endregion


            #region Değeri Olmayan Değişkenler!

            // OOP'ta Class içerisine tanımlanan değişkenlerin varsayılan Default değerleri atanır.
            //Class dışarısında olan değeri olmayan değişkenler ile hiç bir işlem yapamayız.

            //Class içerisinde tanımlanan dğeişkenlerde varsayılan değer otomatik atanmaktadır. Lakin "Main" içerisinde tanımlanan değişkenler de varsayılan değer atanmadığı için böyle boş tanımlanan değişkenlerde ilk değeri manuel vermediğimiz sürece işlem yapamayız.

            // Bir metot içerisinde tanımlanan değişkenlerin ilk değerlerini manuel olarak vermeyi alışkanlık haline getiriniz. Çünkü programın rahatça işlenebilir ve kodlanabilir olması içindir.

            int L;

            //Console.WriteLine(L); [--yorumsatırları kaldırıldığında hata vermesi normaldir.]

            //int LL = L; [--yorumsatırları kaldırıldığında hata vermesi normaldir.]


            #endregion


            #region Değişken Davranışları Genel Bakış(ref keyword için farkındalık) GENEL ÖZET

            //Değişkenler benim yerime yazılımda veri tutan yapılanmadır.
            //Değişkenler bizim yerimize hem bellek optimizasyonu yapabiliryor hem de alan tahsisi yapabileceği yeri biliyor. İstediğimiz zaman bize bana ilgili değeri getiriyor. Davranışsal olarak değişkenler isimleri üzerinden hareket eder.

            //Bir değişkenin ismini assign operatörünün sağında çağırırsak farklı solunda çağırırsak farklı davranış sergiler.
            //= operatörünün solunda değişkeni çağırırsak değişkenin kendisini(bellek adresini, RAM[stack]'te ayrılan alan) getirir. Gelen alana atama(=, assign) işlemleri yapabiliriz. Ayrılan alanın türüne uygun değişken verilerini her çağırdığımızda bu alana gönderebiliriz.
            //= sağ tarafında değişkenin ismiyle çağırıysak stackte yeri ayrılmış alanın içerisindeki değerini çağırıp göndermemize işlem yapmamıza olanak sağlar.


            #endregion


            #region Scope Nedir?
            //Faaliyet alanı
            //Kapsam
            //Değişken ve fonksiyonların erişilebilirlik sınırlarını belirleyen alandır.
            //Tanımlamalarda ve algoritmik çalışmalarda karışıklılığı önleyen bir sınır çizer.
            //c# : Süslü paranterz { } ifade edilir.
            //Bir scope içerisinde tanımlanan değişkene o scope içerisinde her yerde erişilebilir. Tabii tanımlandıktan sonra erişilebilir.
            //Bir scope'da aynı isimde farklı türler dahi olsa değişken olamaz.
            // Farklı scope'larda aynı isimde değişken kullanabiliriz. Çünkü erişilebilirlik sınırları farklıdır. Farklı yerlere hitap ederler.
            #endregion


            #region Değişkenin Faaliyet Alanı Nedir?
            //Bir değişken sade ve sadece tanımladığı scope içerisinden erişilebilir ve kullanılabilir.

            //Değişkenler scopelar arasında erişim sağlanır. Evrensel ve uygulama bütününde erişilemez.

            #endregion


            #region Değişmezler/Sabitler(const)
            //Sabitler; değişmeyen değerleri tutmak için oluşturulmuş yapılardır. Örn: Pi sayısını sabitlerde tutmamız gerekir.
            //Süreçte var olan değeri değiştirilemez , değiştirilmeye çalışıldığında compiler tarafından hata verilir.
            // 'const' keyword'de tanımlanabiliyor.
            //Constant ingilizce çevirisi sabit, değişmez anlamlarına çevrilir.
            //Değişmeyendir.
            //Prototip olarak değişkenlere çok benzer fakat davranışsal olarak değeri bir daha değiştirilemez.
            //Özünde static yapılanmadır. Fakat ayrıyetten const özelliği vardır.
            //const'lar yani sabit değerli değişkenler tanımlama gereği değişken gibi tanımlanıp değer atamaya geldiğimizde tanımlama esnasında değeri atanır ve değeri bir daha değiştirilmez, set edilemez. Bu yüzden static const'lar uygulamanın her yerinde kullanma ihtiyacımız olabileceği için static alanda tanımlanır.
            //'const' sadece tanımlama aşamasında değeri atanır. Başka varyasyonu yoktur.
            //Bir const tanımladnığında stack'te ilgili turde alan tahsis edilecektir ve ilk atanan değer dışında bir daha değer kabul etmeyecektir.
            // const'lar değiştirilemez lakin istenildiği kadar okunulabilir/değerleri elde edilebilir.
            // [const degisken_tipi degisken_adi;] diye tanımlaması yapılır.


            //Static Uygulama bazlı veri depolayabildiğimiz bellekte bir alandır.
            //Static alana gönderilen bir değere, değişkene her yerde erişilebilir ve işlem yapılabilir. Uygulama bazlıdır.
            //Static değişkenler adı üzerinde değerleri değişebilir. Fakat const'lar sabittir. Yapısal olarak static'te tutulur ama sabittir, const'tır.

            //readonly ; sadece okunabilir değişkenler tanımlamaktır.
            //const'tan farkı tanımlandığı yerde anında değer atanabilir, ayrıca constructor içerisinde de değeri atanabilir. Dependency Injection deseninde çok sık tercih edilir.
            //Static değildirler.

            #endregion


            #region Global Değişkenler
            //Bir değişken class scope içerisinde(class elemanı) tanımlanıyorsa buna global değişken diyoruz.
            //Metot içerisinde tanımlanan değişken local değişkendir.

            #endregion


            #region Değişken Tanımlama Varyasyonları
            //Varyasyon1

            int vary = 1;
            int vary2 = 10;

            //Varyasyon2
            //Aynı türde birden fazla değişken tanımlanıp değer atanacaksa bu değişkenleri tek bir imzada aşağıdaki gibi tanımlayabiliriz.

            int vary3 = 5, vary4 = 15;

            string vary5, vary6 = "Yücel";

            char vary7, vary8;

            vary7 = 'Y';
            vary8 = 'Ö';

            #endregion


            #region Değişkenler Arası Değer Atama Durumları-Deep Copy
            //Değişkenler arası değer atanırken verisel açıdan iki davranış söz konusudur. 1-Deep Copy 2-Shallow Copy
            //Deep Copy
            //Değişkenimizdeki veri/değer 1 tane iken Deep Copy neticesinde veri/değer çoğalır/klonlanır ve aynı veri/değerden 2 veri elde etmiş oluruz.    
            //Temel değişkenlerde değişkenin değerini bir başka değişkene atadığımızda Deep Copy yapmış oluruz.
            //Değer türlü değişkenler birbirlerine atanırken [assign edilirken] default olarak Deep Copy geçerlidir. Yani veri otomatik olarak üretilir.

            int dCopy = 5;
            int dCopy2 = dCopy;

            dCopy = dCopy * 3;
            Console.WriteLine(dCopy);
            Console.WriteLine(dCopy2);

            //Yukarıdaki işlemde eğer Deep Copy işlemi olmasaydı dCopy2 değişkeni dCopy değişkeninin son halini yani 15 değerini alıyor olacaktı. Fakat Deep Copy işlemi olduğu için dCopy değişkenin ilk değeri dCopy2 değişkenine klonlanıp/çoğaltılmıştır. Dolayısı ile dCopy2 değişkeni değişmemiş klonlanmıştır ve 15 değerini yazmıştır.

            #endregion


            #region Değişkenler Arası Değer Atama Durumları-Shallow Copy
            //Değişkenler arası değer atamalarında değeri türetmek/çoğaltmak/klonlamak yerine var olanı birden fazla referansla işaretlemeye dayalı kopyalama yöntemidir.
            //Bellekte birden fazla referansın tek bir veriyi işaret etmesidir.
            //Neticede ilgili değer bir değişikliğe uğradığında tüm işaretleyen referanslara bu değişiklik yansıyacaktır.
            //Referans türlü değişkenlerde default assign[atama] işlemi Shallow Copy yöntemidir.

            #endregion


            #region object
            //object aslında tüm türlerin atasıdır. int, string, char vb. aslında object'ten türemiş türledir. Bu yüzden object bunların hepsini kapsar ve tüm değerler/veriler object altında tutulabilir.
            //Tüm türleri karşılayabilen bir ''türdür''.
            //Tüm türler varsayılan[default] olarak object'ten türerler. (Referans Türlü olabilir, Değer Türlü olabilir.)
            //object tüm türlerin ademidir. Hiç bir tür yokken object vardı. Bu yüzden tüm türleri karşılayabilmektedir.
            //Referans türlü bir değişkendir.
            //Değer türlü değişkenleride karşılabilir.
            //object nesleride karşılayıp tutabiliyor. Çünkü nesneler değişkenler tarafından tanımlanır. Dolayısı ile değişkenlerin atası object'tir.

            //Object değişkenler ilgili verileri/değerleri RAM'de object türde tutarlar. Lakin verinin öz türünüde içerisinde bozmadan saklarlar. Yani object içerisindeki veri kendi öz türünde tutulur. 
            //Ama dışarıdan bakıldığında nesne olarak görülür.
            //Veriyi dışarıdan objeye çevirir ama verinin doğasını bozmadan bu işlemi yapar. Yani veri/değerin türü object içerisinde ilgili verinin türünden tutulur. int değerse object içerisinde int olarak tutulur gibi...
            //Bu durum object içerisindeki veriyi/değeri kendi türünde tekrar elde edebiliriz anlamına gelmektedir. ''Unboxing'' denir.
            //Bir veriyi/değeri object türdeki değişken içine koymaya ''Boxing'' denir.
            //Herhangi bir değer object türe assign edildiği anda bu işlem Boxing'dir.


            object objDeger = true;
            object objDeger1 = 1;
            object objDeger2 = "Yücel";
            object objDeger3 = '?';

            //int varsayim = objDeger1;  //hatta vermesinin nedeni object türdeki bir değişkeni int türde değişkene gönderdiğimde int olarak değil object olarak gittiği içindir.
            int varsayim = (int)objDeger1; //olarak tanımladığımda () CAST Operatörü anlamına gelip parantez içerisine gönderdiğim verinin türünü yazdığımda boxing edilmiş int değerim yeniden bana tanımladığım int değişkene int değer olarak gönderildi.

            //Boxing
            //object türdeki bir değişkene herhangi bir türdeki değeri göndermek Boxing olarak nitelendirilmektedir.
            //object varsa Boxing söz konusudur.

            int yYas = 27;    //yaşı RAM'de rakamsal türde yani matematiksel işleme açık bir şekilde tutar. RAM'de int değerinde tutulmaktadır.
            object _yas = 27; //yaş rakamını RAM'de object olarak tutar yani değeri kutulamış bir nesne olarak dönüştürür. Fakat boxing olarak gönderdiğimiz değer int olarak tutulmaya devam eder. BOXING DENİR. Artık _yas isimli değişken bize object türde gelecektir [int olarak gelmez]. matematiksel işlem yapaMAM izin vermez.

            //object bir değişkenin içerisindeki değer üzerinde türüne özgü işlemler yapabilmek için o object'in içerisinde değeri kendi/has/özgün türünde elde etmemiz gerekmektedir. Bu işleme Unboxing [kutudan çıkarma] işlemi diyeceğiz.
            //Unboxing işlemi yapabilmek için Cast Operatörüne ihtiyaç duyacağız.

            //Cast Operatörü
            //Tür dönüşümlerinde bilinçli tür dönüşümü konusunda Cast Operatörü kullanacağız.
            //Kalıtımsal durumlarda da karşımıza çıkacaktır.
            //Boxing edilmiş bir veriyi/değeri kendi türünde elde etmemizi sağlayan bir operatördür.
            // () işaretiyle ilgili değeri Boxing'den kendisine has türden çıkartmak için parantezin içerisinde türü yazacağız.
            //decimal olarak object etip Boxing yaptığımız değer Unboxing işleminde int olarak, double olarak ya da bool olarak gelmez. decimal olarak gelir.
            //Cast Operatörü, object olan değişkenin soluna o object'in hangi türe Unboxing etmek istiyorsak parantez içerisine hedef türü bildirerek kullanılır.

            object doubSayi = 2.50;

            double doubSayi2 = (double)doubSayi; //değişkenin soluna () içerisinde double yazıp Unboxing işlemi yaptım.





            #endregion


            #region c# var Keyword'ü
            //var Keyword'dür. Belirli bir işlemi yapar.
            //Tutulacak değerin türüne uygun bir değişken tanımlayabilmek için kullanılan keyword'dür.
            //var keyword'ü kendisine atanan değerin türüne bürünür.
            //var compile süresinde/Development aşamasında değerin türüne bürünür.
            // var keyword'ü compiler tarafından değerin türüne göre otomatik büründürülen bir keyword'dür.
            //Fakat bir tür değildir. Bu keyword'dür. Çünkü tür olsaydı kendine has bir değer alması gerekirdi. Bu yüzden var'ın alacağı kendine has bir değer türü yoktur.
            //Esas olma sebebi ise farklı diller arasında desteklenmeyen türlerdeki verileri karşılayabilmek için oluşturulmuş ortak bir keyword'dür.
            //Diller arasındaki entegrasyonda kullanıyor.
            //Burada türünü bilebildiğimiz verilerin değişken türlerini ''var'' ile compiler'a yaptırmak ufakta olsa bir maliyettir !
            //Bunun için biz bu maliyetten kaçınmak için bildiğimiz türleri mümkün olduğunca üşenmeden belirteceğiz.
            //1- var keyword'ü ile tanımlanan değişkenin değeri tanımlama aşamasında verilmelidir. Verilmelidir ki türü belirleyip direkt ona dönüşebilsin o türde davranış sergileyebilsin...
            //2- var keyword'ü ile tanımlanan değişkene ilk değer verildikten sonra o değerin türüne bürüneceği için sonraki durumlarda değeri farklı türlerde verilmez !! var'da int olarak değer atadığımız var değişkenine daha sonra '' ulan zaten var'dı bu buna ben string değer assign edeyim'' diyemezsin...
            //3.1- var - object arasındaki fark;
            //3.2- var stack'te değerin türüne göre bellekte direkt kendi öz türü ile alıp işlem yapabilirken[matematiksel vb.] compiler aşamasında çalışan bir keyword'dür.
            //3.3- object'te boxing yapılıp sonrasında unboxing işlemi yapmak zorunda kalırız. Direkt işlem yapamayız, direkt matematiksel işlem yapmaya olanak sağlamaz.

            var vkywrdAd = "Yücel";
            string vkAd = vkywrdAd;

            var vkyrdSayi = 45.6;



            #endregion


            #region c# dynamic Keyword'ü
            //dynamic olarak tanımlanan değişken compile/development aşamasında değerin türüne bürünmez.
            //Development aşamasında değişken hala dynamic olduğu gözlenir.
            //Ne zaman uygulama derlenip çalıştırıldığunda o zaman dynamic ilgili değerin türüne bürünmüş olacaktır. Runtime'de bürünür.
            //var derleme aşamasında değerin türüne bürünürken, 
            //dynamic ise runtime'da verilen değerin türüne bürünecektir.
            //dynamic amacı çalışır halde olan programımıza dışarıdan gelecek verilerin/değerlerin neye göre geldiğini anlayıp karar vermesine olanak sağlar. Güzel özellikmiş birader web'de işime yarar.
            //dynamic runtime'da esnek çalışabilmeye olanak sağlar. Kararlı yapısı yoktur. Bi ipnelik var.
            

            var dgr = 12; //dediğimizde var dgr değişkeni direkt değere göre int değerini almıştır.
            dynamic dgr2 = 12; // dediğimizde 
           // dgr2. //dediğimizde dgr2 halen dynamic olduğu için yani türü halen belli olmadından dolayı her hangi bir metotlarına erişemiyorum. Çünkü türünü runtime yapmadığımız için karar veremiyor halen türünü atamıyor.

            //dynamic'te kod yazarken kodumuza gönderdiğimiz string*int bir işlemde hata almayız çünkü dynamic türünün ne geleceğine runtime'da karar verdiği için editör hatayı bize göstermez. Taa ki runtime yaptığımızda uygulama patladığında gösterir.
            
             dynamic dynmc = "Yücel";
            Console.WriteLine(dynmc.GetType());
            dynmc = 33;
            Console.WriteLine(dynmc.GetType());

            //dynemic keyword'ü runtime'da türü belirleyecektir. Fakat kararlı davranmayacaktır.
            //üstteki yazan kodda ben ''normalde atanan değerin türünü daha sonra değiştirilemez, kararlı olmalı başka türe assign edilmemeli'' diye düşünürken esnekliği sebebi ile karakter yoksunluğundan runtime'da bunu değiştirebilir.

            //dynamic nerelerde tercih edilir ?
            //dışarıdan gelen datanın ne olduğunu bilemediğimiz tahmin edemediğimiz zaman bunu dynamic'te assign edip işlem yaptırabiliriz. Örn; web kullanıcılarından gelen datalar değerler...

            #endregion


            #region Kod Nasıl Çalışır ? Nasıl İşlenir ?
            //Kod 2 şekilde çalışır Senkron diğeri Asenkron yöntemdir.
            //Senkron çalışma mantığı bir işlem bitmeden diğer işlem başlamaz. Herhangi bir zamanda yapılan işi hesap edebilirim.
            //Asenkron çalışma mantığı aynı anda parelel şekilde işlemler ilerler. Daha zahmetlidir. Bir işlem çalışırken farklı işlemlerde ilerlemektedir. İleri düzey programlama ile kodumuzu asenkron hale getirebilmekteyiz.

            //Yazılımlar varsayılan olarak senkron çalışırlar.
            //Bir kodun işi bitmeden diğer kod çalışmaz.

            #endregion


            #region ; Operatörü

            //c# programlama dilinde kodun konseptinin bittiğini ifade eder.
            //Compiler ; ile kod konseplerini ayırıp konsept konsept yorumlamaktadır.
            //Bir kod konsepti sona erdiğinde kullanılmak zorundadır. Aksi taktirde hata verecektir.
            // ; bir konseptin sonunda istenildiği kadar kullanılabilir.

            int konspSayi = 59; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; //gibi

            #endregion


            #region c# Satır Satır Kod Mantığı Hatası!
            //Yanlış mantıktır.
            //Kod compiler tarafından konsept konsept değerlendirilir.
            //Yazdığım tüm kodu tek satırda inşaa edebiliryorum ama compiler ; ile biten konseptleri değerlendirir.
            //Satır olarak değil Konsept mantığı ile gözlemleyip anlamaya çalışmamız gerekiyor.

            #endregion


            #region Tür Dönüşümü Nedir? Neden Verilerin Türlerini Değiştirmek/Dönüştürmek İsteriz?
            //Yazılım yazılım sürecinde elimizdeki değerin türlerini değiştirebilmekteyiz.
            //Tür dönüşümleri elimizdeki verilerin mahiyetindeki türe uygun işlemlere tabii tutabilmek için uygulanabilir. 
            //Farklı servislerden gelen değerleri uygun türlere dönüştürmek isteyebiliriz.
            //Dikkat ! Tür dönüşümlerinde amaç türü dönüştürmektir. Yani ''elimizdeki'' veriye uygun bir türe geçiş yapmaktır.
            //Elimizdeki veri uygun olmayan bir türe dönüştürmeye çalışırsak bu mümkün değildir ! Hata verecektir.
            //Elimizdeki türe uygun dönüşüm yapılmalıdır. 
            //Amaç veriyi değiştirmek değildir. Amaç elimizdeki veriyi karşılayabilecek farklı bir türe dönüştürmektir.

            #endregion


            #region Metinsel Türlü Değerin Diğer Türelere Dönüştürülmesi
            //'Parse' metodu 

            //Sadece 'string' değerleri/dataları hedeflediğimiz türe dönüştürürken kullanılır.
            //Yanlış hedef türüne dönüştürmeye çalıştığımızda compiler bize editörde hatayı göstermeyecektir. Çünkü dönüşüm runtime'da olur, hata runtime'da patlayacaktır.

            string pX = "123";

            int pXX = int.Parse(pX);

            Console.WriteLine(pXX * 8); //1. Yol--String değişkenin değeri ile matematiksel işlem yapabildiğim için 'Parse' metodu yardımıyla int türe dönüştürüp işlemimi yaptırdım.

              Console.WriteLine(int.Parse(pX) * 2); //2. Yol--Çözümleme yolu aynı işlemi yapmaktadır. Fakat değişken tanımlamadan direkt dönüşüm yapıp sonuç aldım. ^^Daha kullanışlu sanki ??''


            string pY = "<";

            char.Parse(pY);

            Console.WriteLine(pY);


            //Convert Fonksiyonu
            //Bu fonksiyon tüm birbirine uygun değerli/datalı türleri dönüştürmemize yardımcı olur.

            string cnvrtX = "22,11";
            Convert.ToDouble(cnvrtX);

            Console.WriteLine(Convert.ToDouble(cnvrtX) + 10.10);


            //Herhangi bir veri string türüne çok rahatlıkla dönüştürülebilir. Çünkü String diğer türlerin tüm değerlerini içerisinde tutabiliyor ve onu string olarak kendisine benzetebiliyor.
            int cnvrtY = 56;
            string cnvrtYY = Convert.ToString(cnvrtY);



            //ToString
            //Diğer ifadelerin metinsel ifadelere dönüştürülmesine hızlı bir şekilde yapmamıza olanak sağlayan ToString Fonksiyonu vardır.
            //Yazılım sürecinde diğer türleri metinsel ifadelere dönüştürülmesi oransal olarak çok fazla olduğu için otomatik hızlı hale getirilmesinde işe yarar.
            //ToString fonksiyonu tüm ama tüm türlerde mevcuttur. Hepsinde vardır.

            float ts_X = 456;

            string ts_Y= ts_X.ToString();



            #endregion


            #region Sayısal İfadelerin Kendi Aralarında Tür Dönüşümü


            // n olduğunu bildiğimiz int bir değer kendinden büyük türlere dönüştürülürken buna bilinçsiz dönüşüm deriz ve burada kendinden büyük türler zaten n'i kapsadığı için dönüşüm ihtiyacı duymaz. Fakat n'in kendinden küçük sayısal türlere dönüştürülmesinde bilinçli tür dönüşümü işlemine tabii tutulmalıdır.
            //Bir saysal değer kendi türünden daha büyük değer aralığına sahip olan diğer türlere dönüştürülürken burada herhangi bir işlem yapmamıza gerek kalmayacağı için bu dönüştürme işlemine bilinçsiz tür dönüşümü denir.
            //Bir sayısal değer kendi türünden daha küçük değer aralığına sahip olaan diğer türlere dönüştürülürken hedef türün ilgili veriyi karşılayamama riskinden dolayı buradaki işlemi bilinçli yapmamız gerekecek. Hali ile buna bilinçli tür dönüşümü denir.
            //Buradaki biliç-bilinçsiz kavramı developer ile alakalıdır. Yani developer'in elindeki bir değeri kendisinden daha dar/küçük olan bir sayısal türe dönüştürürken burada aralıklardan daha büyük olma ve sığmama ihtimali var. Bilgisayar bu ihtimali göze alamıyor ve developer orada iradesi ile bilinçli bir şekilde dönüştürdüğü için bilinçli tür dönüşümü deniyor. Eğer elimdeki değeri kapsayan daha büyük türlere dönüştürmek istediğimde burada irademi bilincimi kullanmadan herhangi bir dönüşüm yapmama gerek olmadığı için ve kontrol compiler tarafında olduğu için bilinçsiz tür dönüşümü ifadesi kullanılıyor.
            //Bir sayısal türün alt türüne bir değeri dönüştürdüğümüzde eğer ki o veri alt türün değer aralığına girmiyorsa o zaman dönüşüm yine gerçekleştirebiliriz FAKAT VERİ KAYBI söz konusu olacaktır.

            int blncszX = 3000;
            long blncszY = blncszX;  //bu satırda tür dönüşümü yapılmıştır. Bilinçsiz Tür dönüşümüdür. çünkü int türündeki değer kendinden büyük long türünü kapsadığı için tür dönüşümü compiler tarafından yapılıyor.


            //Bilinçsiz Tür Dönüşümünde Cast Operatörü ile gerçekleştirilir.
            //Boxing işlemlerinde tanıştığımız Cast Operatörü Bilinçli Tür Dönüşümünde de sayısal türleri kendi aralarında dönüştürürken iradeli bir şekilde bu işlemi yapılmasını sağlayan bir operatördür. 
            //Cast operatörü yani bu () ilgili değişkenin başına yazdım ve byte dönüştürdü. xX değişkenin içerisindeki veriyi byte ile karşıladım vasrsa bir veri kaybı bunu bilinçli olarak ben CAST ile dönüştürdüm ve karar verdim. 
            int xX = 3000;
            byte yY = (byte)xX;    //Bu satırda değer kaybının olmasını bilinçli şekilde karar verip aldığım için bilinçli tür değişimi diyoruz. ^^değer kaybı matematiksel olarak mod'unu alıyor.^^
            Console.WriteLine(yY);

            int zZ = 87997;
            long qQ = (byte)zZ;  //bu satırda önce Cast Operatörü () ile zZ değişkenini byte çevirip bilinçli tür dönüşümü yapıp sonrasında qQ zaten byte türünü kapsadığı için bilinçsiz tür döünüşümü yapıyorum.
            Console.WriteLine(qQ);


            //Checked
            //Bilinçli tür dönüşümü esnasında bir veri kaybı söz konusu olursa eğer runtime'da bizi uyaracak olan bir kontrol mekanizmasıdır.
            //


           // checked
            {
                int chckA = 500;        //elimizdeki değer burada byte'i aştığı için check bu scope'lar arasındaki kodları kontrol ediyor ve runtime'da hata gönderiyor. Çünkü değer kaybı var. Eğer check scope'unu kullanmasaydım console'a veri kayıplı halini yazacaktı.
                byte chckB = (byte)chckA;
                Console.WriteLine(chckB);
            }

            //unchecked
            //Bilinçli tür dönüşümü esnasında veri kaybı söz konusu ise bunu görmezden gelir ve runtime'da hata döndürmez.
            //^^normal bir kod bloğu default olarak zaten unchecked'dir.^^
            unchecked
            {
                int uncA = 500;
                byte uncB = (byte)uncA;
                Console.WriteLine(uncB);
            }


            #endregion


            #region bool Türünün Sayısal Türe Dönüştürülmesi
            //Elimizdeki mantıksal bir değeri herhangi bir sayısal değere Convert edersek ilgili değerin mantıksal karşılığını elde edebiliriz.
         
                bool boolA = true;
                decimal boolB = Convert.ToDecimal(boolA);
                Console.WriteLine(boolB);


            #endregion


            #region Sayısal türlerin bool Türüne Dönüştürülmesi
            //Sıfırın dışında kalan tüm değerler ''true'' sıfır 0 değeri false olarak döner.
            //Tür dönüşümlerinde dönüştürülecek türün hedef türe uygun olması gerekiyordu.
            //Burada bir istisna var.
            //normalde
            // 1 -> true
            //0 -> false  eşit olması ve geri kalanının mümkün olmaması gerekmektedir. Halbuki burada 0'ın dışındaki tüm değerler true olarak kabul edilmesi bir istisnadir.            


            int blSayi = -123;
            bool blSayiB = Convert.ToBoolean(blSayi);
            Console.WriteLine(blSayiB);

            #endregion


            #region char Türünün Sayısal Türe Dönüştürülmesi (ASCII)

            //ASCII bilgisayardaki her bir karakterin sayısal bir karşılığı vardır. Bu sayısal değerlere ASCII kaynak kodu denmektedir.
            //Cast operatörünü : UnBoxing, bilinçli tür dönüşümünde ve burada char türünü sayısal türüne dönüştürürken...
            //Tüm tam sayılar üzerinde bu işlemi yapaabiliriz.
            //Elimizdeki herhangi bir karakterin ASCII kaynak kodunu elde etmek istiyorsak herhangi bir tam sayıya Cast etmemiz yeterli olacaktır.
            //ASCII kodlarının dışında kalan veriler/değerler Cast edildikten sonra konsol çıktısına soru işareti ? olarak gönderecektir.
            char asciiA = 'a';
            int asciiB = (asciiA);
            Console.WriteLine(asciiB);


            #endregion


            #region Sayısal Türlerin char Türüne Dönüştürülmesi

            //Elimizdeki herhangi bir karakterin ASCII kaynak kodunu elde etmek istiyorsak herhangi bir tam sayıya Cast etmemiz yeterli olacaktır.
            //ASCII kodlarının dışında kalan veriler/değerler Cast edildikten sonra konsol çıktısına soru işareti ? olarak gönderecektir.

            int asciiAA = 112;
            int asciiBB = 77;
            int asciiCC = 789;

            int asciiDD = 6;
            char asciiEE = (char)asciiDD;

            Console.WriteLine((char)asciiAA);
            Console.WriteLine((char)asciiBB);
            Console.WriteLine((char)asciiCC);
            Console.WriteLine(asciiEE);

            #endregion


            #region Programlamada Operatör Nedir ?

            //Operatörler temel anlamda bir işe sorumluluğu üstlenen temel yapıtaşlarıdır. 

            //Operatörler belirli bir sorumluluğu/işi/operasyonu üstlenen sembolik yahut metinsel yapılardır. Bizim yerimize o sorumluluğu icra ederler.

            //Operatörlerin işleyişini anlamak değerlendirmek için operatör okuryazarlığı gerekmektedir. Yaptığı işi anlama ve nasıl işlediği hakkında bizlere bilgiler verir.

            #endregion


            #region Programlamada Operatör Okur Yazarlığı


            //Operatörler genellikle iki değer arasında matematiksel mantıksal ya da farklı bir işlemsel görev/operasyon yapan yapılardır.
            //Operatörler genellikle yapılan işler neticesinde bir sonuç döndürürler. Dönülen sonucu alıp farklı bir yerlerde kullanıp işleyebilirim.
            //Operatörleri kullanırken geriye dönüş değerlerine dikkat edilmesi gerekmektedir. *****
            //Genellikle iki değer arasında bağlantı oluşturan yapılar. (Matematiksel,aritmatik, karşılaştırma ve mantıksal bağlantılar vb.)
            //Kesinlikle geri dönüş değeri vardır.


            #endregion


            #region Aritmatik Operatörler Nedir ? Geriye Dönüş Değeri Nedir ?
            // + , - , * , / , % (mod operatörüdür, bir sayıyı bir başka sayıya böldüğümüzde kalanı veren operatördür.)


            //Aritmatik Operatörler Geriye Dönüş Değeri 
            //Aritmatik Operatörler iki sayısal değer üzerinde işlem yapan operatörler oldukları için işlem neticesinde geriye ^^uygun türde^^ sonuç dönerler.

             
            int operA = 3 + 5;  //3 + 5 işlemindeki işlemi yapan + operatörünün üstüne geldiğimizde sağındaki ve solundaki int değerlerin çıktısında bize integer sonuç verdiğini söylüyor. İşte buradan yola çıkarak biz okryazarlık yapıyoruz.

            //inceleme 2 *****
            //Aynı türde olan sayısal değer üzerinde işlem yaparken sonuç ortak tür olacaktır. (short + short değerin çıktı türü yine short olacaktır.)
            long operX = 5, operY = 11;
            long operSonuc = operX % operY;

            //inceleme 3 ******
            //İki farklı türde sayısal değer üzerinde yapılan aritmatik işlem neticesinde sonuç büyük olan türde dönecektir. Yani long*double işleminin sonucunda double long'a göre büyük kapsamda olduğu için derleyici büyük olanın sonucunda çıktı verir.
            long lng1 = 4654;
            byte dble1 = 25;
           long snc1= lng1 - dble1;
            Console.WriteLine(snc1);

            //inceleme 4*********
            //(byte) * (byte) = ? (İstisna ! - Mülakat !!)
            //Normalde iki aynı türdeki sayısal değer üzerinde yapılan aritmatik işlem neticesinde sonuç aynı türde dönecekken bu iki değer byte ise sonuç her daim integer (int) dönecektir. Bu Böyle Kabul Edilmiştir. İSTİSNADIR !
            byte byt1 = 10;
            byte byt2 = 5;
            int bytintsonuc=  byt1 - byt2;



            #endregion


            #region Karşılaştırma Operatörleri
            // < (küçük) (Soldaki sayı sağdaki sayıdan küçük)
            // > (Büyük) (soldaki sayı sağdaki sayıdan büyük)
            // <= (küçük ve ya eşitlik)
            // => (büyük ve ya eşitlik)
            // == (eşitlik)



            //Karşılaştırma Operatörlerinin Geriye Dönüş Değerleri
            //Karşılaştırma operatörleri geriye her daim boolean bir türde değer döndürecektir.
            //Karşılaştırma operatörlerinde geriye dönen değer her zaman true ya da false'dır. Yani 1 ya da 0'dır.
            int krslstrma1 = 1535;
            int krslstrma2 = 5454;

          bool krslstrma3 =  krslstrma1 > krslstrma2;
            if (krslstrma3==true)
            {
                Console.WriteLine("krslstrma1 büyüktür");
            }
            else
            {
                Console.WriteLine("krslstrma2 büyüktür");
            }


            #endregion


            #region Mantıksal Operatörler Nelerdir ?

            //Tüm şartları değerlendirip kendine göre sonuç döndüren operatörlerdir.
            //ve       &&
            //veya     ||
            //ya da    ^


            //programlarımızda algoritma kurarken olmazsa olmaz kullanacağımız mantık operatörlerdir.

            //ve   &&  operatörü
            //Tüm şartların yerine getirilmiş olmasını ister.
            //Annemden patates ve && köfte getir dediğimde annem ikisinide getirirse razı olurum. Fakat sadece birisi gelseydi olmazdı. Hiç birisi gelmeseydi yine olmazdı. İkisininde gelmiş olması gerekiyor.
            // true  &&  true 
            Console.WriteLine(true && true);      //true döner
            Console.WriteLine(true && false);     //false döner 
            Console.WriteLine(false && false);    //false döner
            Console.WriteLine(false && true);     //false döner


            //veya  ||  operatörü
            //Şartlarda en az bir tanesinin yerine getirilmiş olması yeterlidir. Annemden köfte || patates istediğimde annem sadece köfte getirseydi olurdu. Patates gelseydi olurdu ama ikiside gelmeseydi olmazdı. En az bir tanesi olmalı.
            //true/false   ||   true/false
            Console.WriteLine(true || true);      //true döner
            Console.WriteLine(true || false);     //true döner 
            Console.WriteLine(false || false);    //false döner
            Console.WriteLine(false || true);     //true döner



            //ya da   ^  operatörü
            //Şartlardan kesinlikle bir tanesinin yerine getirilmesini ister. Çocuktan kalem ^ silgi alıp gelmesini istediğimde en fazla ve en az bir tanesini getirmesi gerekiyor. Fakat ikisinide getirmesi ve ya getirmemesi şartımı sağlamıyor.
            Console.WriteLine(true ^ true);      //false döner
            Console.WriteLine(true ^ false);     //true döner 
            Console.WriteLine(false ^ false);    //false döner
            Console.WriteLine(false ^ true);     //true döner



            //Mantıksal operatörler mantıksal değerler üzerinde kullanılır.
            //Kesinlikle boolean değer döndürmesi gerekiyor.

            bool kalem = true , silgi = false;

           bool ks1= kalem && silgi;
           bool ks2= kalem || silgi;
           bool ks3= kalem ^ silgi;

            Console.WriteLine(ks1);
            Console.WriteLine(ks2);
            Console.WriteLine(ks3);     //console çıktısında şartlarımızı sağlaması durumuna göre sonuçlar mantıksal operatörlerin değerlerini karşılamışsa ona göre değer döndürecektir/yazacaktır.


            Console.WriteLine(((true && true) || false && ((true ^ false) && false) || true));
                                                  


            #endregion


            int sefsf=56;
            Console.WriteLine(sefsf);

        }
    }
}
