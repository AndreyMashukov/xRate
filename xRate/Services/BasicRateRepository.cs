using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using xRate.Model;

namespace xRate.Services
{
    public class BasicRateRepository : IRateRepository
    {
        private const string CbDsn = "https://www.cbr.ru/scripts/XML_daily.asp";
        
        private readonly HttpClient _httpClient;

        private DateTime LastRequest;

        private Rate[] Cached;
        
        public BasicRateRepository(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public Rate[] GetList()
        {
            var date = DateTime.Now;
            DateTime lastRequest = DateTime.Now.AddMinutes(-60);

            if (this.LastRequest is DateTime)
            {
                lastRequest = this.LastRequest;
            }

            if (date.Subtract(lastRequest).TotalMinutes < 5 && this.Cached is Rate[])
            {
                return this.Cached;
            }

            Rate[] result = this._doRequest();
            this.LastRequest = date;
            this.Cached = result;

            return result;
        }

        private Rate[] _doRequest()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ValCurs));
            
            var date = DateTime.Now;
            string url = $"{CbDsn}?date_req={date.ToString("dd/MM/yyyy")}";

            HttpResponseMessage response;

            try
            {
                response = this._httpClient.Send(new HttpRequestMessage(HttpMethod.Get, url));
            }
            catch
            {
                // todo: logger here...
                return new Rate[] { };
            }

            ValCurs curs;

            try
            {
                Stream content = new StreamReader(response.Content.ReadAsStream(), Encoding.GetEncoding("windows-1251")).BaseStream;
                curs = (ValCurs) serializer.Deserialize(XmlReader.Create(content));
            }
            catch
            {
                // todo: logger here...
                return new Rate[] { };
            }

            return curs?.List.Select((item) =>
            {
                var value = float.Parse(item.Value.Replace(',', '.'));

                return new Rate($"{item.CharCode}-RUB", value, date);
            }).ToArray();
        }
    }
}