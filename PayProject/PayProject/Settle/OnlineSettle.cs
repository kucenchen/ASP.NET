using Microsoft.AspNetCore.Http;
using PayProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayProject.Settle
{
    public abstract class OnlineSettle
    {
        
        public static List<Settle_plat> PlatList {
            get {
                object o = Dos.Common.CacheHelper.Get("settle_plat_list");
                if (o == null)
                {
                    o = DB.Context.From<Settle_plat>().ToList();
                    Dos.Common.CacheHelper.Set("settle_plat_list", o, 600);
                }
                return (List<Settle_plat>)o;
            }
        }

        public static List<Settle_mch> MchList
        {
            get
            {
                object o = Dos.Common.CacheHelper.Get("settle_mch_list");
                if (o == null)
                {
                    var olist = DB.Context.From<Settle_mch>().ToList();
                    for (int i = 0; i <= olist.Count - 1; i++) {
                        Settle_plat tempp = PlatList.Find(p => p.Plat_id == olist[i].Plat_id);
                        if (tempp != null) {
                            olist[i].BankList = tempp.Banklist;
                            olist[i].Max_money = tempp.Max_money;
                            olist[i].Min_money = tempp.Min_money;
                        }
                    }

                    Dos.Common.CacheHelper.Set("settle_mch_list", olist, 600);
                    return olist;
                }
                return (List<Settle_mch>)o;
            }
        }

        public static Settle_plat GetPlat(int platid) {
            return PlatList.Find(p => p.Plat_id == platid);
        }
        public static Settle_mch GetMch(int mchid) {
            return MchList.Find(p => p.Id == mchid);
        }


        /// <summary>
        /// 支付平台
        /// </summary>
        public PayPlat Plat { get; set; }

        /// <summary>
        /// 商户ID
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string MchID { get; set; }
        /// <summary>
        /// 商户名称 (管理用)
        /// </summary>
        public string MchName { get; set; }
        /// <summary>
        /// 商户密钥
        /// </summary>
        public string MchKey { get; set; }

        /// <summary>
        /// 商户密钥2
        /// </summary>
        public string MchKey2 { get; set; }
        /// <summary>
        /// 平台ID
        /// </summary>
        public int Plat_Id { get; set; }
        /// <summary>
        /// 回调 域名
        /// </summary>
        public string Callback_Host { get; set; }
        /// <summary>
        /// 回调 Url
        /// </summary>
        public string CallbackUrl { get { return string.Format("{0}/settle/callback_{1}_{2}.do", Callback_Host, this.Plat_Id, this.MchID); } }
        /// <summary>
        /// 通知Url
        /// </summary>
        public string NotifyUrl { get { return string.Format("{0}/settle/notify_{1}_{2}.do", Callback_Host, this.Plat_Id, this.MchID); } }
        /// <summary>
        /// 通知成功信息
        /// </summary>
        public string NotifySuccessMsg { get; set; }

       
        public abstract Task<UnifiedorderReturn> Unifiedorder(string OrderId, string Bank_name,string Bank_branch,string Bank_card_number, string Bank_account,decimal Totalfee,string Ip, string Attach);
        public abstract Task<QueryReturn> OrderQuery(string OrderNumber);
        public abstract Task<NotifyReturn> Notify(HttpRequest request);
        public abstract Task<NotifyReturn> CallBack(HttpRequest request);
        public OnlineSettle() {
        }
        public OnlineSettle(int plat, string mchid) {
            Settle_plat p = PlatList.Find(pp => pp.Plat_id == plat);
            if (p==null || p.Plat_id != plat)
                return;
            Settle_mch m = MchList.Find(mm => mm.Plat_id == plat && mm.Mch_id == mchid);
            if (m == null || m.Plat_id != plat || m.Mch_id!=mchid )
                return;
            this.Plat.Id = p.Plat_id;
            this.Plat.Name = p.Plat_name;
            this.Plat.Settle_gateway = p.Pay_gateway;
            this.Plat.Bank_list = p.Banklist;
            this.Plat.Req_gateway = p.Req_gateway;
            this.Plat.Class = p.Plat_class;
            this.Callback_Host = m.Callback_host;
            this.ID = m.Id;
            this.MchID = m.Mch_id;
            this.MchKey = m.Mch_key;
            this.MchKey2 = m.Mch_key2;
            this.MchName = m.Mch_name;
            this.Plat_Id = m.Plat_id;
        }

        public OnlineSettle(Settle_plat p, Settle_mch m)
        {
          
            if (p == null )
                return;
          
            if (m == null )
                return;
            this.Plat.Id = p.Plat_id;
            this.Plat.Name = p.Plat_name;
            this.Plat.Settle_gateway = p.Pay_gateway;
            this.Plat.Bank_list = p.Banklist;
            this.Plat.Req_gateway = p.Req_gateway;
            this.Plat.Class = p.Plat_class;
            this.Callback_Host = m.Callback_host;
            this.ID = m.Id;
            this.MchID = m.Mch_id;
            this.MchKey = m.Mch_key;
            this.MchKey2 = m.Mch_key2;
            this.MchName = m.Mch_name;
            this.Plat_Id = m.Plat_id;

            //this = (OnlinePay)Activator.CreateInstance(Type.GetType(this.Plat.Class));
        }


        public static string GetParamSrc(SortedDictionary<string, string> paramsMap)
        {

            //StringBuilder str = new StringBuilder();
            //foreach (KeyValuePair<string, string> kv in paramsMap)
            //{
            //    string pkey = kv.Key;
            //    string pvalue = kv.Value;
            //    str.Append(pkey + "=" + pvalue + "&");
            //}

            //String result = str.ToString().Substring(0, str.ToString().Length - 1);
            //return result.ToString();
            return GetParamSrc(paramsMap, "=");
        }
        public static string GetParamSrc(SortedDictionary<string, string> paramsMap, string linkChar)
        {

            StringBuilder str = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in paramsMap)
            {
                string pkey = kv.Key;
                string pvalue = kv.Value;
                str.Append(pkey + linkChar + pvalue + "&");
            }

            String result = str.ToString().Substring(0, str.ToString().Length - 1);
            return result.ToString();
        }
    }

    public class PayPlat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Req_gateway { get; set; }
        public string Settle_gateway { get; set; }
        public string Bank_list { get; set; }
    }
    public enum PayReturnType {
        Err=0,
        Html=1,
        Url=2,
        ImgUrl=3,
        ImgBase64=4,
        QRcodeUrl=5,
        AppJson=6
    }
   
    public class UnifiedorderReturn
    {
        public PayReturnType Type;//0 失败,1 html,2 url,3 ImgUrl,4 ImgBase64,5 QRcodeUrl,6 AppJson,7 手机端扫码
        public string Content;//如果调用失败，返回接口的错误信息，否则按类型返回信息
        public string OrderNumber;
        public string SerialNumber;
        public string RealPrice;
    }
    public class QueryReturn
    {
        public string ReturnMsg;//接口返回信息  ok 表示查询成功
        public string Attach; //附加信息
        public string OrderNumber;//商户订单号
        public string SerialNumber;//支付平台流水号
        public decimal Totalfee;//支付成功总金额
        public bool IsPay;//是否付款成功
    }
    public class NotifyReturn : QueryReturn
    {
        public string MchID;//商户号
        public bool IsCheck;//是否验证通过
    }


}
