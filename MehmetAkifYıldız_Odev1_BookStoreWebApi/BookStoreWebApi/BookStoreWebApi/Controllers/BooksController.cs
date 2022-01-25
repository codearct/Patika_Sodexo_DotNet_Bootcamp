using BookStoreWebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly List<Book> books;
        public BooksController()
        {
            books = new List<Book>()
            {
                new Book
                {
                    Id=1,
                    Title="Varlık ve Zaman",
                    Author="Martin Heidegger",
                    Translator="Kaan Ökten",
                    Publisher="Alfa Yayıncılık",
                    PageNumbers=648,
                    Description="Martin Heidegger’in başyapıtı Varlık ve Zaman 1927 yılında yayımlandı. Bu kitapta Heidegger, insanın dünya içindeki varoluşunu (Dasein’ı) özgün bir yöntem ve terminolojiyle çözümleyip açıkladı. İnsanın varoluşunun zaman ufku içinde açığa çıktığını, bunun da varlığın açımlanması anlamına geldiğini ortaya koydu. Bu sayede Heidegger, özne-nesne ve ruh-beden ayrımının üstesinden gelmeyi hedefleyen bir ontoloji yarattı.Çağdaş felsefenin en önemli yapıtlarından biri olan bu kitapla Heidegger, yalnızca felsefede değil sanat, politika, dil, psikoloji, mimarlık ve teknoloji gibi alanlarda da derin bir etki yarattı. Sartre, Levinas, Binswanger, Boss, Merleau-Ponty, Foucault, Derrida, Arendt, Gadamer, Jonas, Marcuse, Rorty, Agamben, Dreyfus gibi çok sayıda çağdaş düşünür Varlık ve Zaman’dan ilham aldı."
                },
                new Book
                {
                    Id=2,
                    Title="Bozkır Gelini",
                    Author="Bekir Yıldız",
                    Publisher="Everest Yayınları",
                    PageNumbers=113,
                    Description="Yeşil-kırmızı ışıklı bir yol kesiminde durdu araba. Atiye`nin düşündükleri de durdu sanki... Kafesli demir pencereden içeriye girdi köy. Çevresine bakındı. İki jandarmanın arasındaydı hâlâ. Elleri kelepçeliydi. Gelin gittiği o ilk gece, o ilk gecenin üzerinden geçen geceler neredeydi şimdi? Everest Yayınları, Türk edebiyatının en yetkin kalemlerinden Bekir Yıldız`ın kitaplarını yayımlamaya Bozkır Gelini`yle devam ediyor.Bekir Yıldız, bu kitabında Anadolu insanının çıkmazlarını anlatırken, şehirlilerin yaşadığı fakirlik, işsizlik ve darbe döneminin o kasvetli günlerini de ustalıkla okuyucuya yansıtıyor.Kitaba adını veren \"Bozkır Gelini\" adlı öyküde ise, başlık parası karşılığında satılan dokuz yaşındaki Atiye`nin hikayesi anlatılıyor. Atiye, başına geleceklerden habersiz bir \"çocuk gelin\" olarak felçli bir yaşlıya bakmak ve onun oğluna kadınlık yapmak üzere yeni evine gelin gidiyor. Bekir Yıldız, Anadolu`daki bu acı gerçeği her zamanki ustalığıyla bir kez daha gözler önüne seriyor."              
                },
                new Book
                {
                    Id=3,
                    Title="Hayvan Çiftliği",
                    Author="George Orwell",
                    Translator="Celal Üster",
                    Publisher="Can Yayınları",
                    PageNumbers=152,
                    Description="İngiliz yazar George Orwell, ülkemizde daha çok Bin Dokuz Yüz Seksen Dört adlı kitabıyla tanınır. Hayvan  Çiftliği, onun çağdaş klasikler arasına girmiş bir diğer çok ünlü eseridir. 1940`lardaki \"reel sos­yalizm\"in eleştirisi olan bu roman, dünya edebiyatında yergi türünün başyapıtlarından biri olarak kabul edilir.Hayvan Çiftliği`nin başkişileri hayvanlardır. Bir çiftlikte yaşayan hayvanlar, kendilerini sömüren insanlara başkaldırıp çiftliğin yönetimini ele geçirir. Amaçları daha eşitlikçi bir topluluk oluşturmaktır. Aralarında en akıllı olan domuzlar, kısa sürede önder bir takım oluşturur; ama devrimi de yine onlar yolundan saptırır.Ne yazık ki insanlardan daha baskıcı, daha acımasız bir diktatörlük kurulmuştur artık.George Orwell, bu romanında tarihsel bir gerçeği eleştirmektedir.Romandaki önder domuzun, düpedüz Stalin`i simgelediği açıktır.Diğer kahramanlar gerçek kişileri çağrıştırmasalar da, bir diktatörlük ortamında olabilecek kişilerdir.Altbaşlığı bir peri masalı olan Hayvan Çiftliği, bir masal anlatımıyla yazılmıştır; ama küçükleri eğlendirecek bir peri masalı değil, çarpıcı bir politik taşlamadır."                
                },
                new Book
                {
                    Id=4,
                    Title="Tutsak",
                    Author="Emine Işınsu",
                    Publisher="Bilge Kültür Sanat",
                    PageNumbers=200,
                    Description="1960 öncesi Türkiye’si ve Kerkük. Tutsak’ta üç tutsaklık birbirine geçer, dolanır, birlikte akar: yaklaşan ihtilalin gerilimindeki Türkiye’de insanların insafsız siyasî akışa tutsaklığı, yanlış bir evliliğe hapsolmuş kadının tutsaklığı ve Kerkük Türkü’nün Irak diktatoryası altındaki tutsaklığı. Romandaki 1960 öncesi Kerkük’tür ama o Kerkük hiç bitmedi. Orda katliamlar hâlâ devam ediyor. Ne diyelim? Bir yakın tarih romanı mı, aktüalite mi, kehanet mi? Belki hepsi.*Midem ne kadar çok bulanıyordu. Gözlerim kapalı, istediğim o kurşun uykusu yok. Kafam, bozuk bir motor gibi ağır ağır çalışıyor. İçimde bir yerde iniltiler; ‘öldü’ diye değil, ‘beni bırakıp gitti’ diye yanıyorum!Tanrı’m, bu kadar mı bencilim ben? Bu kadar mı vahşi, gaddar? Gayrı özümden de iğrenmiyorum; cam gözlerle, camdan gerçeklere bakanlar gibiyim.* "                
                },
                new Book
                {
                    Id=5,
                    Title="Kehribar Geçidi",
                    Author="Nazan Bekiroğlu",
                    Publisher="Timaş Yayınları",
                    PageNumbers=608,
                    Description="Kusurlu bir sikke elden ele, keseden keseye geçerek bütün Roma’yı nasıl dolaşır?Hikâyeyi hikâyeye, yolu yolcuya, rüyayı rüyete, yedi kişiyi erdemli bir köpeğe nasıl bağlar?Gölgelerin mağarasına dönen haberci her defasında niye taşlanır?Kehribar Geçidi, MS 300’lü yıllarda İmparator Diocletianus Roma’sında bu sorulara cevap arıyor.Okuyucularını Forum’un, Colosseum’un, Senato’nun, Tiber ırmağının, Şifa Tapınağı’nın, sonradan kaybedilmiş veya hiç edinilmemiş özgürlüklerin, hitabetin, yazmaların, lâhitlerin, şifalı otların, kurtların kuşların, dağların, en dehşetli dövüşlerin, toga picta’nın ve dikenli deniz salyangozlarının arasında uzun bir yolculuğa davet ediyor.Berrak fakat derin dili, karakterlerinin canlılığı, olaylarının sürükleyiciliği, dönemsel detaylarının zenginliği, can yakıcı meselelerinin her daim geçerliliği ile tarihin özel bir noktasından çekip çıkarılmış olsa da evrensel insanlık hallerine dair söyleyecek sözü olan destansı bir başyapıt. Sekiz yıllık bir emeğin sonucu.“Sanki ölmüşüz de bu dünyadaki günlerimizi anarak konuşuyoruz seninle. Sanki bu dünyadaki yaşamımız bitmiş de biri, bütün dertlerimize dönüp şöyle bir bakalım diye omuzumuzu okşar gibi. Bitti artık, geçti, der gibi.”"                
                },
                new Book
                {
                    Id=6,
                    Title="Puslu Kıtalar Atlası",
                    Author="İhsan Oktay Anar",
                    Publisher="İletişim Yayıncılık",
                    PageNumbers=238,
                    Description="*Yeniçeriler kapıyı zorlarken* düşler üstüne düşüncelere dalan Uzun İhsan Efendi, kapı kırıldığında klasik ama hep yeni kalabilen sonuca ulaşmak üzeredir: *Dünya bir düştür. Evet, dünya... Ah! Evet, dünya bir masaldır.*Kendini saran dünyayı düşleyen bir haritacının, düşlerinden devşirdiklerini döktüğü Puslu Kıtalar Atlası adlı kitap oğlunun eline geçtiğinde onu kendisinin bile tahmin edemeyeceği maceralara sürükler, oysa yaşayacakları elindeki kitaba çoktan yazılmıştır.Geçmiş üzerine, dünya hali üzerine, düşler ve *puslu kıtalar* üzerine bir roman. Hulki Aktunç’un önsözüyle..."                
                }
            };
        }

        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            return books;
        }

        /*[HttpPost]
        public ActionResult<List<Book>> GetAll()
        {
            return books;
        }*/

        [HttpGet("{id}")]
        public ActionResult<Book> GetByIdFromRoute(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçerli bir Id giriniz");
            }

            var book = books.Where(b => b.Id == id).SingleOrDefault();

            if (book is null)
            {
                return NotFound("Kitap bulunamadı");
            }
            return book;
        }

        /*[HttpGet]
        public IActionResult GetByIdFromQuery([FromQuery] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçerli bir Id giriniz");
            }

            var book = books.Where(b => b.Id == id).SingleOrDefault();

            if (book is null)
            {
                return BadRequest("Kitap bulunamadı");
            }
            return Ok(book);

        }*/

        [HttpPost]
        public IActionResult Add([FromBody] Book book)
        {
            books.Add(book);

            return Ok($"\"{book.Title}\" adlı kitap eklendi");
            //return Ok(books);eklenen kitabın da olduğu listeyi döndürmek istersek...
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Book model)
        {
            if (id <= 0)
            {
                return BadRequest("Geçerli bir Id giriniz");
            }

            var book = books.Where(b => b.Id == id).SingleOrDefault();

            if (book is null)
            {
                return BadRequest("Kitap bulunamadı");
            }

            book.Id = model.Id == default ? book.Id : model.Id;
            book.Title = string.IsNullOrEmpty(model.Title) ? book.Title : model.Title;
            book.Author = string.IsNullOrEmpty(model.Author) ? book.Author : model.Author;
            book.Translator = string.IsNullOrEmpty(model.Translator) ? book.Translator : model.Translator;
            book.Publisher = string.IsNullOrEmpty(model.Publisher) ? book.Publisher : model.Publisher;
            book.PageNumbers = model.PageNumbers == default ? book.PageNumbers : model.PageNumbers;
            book.Description = string.IsNullOrEmpty(model.Description) ? book.Description : model.Description;

            return Ok($"\"{book.Title}\" adlı kitap güncellendi");
            //return Ok(books);güncellenen kitap bilgilerinin olduğu listeyi döndürmek istersek...
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            if (id<=0)
            {
                return BadRequest("Geçerli bir Id giriniz");
            }

            var book = books.Where(b => b.Id == id).SingleOrDefault();

            if (book is null)
            {
                return NotFound("Kİtap bulunamadı");
            }

            books.Remove(book);

            return Ok($"\"{book.Title}\" adlı kitap kaldırıldı");
            //return Ok(books); silinen kitabın olmadığı listeyi döndürmek istersek...
            
        }
    }
}
