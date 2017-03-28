namespace Application.AppServices.VehicleAppservices
{
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Text;
    using Core.Entities.Vehicle;
    using Core.Exceptions;

    public class VehicleAppService
    {
        public VehiclePrise.Rootobject PostToGetVehiclePrise(string vehicleCode, string seriesCode, string registerDate = "2015-01-01", string mile = "12", string pid = "110000", string cid = "110100")
        {
            ////string url = ConfigurationManager.AppSettings["VehiclePriceUrl"];
            string url = "http://ygst.ywsoftware.com/smc/asmx/smcdb.asmx/GetCarPriceResult";
            var data = new NameValueCollection();
            data.Add("vehicleCode", vehicleCode);
            data.Add("seriesCode", seriesCode);
            data.Add("registerDate", registerDate);
            data.Add("mile", mile);
            data.Add("pid", pid);
            data.Add("cid", cid);
            var wc = new System.Net.WebClient();
            wc.Encoding = Encoding.UTF8;
            var res = wc.UploadValues(url, "POST", data);
            var r = Encoding.UTF8.GetString(res);
            var ob = Newtonsoft.Json.Linq.JObject.Parse(r);
            var rb = new VehiclePrise.Rootobject();
            if ((int)ob["ResultSign"] == 1)
            {
                rb.Sign = 1;
                rb.Result.Sale.VeryGood.Min = ob["Result"]["highMinPrice"].ToString();
                rb.Result.Sale.VeryGood.Max = ob["Result"]["highMaxPrice"].ToString();
                rb.Result.Sale.Good.Min = ob["Result"]["minPrice"].ToString();
                rb.Result.Sale.Good.Max = ob["Result"]["maxPrice"].ToString();
                rb.Result.Sale.Poor.Min = ob["Result"]["lowMinPrice"].ToString();
                rb.Result.Sale.Poor.Max = ob["Result"]["lowMaxPrice"].ToString();
                rb.Result.Buy.VeryGood.Min = ob["Result"]["hMinPrice"].ToString();
                rb.Result.Buy.VeryGood.Max = ob["Result"]["hMaxPrice"].ToString();
                rb.Result.Buy.Good.Min = ob["Result"]["mnPrice"].ToString();
                rb.Result.Buy.Good.Max = ob["Result"]["mxPrice"].ToString();
                rb.Result.Buy.Poor.Min = ob["Result"]["lMinPrice"].ToString();
                rb.Result.Buy.Poor.Max = ob["Result"]["lMaxPrice"].ToString();

                return rb;
            }

            throw new AppException(message: "接口返回数据无内容");
        }
    }
}
