using Newtonsoft.Json;

namespace GenshinDailyHelper.Entities
{
    /// <summary>
    /// 签到信息
    /// </summary>
    public class SignDayEntity : RootEntity<SignDayData>
    {

    }

    public class SignDayData
    {
        /// <summary>
        /// 签到天数
        /// </summary>
        [JsonProperty("total_sign_day")]
        public int TotalSignDay { get; set; }
        /// <summary>
        /// 今日
        /// </summary>
        [JsonProperty("today")]
        public string Today { get; set; }
        /// <summary>
        /// 是否签到
        /// </summary>
        [JsonProperty("is_sign")]
        public bool IsSign { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("first_bind")]
        public bool FirstBind { get; set; }

        public override string ToString()
        {
            var sign = IsSign ? "已签到" : "未签到";
            return $"状态:{sign}\n累签:{TotalSignDay}\n日期:{Today}";
        }
    }
}
