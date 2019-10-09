using Microsoft.AspNetCore.Http;
using PayProject.Core;
using PayProject.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayProject.Logic.Settle
{
    public abstract class OnlineSettle
    {

        public static List<SettlePlat> PlatList
        {
            get
            {
                object o = Dos.Common.CacheHelper.Get("settle_plat_list");
                if (o == null)
                {
                    o = DbContext._.Db.From<SettlePlat>().ToList();
                    Dos.Common.CacheHelper.Set("settle_plat_list", o, 600);
                }
                return (List<SettlePlat>)o;
            }
        }

        public static List<SettleMch> MchList
        {
            get
            {
                object o = Dos.Common.CacheHelper.Get("settle_mch_list");
                if (o == null)
                {
                    var olist = DbContext._.Db.From<SettleMch>().ToList();
                    for (int i = 0; i <= olist.Count - 1; i++)
                    {
                        SettlePlat tempp = PlatList.Find(p => p.Plat_id == olist[i].Plat_id);
                        if (tempp != null)
                        {
                            olist[i].BankList = tempp.Banklist;
                            olist[i].Max_money = tempp.Max_money;
                            olist[i].Min_money = tempp.Min_money;
                        }
                    }

                    Dos.Common.CacheHelper.Set("settle_mch_list", olist, 600);
                    return olist;
                }
                return (List<SettleMch>)o;
            }
        }

        public static SettlePlat GetPlat(int platid)
        {
            return PlatList.Find(p => p.Plat_id == platid);
        }
        public static SettleMch GetMch(int mchid)
        {
            return MchList.Find(p => p.Id == mchid);
        }


        /// <summary>
        /// 支付平台
        /// </summary>
        //public PayPlat Plat { get; set; }
        public SettlePlat Plat { get; set; }

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
        public string CallbackUrl { get { return string.Format("{0}/settle/callback_{1}_{2}.do", Callback_Host, this.Plat_Id, this.ID); } }
        /// <summary>
        /// 通知Url
        /// </summary>
        public string NotifyUrl { get { return string.Format("{0}/settle/notify_{1}_{2}.do", Callback_Host, this.Plat_Id, this.ID); } }
        /// <summary>
        /// 通知成功信息
        /// </summary>
        public string NotifySuccessMsg { get; set; }


        public abstract Task<UnifiedOrderReturnModel> Unifiedorder(string OrderId, string Bank_name, string Bank_branch, string Bank_card_number, string Bank_account, decimal Totalfee, string Ip, string Attach);
        public abstract Task<QueryReturnModel> OrderQuery(string OrderNumber);
        public abstract Task<NotifyReturnModel> Notify(HttpRequest request);
        public abstract Task<NotifyReturnModel> CallBack(HttpRequest request);
        public OnlineSettle()
        {
        }
        public OnlineSettle(int plat, string mchid)
        {
            SettlePlat p = PlatList.Find(pp => pp.Plat_id == plat);
            if (p == null || p.Plat_id != plat)
                return;
            SettleMch m = MchList.Find(mm => mm.Plat_id == plat && mm.Mch_id == mchid);
            if (m == null || m.Plat_id != plat || m.Mch_id != mchid)
                return;
            this.Plat = new SettlePlat();
            this.Plat.Plat_id = p.Plat_id;
            this.Plat.Plat_name = p.Plat_name;
            this.Plat.Pay_gateway = p.Pay_gateway;
            this.Plat.Banklist = p.Banklist;
            this.Plat.Req_gateway = p.Req_gateway;
            this.Plat.Plat_class = p.Plat_class;
            this.Callback_Host = m.Callback_host;
            this.ID = m.Id;
            this.MchID = m.Mch_id;
            this.MchKey = m.Mch_key;
            this.MchKey2 = m.Mch_key2;
            this.MchName = m.Mch_name;
            this.Plat_Id = m.Plat_id;
        }

        public OnlineSettle(SettlePlat p, SettleMch m)
        {

            if (p == null)
                return;

            if (m == null)
                return;
            this.Plat = new SettlePlat();
            this.Plat.Plat_id = p.Plat_id;
            this.Plat.Plat_name = p.Plat_name;
            this.Plat.Pay_gateway = p.Pay_gateway;
            this.Plat.Banklist = p.Banklist;
            this.Plat.Req_gateway = p.Req_gateway;
            this.Plat.Plat_class = p.Plat_class;
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

}
