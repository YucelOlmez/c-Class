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


            Console.WriteLine(((true && true) || false && ((true ^ false) && false) || true));   //işlem önceliğine göre sonuç console'da true dönecektir.
                                                  


            #endregion


            #region   Arttırma(++) Azaltma(--) Operatörleri

            // arttırma ve azaltma operatörleri elimizdeki sayıyı sadece 1 arttırır ya da 1 azaltır. 2 arttırıp 3 azaltma işlemi yapmaz.
            //bu operatörleri daha sonra öğreneceğim döngülerdeki kombinasyonları kontrol edip programlama işlemlerinde kullanacağımı öğreneceğim.
            //Tanımlanan değişkenin sağına ya da soluna yazılmaları durumunda davranış değişikliği gösterirler.
            //  ++n; farklı davranış sergiler. Öncelikle n'in değerini 1 arttırır önceki değeri ezer sonra stackten arttırılmış yeni değeri döndürür/çıktısını verir.
            //  n++; farklı davranış sergiler. Öncelikle n değerini stackten çıktısını verir. Daha sonra çıktısını verdiği değeri ezip 1 arttırır.
            //C.W(++n); Ekrana direkt arttırılmış değeri yazacaktır.
            //C.W(n++); Önce ekrana direkt stackteki değerini yazacak daha sonra arttıracaktır. örneğin ekranda 10 yazılıysa bellekteki değeri 11 olacaktır. yeniden C.W(n++); yazarsak 11 yazacak stack'teki değeri 12 olarak tutulup yazılmayı bekliyor olacaktır. 
            //İşlem neticesinde değişkenin değerini döner.

            int artI = 5;
            Console.WriteLine(artI++);  // Çıktı : 5  |  Bellek : 6      //compiler şu şekilde çalışmaktadır C.W'ye geldi parantez içine girdi önce stackte gördüğü 5 i çıktı olarak Console yazdırdı ve yoluna 5i 1 arttırıp bellekte 6 olarak tuttu.
            Console.WriteLine(++artI);  // Çıktı : 7  |  Bellek : 7      //Sonra buraya geldi bellekte 6 olarak tuttuğu değeri 1 arttırıp ezdi 6 değerini silip 7 olarak tuttu ve Console'a yazdırdı. Çalıyolar ama yapıyolarda yav sfekjsefkl


            int eksI = 10;
            int eksII=eksI--;     
            Console.WriteLine(eksI);         //9 
            Console.WriteLine(eksII--);      //10
            Console.WriteLine(eksII--);      //9
            Console.WriteLine(eksII);        //8  verir
            #endregion 


            #region Üzerine Ekleme/Yığma Operatörleri

            // +=   Sadece bu operatör metinsel ifadelerde kullanılmaktadır.
            // -=
            // *=
            // /=
            // %=

            int FF = 35;
            FF += 2; // FF = FF+2; açılımıdır. 
            FF -= 14;
            FF *= 4;
            FF /= 2;
            FF %= 33;
            Console.WriteLine(FF);


            //Matematiksel işlemleri daha hızlı ve pratik yapmamızı sağlar.
            //Kısacası buradaki operatörleri farklı kaynak kodların içinde gördüğümde neyi ifade ettiğini bilmem gerekir.

            #endregion
           

           #region Metinsel İfadelerde Kullanılan Operatörler

            //+ Operatörü
            //Metinsel ifadelerde + operatörü yan yana birleştirilme işleminde kullanılır.
            //Metinsel ifade ile sayısal bir ifadenin + operatörü ile kullanılması işleminde sonuç string olarak dönecektir. Yani aritmatik bir işlem değil metinsel bir işlem olarak türü tutulacaktır.            

            string ww = "Yücel";
            string ww2 = "Ölmez";
            Console.WriteLine(ww + ww2);



            //Tür dönüşümlerinde herhangi bir değeri string'e dönüştürebilmek için .ToString fonksiyonunu kullanıyorduk.
            //Diğer yandan ilgili türü string'e dönüştürebilmek için string bir ifade ile + operatörüne tabii tutulması yeterli olacaktır.

            int ee1 = 10;
            string ee2 = "Ağaç";
            Console.WriteLine(ee1 + ee2);    // ee1 + ee2; İşleminde aslında + operatörünün solundaki ee1 int boxing yapılıp bilinçsiz tür dönüşümü yaşamıştır ve bu işlemin sonunda tutulan tür string olarak stack'te tutulacaktır. 


             // += Operatörünün Metinsel ifadelerde Kullanımı 
            string cc1 = "Mavi";
            string cc2 = "Araba";
            // cc1 = cc1 + cc2;
            cc1 += cc2; // compiler şu şekilde çalışmaktadır. cc1 değerine cc2 değerini yanına ekleyip daha sonra cc1 değerine atayacaktır. C.W. metodunda cc1 değişkenini yazdırdığımızda sonuç MaviAraba olarak dönecektir. Kod cimriliği yaptık.
            Console.WriteLine(cc1);



            // == Operatörünün Metinsel İfadelerde Kullanımı
            //Metinsel ifadeleri birbirleri ile kıyaslayıp karşılaştırabiliriz. Eşitlik durumunu karşılaştırabiliyoruz.
            //İçerik olarak değer olarak biribiri ile aynısı mıdır ?
            //Sonuç boolean dönecektir.
            string rr1 = "Joe";
            string rr2 = "Ellie";

            bool rr3 = rr1 == rr2;
            bool rr4 = rr1 != rr2;
            Console.WriteLine(rr3);  //Burada compiler Joe ve Ellie metinsel ifadelerinin == operatörü yardımı ile karşılaştırdığında console çıktısıne false olarak yazdırmıştır. Çünkü eşitmidir sorgusu yapıyorum.
            Console.WriteLine(rr4);  // != eşit değilmi operatörünün console çıktısı burada true'dur. Çünkü sorgulamam sonucu Joe Ellie 'ye eşit değil mi sorumun cevabı evet eşit değildir.


            #endregion


            #region c# Operatörler - ! operatörü

            //Programlamada olumsuzluk anlamına gelir, Değildir olumsuzluk anlamında kullanılır.
            //Mantıksal yapılarda olumsuzluk ifade eder. true yada false durumlarında gibi...

            // !true   çıktısı  false
            // !false  çıktısı  true     olur.
            // != kullanıldığında eşit değillik durumuna ithafen kullanılır
            //Sorgu yaparken manevratik döndürme işlemlerimizin sonucunu öğrenmede kullanılır.

            // null References (c# 8.0 ile gelmiştir)  string ifadelerde null durumlarında belirli kontroller yapmamızı sağlar ! operatörü forgiven dediğimiz bir noktada kullanıyoruz. Tekrar değinilecek.

            Console.WriteLine(!true);

            int wer=5;
            int rew=10;
            Console.WriteLine(wer==rew); //çıktısı false döner çünkü == eşit midir sorgumuzun sonucu hayır eşif değil false'dır
            Console.WriteLine(wer!=rew); //çıktısı true döner çünkü != eşit değil midir sorgumun sonucu evet eşit değildir true'dır
            Console.WriteLine(!(wer==rew)); //Bu operatörün dışında sade ve sadece mantıksal değerlerin yanında kullanılabilir.


            #endregion 


           #region Ternary Operatörü

            //Kalıpsal operatördür kalıpsaldan kast edilen ? ...... : .....; yapısıdır. Yani koşulumuzun durumuna göre soru işaretinden sonraki alanı döndürecektir eğer koşul sağlanmıyorsa iki nokta üst üste olanın sağı döndürülecektir.
            //şarta bağlı değer döndüren operatördür
            //Kendi kalıbında farklı değerleri şartlara göre döndüren operatörüdür.
            //Bir değişkene metoda property'e değer atarken eğer ki bu değer şarta göre fark edecekse tek satırda ya da satır bazlı bu şart kontrolunü yaparak duruma göre değeri döndürmemizi sağlayan bir kalıpsal operatördür.
            //taslak olarak aşağıdaki gibidir
            int qwe = 2653;
            int ewq = 546654;
            int QWE = qwe > ewq ? qwe : ewq;
            //    şartımKoşulum ? .1..:..2.;      Eğerki şart true ise :'nın solundaki değer yani 1 dönecektir. Eğerki false ise :'nin sağındaki değer yani 2 dönecektir.
            Console.WriteLine(QWE);



            //Karşılaştırma ya da mantıksal işlem sonucunda geriye bir boolean değer döndüren yapı.
            //Dönecek değerler aynı türde olmalıdır. Ki ben ortak değerde karşılayıp o değişkende tutayım.
            //Polimorfizm kurallarına göre birbirlerinden türeyen değerlerde artık desteklenmektedir.(c# 9.0 ile geldi)



            //Birden Fazla Condition Uygulama
            int yas = 27;
            //Yaşı; 27'den küçük olanlara A, 27 olanlara B, büyük olanlara C değerini döndüren ternary operatörünü oluşturuyorum
            char sonuc = yas < 27 ? 'A' : (yas == 27 ? 'B':'C');
            Console.WriteLine(sonuc);

            // Örnek
            //Kullanıcı tarafından girilen sayının aşağıdaki önergelere göre hesabını gerçekleştiren kodu yazınız.
            // sayı < 3                           => sayı * 5
            // sayı > 3 && sayı < 9               => sayı * 3
            // sayı >=9 && sayı % 2 == 0          => sayı * 10 
            // sayı % 2 == 1                      => sayı
            // hiç biri değilse                   => -1
            Console.WriteLine("Lütfen bir sayı giriniz !");            
            int _sayi= int.Parse (Console.ReadLine());      // Console.ReadLine(); Kullanıcının girdiği değeri string olarak getiren/yakalayan bir komuttur.
            int sonnuc=_sayi < 3 ? _sayi * 5 : 
                (_sayi > 3 && _sayi < 9 ? _sayi * 3 : 
                (_sayi >= 9 && _sayi % 2 == 0 ? _sayi * 10 : 
                (_sayi % 2 == 1 ? _sayi : 
                (-1))));
            Console.WriteLine("Sonuç " + sonnuc);


            //Örnek 2
            //Hava durumunu tutan string değişkenin değerine göre aşağıdaki önergeleri uygulayan kodu yazınız.
            // "Yağmurlu"  => "Şemsiye Almalısın"
            // "Güneşli"   => "D Vitamini alacaksın"
            // "Kapalı"    => "Dikkatli ol yağmur yağabilir"
            string havaDurumu = "Kapalı";
            Console.WriteLine(havaDurumu == "Yağmurlu" ? "Şemsiye almalısın" : 
                (havaDurumu == "Güneşli" ? "D Vitamini alacaksın" : 
                "Dikkatli ol yağmur yağabilir"));
            //En sonuncu önergemizin şartını bildirmeyebiliriz. Zaten 2 ihtimalden birisi olmamışsa geriye kalan sadece 3. ihtimal olacağı için onun gerçekleşme koşulu kesinleşmiş oluyor. 3. durumun kontrol edilmesi gereksiz oluyor.

            #endregion


             #region Atama(assing) Operatörü
            // Atama operatöründe = sembolünü kullanırız bu sembolün sağ tarafına gelen value(değer) assign operatörünün solundaki değişkene atanır ve artık value alan değişken bellek adresinde saklanıyor olur.
            #endregion


            #region .(Member Access - Üye Erişimi) Operatörü
            //Elimizdeki değerlerin türleri alt elemanlara sahiptir.
            //Elimizdeki değerin türüne uygun member'lara erişmemize sağlayan operatördür.
            //Member Access elimizdeki bir değerin türüne uygun elemanlarını/Fonksiyonlarını/Metotlarını/Propertylerini/field erişmemizi/çalıştırmamızı/çağırmamızı sağlayan bir operatördür.
            //Member Access kodun devamını getirir.
            // . (nokta ile sembolize edilir)
            // int i=5; olarak tanımlanan bir değişkenin 
            // i.ToString ifadesiyle gördüğümde burada int i'nin altında çıkan özelliklerinden kullanıldığını anlayıp yorumlamam gerekiyor.

            #endregion


            #region Cast Operatörü
            //Genellikle tür dönüşümlerinde kullanılan bir operatördür.
            // (type)value Value'u type'a dönüştürür. parantez () cast işlemidir. içinde dönüştürmek istediğimiz type vardır.

            //Boxing - Unboxing
            object o1 = 123;     //boxing işlemi vardır.
            int o2 = (int)o1;    //Unboxing işlemi vardır.



            //Bilinçli Tür Dönüşümü
            int r1 = 45;
            short r2 = (short)r1;

            

            //Char -> int | int -> Char (ASCII)
            int asciii = 99;
            Char asciii2 = (Char)asciii;


            //İleride Polimorfizm durumunda 'base class' referansıyla işaretlenen bir nesneyi kendi türünde de elde edebilmemizi sağlamaktadır.

            #endregion


            #region sizeof Operatörü
            //Metinsel bir keyword'dür.
            //Verilen türün bellekte kaç byte'lık yer kapladığını integer olarak geriye döndürür.

            Console.WriteLine("int : " + sizeof(int));
            Console.WriteLine("char : " + sizeof(char));
            Console.WriteLine("bool : " + sizeof(bool));

            #endregion


            #region typeof Operatörü
            //Verdiğimiz türün type'ını getirir.
            //ileride düzey programlamada reflection'a girmemize sağlayan bir operatördür. OOP'ta görüp öğreneceğim.
            //Verilen türün ya da değerin type'ını yani türünü getirir.
            //İlgili tür ile bilgileri edinmek için kullanılan bir operatördür.

           Type typ= typeof(int); //int türüne ait tüm bilgiler burada t değişkenine atanmıştır.
            Console.WriteLine(typ.Name);
            Console.WriteLine(typ.IsValueType);
            Console.WriteLine(typ.IsPrimitive);
            Console.WriteLine(typ.IsClass);

            //Elimizdeki verilerin türü (type) ile ilgili bilgileri elde etmek için kullanlır.

            #endregion


            #region default Operatörü
            //Belirtilen türün default değerini döndüren operatördür.
            //Default değer ne demektir ? Default değerler, her tür için yazılım tarafında tanımlanmış bir varsayılan değer demektir.
            //sistem tarafından varsayılan değerler atanır.

            //sayısal = 0
            //bool = false
            //string = null
            //char = \0
            //referans = null

            //null değersiz demektir. çıktısı boşluktur.

            Console.WriteLine(default(bool));
            Console.WriteLine(default(byte));
            Console.WriteLine(default(short));
            Console.WriteLine(default(Program));   //Program bir referans türüdür. Referans'ın default değeri gelecektir.




            #endregion


            #region is Operatörü
            //Boxing'e tabii tutulmuş bir değerin öz türünü öğrenebilmek/check edebilmek/kontrol edebilmek için kullanılan bir operatördür.
            //is operatörü denetleme neticesinde durumu bool yani true ya da false olarak döndürecektir.
            //Elimizdeki objectin içerisindeki değerin bazen hangi türe ait olduğunu bilemeyebiliriz. Bilemediğimiz durumlarda is operatörü ile kontrol edeceyiz.


            object isX = true;  //Boxing yaptım.
            Console.WriteLine(isX is bool);
            Console.WriteLine(isX is string);
            Console.WriteLine(isX is Program);

            //İleride if yapılanmasında vs. çok tercih ettiğimiz bir operatör olacaktır.
            //OOP yapılanmasında polimorfizm is operatörü ile kalıtımsal durumlardaki nesnelerin türlerinide öğrenebileceğiz...



            #endregion


            #region is null Operatörü
            //Bir değişkenin değerinin null olup olmamasını kontrol eden ve sonuç olarak geriye bool türünde bir değer döndüren operatördür.
            string isnullX = null;
            Console.WriteLine(isnullX is null);

            //is null operatörünü sadece null olabilen türlerde kullanabilmekteyiz.

            //İki çeşit değişkenlerimiz vardır.
            //1-Değer Türlü Değişkenler: is null operatörünü sonuçları değerle dönen değişkemlerde kullanılmaz. defaultlarında dahi değerle dönen değişkenlerdir.
            //2-Referans Türlü Değişkenler: null olabilen değişkenlerdir. Çıktısı boştur. String referans türlü bir değişkendir. is null operatörü kullanılabilir.



            #endregion


            #region is not null Operatörü
            //Elimizdeki değerin null olup olmamasıyla ilgilenmekte ve geriye boolean sonuç döndürmektedir.
            string pp1 = null;
            Console.WriteLine(pp1 is not null);

            //sadece null alan türlerde kullanabilir.

            #endregion


            #region as Operetörü
            // as Operatörü Cast operatörüne alternatif olarak üretilmiş bir operatördür.
            // Dönüşümde kullanırız.
            // Cast operatörünün Unboxing işlemine alternatif olarak üretilmiştir.
            // Sadece Unboxing işlemine alternatif üretilmiştir.


            // Unboxing'te type öz Value'ya uygunsa value type'ına uygun şekilde başarılı unboxing çıktısı verecektir.
            // Fakat type value'su as edilecek type'a uygun değilse HATA VERMEYİP null çıktı verecektir ve bu null çıktısı bizim programımızı patlatmadan code yazmamıza devam etmeyi sağlayacaktır. Bu aşamada cast hata verip programı patlattığı için code yazamıyorduk. Cast işlemine kıyasla böyle bir avantajı vardır.
            // Programatik olarak yazılımın sonlanmadan akışta kontrol edilmesine müsaade edecek ve işleme devam edecektir.

            //as Operatörü tür uygun olmadığı taktirde geriye null döndüreceği için bu null'u karşılayabilen türlerde çalışmak isteyecektir. Haliyle as operatörü değer türlü değişkenlerde kullanılmadığı için aşağıdaki örnekte Type yerine int olarak kullanamayız. Çünkü eğer unboxing işlemi başarısız olursa yani uygun türe ' 'as' ' edilemediğinde program referans türlü null verebilen değişken türler ile karşılaması hedeflenmiştir.

            object h0 = "ölmez";
            Program h1 = h0 as Program;
            Console.WriteLine(h1);
            #endregion


            #region ?(Nullable) Operatörü

            //c# Prog. dilince Değer Türlü Değişkenler normal şartlarda null değer alamazlar yani (not nullable)dır.
            //Değer türlü değişkenin null değer alabilmesini istersem bunu nullable ? ile yapabilirim.

            int? bb0 = null;  // ? ile işaretledim.
            bool? bb1 = null; // gibi...

            Console.WriteLine(bb0 is null);  // is sorgusu ile console çıktısına boolean değer döndürdüğü için sonuç true olacaktır.


            //Bir değer türlü değişken nullable yapıldıysa eğer; 
            //is null
            //is not null
            //as 
            //gibi null ile çalışan operatörleri üzerinde kullanabiliriz.


            object bb2 = 123;
           int? bb3 = bb2 as int?;
            Console.WriteLine(bb3);

            //Bir değişkenin null olup olmamasının kontrolünü nullable ? operatörü ile yapabiliyoruz.

            #endregion


            #region ??(Null-Coalescing) Operatörü

            //Elimizdeki değişkenin değerinin null olama durumuna olmasına istinaden farklı bir değer göndermemizi sağlayan operatördür.

            string jk = null;
            Console.WriteLine(jk ?? "Null olduğu için bu coalescing yüzünden bunu yazdı");
            //if else yapısı kullanmadan beni sonuca daha efektif ve daha az kod yazarak götürdü.

            // Console.WriteLine(jk ?? 3);    ?? işaretinin sağı ile solundaki türlerin değeri birebir aynı olmalıdır. Bu şekilde bir kullanım yoktur ve çalıştırmaz.


            #endregion


            #region  ??= Operatörü (Null-Coalescing Assigment) (c#8.0)

            string mm0 = null;
            Console.WriteLine(mm0 ??= "Null-Coalescing Assigment sonucu mm0 isimli değişkene bu metin bellek adresinde atanmıştır ??= ile");  // işleyiş; eğer ki mm0'ın değeri null ise metini yazdır ve metinin değerini mm0'a ata.

            #endregion


        }
    }
}
