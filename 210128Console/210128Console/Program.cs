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

            string ts_Y = ts_X.ToString();



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
            long snc1 = lng1 - dble1;
            Console.WriteLine(snc1);

            //inceleme 4*********
            //(byte) * (byte) = ? (İstisna ! - Mülakat !!)
            //Normalde iki aynı türdeki sayısal değer üzerinde yapılan aritmatik işlem neticesinde sonuç aynı türde dönecekken bu iki değer byte ise sonuç her daim integer (int) dönecektir. Bu Böyle Kabul Edilmiştir. İSTİSNADIR !
            byte byt1 = 10;
            byte byt2 = 5;
            int bytintsonuc = byt1 - byt2;



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

            bool krslstrma3 = krslstrma1 > krslstrma2;
            if (krslstrma3 == true)
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

            bool kalem = true, silgi = false;

            bool ks1 = kalem && silgi;
            bool ks2 = kalem || silgi;
            bool ks3 = kalem ^ silgi;

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
            int eksII = eksI--;
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

            int wer = 5;
            int rew = 10;
            Console.WriteLine(wer == rew); //çıktısı false döner çünkü == eşit midir sorgumuzun sonucu hayır eşif değil false'dır
            Console.WriteLine(wer != rew); //çıktısı true döner çünkü != eşit değil midir sorgumun sonucu evet eşit değildir true'dır
            Console.WriteLine(!(wer == rew)); //Bu operatörün dışında sade ve sadece mantıksal değerlerin yanında kullanılabilir.


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
            char sonuc = yas < 27 ? 'A' : (yas == 27 ? 'B' : 'C');
            Console.WriteLine(sonuc);

            // Örnek
            //Kullanıcı tarafından girilen sayının aşağıdaki önergelere göre hesabını gerçekleştiren kodu yazınız.
            // sayı < 3                           => sayı * 5
            // sayı > 3 && sayı < 9               => sayı * 3
            // sayı >=9 && sayı % 2 == 0          => sayı * 10 
            // sayı % 2 == 1                      => sayı
            // hiç biri değilse                   => -1
            Console.WriteLine("Lütfen bir sayı giriniz !");
            int _sayi = int.Parse(Console.ReadLine());      // Console.ReadLine(); Kullanıcının girdiği değeri string olarak getiren/yakalayan bir komuttur.
            int sonnuc = _sayi < 3 ? _sayi * 5 :
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

            Type typ = typeof(int); //int türüne ait tüm bilgiler burada t değişkenine atanmıştır.
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





            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





            #region  Akış Kontrol Mekanizmaları Nelerdir ? Ne Amaçla Kullanılırlar ?

            // Kodun akışında belirli şarta göre gideceğin yönü/çalıştıracağın farklı kodları belirlemeni sağlayan yapılara Akış Kontrol Mekanizması denir.
            // Akış kontrol mekanizmaları kodun akış sürecinde belirli şartlara göre farklı yönlendirmeleri yapmamızı ve farklı algoritmaları/kodları/yapılanmaları çalıştırmamızı sağlayan mekanizmalardır.

            //temelde if-else ve switch olarak söyleyebiliriz.

            //Akış Kontrol Mekanizmaları neye yaramaktadır ??
            //Yazılım kodunun akış sürecinde şarta göre yönlendirmesini sağlamaktadır.
            //Algoritmalarda ciddi anlamda kullanılan yapılanmalardır. O yüzden yazılımcılar açısından olmazsa olmaz yapılanmalardır.
            //Akış Kontrol Mekanizmalarında if-else ya da switch yapılanmaları aynı işi farklı şekilde yapmamızı sağlayan birbirlerinden farklı yapılanmalardır.
            //İkisi arasında teknik olarak fark olsa da işleyiş ya da kullanım açısından amaç açısından bir fark yoktur.

            //İstediğimiz şartlara giden yolu değiştiren, durumların yönünü değiştiren yapılardır. 


            #endregion


            #region Switch Case

            //Switch Case kodun akışında belirli bir şarta göre yönlendirme yapmamızı(Farklı algoritma çalıştırmamızı/farklı operasyon gerçekleştirmemizi/tetiklememizi) sağlayan yapılanmadır.
            //Switch Case akışın yönlendirilmesi noktasında/dönüm noktasında eşitlik durumuna göre bir şart varsa kullanılabilir.
            //Switch Case yapılanması sadece bir değişkenin değerini sadece eşitlik durumlarını kontrol ederken kullanılabilir.
            //Sadece eşitlik durumu check edilecekse o zaman switch kullanılabilir.

            //Switch paratezinde kontrol edilen değer bir değişken yahut sabit/statik bir değer olabilirken case bloklarındaki değerler kesinlikle sabit/statik olmak zorundadır. caselerdeki değerler değişkenlerden alınamaz !!!

            //eşitlik durumu sağlandığı anda diğer kalan case varsa eğer kalanlara bakmadan switch scope'undan çıkıp gidecektir.(compiler)
            //switch yapılanmasında amaç eşitlik durumuna göre belirli bir kod bluğu tetiklemektir.
            //case'lerdeki statik/sabit değerlerin sıralaması önemli değiltir. default case'ini istersen ortaya yazabilirsin.
            //

            string scAdi = "yücel";
            switch (scAdi)//süreçte eşitlik durumu kontrol edilecek olan değer buraya yazılmalıdır.
            {
                case "Ali":
                    Console.WriteLine("adı Ali");
                    break;

                case "Ayşe":
                    Console.WriteLine("adi Ayşe");
                    break;

                default:
                    Console.WriteLine("hiç biri değil");   // case bloklarından hiç biri eşleştirmeye uymuyorsa eğer varsa default-break arasındaki kodlar tetiklenir.
                    break;
            }

            #endregion


            #region Switch-Case'de When Şartı
            //Switch yapılanmasında sadece elimizdeki değerin eşitlik değerini kontrol edebilmekteyiz. Bunun dışında bu kontrol esnasında farklı şartları da değerlendirmek istiyorsak eğer When keyword'unu kullanabiliriz.
            // case'den sonra when şartı ile switch'i zenginleştiren bu şart koşulu ile farklı sorgulamalarda yapabilmemize olanak sağlamaktadır.
            // şart varsa sonuç herzaman boolean döner yani mantıksal çıktı değeri vermesi gereyor.

            int satisUcrti = 500;
            switch (satisUcrti)
            {
                case 500 when (3 == 5):
                    break;


                case 500 when (3 == 3):
                    break;

            }


            #endregion


            #region Switch-Case'de goto Keyword'ü
            //Switch case yapılanmasında sadece eşitlik durumunu inceleyebildiğimiz için mantıksal bir işlem gerçekleştirememeteyiz. Dolayısı ile bazen farklı değerlere eşit olma durumunda aynı operasyonu kodu/akışı kullanacağımız senaryolarla karşılaşabilmekteyiz.
            //case'lerde farklı eşitliklerde aynı kodu çalıştıracaksak eğer kod tekrarına girmemek için goto keyword'ü ile ''şu case'deki kodu çalıştır'' diyebiliyoruz. Yani caseler arasında zıplama yapabiliyoruz.

            int sayyi = 15;
            switch (sayyi)
            {
                case 5:
                    Console.WriteLine(sayyi * 10);
                    break;


                case 6:
                    Console.WriteLine(sayyi / 5);
                    break;


                case 7:
                    goto case 5;    //bu satırda eğer eşitlik durumu 7 ile sağlandığında ve aslında case 5 deki sağlanan kod ile aynı işlemi yapacaksa  case 7 yönlendirmesini 5e gönderiyorum ve Console.WriteLine(sayyi * 10); kodunu çalıştırıyor.
                                    //Burada break; komutunu kaldırmamız önemli çünkü manevratik komutlarımızdan biridir. break olmadığı için goto ile ilgili kodun çalışacağı case'e yönlendirme yapıyoruz.


                case 10:
                    goto case 5;  //case 5'deki kodu çalıştır demiş oluyoruz. goto ile gönderdiğimde şarta bakmadan case içindeki kodu/algoritmayı çalıştırıyor.

                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    goto case 5;
                    //birden fazla aynı case'e yönlendirilen goto keyword'ünün kullanıldığı durumlarda yukarıdaki gibi daha pratik bir yaklaşım yapabilmekteyiz.

            }

            #endregion


            #region c# 8.0 Switch Expressions Nedir ?
            //Tek satırlık işlemler için maliyet düşürücü ve kullanışlı semantıklerdir.
            //tek satırlık değer atama işlemlerini Switch Expressions ile atayabiliyoruz.
            string exprssIsim = "";
            int exp = 10;
            switch (exp)
            {
                case 5:
                    exprssIsim = "mehmet";
                    break;


                case 7:
                    exprssIsim = "ayşe";
                    break;


                case 10:
                    exprssIsim = "Yücel";
                    break;

            }


            int exp1 = 10;                //Yeni yöntem Switch Expression tek satırlık değer atama işlemi daha az maliyetli
            string expIsim = exp1 switch   // expIsim değişkeninin switch'ine girdi, expIsim'in kıyaslanacağı eşitlik durumları ve değeri altta inceleniyor. Değişkenin 5 ise 7 ve 10 olma durumlarına göre "hacı", "ali" ve "veli"  değerleri expIsim değişkenine gönderiliyor.
            {
                5 => "hacı",       //    => ise anlamına gelmektedir.
                7 => "ali",
                10 => "veli"
            };

            //yapısal olarak tüm kurallar geçerli, denetlediğim değer tür ile karşılaştırma yapıp hangi değişkene atama yapacaksam o değere uygun bir değer gönderiyorum.



            #endregion


            #region Switch Expressions-When Şartı

            //Elimizde kontrol ettiğimiz değeri değişkene tanımlayarak atayabiliyoruz.
            //ilgili değişken üzerinden birden fazla farklı condisition'ıda verebiliyoruz.

            int y77 = 10;
            string nname = y77 switch
            {
                5 when 3 == 3 => "atilla",  //elimizdeki karşılaştırmaları ise => operatöründen önce yazıyorken aynı satırda when ile farklı şartları yazabiliyoruz. eğerki 3=3 true ise ve karşılaştırılan değer 5 ise "atilla" değeri veriliyor.  'when' ve diye okunarak kodlar yorumlanabilir. bu yol when'in direkt kullanımıdır.


                var y88 when y88 == 7 && y88 % 2 == 1 => "metehan", // burada kıyaslanacak değişken değerini yazmadan ve  =>ise operatöründen önce içeride 'var' ile bir değişken tanımlayıp when dedim artık y88 y77'nin o anki değerine takabül ediyor ve sonrasında mantıksal ooperatörler ve aritmatik işlemler kullanıp 'when' şartının 2. kullanım halini de bu şekilde yorumlayabiliyoruz.

                //y77 değişkenin türüne uygun y77 değişkenini karşılayabilen farklı değişkenler ile de tanımlayabiliriz. yani y88'i var ile değil decimal ile de tutabilirdik.


                10 => "cansu",



                var yyy9 => "hiç biri" //Default : hiç birinin olmadığı durumlarda default tanımlamasına karşılık gelecektir.
            };

            ///bir değişken kullanıyorsak kullandığımız değişkende direkt eşitlik durumunu kontrol edeceğimiz bir değer tanımlamaya gerek kalmamaktadır.

            #endregion


            #region Switch Expressions-Tuple Patterns


            // Tuple Patterns ise switch yapılanmasını Tuple nesnelerini kontrol edebilecek şekilde hem standart hemde yeni yapılanmayla bizlere sunmaktadır.

            int lo1 = 10;
            int lo2 = 20;
            string lo3 = "";
            switch (lo1, lo2)
            {
                case (5, 10):
                    lo3 = "5 ile 10 değerleri";
                    break;

                case (10, 20):
                    lo3 = "10 ile 20 değerleri";
                    break;
            }
            Console.WriteLine(lo3);
            //-------------------------------------------------------- alttaki Switch'Exp-Tuple yöntemi üstteki Switch'Exp-Tuple yöntemine göre daha az kod maliyetli ve daha kullanışlıdır.

            int lo4 = 30;
            int lo5 = 40;

            string lo6 = (lo4, lo5) switch
            {
                (32, 38) => "32 ve 38 değerleri",
                (30, 40) => "30 ve 40 değerleri"
            };
            Console.WriteLine(lo6);



            //Bu kodların asıl meselesi Switch Case yapılanması içerisinde TEK SATIRLIK İŞLEM yapıyorsak yapmış olduğumuz tek satırlık işlemde bir değişkene değer atıyorsak Switch Expression mantığını kullanabiliyoruz.



            #endregion


            #region Switch Exp-Tuple Patterns When şartı Uygulamak
            //burada switch içerisindeki tanımladığımız tuple ortak bir tür olarak karşılanmadığı için var keyword'ünü kullanıp değişkeni bu şekilde karşılıyoruz.

            //int mko = 10;
            //int mko2 = 20;
            //string mko3 = (mko, mko2) switch
            //{
            //    (11, 15) when (true) => "11 ile 15 değerleri",
            //    var mko4 when mko4.mko % 2 == 1 || mko4.mko2 == 10 => "10 ile 20 değerleri" //var mko4 değişkeni mko ve mko2 değerlerini yakalıyor ve biz onun üzerinden şart uygulayabiliyoruz.
            //};

            //Console.WriteLine(mko3);

            #endregion


            #region Switch Exp - Positional Patterns

            //Positional Patterns ise Deconstruct özelliği olan nesneleri kıyaslamak yahut değersel karşılaştırmak için kullanılan bir gelişimdir.


            #endregion


            #region Switch Exp - Positional Patterns when Şartı

            // Switch Exp-When şartındaki kurallar burada da geçerlidir.

            #endregion


            #region Switch Exp - Property Patterns

            // Property Patterns, nesnenin property'lerine (member'larına) girerek belirli durumları hızlı bir şekilde kontrol etmemizi gerçekteştiren ve bunu farklı değerler için birden fazla kez tekrarlı bir şekilde yapmamıza olanak sağlayan güzel bir gelişimdir.


            #endregion


            #region Switch Exp - Property Patterns when Şartı

            // Switch Exp-When şartındaki kurallar burada da geçerlidir.

            #endregion


            #region if Yapısı-Akış Kontrol

            //Switch ile aynı amaca hizmet ederler. Aralarında küçük bir fark vardır.
            //Switch elimizdeki bir değerin farklı değerlere olan '''''eşitliğini kontrol''''' eder.
            //if yapılanması ile tüm şartları karşılaştırma operatörlerin tümünü kullanabiliyoruz ve mantıksal operatörler sonucuna göre yönlendirmeler üstelik null, is not null operatörlerini dahi kullanabiliyoruz.

            // if Yapılanması elimizdeki bir değerin eşitlik durumuda DAHİL tüm bütün kıyaslamaları karşılaştırmaları yapmamızı sağlayan ve sonuca göre akışı yönlendirmemizi sağlayan bir yapılanmadır.
            // if () içerisinde şartımızı yazıyoruz. bu şart doğru yani true ise altındaki scope {} içindeki içindeki code'lar tetiklenecektir. eğer şartımız false ise compiler if scopunu okumadan yoluna devam edecektir.
            // if yapılanmasında şartı yazdığımı parantez içi () her daim boolean olmalıdır. yani şartımız boolean olmalıdır.
            //Karşılaştırma operatörlerin ve mantıksal operatörlerin hepsi burada kullanılabilir. Karşılaştırma operatörleri sonuç olarak true yada false yani boolean mantıksal operatörlerin hepsi true ya da false döndürür. buna göre belirli bir algoritmayı tetikleyeceğim.

            bool medenihal = true;

            if (medenihal == true)
            {
                Console.WriteLine("Mutluluklar");
            }

            bool medenihal2 = true;
            if (!medenihal2)
            {
                Console.WriteLine("tebrikler BU yazı if 'in şart koşulu için kullanılan karşılaştırma operatörsüz çıktı yazısıdır.");
            }
            Console.WriteLine("if (!medenihal2) şartı içinde kullandığım ! sonucu true olan medenihal2 ünlem ile false sonucu dönerek bu çıktıyı vermiştir");
            // if yapılanması tek başına kullanılıyorsa sadece şarta bağlı çalışacak koda odaklanır. Şartın dışındaki duruma odaklanmaz.



            // if yapılanmasında illa ki else kullanmak zorunda değiliz.
            int ifsayi = 10;
            if (ifsayi == 10)
            {
                Console.WriteLine("if'e merhaba");
            }
            Console.WriteLine("if'ten bağımsız merhaba");





            #endregion


            #region if-else Yapısı

            //if şarta göre scope içerinde çalışmamasını belirliyor. Ayrıyetten şartın sağlanmadığı durumlarda başka bir code'un çalışmasını istiyorsak else scopelarını açıp oraya code'u yazıyoruz.
            //Yani else scope'u if şartının sağlanmaması sonucunda çalışması gerekli olan alternatif kodları yazacağımız alandır.
            // if bloğunda else varsa şartın false olması durumunda kesinlikle else bloğu tektiklenir.
            // if-else yapılanmasında şart bloğu olduğunda sadece if, yanlış olduğunda ise sadece else blokları tetiklenir.

            int ifelsesayi = 10;

            if (ifelsesayi > 5)
            {
                Console.WriteLine(" ifelsesayi değişkeni 5den büyüktür diye yazdırdı.");
            }
            else
            {
                Console.WriteLine("ifelsesayi değişkeni 5'den küçüktür diye yazdırdı.");
            }


            int RR1 = 10;
            if (RR1 != 10)
            {
                Console.WriteLine("sayı 10'a eşit değildir.");
            }
            else
            {
                Console.WriteLine("sayı 10'a eşittir.");
            }
            //üstte != ile sayının 10a eşit değilse if bloğuna girmesini eğer sayı 10'a eşitse else bloğuna girmesi gerçekleşir. Manevratik işlem burada yapılmıştır.


            //if-else bloklarında code tekrarlarını yaparsan bu gereksiz ve saçma olacaktır. buna alternatif olarak blokların sonrasında yazıp analitik bir çözüm bulabiliriz.
            // her iki durumda da ortak çalıştırılacak olan komutları if-else bloğunun dışına yazmamız daha analitik çözüm olacaktır.
            // kod tekrarının olduğunu gördüğün an orada problem vardır. gereksiz kullanım vardır. traş edilmesi gerekir.


            #endregion


            #region if-else-if Yapısı

            // birden fazla şartın kontrol edilmesini sağlayan yapılanmadır.
            //eğer ki if-else demeden if-else-if diyorsak mevcut şartın dışında başka bir şartı da kontrol etmek istiyoruz anlamındadır.
            // birden fazla şartı kontrol etmemizi sağlayan bir yapılanmadır.
            // eğer hava yağmurluysa şunu yap, değilse bunu yap mantığı if-else yapısıdır.
            // eğer hava yağmrluysa şunu yap, değilse güneşliyse bunu yap, yine değilse karlıysa botunu giy mantığı if-else-if yapısıdır.
            //bu yapı içerisinde sadece tek bir şartımız doğruysa ya da istediğimiz durumu karşılıyorsa ilgili şartın içindeki kodlar çalışacaktır.
            // if-else-if yapısında her if'in başında () vardır ve şartını yazmamız gerekmektedir.
            // kaçtane şartımız varsa ve bunları kontrol edip şartlar bağlamında kod yazdıracaksak if ()'lerine şartlarımızı yazmamız gerekmetedir.

            //if yapılanmalarından herhangi biri doğrulandıysa eğer diğer else-if yapıları denetlenmeyecektir.


            int RR2 = 30;
            if (RR2 > 5 && RR2 <= 10)
            {
                Console.WriteLine(RR2 * 5);
            }
            else if (RR2 > 10 && RR2 <= 20)
            {
                Console.WriteLine(RR2 * 10);
            }
            else if (RR2 > 20 && RR2 <= 30)
            {
                Console.WriteLine(RR2 * 20);
            }


            // Birden fazla şarta göre birden fazla işlem yapmak istiyorsak if-else-if bizim için mantıksal bir hataya sebep olabilir.




            #endregion


            #region Scope'suz if Yapısı

            // if yapılanması tek satırlık bir işlem gerçekleştiriliyorsa eğer bunu scope içerisinde yazmak mecburiyetinde değiliz.
            // Eğer ki birden fazla konsept/işlem/operasyon barındıracaksa bunları kesinlikle scope içerisine almamız gerekmektedir. Aksi taktirde scopesuz çalışılırsa ilk işlemi if bloğu alacak diğerlerini almayacaktır.

            #endregion


            #region if Yapısı ile ilgili Çözümler

            // İki ürün fiyatı girildiğinde toplam fiyat 200 TL'den fazla ise 2. üründen %25 indirim yaparak ödenecek tutarı gösteren uygulamayı yazınız.

            Console.Write("Lütfen birinci ürünün fiyatını giriniz : ");
            int urun1 = int.Parse(Console.ReadLine());
            Console.Write("Lütfen ikinci ürünün fiyatını giriniz : ");
            int urun2 = int.Parse(Console.ReadLine());

            int uruntoplam = urun1 + urun2;

            if (uruntoplam > 200)
            {
                Console.WriteLine(urun1 + (urun2 * 75 / 100));
            }
            else
            {
                Console.WriteLine(uruntoplam);
            }


            //Belirlenen kullanıcı adı ve şifre doğru girildiğinde "giriş Başarılı", yanlış girildiğinde "Girdiğiniz kullanıcı adı ve şifre hatalı" mesajı veren console uygulaması yapınız.

            Console.WriteLine("lütfen kullanıcı adınızı yazınız !");
            string kullaniciAdi = Console.ReadLine();
            Console.WriteLine("lütfen şifrenizi giriniz !");
            string sifree = Console.ReadLine();

            //  if (!(kullaniciAdi=="Yücel" && sifree=="12345"))
            //      Console.WriteLine("Kullanıcı adı ve ya şifre hatalı");                        
            //  else
            //      Console.WriteLine("Giriş başarılı");

            //---------------------------------------------------------------------------------------------------------

            //  Console.WriteLine(kullaniciAdi == "Yücel" && sifree == "12345" ? "Giriş Başarılı" : "Kullanıcı adı ve ya şifre hatalı"); // Ternary Operatörlü çözümüdür.

            string kullName = kullaniciAdi;
            string sifree2 = sifree;
            switch (kullName)
            {
                case "Yücel" when (sifree2 == "12345"):
                    Console.WriteLine("Giriş başarılı");
                    break;

                default:
                    Console.WriteLine("Kullanıcı adı ve ya şifre hatalı");
                    break;

            }


            //Kullanıcıdan alınan iki sayının ve yapılacak işlem türünün (toplama, çıkartma, çarpma, bölme) seçilmesiyle sonucu hesaplayan programı yazınız.
            Console.WriteLine("Lütfen birinci sayıyı giriniz");
            int userNumb1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen ikinci sayıyı giriniz");
            int userNumb2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz");
            char islmSNC = char.Parse(Console.ReadLine());

            //int SNC = islmSNC switch
            //{
            //    '+' => userNumb1 + userNumb2,
            //    '-' => userNumb1 - userNumb2,
            //    '*' => userNumb1 + userNumb2,
            //    '/' => userNumb1 - userNumb2
            //};

            Console.WriteLine(islmSNC == '+' ? userNumb1 + userNumb2 :
                (islmSNC == '-' ? userNumb1 - userNumb2 :
                (islmSNC == '*' ? userNumb1 * userNumb2 : userNumb1 / userNumb2)));



            //girilen sayının değeri 10 değilse ekrana ^^sayı yanlış^^ yazdırınız.

            int Numbdsy = int.Parse(Console.ReadLine());
            if (Numbdsy != 10)
                Console.WriteLine("Sayı yanlış");



            //Girilen sayının negatif ya da pozitif olduğunu gösteren uygulamayı yazınız.
            int NPsayi = int.Parse(Console.ReadLine());

            string NPsonuc = "";
            if (NPsayi > 0)
            {
                NPsonuc = "Pozitiftir";
            }
            else
            {
                NPsonuc = "Negatiftir";
            }
            Console.WriteLine(NPsonuc);
            // Buradaki compiler işleyişi mantığı şu şekildedir; 1) Bazen akış kontrol mekanizma scopeları içerisinde elde edilen değer ilgili scope'tan dışarı çıkartılıp kullanılmak istenilebilir. Dışarıda tanımlanan değişkene scopelar içerisinde değer atanıp daha sonra atanan değeri farklı yerlerde kullanıp işlemek isteyebiliriz. mesela if içerisinde elde ettiğimiz bir değeri(if scopeları içinde atanan bir değeri) if scopelarının dışarısında kullanmak gibi. Yani kısaca burada mantığı değerlendirmek önemlidir.

            #endregion


            #region c# 7.0 Pattern Matching - Type Pattern

            //Akış kontrol mekanizmalarında belirli kontrolleri yapabildiğimiz yapılanmaların daha da desenleştirilmiş halidir.
            // İlgili senaryoya bu tasarım eşleşiyor gibi düşünebiliriz.
            // Tasarım eşleştirmesi anlamına gelmektedir.
            // c# 7.0 ile gelmiştir. Mevcut sürümde varolanlar daha da güçlendirilmiştir.


            // Type Pattern object içerisindeki bir tipin belirlenmesinde kullanılan '''is''' operatörünün desenleştirilmiş halidir.
            // is ile belirlenen türün direkt dönüşümünü sağlar.

            object tyX = 123;
            if (tyX is int tyXX)        // Compiler şu şekilde konuşuyor: eğer object tyX değişkenin içindeki değer integer ben sana bunu tyXX değişkenine cast ederim hiç içeride castle uğraşma demektedir. tyXX değişkenini if scopeunun içinde istediğimiz gibi kullanabiliriz. fakat buradan sonraki scopelar dışında da ilgili değişkene ulaşabilirken kullanmak istediğimizde compiler hata verecektir. çünkü burada tanımlanan değişken null olarak dönebilme ihtimalini okumaktadır. bir değişkenin null dönüp dönmeme ihtimali varsa compiler bu ihtimali göz ardı etmez direkt olarak hata döndürüp başka bir yol bul ey yazılımcı demektedir. bu sebeple ulaşılabilir ama kullanılamaz. sadece if scope içinde kullanılıp değer ataanabilir.

                Console.WriteLine(tyXX);

            else if (tyX is decimal tyXXX)  //buradaki kritik eğer if içerisindeki type pattern ile tanımladığımız değişkenin isminin aynısını burada kullanamayız. Farklı bir değişken ismi tanımlamam gerekmektedir.
                Console.WriteLine(tyXXX);



            #endregion


            #region Constant Pattern (c# 7.0 Pattern Matching)

            //Elimizdeki bir veriyi sabir bir değer ile karşılaştırabilmemizi sağlar.
            // == ile aynı görevde çalışır. Değerleri bir biri ile karşılaştırır.
            //Karşılaştırma işleminin boolean türde true ya da false olarak çalıştırır. compiler mantığı burada boolean ile çalışıyor.
            int CPxx = 150;
            Console.WriteLine(CPxx is 150);


            object CPx = 123;
            if (CPx is 123) //burada değeri karşılaştırıyor Buna Constant Pattern diyebiliriz.
            {

            }
            if (CPx is int) //burada türünü karşılaştırıyor [is operatörünün kendi işleyişi kullanılıyor]
            {

            }

            // is operatörü bir değişkenin türünü sormamızı/belirlememizi sağlayan bir operatördür ve bu operatörün kullanıldığı değişkenlerin türü illa bir referans türlü olma zorunda değildir.
            // istersek değer türlü değişkenlerde de is operatörü kullanılabilmektedir ve hatta primitive türlerde bile kullanılabilmektedir.
            // Eğer ki is operatörü ile bir değişkenin değerini == operatörünün sorumluluğu ile check ediyorsak buna constant pattern denmektedir.

            // Burada önemki olan bölüm şudur: is operatöründe TÜR kontrolü yapıyorsam bu Constant Pattern olmaz. Constant Pattern olması için is operatöründe DEĞER kontrolü yapmam lazım. değişkende değer kontrolü yapıyorsam Constant Pattern'dir. Değişkende tür kontrolü yapıyorsam bu is operatörünün kendi işleyişindeki normal olağan kontrol check işlemidir.
            //Türe uygun değerleri check etmemiz gerekir. aksi takdirde uygun olmayan değeri kontrol ettiğimizde kod hata verecektir.

            #endregion


            #region var Pattern (c# 7.0 Pattern Matching)

            // Eldeki veriyi var keyword değişkeni ile elde etmemizi sağlamaktadır.
            // var verilen değerin türüne bürünen bir keyword'dür. Runtime'da bürünme işlemini gerçekleştirir. yani runtime'da ilgili değişkenin türüne büründüğü anda boxing edilmiş değişkeni unboxing edecektir.
            // type Pattern'nin daha hızlı hali diyebiliriz.

            object x77 = "sefsfesfs";  //boxing yapılmış değişken
            if (x77 is var x88)        // burada var keyword'ü ile runtimeda ilgili değişkenin türüne bürünerek unboxing işlemi yapılıyor.
            {

            }

            // var Pattern ile normal var arasındaki fark şudur; normal var derleyici sürecinde türü belirler iken var Pattern farkı runtime'da belirlenir. Bu önemlidir. iki var arasındaki davranış değişikliği budur.

            //değişken ile ilgili atanan değerin türüne runtime'da bürüneceksek bu dynamic'tir.

            #endregion


            #region Recursive Pattern

            //Bu desen switch-case yapılanması üzerinde bir çok yenilik getirmektedir.
            //Switch bloğunda referans türlü değişkenler de kontrol edilebilmektedir.
            // c# 7.0'dan önce switch operatörünün () içinde saddece değer türlü değişkenleri kullanabiliyorduk fakat şu an bu () içinde artık referans türlü değişkenleride kontrol edebiliyoruz.
            //Recursive Pattern, tür kontrolü yaptığı için Type Pattern'i kapsamaktadır.
            //Switch-Case yapılanmasında referans türlü değişkenlerin türlerini check edebiliyorum ve değişkenlerde bu türleri karşılayabiliyorum. ÖNEMLİ !
            // Recursive Pattern case null komutu ile ilgili türün/referansın null olup olmamasını kontrol edebilmesinden dolayı Constant Pattern'i kapsamaktadır.


            #endregion


            #region Var Pattern - Type Pattern Kritik

            object ppp = "sefsefsefes";
            if (ppp is string ppp1)
            {

            }
            if (x is var ppp2)
            {

            }

            // Type - var patternleri illaki akış kontrol mekanizmalarında kullanmamız gerekmemektedir.

            bool result = ppp is string ppp3;  //ppp is string sonucunu result'a aldım hemde string'den sonra ppp3 isiminde bir değişken tanımlamış oldum. Bu Type Pattern'dir
                                               // Console.WriteLine(ppp3);
                                               // ppp eğer string ise sonuc true olarak result'a gelecek ama false olma ihtimali olduğu için ppp3 dışarda kullanmak istediğimizde buradaki sonucun false olma ihtimali yüzünden kullanmamıza direkt hata veriyor.
                                               //Type Pattern'de ppp değişkenin değerinin string olmama ihtimalinde ppp3'in null olma ihtimali söz konusu olduğu için ppp3 kullanılırken hata vermektedir.

            bool result2 = ppp is var ppp4; //Var Pattern'dir.
            Console.WriteLine(ppp4);
            //Var Pattern'de ppp değişkenin değerinin ne olursa olsun var ile ppp4'e atanacağından dolayı ppp4'ün null olma ihtimali yoktur. Dolayısı ile ppp4'ü rahatça kullanabilmekteyiz.

            #endregion



            #region Simple Type Pattern (c# 9.0)

            //Type Pattern'nın geliştirilmiş halidir.
            // Bir değişken içerisindeki değerin belirli bir türde olup olmadığını hızlı bir şekilde kontrol etmemizi sağlayan bir desendir. Type Pattern ile aynı açıklamayı kullanabiliriz.
            // c# 7.0'da Type Pattern'de tür kıyaslaması yaparken değişken tanımlayıp kıyaslama yaparken ve bu değişkenin tanımlanması zorunluyken 9.0 ile gelen Simple Type Pattern'de sadece tür odaklı kıyaslama yapmamıza yani kullanmayacağımız yeni değişkeni tanımlamamıza gerek kalmayıp sadece tür kıyaslamamıza odaklanılmıştır. Yeni değişken tanımlayıp check etmemiz gerekmiyor.


            #endregion


            #region Relational Patterns (c# 9.0)

            // İlişkisel Kıyaslama yapabildiğimiz bir patterndir
            // Desenlerde < < <= ve >= operatörleri kullanılabilmekte ve belirli karşılaştırmalar hızlıca gerçekleştirilebilmektedir.
            // Switch özü itibari ile sadece eşitlik durumunu inceleyen bir akış kontrol şemasıYDI. Relational Pattern ile diğer türlü karşılaştrmalarıda yapabilmekteyiz.

            int RLnumber = 123;
            string resultt = RLnumber switch
            {
                < 50 => "50'den küçük",
                > 50 => "50'den büyük",
                _ => "Hiçbiri"  // buradaki _ default anlamına geliyor.                
            };

            // Kritik; 7.0'dan 9.0'a kadar switch sadece eşitlik durumunu yaparken artık switch diğer karşılaştırmaları yapabilmektedir.


            #endregion


            #region Logical Pattern (c# 9.0)

            // Programlamaya mantıksal bir desen getirir.
            // and, or ve not gibi mantıksal operatörler kullanılabilmektedir.
            // Relational Pattern ile oldukça uyumludur.

            int logNumb = 60;
            string resultT = logNumb switch
            {
                > 10 and < 50 => "10'dan büyük 50'den küçük",
                > 50 or < 60 => "50den büyük 100'den küçük",
                //not 51 => "51 değil"
            };


            #endregion


            #region Not Pattern (c# 9.0)

            // not operatörünün kullanılabildiği bir desendir.

            #endregion


            #region Hata Kontrol Mekanizmaları Nedir ? Ne Amaçla Kullanılır ?

            // 3 çeşit hata vardır:
            // 1-Derleyici Hataları (Söz dizimi hataları)
            // 2-Runtime Hataları
            // 3-Mantıksal Hatalar

            // Bu hatalara yaklaşım davranışları farklıdır.

            #endregion


            #region Hata Türleri - Derleme/Syntax/Sözdizimi Hatası

            // Programlama dili kurallarına aykırı olan tüm hatalara sözdizimi hataları diyoruz.
            // Derleme/Syntax/Sözdizimi hatalarının üçüde birbirlerinin aynısınıdır. Hepsi aynı kapıya çıkan hatalardır.
            // Bu hataların birbirleriyle aynı kapıya çıkmasının sebebi ile fark edilmesi ve çözümü en kolay hata türüdür.


            #endregion


            #region Runtime Hatası

            // Editörü aldatıp programı ayağa kaldırma sürecini başlattıktan soonra programın işletim sistemi tarafından okunmayacağını bir mesaj ve ya ileti ile developer'a konuşan hatalardır.

            //Çalışma zamani hataları programın işleyişi ortasında direkt kullanıcıyla temas edebilecek hatalardır.

            //Yazılımcılar son kullanıcının run time hataları ile karşılaşmasını istemez.
            //Olası hataları yazılımcı öngörüp bir şekilde tespit edip alabileceği hataları kullanıcıya çaktırmadan manipüle etmesi gerekiyor.
            //Örneğin olmayan bir dosyayı mimaride açmaya çalışması bir ön tanımlı mesaj varsa bu ilgili mesaj ile kullanıcıya gönderilir ve manipüle edilir. Eğer hata öngörülüp traşlanmadıysa bu ilgili hata son kullanıcıya işletim sistemi dilinde bir hata fırlatacaktır. Bu hatalar anlamsız ve kompleks olabilir. Kullanıcıda nerede hata yaptığını bilemez ve bu sebeple yazılımcı log kullanma yöntemi ile ilgili mimariye hata kayıt defterini oluşturur. Daha sonra hatayı okuyup yazılımı geliştirmek için kayıtlı hataları gidermek ister.
            // hataları görebildiğin kadar giderdikten sonra programını testerlara gönderilip kullanıcı gibi hata arama avına başlarlar.
            //Uygulama mümkün mertebe test edilerek çalışma zamanı hataları tespit edilmeli ve programcı tarafından tanımlanmalıdır.

            //Nasıl yapacağız ?
            //Yazılımdaki hata kontrol mekanizmalarını devreye sokarız.
            //Hata Kontrol Mekanizmaları Hatayı kullanıcıya hissettirmeden yakalayabilmek ve ilgili hatayı manipüle edebilmek için vardır.
            //Hata.K.M.ları run time hatalarını için söz konusudur.



            #endregion


            #region try-catch Mekanizması Teorik Anlatım

            Console.WriteLine("Lütfen birinci sayıyı giriniz.");
            int nummb1 = 0, nummb2 = 0;
            try
            {
                // olası çalışma zamanı hatalarını barındıran / verebilecek olan kodları buraya yazıuyoruz

                nummb1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Lütfen ikinci sayıyı giriniz.");
                nummb2 = int.Parse(Console.ReadLine());
            }
            catch
            {
                //try içerisinde bir hata söz konusu olduğunda catch bloğu tetiklenecektir.
                // hataya dair; log, kullanıcı bilgilendirme kontrollü kapanış vs..
                //Hatalara dair kullancıyı manipüle edeceğimiz kodları, kod mtinlerini buraya yazacağız
                Console.WriteLine("Lütfen doğru bir ifade giriniz !");
            }
            Console.WriteLine("Toplam: " + (nummb1 + nummb2));
            // ve üstteki kullanım en verimli kullanımdır ve ilgili mantığa göre kodlarımı yazarsam performans açısından daha verimli olacaktır.


            //try-catch yapısı olası hatanın ihtimal olduğu kodları durmadan kontrol eden MALİYETLİ bir yapıdır. Dolayısi ile try içerisinde kontrol edilen kodlar lüzumsuz yere tüm kodlar olmamalıdır. Sadece olası hata verecek olan kodları barındıran bir yaklaşım sergilemem kontrol maliyeti açısından daha verimli ve performanslı olacaktırç Performans açısından sadece önemli ve ciddi hata verecek kodları buraya yazmam daha doğru olacaktır. Önemli manipülasyonları burada tutmam gerekir.

            //eğer try içerisindeki scopelarda patlama yada hata dönmezse doğal olarak catch'de çalışmayacaktır.

            // run time'da alınan hataları karşılamamızı kontrol ve manipüle etmemizi sağlayan bir yapılanmadır.
            // try - catch yapılanması uygulama sürecinde yaşanan olası hatayı kullanıcıya hissettirmeksizin farklı bir durum yada olağan bir mesaj gibi göstermemizi sağlayan ve bunun yanında patlamaya/hataya dair bizlere bilgi sunan ve böylece bu bilgiler eşliğinde kayıtlar/log oluşturmamızı sağlayan bir programatik yapılanmadır.

            //Amaç
            // 1- Kullanıcıya alınan hatayı hissettirmemek
            // 2- Alınan hatanın nedenine dair kullanıcıyı bilgilendirmek
            // 3- İşletim sistemleri aykırı durum yaşandığında uygulamayı sonlandırmak isterler ve sonlandırırlar. try-catch yapılanması ile alınan hataya dair bir manipülasyon gerçekleştiriliyor ve uygulamanın kapanmadan devam edilmesi sağlanabiliyor.

            //try ve catch'in kendisine ait scope'ları vardır. try scope'u içine olası runtime hatalarını verebilecek kodlar yazılır. try içerisinde olası hata söz konusu ise kodun akışı try scope'unda kesilip catch bloğundan devam edecektir.


            //try-catch Hata Parametresi
            //çalışma zamanında alınan hataya dair bizlere bilgi veren taşıyan parametrelerdir.
            //Runtime'da hata alındığında bunu editör üzerinden görebilmekteyiz. Bizim aldığımız ya da karşılaştığımız hatanın türünü ifade etmektedir.
            //Alınan hatanın yapısına göre hata türü fırlatılacaktır.
            //Yapmak istediğimiz işlemlere işleyişe göre hata fırlatılır.

            try
            {
                int trySa = 0, trySa1 = 10;
                int trySo = trySa / trySa1;

            }
            catch (Exception xxxHatanin)  //Exception bana fırlatılan hata ile ilgili tüm bilgileri getirecek olan bir üst türdür. Üst Türden kasıt ileride OOP'ta kalıtımsal bir yapılanma ve baseclass olarak anlatılacaktır. Yani bütün hataları karşılayabilen bir türdür. Bu parametre üzerinden bizler alınan hataya dair bilgiler edinebilmekte ve log'lama vs. gibi operasyonları gerçekleştirebilmekteyiz. Bu parametre catch bloğuna tanımlanmak zorunda değildir eğer ki tanımlama yapılırsa hataya dair bilgileri member access ile erişimi ile yazdırabiliyoruz.
            {
                Console.WriteLine(" Mesaj : " + xxxHatanin.Message);
                throw;
            }
            //Exeption tüm hata türlerinin atasıdır. Exeption'ın atası object'tir ve referans türlü bir türdür. 
            //catch bloğu bir parametre tanımlanmazsa eğer tüm hataları karşılayabilen bir bloktur. Eğer ki parametre tanımlanır ve bu parametrenin türü exception'sa yine tüm hataları karşılayabilecektir. Fakat parametre exception değil özelleştirilmiş bir hataya indirgenmişse böyle bir durumda sadece ilgili türe ait hataları yakalayabilecek ve karşılayabilecektir. Aksi taktirde catch bloğu çalışmadan hata yine kullanıcıya yansıyacaktır.
            //try bloğu içerisinde birbirinden farklı hata türleri fırlatabileceğini öngördüğümüz zaman her hataya ait spesifik catch bloğu parametresi hata türleri oluşturabiliyoruz.
            // try bloklarının içerisinde editöre öncesinde tanımlanmış öngöremediğimiz hatalardan birisi çıkarsa ve bu hataları catch bloğu ile yakalayacak öngörüyü yazamadığımız zaman bu ihtimali es geçmemek için tüm catch'lerin altına genel bir exception catch bloğu açarız ve bu durumu ortadan kaldırırız. Yani üstteki catch'ler ile yakalayamadığımız hataları en kötü ihtimal en sona açtığımız exception ile yakalayıp yine manipüle edebiliyoruz.
            // catch bloğu sıralaması önemlidir ve exception her zaman en sona yazılmalıdır.




            //editöre tanımlanmış hatalar vardır yani hata durumlarının bir türe AİT olduğunu bilmemiz yeterlidir.



            // c# programlama dilinde ''''türeme'''' kavramı kalıtımdan gelir.


            #endregion


            #region finally Bloğu

            //finally bloğu, try catch yapılanmasında hata alınsada alınmasada her iki durumda da tetiklenmesi/çalıştırılması gereken kodları yazdığımız bloktur.
            //try, catch ve en son finally bloğunu tanımlamamız gerekiyordur aksi taktirde editör hata verecektir.

            #endregion

            #region try-catch_when
            // catch bloğunu filtreleyip bir koşul ile kontrol etmek istediğimizde parametrenin () hemen soluna when şart koşulu açıp aynı hata türlerini belirli koşullar olduğunda kontrol edebileceğimiz durumlarda işimize yaramaktadır.
            #endregion


            #region Mantıksal Hatalar-Hata Türleri
            //Programn mantığında akışında algoritmasında stratejisinde bir takım şeylerin yanlış hesaplanması düşünülmesi tasarlanması neticesinde alınan hatalardır.
            //Syntax, runtime ve derlenmesinde hata çıkmaz. Kod çalışır ve sonuç verir fakat sonuçlar hatalıdır beklenilen sonuçları vermez Bu gibi durumda Logic error MAntıksal Hata denir.
            //Logic Error Bug olarak nitelendirilir. Mantıksal hatalar bug'dır.
            //Tespiti çok zordur ve en tehlikeli hata türüdür.
            //En maliyetli hata olabilir.
            //Mantıksal hatalarda bazen tek çözüm debug'dır.
            //Tüm değişkenlerin akışın kontrol edilmesini sağlayan bir teknolojidir. kodu adım adım incelememizi sağlar.
            #endregion


            #region Döngüler

            //Belirli bir koşula bağlı ve bağlı olunan koşul doğrulandıkça belirlenen tekrarda aynı kodu çalıştıran kombinasyondur.
            //Programlama dilinin temel yapı taşıdır. Programlama dilince döngü yoksa ilgili dilde bir işlem yapmamız imkansızdır.

            //Hangi döngü nerede kullanılmalıdır? sorusu YANLIŞTIR !
            //Hangi döngü nereye/hangi senaryoya daha çok yakışır ? sorusu DOĞRUDUR !


            #endregion


            #region for Cycle 
            //Prosedurel programlamada döngü yapılarından biridir.
            //Genellikle ardışık işlemlerde kullanılan bir döngü yapılanmasıdır.


            //for döngüsünün içerinde genellikle 3 parametre girilir. (    1   ;    2   ;   3   )
            //1-Genellikle başlangıç değeri ismi verilen değişken burada tanımlanabilir.İllaki tanımlayıp kullanma zorunluluğu yoktur.
            //1-Başlangıç değer ya da ilk değer atama kısmıdır.
            //1-ardışık algoritmalarda for döngüsü başlana bilmesi için genellikle ilk değere ihtiyaç vardır. işte bu ihtiyacı 1. alanda tanımlayabiliroz. bu tanımlama zorunlu değildir.
            //1- eğer başlangıç değeri tanımlandıysa kesinlikle bir değer atanmalıdır. null olamaz
            //for döngüsünde 1. adıma compiler tek sefer girmektedir. !!!!
            //2-Şartı belirlediğimiz yerdir.
            //2-Herhangi bir şart/koşul ifadesi tanımlanabilir. Genellikle ilk değer olarak tanımlanan değişken durumu burada kontrol edilir. Yani şarta bağlanır. Şart true olduğu sürece döngü tetiklenecektir.
            //3-Genellikle başlangıç değerinin değerini arttırmak ya da azaltmak için burası kullanılır.
            //3- Herhangi bir dğeişken üzerinde işlem yapabiliriz. Genellikle başlangıç değeri üzerinde bir arttırma ya da azaltma işlemi yapılır. Lakin 1 değerinin dışında diğer arttırma ve azaltma işlemlerinde ihtiyaca binaen yapılmaktadır. Kullanılma zorunluluğu yoktur.
            //şart true oldukça for scopeları tetiklenip çalışacaktır.


            // bu üç alanı bize zorunlu olarak yapacaksın diye bir diretmesi yoktur.


            //Örn: 1 ile 60(dahil) arasındaki çift sayıları toplayarak sonucu ekranda gösteriniz.
            int toplamSnc = 0;
            for (int i = 1; i <= 60; i++)
            {
                if (i % 2 == 0)
                {
                    toplamSnc += i;
                }
            }
            Console.WriteLine("1 ile 60 arasındaki toplam sonuç: " + toplamSnc);

            //Klavyeden girilen sayının faktöriyelini bulan programı yapalım.
            int fakSayi = int.Parse(Console.ReadLine());
            int faksonc = 1;
            string fakSnnc = "";
            //for (int i = 1; i <= fakSayi; i++)
            //{
            //    faksonc *= i;
            //}
            //Console.WriteLine("Faktöriyel Sonuç: " + faksonc);

            //2. Çözüm
            for (int i = faksonc; i > 0; i--)
            {
                faksonc *= i;
                fakSnnc += i + (i == 1 ? "=" : "x");
            }
            Console.WriteLine("Faktöriyel 2. Çözüm sonucu: " + faksonc);


            int forI = 0;
            for (forI = 0; forI < 10;)
            {
                forI++;
            } //gibi bir kullanım senaryosu vardır.
            //metodun 1. bölümünde dışarıda tanımlanan forI değişkenini for döngüsünde başlangıç değeri olarak göstermek istiyorsak eğer yine bir başlangıç değeri zorunlu kılmaktadır. Yani içeride bu başlangıç değerini vermemiz gerekmektedir.
            //2. bölüm olarak tanımlanan kısımdaki koşulun başlangıç değeri olarak tanımlanan değişkene bağlı olma zorunluluğu yoktur. for'dan önce dışarıda tanımlanan herhangi bir string boolean bir değişkene bağlı bir koşulda yazılabilir.
            // parametre alanını tamamen boş bırakma gibi bir olanağımız vardır fakat bu sonsuz döngüye sokacaktır.
            //1. ve 3. alanları yazıp 2. alanı boş bırakırsakta sonsuz döngüye girecektir.

            for (int forII = 0, forIII = 2; forII < 10 && forIII < 5; forIII--, forII++)
            {
                Console.WriteLine(forII);
                Console.WriteLine(forIII);

            }




            #endregion


            #region while Cycle

            //while döngüsü sadece şarta bağlı döngüdür. parametredeki şart doğrulandıkça tetiklenecektir.
            //orta seviye programlama dillerinde ilk tasarlanmış döngüdür.
            //bütün dillerde while döngüsü vardır.
            //Genellikle sonsuz döngülerde ya da süreci bilinmeyen durumlarda kullanılan bir döngüdür. Fakat istedğin yerde kullanabilirsin.



            #endregion


            #region while - for kıyası

            //while döngüsünde for gibi çalışabilmek için kobinasyonu kendimiz oluşturmamız gerekiyor.
            //while parametresi taa ki false olana kadar döngü tektiklenecektir.
            //while döngüsünde çalışırken arttırma ve azaltma işlemlerinin nerede yapıldığına dikkat etmeliyim aksi taktirde mantıksal hata oluşabilir. MAntıksal hata en maliyetli hata idi.
            //Yani algoritmada koşul varsa if gibi... kullanılacak değer önce arttırılıp veyahut azaltılıp kullanılmamalıdır. Çünkü mantıksızlık olur.

            //while sonsuza giden algoritmalarda kullanılması daha temiz olur
            //for ardışık giden algoritmalarda kullanılması daha temiz olur. 

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Yücel");
            }
            //----------------------------------------------
            int ii = 0;
            while (ii < 10)
            {
                Console.WriteLine("Ölmez");
                ii++;
            }

            //davranış olarak ikiside aynı çıktıyı verecektir fakat kalıpsal farklılık söz konusudur.


            //aşağıda anlık tarihin ve saniyenin değeri 5'in katıysa tarihi ekranda gösteren kodu yazıyorum

            while (true) // buradaki true sonsuze gittiğine işaret ediyor.
            {
                if (DateTime.Now.Second % 5 == 0)
                {
                    Console.WriteLine(DateTime.Now.Second);
                }
            }


            #endregion


            #region do-while Cycle
            //while'da şart true oldukça şart tetikleniyor.
            //while döngüsünde compiler önce şarta bakıp sonra scopelarını çalıştırır.
            //do while döngüsünde compiler önce kodu çalıştırır, sonra şarta bakıyor.
            //while ile yapılan kontrolde şart true olursa döngü tetiklenecek false olursa hiç bir zaman tetiklenmiyor.
            //do-while döngüsü şart true'da olsa false'da olsa en az 1 kez tetiklenecektir.
            //do-while metaforlayacak olursam şemsiyeyi önce yanıma alıp havanın durumuna daha sonra bakmam gibi betimlenebilir.


            #endregion


            #region Scope'less Cycle
            //döngülerden herhangi biri tek satırlık bir işlemse bunu scopesuz tanımlayabiliyorum.

            //eğer ilgili döngüye ait birden fazla komut işleyecek olursam scope kullanmam şarttır.

            #endregion


            #region Endless Cycle
            //aşağıda sonsuz döngülü for'a manevratik bir işlem ile kontrol yapabilmekteyiz.
            bool dongu = true;
            for (; true;)
            {
                dongu = !dongu;
            }

            //While sonsuz döngüsünü manevratik bir işlem ile kontrol edebilmekteyiz.
            bool dongu2 = false;
            while (!dongu2)
            {
                if (true)
                {
                    dongu2 = !dongu2;
                }
            }

            //do-while sonsuz döngüsünü manevratik bir işlem ile kontrol edebilmekteyiz.
            bool dongu3 = true;
            do
            {
                dongu3 = !dongu3;
            } while (true);

            #endregion


            #region Nested Loop

            for (int i = 0; i < 10; i++)
            {
                while (true)
                {
                    do
                    {

                    } while (true);
                }
            }
            //döngünün zaten bir performans maliyeti var. Bir iç içe döngüye aldığımız zaman maliyet daha da artmaktadır.
            #endregion


            #region with for-nested Loop
            //iç içe for döngülerinde değişken isimleri farklı olmalıdır.
            //iç içe döngülerde maliyet tüm döngülerin maliyetinin yani tur sayisinin bir başka deyişle periyodik çalışmasına eşittir.
            for (int k = 0; k < 10; k++)
            {
                for (int kk = 0; kk < 5; kk++)
                {
                    for (int kkk = 0; kkk < 3; kkk++)
                    {

                    }
                }
            }

            #endregion


            #region foreach bir döngü mü ?
            //Döngü: Belirli bir kombinasyon eşliğinde çalışan ve belirli bir şarta bağlı olan periyodik işlemler gerçekleştiren yapılanmalardır. Döngüde istediğimiz veriden başlama imkanımız vardır. Her döngü işlemi yapabilen kod parçalarını döngüler başlığına almıyoruz.
            //İterasyon: İterasyon mantığında ne kombinasyon ne de şart vardır. İterasyonda sonraki veri/oteki veri anlamına gelen itere etme fiili vardır. Bir veri kümesi üzerinde işlem yapmamızı/verileri elde etmemizi sağlayan yapılanmadır. İterasyonda küme içerisinde istediğimiz yerden başlama olanağımız yoktur. Başlangıçtan başlar ve son veriye kadar gider. foreach bir iterasyondur. bu yüzden arraylist dizisinde kümeler dizisinde kullanırız. Bu arada iterasyon döngü maksatlıda kullananlar vardır ama Döngü değildir.
            #endregion


            #region Keyword Nedir ? Operatörden Farkı Nedir ?
            //Keyword: Programlama dilinin en atomik küçük parçalarıdır diyebiliriz. Temel yapı taşlarıdır. Keyword'ler üzerinden programlama dilini şekillendiriyoruz.
            //Önceden tanımlanmış olan metinsel yapılanmalardır. Derleyici açısından ön tanımlı bir amaca hizmet edecek olan operasyonel bir yapılanmalardır.
            //Derleyici için ön tanımlı olan nerede hangi amaca hizmet edeceği belli olan ve kod içerisinde hangi noktalarda çağrılabileceği/kullanılabileceği kurallarla sınırlandırılmış olan anahtar sözcüklerdir.
            //Derleyici için ön tanımlı olan kullanım alanları sınırlandırılmış belirli yerlerde belirli alanlarda kullanılır.
            //Keyword'lerin operatörlerden Farkı
            //Operatörler esas olarak belirli bir opperasyonu / eylemi üstlenen yapılardır.
            //Keywordler daha geniş kavramlardırlar. Bazen bir keyword bir operatörü temsil edebilir. is, typeof operatör keywordleridir
            //Operatör direkt fiile eyleme bir işleme odaklı ise bu zaten kendini operatör olarak belli eder.
            //Fakat eyleme değil modellemeye odaklı vb. durumlarda kullanılan keyword'ler operatör değildir. Keyword'dür.
            //Keyword'ler operatörleri kapsar. Yani bir başka deyişle Operatörler Keyword'lerin kapsama alanı içeerisinde kalır.
            //Her keyword bir operatör değildir ama her operatör bir keyword olarak kullanılabilir. sembolik operatörlerde vardır == ya da + gibi...
            //Keyword'lerin davranışsal farklılıkları vardır. Yani nerede hangi anda ve alanda kullanmamıza bağlı olarak davranış farklılıkları gösterirler. var keyword'ünün compiler zamanında ve pattern match'de runtime'da farklılık göstermesi gibi...


            //Konseptli keywordler while gibi for gibi try-catch gibi belirli bir iskeleti ve parametreler alabilen keywordlerdir. Bunlar tek başına yazıldığında derleyici tarafından bir anlam ifade etmez. Anlam ifade etmeleri için iskeleterinin kalıplarının ya da kullanım standartlarıyla yazılmaları gerekmektedir.
            //Konseptsiz keywordler tek başına sadece kelime olarak bir anlam ifade eden iskeleti kalıpları olmayan operasyonel olmayan keywordlerdir. return;  break;  goto keywordleri gibi...


            #endregion


            #region Yardımcı Manevratik Komutlar
            //Kodu durdurmak, devamını okumamak, var olan bir döngüden çıkış yapmak ya da komple metodu sonlandırmak yani kodun yönlendirmek için kullanılan komutlardır.
            //Manevratik komutlar yapamayacağımız şeyleri yapmamızı sağlayan komutlar değildir. Yapabileceğimiz manevraları/kodun yönlendirmelerini daha efektif daha güzel yapmamızı sağlarlar.
            //4 tane manevra komutu vardır.
            //break, continue, return, goto
            #endregion


            #region break Command (Komutu)
            //Sadece 2 yerde kullanılır switch ve döngülerde. foreach iterasyonunda da kullanılır.
            //Kullanıldığı yapıdan çıkış yapılmasını kullanıldığı yapıyı sonlandırmaya yarayan bir keyword'Dür.
            //İç içe döngülerde en içteki metotta kullanılırsa sadece ilgili metottan çıkış yapacaktır.
            //switch'teki kullanımı üstteki belirtilen mantıkla aynıdır. yani switch'te case'in sonunda kullanılmazsa karşılaştırma yaptığımız değeri bulsa bile diğer caseleri okumaya devam edecektir. Bulduğu değeri ilgili case'in sonunda break ile sonlandırırsak. diğer karşılaştırmaları yapmadan kodumuz hızlı bir şekilde compile edilmeye devam edecektir.
            switch (10)
            {
                case 5:
                    break;
                case 10:
                    break;
                case 15:
                    break;
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 2)
                        break;
                    Console.WriteLine("i: " + i + " j: " + j);
                }
            }


            //Exercise 1
            int toplam = 0;
            while (true)
            {
                Console.WriteLine("sayı giriniz");
                string girilenDeger = Console.ReadLine();
                if (girilenDeger == "t")
                {
                    Console.WriteLine("Toplam Sonuç: " + toplam);
                    break;
                }
                else
                {
                    try
                    {
                        toplam += int.Parse(girilenDeger);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Lütfen doğru giriniz");

                    }

                }
            }

            //Exercise 2
            while (true)
            {
                Console.WriteLine("Lütfen sayı giriniz !");
                try
                {
                    int girilenDeger2 = Convert.ToInt32(Console.ReadLine());
                    if (girilenDeger2 % 37 == 0)
                    {
                        Console.WriteLine("Uygulama sonlanmıştır.");
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Lütfen uygun değer giriniz !!!");
                }
            }


            #endregion


            #region continue Command
            //Sadece döngülerde kullanılabilen keyword'dür.
            //Amacı ''Devam et'' anlamına gelmektedir. Döngüde bir sonraki tura geçilmesini sağlar. Bir sonraki periyoda geçiş yaptırır.
            //manevra yaptırmamızı sağlar.

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 != 0)
                    continue;
                Console.WriteLine(i);
            }

            //Exercise 1
            int carpim = 1;
            while (true)
            {
                Console.WriteLine("Lütfen bir sayı giriniz !");
                string girilenDger = Console.ReadLine();
                if (girilenDger == "t")
                {
                    Console.WriteLine(carpim);
                }
                int sayi9 = int.Parse(girilenDger);
                if (sayi9 < 0)
                    continue;
                carpim *= sayi9;
            }

            //Exercise
            for (int i = 1; i < 1000; i++)
            {
                if (i % 7 == 0)
                    continue;
                Console.WriteLine(i);
            }

            #endregion


            #region return Command
            //Her yerde metot içerisinde her yerde kullanılabilir erişilebilir keyword'dür
            // 2 işlevi görmektedir.
            //1- nerede çağrılıyorsa çağrılsın bulunduğu metottan çıkış yapar. Yani metodu sonlandırır. return'den sonra hangi komut gelirse gelsin metot sonlanacağı için işlenmeyecektir.
            //2- İleride göreceğim metotlar konusunda geriye değer döndürme sorumluluğunu da üstlenen bir keyword'dür.

            //Exercise

            while (true)
            {
                if (Console.ReadKey().KeyChar == 'c')
                {
                    Console.WriteLine("Application has ended !");
                    return;
                }
                Console.WriteLine("");
                Console.WriteLine("Application is running...");
            }

            #endregion


            #region goto Command
            //Kodun senkronizasyonunu bozup akışı ters istikamette almamızı sağlayan bir manevratik komuttur.
            //Switch case yapılanmasında dahili olarak kullanılan bu komut metot içeriisnde her yerde kullanılabilir.
            //Prototipinde yapısında 2 operasyonu barındırır. dönebilme ihtimali olan yere işaretleyen bir referans tanımlanabilir ''':''' koyduğumuz yerde goto keyword'ü buraya dönme ihtimali olabilir. yani tanımlanmış referansa kodun akışını yönlendiriyoruz. Compiler okuyucusunu referans ettiğim yere yönlendiriyorum.
            //Döngü değildir fakat döngü davranışını sergiler.
            //Gerekmediği sürece kullanılmamalıdır.

            //Exercise
            int mmm = 1;
        x:
            Console.WriteLine(mmm++);
            if (mmm <= 100)
                goto x;

            #endregion


            #region Additional Information
            //Bazen(ki ileride asenkron programlamada) içi boş sonsuz döngülere ihtiyacımız olabilir. Bu durumlarda normal döngü gövdelerini kullanabileceğimiz gibi scopesuz bu şekilde kullanabilmekteyiz.

            while (true) ;

            for (; ; );

            do;
            while (true);

            #endregion


            #region Diziler - Array
            //Tek bir değişken altında birden fazla aynı türde değeri toplamamızı sağlayan veri kümelerine dizi denir.
            //diziler içerisinde birden fazla aynı türde değer tutabilen yapılardır.
            //Prosedürel programlamanın temel veri kümeleridir. Yazılımsal boyutta yazılım adına ram'de birden fazla dğeri tek bir dğişken altında bir veri kümsei halinde tutabilirler.
            //Diziler veri kümeleri oldukları için içlerindeki birden fazla veri üzerinde kümesel işlemler yapmamızı sağlayabilirler. istatiksel çalışma, tek verilere erişip çalışma yapılabilir gbii..
            //Diziler prosedürel programlamanın temel yapıları oldukları için daha gelişmiş yapılar olan koleksiyonlarında temelini teşkil etmektedirler ve gelişmelerine katkıda bulunmaktadırlar.
            //diziler Referans türlü değerlerdir. Yani nesnel yapılardır. Özlerinde class'tırlar(OOP info). Nesnel yapılarda oldukları için bellek yönetimini yaparken nerede çalıştığımızı bilmemizdir.
            //Yapısal olarak RAM'de Heap'te tutulurlar. Kümesel veri nesnesi bellekteki yani RAM'deki adresi Heap'tir(içerisindeki veriler uygun şekilde stack'te tutulmaktadır).
            //dizi içerisinde her türlü değer eklenebilir. Hem referans hem değer türlü verileri.
            //Bir dizi sadece tek bir türde değer alabilir. Bir diziyi sadece int değerler ile oluşturacaksam onun içerisine char veri tipini ekleyemem. Fakat birden fazla ver tipli dizi yapacaksam bunu object olarak tutabilirim ama object'e gelmedim.
            //dizi içerisine eklenen değerler işlevsel olarak aynı mahiyette olmalıdır. örnk. maaş kümesi oluşturduğum bir diziye yaş değerlerini eklemem maantıksız olacaktır.
            //Dizi konusu yazılım dünyasına index kavramını kazandırmıştır.
            //Diziler içerisine eleman/değer eklendikçe bunları serseri bir şekilde depolamaz sıralı/düzenli bir şekilde depolayacaktır.
            //Dizilerde eklenen elemanlar/değerler index ismini verdiğimiz numaralar ile ardışık bir şekilde numaralandırılmaktadır.
            //index: her bir elemana verilen ardışık sayı. İlk eleman 0'dan başlar n-1'e kadar gider.
            //index numaralandırması compiler tarafından otomatik yapılmaktadır.
            //Bir değişken tnaımlanırken türünün yanına [] bu operatörü eklersek o değişken ilgili türde bir dizi değişkeni olacaktır. [] bu operatörün ismi INDEXER'dır.
            // string[] nameS = new string['''Buraya dizinin alacağı eleman sayısı bildirilir.'''];  buradaki '''new''' OOP'ta göreceğim. Bir dizi nesnesi oluşturmamızı sağlar. Şimdilik bir kalıptır. Mantıklı bir açılması var.
            //Diziyi tanımladıktan sonra eleman sayısını bildirmemiz zorunludur ve belirtilen eleman sayısı kadar RAM'in heap bölümünde alan tahsisi yapılır. Bu zorunluluk bir sınırlılıktır.
            //Bu sınırlılık kavramı tahsis edilen Heap'teki alanı kullansakta kullanmasakta bellek boyutunda bir maliyete sebep olacaktır. İşte bu sınırlılıktır. Bu sınırlılığı koleksiyonlar konusunda aşacağız.
            //Diziler sınırlı yapılardır. Sınırlılıklarını aşmak için ileride koleksiyonların üretilmesine sebep olmuşlardır. Koleksiyon yapıları dizilerin sınırlılıklarının aşılmış halidir.
            //Diziler alan tahsisi yapıldığında ilgili alanalara türüne uygun default değerleri atarlar.
            //dizilerdeki index kavramı dizilerin kullanılabilirliğini arttırmaktadır. ilgili verileri index numarası ile çağırıp işleyebilmemize olanak sağlar. okuma atama ekleme silme vb...
            //Dizilerde indexleri çağırıp ilgili index'e değer atama işlemi== ilgili indexteki değişkeni çağırıp değer atama işlemiyle ayndır.
            //indexler değişken davranışları gösterirler ki zaten değişkendirler. 

            //Dizi içerisinde dönecek olan döngü kombinasyonunda dizinin eleman sayısını manuel şekilde kullanmamalı, bu sayısal değeri dizinin kendisinden almalıyız.
            //Dizinin kaç elemanlı olduğunu int değer olarak geri döndürür. Bunu dizi değişkenin ismine .lenght diyerek döngünün koşuluna şartlaya biliyoruz.

            int[] yaslarr = new int[10];
            yaslarr[1] = 9;
            yaslarr[9] = 13;
            int whileSayi = 0;
            while (whileSayi < yaslarr.Length)
            {
                Console.WriteLine(yaslarr[whileSayi++]);

            }


            #endregion

            #region Dizilerde Sınırlılık ve Koleksiyon Yapılarının Doğuşu
            //Dizilerde eleman sayısı bildirimi--belirttiğim eleman sayısı kadar RAM'de alan tahsisinin yapılması sonucu maliyet oluşumu--dizilerde istediğimiz zaman eleman sayısının genişletilemeyip daraltılamaması-- SINIRLILIKTIR !
            //Bu sınırlılıklardan kurtulduktan sonra karşımıza arraylist dizi çeşiti gelecektir. Fakat arraylist'in de kendine göre sınırlılıkları vardır. Bu sınırlılıkları aşınca karşımıza daha esnek davranış sergileyen koleksiyonlarla karşılaşacağım.
            #endregion

            #region Dizi Tanımlama Varyasyonları
            //1------------------------
            int[] yaslar = new int[10];
            yaslar[0] = 15;
            yaslar[8] = 19;
            Console.WriteLine(yaslar[0] + " " + yaslar[8]);


            //2-----------------------
            int[] yaslar2 = { 30, 22, 21, 30 };
            Console.WriteLine(yaslar2[2]);

            //3-----------------------
            string[] isimler = new string[] { "ali", "mehmet", "ayşe", "fatma" };

            //4-----------------------
            string[] isimler2 = new string[3] {"atilla","raşit", "turgut"};
            //Burada eleman sayısını belirttiğim için süslü parantezler içerisini boş bırakamayacağımı compiler hata vererek bildiriyor. Fazla yada eksik sayıda eleman sayısı giremem.

            //5---------------------------------
            var sayılar2 = new[] { 1, 2, 3, 55, 666 };

            #endregion


            #region Array

            //Dizi olarak tanımlanan değişkenler Array sınıfından türetilmektedirler.
            //Dolayısıyla dizilerde Array sınfından gelen belirli metodlar ve özellikler mevcuttur.


            //Bir dizinin kendi türünde tanımlanması ile Array sınıfında tanımlanması arasındaki fark
            int[] yaslar5 = new int[5];  //Dizi eğerki kendi türünde referans ediliyorsa indexer operatörü kullanılabilir. Bu şekilde çalışırken ilgili diziye verisel müdehaleler operatif yani indexer operatörü ile gerçekleştirilirken, Genellikle bu format algoritmalarda tercih edilir. Çünkü indexer operatörü algoritmalarda çok kullanılır.
            Array yaslar4 = new int[5]; //Dizi eğer Array türünde referans ediliyorsa indexer operatörü kullanılmaz !! Bu şekilde çalışurken ilgili diziye verisel müdehaleler fonksyonel yani fonksiyonlar aracılığı ile gerçekleştirilir. Genellikle elimizdeki dizinin üzerinde işlem yapılırken tercih edilir. Dizi hakkında bilgilendirmeler vs.. kullanılır.


            //Değer Atama ve Okuma
            //1. Varyasyon
            int[] dizii = new int[3];
            dizii[0] = 99;
            dizii[1] = 98;
            dizii[2] = 97;
            Array dizii2 = dizii;

            //2. Varyasyon
            Array dizi3 = new int[3] { 33, 22, 11 };

            //3.Varyasyon
            Array dizi4 = new int[] { 44, 55, 88 };

            //4. Varyasyon
            Array dizi5 = new int[3];
            dizi5.SetValue(132, 0);
            dizi5.SetValue(14, 2);
            dizi5.SetValue(11, 1);

            object diziDeger= dizi5.GetValue(2); //Burada .GetValue komutu ilgili index'teki değeri object'e boxing ediyor ve bize boxing çıktı veriyor. Biz gerekli gördüğümüzde ilgili değeri kendi türünde unboxing işlemi yapabiliriz.
            Console.WriteLine(diziDeger);



            //Array Metotları
            //Clear
            //Dizi içerisindeki tüm elemanlara dizinin türüne uygun default değerleri atayan bir fonksiyondur. İndexlerdeki değerler kaybolmaz ama bu fonksiyon ilgili index'lere default değer atar. Index aralıklarını belirleyebiliyoruz.
            // .Lenght komutunu silme işleminde kullanırsak dizideki bulunan eleman sayısı kadar silme işlemi yapar
            Array listX = new string[] { "Kemal", "Ali", "Jale", "Ayşe", "Hale", "Mete", "Aydan", "Sinem", "Levent", "Halil", "Yağmur", "Mehmet", "Hasan" };
            for (int i = 0; i < listX.Length; i++)
            {
                Console.WriteLine(listX.GetValue(i));
            }
            Console.WriteLine("-------------------------------------------------");
            Array.Clear(listX, 0, listX.Length);
            for (int i = 0; i < listX.Length; i++)
            {
                Console.WriteLine(listX.GetValue(i));
            }



            //Copy Fonksiyonu
            //Elimizdeki bir dizinin verilerini bir başka diziye koplanmamızı sağlayan bir fonksiyondur.
            Array nameSource = new[] { "Kemal", "Ali", "Jale", "Ayşe", "Hale", "Mete", "Aydan", "Sinem", "Levent", "Halil", "Yağmur", "Mehmet", "Hasan" };
            string[] hedefDizi = new string[nameSource.Length];


            //Array.Copy(nameSource, hedefDizi, 4);
            //for (int i = 0; i < hedefDizi.Length; i++)
            //{
            //    Console.WriteLine(hedefDizi[i]);
            //}


            Array.Copy(nameSource, 3, hedefDizi, 5, 4);    //Bu kullanım şekli daha esnek ve kontrolcü bir yapıya sahiptir. Zaten Copy fonksiyonunun 4 farklı kullanım senaryosunu compiler bize gösteriyor.
            for (int i = 0; i < hedefDizi.Length; i++)
            {
                Console.WriteLine(hedefDizi[i]);
            }



            //IndexOf Operation
            //Dizi içerisinde bir elemanın var olup olmadığını sorgulayabildğiniz fonksiyondur.
            //Arama neticesinde ilgili değer varsa int olarak o değerin index numarasını döndürecektir.
            //Eğer yoksa -1 değerini döndürür.
            //Kullanım senaryosunun üçüncüsünde daha detaylı indexler arasında arama yapabilmekteyiz.
            int indexOff = Array.IndexOf(nameSource, "Sinem");
            if (indexOff != -1)
            {
                //Demekki aranan değer ilgili dizide bulunmaktadır.
                Console.WriteLine("Sinem değeri dizide olduğu için bu yazıyı yazdırdı.");
            }





            //Reverse Function
            //Elimizdeki dizinin elemanlarını tersine sıralayan bir fonksiyondur
            //4 Tane overload senaryosu vardır. Belirlediğimiz index'ten itibaren örneğin 3 tane değeri döndür diyeibliyoruz.
            Array.Reverse(nameSource);
            for (int i = 0; i < nameSource.Length; i++)
            {
                Console.WriteLine(nameSource.GetValue(i));
            }



            //Sort Function
            //Elimizdeki dizinin sıralanmasını sağlayan fonksiyondur. Küçükten-Büyüğe -- A'dan-Z'ye gibi...
            Array.Sort(nameSource);
            for (int i = 0; i < nameSource.Length; i++)
            {
                Console.WriteLine(nameSource.GetValue(i));
            }




            //IsReadOnly
            //Array Sınıfının Property'leri
            //Bir dizinin sadece okunabilir olup olmadığını boolean türde bildiren bir özelliktir.
            //Salt okunabilirlik durumunu kontrol eder.
            //Oluşturduğumuz dizinin sadece okunabilir olduğunu istediğimiz durumlar ve bu duruma bağlı olarak diziyi sınırlandırdığımız çalışmalar olabiliyor. Bu keyword ile dizilerin durumlarını inleyebiliyoruz.
            Console.WriteLine(nameSource.IsReadOnly);




            //IsFixedSize
            //Bir dizinin, bir veri kümesinin boyutunun eleman sayısının sabit olup olmama durumunu vermektedir. 
            Console.WriteLine(nameSource.IsFixedSize);
            //Tüm dizilerde eleman sayısı sabit olduğu için sürekli true dönecektir. 
            //Örneğin ArrayList koleksiyonunda false dönmektedir.




            //Lenght
            //Bir dizinin eleman sayısını verir.



            //Rank
            //Bir dizinin derece sayısını döndürür.
            int[,,,] diziRank = new int[2, 3, 4, 6];
            Console.WriteLine(diziRank.Rank);



            //CreateInstance
            //Normalde yukarıdakiler gibi tanımlaması yapılan diziler esnasında arkaplanda Array sınıfının CreateInstance metodunu kullanmaktadır. Biz bu metodu kullanarak fonksyonel diziler oluşturabilmekteyiz.
            //Bazen programatik ve fonksyonel dizi oluşturma ihtiyacımız olduğunda kullanılabilir.
            //Overload'ları vardır.
            Array cinsArr= Array.CreateInstance(typeof(int), 5);

           Array multiCi = Array.CreateInstance(typeof(string), 5, 66, 44, 8, 123); //5 dreceli dizi tanımlandı sırası ile eleman sayıları typeof'tan sonra gelen 5,66,44,8,123 elemanlı diziler tanımlanmıştır. çok boyutlu dizi tanımlamasıdır.



            //Ranges and Indices
            //c# 8.0 ile veri kaynakları üzerinde gerekli manipülasyonları sağlayabilmek ve bunun yanında kaynak içerisindeki tüm veriler üzerinde yapılan genel sorgulamalar ve algoritmalardan kaçınmak, yani direkt olarak hedef veri'ler odaklı çalışabilmek için yeni tipler ile operatörler geliştirilmiştir.
            // System.Index-System.Range---------------   ..  -   ^(tersine sembolüdür) operatörleri gelmiştir.


            //System.Index
            //Dizi ve koleksiyon yapılaındaki index kavramının tip olarak belirlenmiş halidir.
            //Index'i artık System.Index ile türleştirilmiştir. VE artık bu index numaralarına karşılık gelen değerdir.
            //Temelde index değerini bir tür ile tutmakla beraber ^ operatörüyle birlikte daha fazla anlam ifade etmekte ve dizinin index değerlerini tersine ifade edecek şekilde bir sorumluluk yüklenmektedir.
            // ^ operatörü ile tersini aldığımız index sıralamasında bu işlemi yaptığmız zaman 0'dan başlamaz direkt 1'den başlar.
            // ^ operatörü diziyi tersinden baz alarak ve 1' index numarası vererek çalışır. Burada dizinin elemanlarının yeri değişmiyor sadece tersten işleme alıyor. soldan sağa(0,1,2,3) DEĞİL Sağdan sola(3,2,1) ÇALIŞIR !!
            int[] ornkDz = { 4, 55, 66, 789, 5, 45, 68, 83, 12, 2, 7, 987, 6 };
            Index index = ^5; //Sağdan 1. id vererek gelir ce çıktı 12 değeri olur.
            Console.WriteLine(ornkDz[index]);


            #endregion





        }
    }
}
