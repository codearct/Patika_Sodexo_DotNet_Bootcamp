using Business.Abstract;
using Core.Helpers;
using DataAccess.Abstract;
using Entities.Concrete;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IUnitOfWork _uow;

        public ExchangeRateService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<Currency> GetAllExchangeRates()
        {
            //Döviz kurlarını çekeceğimiz adres
            var url = "https://uzmanpara.milliyet.com.tr/doviz-kurlari/";

            HtmlWeb web = new HtmlWeb();
            //url'deki bütün html sayfa kaynağını yüklüyoruz
            HtmlDocument doc = web.Load(url);

            //Xpath'ne göre ilgili html etiketlerini ve içeriklerini liste halinde alıyoruz
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("/html/body/div[9]/div[7]/div[2]/div[1]/table/tbody/tr[position()>1]");

            //Oluşturulan listenin belirttiğimiz alt etiketine göre tek tek içeriğine ulaşıp üzerinde işlem yapıp data adlı listeye atıyoruz
            var data = new List<Currency>();

            foreach (var node in nodes)
            {
                //td etiketlerinin 2.sırasındaki td etikenin içeriğini TypeName olarak tutuyoruz
                var typeName = node.SelectSingleNode("td[2]").InnerText.ToUTF8();
                var currencyType = _uow.CurrencyType.Get(c => c.Name == typeName);
                if (currencyType !=null)
                { 
                    var currency = new Currency()
                    {
                        TypeId = currencyType.Id,
                        //td etiketlerinin 3.sırasındaki td etikenin içeriğini decimal e parse edip objenin purchase değerine atıyoruz
                        Purchase = decimal.Parse(node.SelectSingleNode("td[3]").InnerText),
                        //td etiketlerinin 4.sırasındaki td etikenin içeriğini decimal e parse edip objenin sale değerine atıyoruz
                        Sale = decimal.Parse(node.SelectSingleNode("td[4]").InnerText),
                        //td etiketlerinin 6.sırasındaki td etikenin içeriğini objenin time değerine atıyoruz
                        Time = node.SelectSingleNode("td[6]").InnerText,
                        //Her döviz kuru çekme işleminde ilgili kurun status değerini true ya çekiyoruz
                        Status = true
                    };
                    data.Add(currency);
                }               
            }
            return data;
        }
    }
}
